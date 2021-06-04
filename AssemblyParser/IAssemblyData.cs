using System.Collections.Generic;

namespace AssemblyDataParser
{
    public interface IAssemblyData
    {
        /// <summary>
        /// Получает строку мета-информации из файла сборки
        /// Get meta information row from assembly by key
        /// </summary>
        /// <param name="key">ключ строки мета-информации</param>
        /// <returns>строка данных</returns>
        public string ParseLinkerInformationString(string key);

        /// <summary>
        /// Получает информацию о версиях из мета-информации сборки
        /// Get Version information from assembly meta-information
        /// </summary>
        /// <returns>список версий</returns>
        public IEnumerable<AssemblyVersionData> ParseLinkerUpdatesData();

        /// <summary>
        /// Забирает дату сборки из мета-информации
        /// Get DateTime of build from assembly meta-information
        /// </summary>
        /// <returns>дата и время сборки</returns>
        public string ParseLinkerTime(bool CheckFileCrationIfNoData = false, string TimeFormat = "dd/MM/yyyy HH:mm");

        /// <summary>
        /// Получение информации о компании из сборки
        /// Get company data from assembly
        /// </summary>
        /// <returns></returns>
        public string ParseCompany();

        /// <summary>
        /// Получение информации о версии сборки
        /// Get PackageVersion data from assembly
        /// </summary>
        /// <returns></returns>
        public string ParsePackageVersion();

        /// <summary>
        /// Получение информации о Конфигурации из сборки
        /// Get Configuration data from assembly
        /// </summary>
        /// <returns></returns>
        public string ParseConfiguration();

        /// <summary>
        /// Получение информации о авторстве из сборки
        /// Get Copyright data from assembly
        /// </summary>
        /// <returns></returns>
        public string ParseCopyright();

        /// <summary>
        /// Получение информации о описании из сборки
        /// Get Description data from assembly
        /// </summary>
        /// <returns></returns>
        public string ParseDescription();

        /// <summary>
        /// Получение информации о файловой версии сборки
        /// Get FileVersion data from assembly
        /// </summary>
        /// <returns></returns>
        public string ParseFileVersion();

        /// <summary>
        /// Получение информации о продукте из сборки
        /// Get Product data from assembly
        /// </summary>
        /// <returns></returns>
        public string ParseProduct();

        /// <summary>
        /// Получение информации о времени формирования файла сборки
        /// Get Creation time of assembly
        /// </summary>
        /// <returns></returns>
        public string ParseCreationTime(bool CheckMetaDataIfNoFile = false, string TimeFormat = "dd/MM/yyyy HH:mm");

        /// <summary>
        /// Получение информации заголовка из сборки
        /// Get Title data from assembly
        /// </summary>
        /// <returns></returns>
        public string ParseTitle();

        /// <summary>
        /// Получение информации о торговой марке из сборки
        /// Get Trademark data from assembly
        /// </summary>
        /// <returns></returns>
        public string ParseTrademark();
    }
}