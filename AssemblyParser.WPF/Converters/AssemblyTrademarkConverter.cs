using System.Reflection;
using AssemblyDataParser.WPF.Converters.Base;

namespace AssemblyDataParser.WPF.Converters
{
    public class AssemblyTrademarkConverter : AssemblyConverter
    {
        public AssemblyTrademarkConverter() : base(GetAttributeValue<AssemblyTrademarkAttribute>(a => a.Trademark)) { }
    }
}
