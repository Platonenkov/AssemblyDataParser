using System.Globalization;
using System.Threading;
using AssemblyDataParser.Annotations;

namespace System
{
    public static class StringExtensions
    {
        /// Extension method parsing a date string to a DateTime? <para/>
        /// <summary>
        /// </summary>
        /// <param name="dateTimeStr">The date string to parse</param>
        /// <param name="date">Parsed DateTime</param>
        /// <param name="DateFmt">dateFmt is optional and allows to pass 
        /// a parsing pattern array or one or more patterns passed 
        /// as string parameters</param>
        /// <returns>parse result</returns>
        public static bool ToDateTime(this string dateTimeStr, out DateTime date, [CanBeNull] params string[] DateFmt )
        {
            string[] DateFormats = {
          "dd.MM.yyyy",
          "dd.MM.yyyy HH:mm",
          "dd.MM.yy",
          "dd.MM.yy HH:mm",

          "dd-MM-yyyy",
          "dd-MM-yyyy HH:mm",
          "dd-MM-yy",
          "dd-MM-yy HH:mm",

          "dd.MM.yyyy",
          "dd.MM.yyyy HH:mm:ss",
          "dd.MM.yy",
          "dd.MM.yy HH:mm:ss",

          "dd-MM-yyyy",
          "dd-MM-yyyy HH:mm:ss",
          "dd-MM-yy",
          "dd-MM-yy HH:mm:ss",

          // --------------------

          "yyyy.MM.dd",
          "yyyy.MM.dd HH:mm",
          "yy.MM.dd",
          "yy.MM.dd HH:mm",

          "yyyy-MM-dd",
          "yyyy-MM-dd HH:mm",
          "yy-MM-dd",
          "yy-MM-dd HH:mm",

          "yyyy.MM.dd",
          "yyyy.MM.dd HH:mm:ss",
          "yy.MM.dd",
          "yy.MM.dd HH:mm:ss",

          "yyyy-MM-dd",
          "yyyy-MM-dd HH:mm:ss",
          "yy-MM-dd",
          "yy-MM-dd HH:mm:ss",
            };

            const DateTimeStyles style = DateTimeStyles.AllowWhiteSpaces;
            var formats = DateFmt;
            // Проверка формата который передали в метод дополнительно
            if (formats != null && DateTime.TryParseExact(
                dateTimeStr, formats, CultureInfo.InvariantCulture,
                style, out date))
                return true;

            // Проверка коротких форматов   
            formats = DateFormats;
            if (DateTime.TryParseExact(
                dateTimeStr, formats, CultureInfo.InvariantCulture,
                style, out date))
                return true;

            // Проверка форматов культуры
            formats = CultureInfo.InvariantCulture.DateTimeFormat.GetAllDateTimePatterns();
            if (DateTime.TryParseExact(
                dateTimeStr, formats, CultureInfo.InvariantCulture,
                style, out date))
                return true;
            formats = CultureInfo.CurrentCulture.DateTimeFormat.GetAllDateTimePatterns();
            if (DateTime.TryParseExact(
                dateTimeStr, formats, CultureInfo.InvariantCulture,
                style, out date))
                return true;

            // Проверка форматов потока
            formats = Thread.CurrentThread.CurrentCulture.DateTimeFormat.GetAllDateTimePatterns();
            if (DateTime.TryParseExact(
                dateTimeStr, formats, CultureInfo.InvariantCulture,
                style, out date))
                return true;
            return false;
        }
    }

}