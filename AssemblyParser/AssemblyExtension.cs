using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using AssemblyDataParser.Annotations;

namespace AssemblyDataParser
{
    public static class AssemblyExtension
    {
        [NotNull]
        static Func<Assembly, object> GetAttributeValue<T>([NotNull] Func<T, object> Converter)
            where T : Attribute => asm =>
        {
            if (asm is null) return null;

            var a = asm.GetCustomAttributes(typeof(T), false).OfType<T>().FirstOrDefault();
            return a is null ? null : Converter(a);
        };
        static string GetStringData(this Func<Assembly, object> converter, Assembly v) => converter(v)?.ToString() ?? AssemblyParserConstans.EMPTY;

        #region Information Section

        /// <summary>
        /// Получает строку мета-информации из файла сборки
        /// </summary>
        /// <param name="assembly">сборка из которой получить данные</param>
        /// <param name="key">ключ строки мета-информации</param>
        /// <returns>строка данных</returns>
        public static string ParseLinkerInformationString(this Assembly assembly, string key)
        {
            try
            {
                var func = GetAttributeValue<AssemblyInformationalVersionAttribute>(i => i.InformationalVersion);
                var values = func.GetStringData(assembly).Split('^');
                var current = values.FirstOrDefault(v => v.Trim().StartsWith(key));
                if (current is not null)
                {
                    return current.Substring(key.Length).Trim();
                    //return current[key.Length..].Trim(); //only for version net5.0 and above, netcoreapp3.1, netstandard2.1
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return string.Empty;

        }

        /// <summary>
        /// Получает информацию о версиях из мета-информации сборки
        /// </summary>
        /// <param name="assembly">сборка из которой получить данные</param>
        /// <returns>список версий</returns>
        public static IEnumerable<AssemblyVersionData> ParseLinkerUpdatesData(this Assembly assembly)
        {
            if (ParseLinkerInformationString(assembly, AssemblyParserConstans.UpdateSection) is { Length: > 0 } row)
                return GetVersionsDataFromJson(row);

            return Enumerable.Empty<AssemblyVersionData>();
        }
        /// <summary>
        /// Получает информацию о версиях из строки json
        /// </summary>
        /// <param name="row">строка формата json</param>
        /// <returns>список версий</returns>
        private static IEnumerable<AssemblyVersionData> GetVersionsDataFromJson(string row)
        {
            try
            {
                var options = new JsonSerializerOptions() { AllowTrailingCommas = true };
                var data = JsonSerializer.Deserialize<IEnumerable<AssemblyVersionData>>(row.Trim(), options);
                return data;
            }
            catch (Exception)
            {
                return Enumerable.Empty<AssemblyVersionData>();
            }
        }

        /// <summary>
        /// Забирает дату сборки из мета-информации
        /// </summary>
        /// <param name="assembly">сборка из которой получить данные</param>
        /// <param name="CheckFileCrationIfNoData"></param>
        /// <param name="TimeFormat">формат времени</param>
        /// <returns>дата и время сборки</returns>
        public static string ParseLinkerTime(this Assembly assembly, bool CheckFileCrationIfNoData = false, string TimeFormat = "dd/MM/yyyy HH:mm")
        {
            if(ParseLinkerInformationString(assembly, AssemblyParserConstans.DateTimeSection) is { Length: > 0 } row)
            {
                if (DateTime.TryParseExact(row, "yyyy-MM-ddTHH:mm:ss:fffZ", CultureInfo.InvariantCulture,DateTimeStyles.None,out var date))
                    return date.ToString(TimeFormat);
            }

            if (CheckFileCrationIfNoData)
                return assembly.ParseCreationTime(false,TimeFormat);

            return default;
        }

        #endregion

        #region Assembly from converter

        /// <summary>
        /// Получение информации о компании из сборки
        /// Get company data from assembly
        /// </summary>
        /// <param name="assembly">Assembly</param>
        /// <returns></returns>
        public static string ParseCompany(this Assembly assembly) => GetAttributeValue<AssemblyCompanyAttribute>(i => i.Company).GetStringData(assembly);

        /// <summary>
        /// Получение информации о версии сборки
        /// Get PackageVersion data from assembly
        /// </summary>
        /// <param name="assembly">Assembly</param>
        /// <returns></returns>
        public static string ParsePackageVersion(this Assembly assembly) => assembly.GetName().Version?.ToString() ?? AssemblyParserConstans.EMPTY;

        /// <summary>
        /// Получение информации о Конфигурации из сборки
        /// Get Configuration data from assembly
        /// </summary>
        /// <param name="assembly">Assembly</param>
        /// <returns></returns>
        public static string ParseConfiguration(this Assembly assembly) => GetAttributeValue<AssemblyConfigurationAttribute>(i => i.Configuration).GetStringData(assembly);

        /// <summary>
        /// Получение информации о авторстве из сборки
        /// Get Copyright data from assembly
        /// </summary>
        /// <param name="assembly">Assembly</param>
        /// <returns></returns>
        public static string ParseCopyright(this Assembly assembly) => GetAttributeValue<AssemblyCopyrightAttribute>(i => i.Copyright).GetStringData(assembly);
        /// <summary>
        /// Получение информации о описании из сборки
        /// Get Description data from assembly
        /// </summary>
        /// <param name="assembly">Assembly</param>
        /// <returns></returns>
        public static string ParseDescription(this Assembly assembly) => GetAttributeValue<AssemblyDescriptionAttribute>(i => i.Description).GetStringData(assembly);
        /// <summary>
        /// Получение информации о файловой версии сборки
        /// Get FileVersion data from assembly
        /// </summary>
        /// <param name="assembly">Assembly</param>
        /// <returns></returns>
        public static string ParseFileVersion(this Assembly assembly) => GetAttributeValue<AssemblyFileVersionAttribute>(i => i.Version).GetStringData(assembly);
        /// <summary>
        /// Получение информации о продукте из сборки
        /// Get Product data from assembly
        /// </summary>
        /// <param name="assembly">Assembly</param>
        /// <returns></returns>
        public static string ParseProduct(this Assembly assembly) => GetAttributeValue<AssemblyProductAttribute>(i => i.Product).GetStringData(assembly);

        /// <summary>
        /// Получение информации о времени формирования файла сборки
        /// Get Creation time of assembly
        /// </summary>
        /// <param name="assembly">Assembly</param>
        /// <param name="CheckMetaDataIfNoFile">Check linker Meta-information if assembly file was not found</param>
        /// <param name="TimeFormat">Time format</param>
        /// <returns></returns>
        public static string ParseCreationTime(this Assembly assembly, bool CheckMetaDataIfNoFile = false, string TimeFormat = "dd/MM/yyyy HH:mm")
        {
            var time = assembly.Location is {Length: > 0} location ? new FileInfo(location).CreationTime.ToString(TimeFormat) :
                CheckMetaDataIfNoFile ? assembly.ParseLinkerInformationString(AssemblyParserConstans.DateTimeSection) : AssemblyParserConstans.UNKNOWN;
            return string.IsNullOrWhiteSpace(time) ? AssemblyParserConstans.UNKNOWN : time;
        }

        /// <summary>
        /// Получение информации заголовка из сборки
        /// Get Title data from assembly
        /// </summary>
        /// <param name="assembly">Assembly</param>
        /// <returns></returns>
        public static string ParseTitle(this Assembly assembly) => GetAttributeValue<AssemblyTitleAttribute>(i => i.Title).GetStringData(assembly);
        /// <summary>
        /// Получение информации о торговой марке из сборки
        /// Get Trademark data from assembly
        /// </summary>
        /// <param name="assembly">Assembly</param>
        /// <returns></returns>
        public static string ParseTrademark(this Assembly assembly) => GetAttributeValue<AssemblyTrademarkAttribute>(i => i.Trademark).GetStringData(assembly);

        #endregion
    }
}