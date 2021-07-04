using System;
using System.Globalization;
using System.Windows.Data;
using AssemblyDataParser.WPF.Converters.Base;

namespace AssemblyDataParser.WPF.Converters.Files
{
    [ValueConversion(typeof(AssemblyVersionFileConverter), typeof(object))]
    public class AssemblyVersionFileConverter : ValueConverter
    {
        public string FileName { get; set; }
        #region Overrides of ValueConverter

        public override object Convert(object v, Type t, object p, CultureInfo c)
        {
            if (string.IsNullOrWhiteSpace(FileName))
                return null;

            var data = AssemblyVersionData.GetVersionInfoFromFile(FileName);
            return data;
        }
        #endregion
    }
}