using AssemblyDataParser.WPF.Converters.Base;

namespace AssemblyDataParser.WPF.Converters
{
    public class AssemblyVersionConverter : AssemblyConverter
    {
        public AssemblyVersionConverter() : base(a => a.GetName().Version) { }
    }
}
