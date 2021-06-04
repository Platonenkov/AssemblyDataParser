using System.IO;
using AssemblyDataParser.WPF.Converters.Base;

namespace AssemblyDataParser.WPF.Converters
{
    public class AssemblyTimeConverter : AssemblyConverter
    {
        public AssemblyTimeConverter() : base(a => a.Location is not {Length:>0} location ? a.ParseLinkerTime() : new FileInfo(location).CreationTime) { }
    }
}