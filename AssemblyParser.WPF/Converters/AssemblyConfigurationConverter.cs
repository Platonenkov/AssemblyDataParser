using System.Reflection;
using AssemblyDataParser.WPF.Converters.Base;

namespace AssemblyDataParser.WPF.Converters
{
    public class AssemblyConfigurationConverter : AssemblyConverter
    {
        public AssemblyConfigurationConverter() : base(GetAttributeValue<AssemblyConfigurationAttribute>(a => a.Configuration)) { }
    }
}