using System.Reflection;
using AssemblyDataParser.WPF.Converters.Base;

namespace AssemblyDataParser.WPF.Converters
{
    public class AssemblyDescriptionConverter : AssemblyConverter
    {
        public AssemblyDescriptionConverter() : base(GetAttributeValue<AssemblyDescriptionAttribute>(a => a.Description)) { }
    }
}