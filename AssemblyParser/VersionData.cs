using System.Collections.Generic;

namespace AssemblyDataParser
{
    public class AssemblyVersionData
    {
        public string VersionNumber { get; set; }
        public IEnumerable<string> Description { get; set; }
    }
}
