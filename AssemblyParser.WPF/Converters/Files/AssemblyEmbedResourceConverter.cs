using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using AssemblyDataParser.Extensions;
using AssemblyDataParser.WPF.Converters.Base;

namespace AssemblyDataParser.WPF.Converters.Files
{
    [ValueConversion(typeof(AssemblyVersionEmbedResourceConverter), typeof(object))]
    public class AssemblyVersionEmbedResourceConverter : ValueConverter
    {
        public string FileName { get; set; }
        #region Overrides of ValueConverter

        public override object Convert(object v, Type t, object p, CultureInfo c)
        {
            if (v is not Assembly assembly)
                return null;
            if (string.IsNullOrWhiteSpace(FileName))
                return null;

            var data = assembly.GetDataFromJsonResourceFile<List<AssemblyVersionData>>(FileName);
            return data;

        }
        #endregion
    }
}
