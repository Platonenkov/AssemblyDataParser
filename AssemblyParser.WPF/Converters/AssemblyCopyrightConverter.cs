using System.Reflection;
using AssemblyDataParser.WPF.Converters.Base;

namespace AssemblyDataParser.WPF.Converters
{
    public class AssemblyCopyrightConverter : AssemblyConverter
    {
        public AssemblyCopyrightConverter() : base(GetAttributeValue<AssemblyCopyrightAttribute>(a => a.Copyright)) { }
    }
}