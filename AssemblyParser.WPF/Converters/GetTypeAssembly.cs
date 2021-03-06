using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Markup;
using AssemblyDataParser.WPF.Converters.Base;

namespace AssemblyDataParser.WPF.Converters
{
    [ValueConversion(typeof(Type), typeof(Assembly)), MarkupExtensionReturnType(typeof(GetTypeAssembly))]
    public class GetTypeAssembly : ValueConverter
    {
        public override object Convert(object v, Type t, object p, CultureInfo c) => ((Type)v).Assembly;
    }
}