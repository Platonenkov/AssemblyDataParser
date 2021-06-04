using System.Reflection;
using AssemblyDataParser.WPF.Converters.Base;

namespace AssemblyDataParser.WPF.Converters
{
    public class AssemblyCompanyConverter : AssemblyConverter
    {
        public AssemblyCompanyConverter() : base(GetAttributeValue<AssemblyCompanyAttribute>(a => a.Company)) { }
    }
}