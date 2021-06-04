using System.Reflection;
using AssemblyDataParser.WPF.Converters.Base;

namespace AssemblyDataParser.WPF.Converters
{
    public class AssemblyFileVersionConverter : AssemblyConverter
    {
        public AssemblyFileVersionConverter() : base(GetAttributeValue<AssemblyFileVersionAttribute>(a => a.Version)) { }
    }
}