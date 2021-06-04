using AssemblyDataParser.WPF.Converters.Base;

namespace AssemblyDataParser.WPF.Converters
{
    public class AssemblyLinkerTimeConverter : AssemblyConverter
    {
        public AssemblyLinkerTimeConverter() : base(a=>a.ParseLinkerTime()) { }
    }
}