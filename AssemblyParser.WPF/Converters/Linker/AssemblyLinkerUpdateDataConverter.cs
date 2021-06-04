using AssemblyDataParser.WPF.Converters.Base;

namespace AssemblyDataParser.WPF.Converters
{
    public class AssemblyLinkerUpdateDataConverter : AssemblyConverter
    {
        public AssemblyLinkerUpdateDataConverter() : base(a=>a.ParseLinkerUpdatesData()) { }
    }
}