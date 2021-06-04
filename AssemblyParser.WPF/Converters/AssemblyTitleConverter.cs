using System.Reflection;
using AssemblyDataParser.WPF.Converters.Base;

namespace AssemblyDataParser.WPF.Converters
{
    public class AssemblyTitleConverter : AssemblyConverter
    {
        public AssemblyTitleConverter() : base(GetAttributeValue<AssemblyTitleAttribute>(a => a.Title)) { }
    }
}