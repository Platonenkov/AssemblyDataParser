using System.Reflection;
using AssemblyDataParser.WPF.Converters.Base;

namespace AssemblyDataParser.WPF.Converters
{
    public class AssemblyProductConverter : AssemblyConverter
    {
        public AssemblyProductConverter() : base(GetAttributeValue<AssemblyProductAttribute>(a => a.Product)) { }
    }
}