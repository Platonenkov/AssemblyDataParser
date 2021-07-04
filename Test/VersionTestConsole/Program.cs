using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using AssemblyDataParser;
using Newtonsoft.Json.Linq;

namespace VersionTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Test_Versions();
            var buildTime = Assembly.GetAssembly(typeof(AssemblyParser)).ParseLinkerTime(true);
            Console.WriteLine($"Build time at {buildTime}");

            PrintVersionUpdateData(Assembly.GetAssembly(typeof(AssemblyParser)));

            Test();

            Console.WriteLine("Write any key to close");
            Console.ReadKey();
        }

        static async void Test_Versions()
        {
            var from_embed_resource_file = await Assembly.GetAssembly(typeof(Program)).GetDataFromJsonResourceFileAsync<List<AssemblyVersionData>>("Versions.json");
            var from_file = AssemblyVersionData.GetVersionInfoFromFileAsync("Versions.json");

        }
        /// <summary>
        /// Печатает на экран информацию о версиях ПО
        /// </summary>
        /// <param name="assembly">имя сборки которую читаем</param>
        private static void PrintVersionUpdateData(Assembly assembly)
        {
            var data = assembly.ParseLinkerUpdatesData();
            foreach (var d in data)
                foreach (var pair in JObject.FromObject(d))
                {
                    Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
                }
        }
        static void Test()
        {
            Console.WriteLine("Assembly info");
            var assembly = Assembly.GetAssembly(typeof(AssemblyParser));
            Console.WriteLine(assembly.ToString());
            Console.WriteLine("Example test 1");
            Test_1();
            Console.WriteLine();
            Console.WriteLine("Example test 2");
            Test_2();
        }

        static void Test_1()
        {
            Console.WriteLine("{0,-15} - {1,0}", "Package", Assembly.GetAssembly(typeof(AssemblyParser)).ParseTitle());
            Console.WriteLine(
                "{0,-15} - {1,0} from {2,0}", "Version", Assembly.GetAssembly(typeof(AssemblyParser)).ParsePackageVersion(),
                Assembly.GetAssembly(typeof(AssemblyParser)).ParseCreationTime(true));
            Console.WriteLine("{0,-15} - {1,0}", "File version", Assembly.GetAssembly(typeof(AssemblyParser)).ParseFileVersion());
            Console.WriteLine("{0,-15} - {1,0}", "Project", Assembly.GetAssembly(typeof(AssemblyParser)).ParseProduct());
            Console.WriteLine("{0,-15} - {1,0}", "Company", Assembly.GetAssembly(typeof(AssemblyParser)).ParseCompany());
            Console.WriteLine("{0,-15} - {1,0}", "Trademark", Assembly.GetAssembly(typeof(AssemblyParser)).ParseTrademark());
            Console.WriteLine("{0,-15} - {1,0}", "Copyright", Assembly.GetAssembly(typeof(AssemblyParser)).ParseCopyright());
            Console.WriteLine("{0,-15} - {1,0}", "Configuration", Assembly.GetAssembly(typeof(AssemblyParser)).ParseConfiguration());
            Console.WriteLine("{0,-15} - {1,0}", "Description", Assembly.GetAssembly(typeof(AssemblyParser)).ParseDescription());
        }

        static void Test_2()
        {
            //var V = new AssemblyParser(typeof(AssemblyParser));
            var V = new AssemblyParser<AssemblyVersionData>();
            Console.WriteLine("{0,-15} - {1,0}", "Program", V.ParseTitle());
            Console.WriteLine("{0,-15} - {1,0} from {2,0}", "Version", V.ParsePackageVersion(), V.ParseCreationTime());
            Console.WriteLine("{0,-15} - {1,0}", "File version", V.ParseFileVersion());
            Console.WriteLine("{0,-15} - {1,0}", "Project", V.ParseProduct());
            Console.WriteLine("{0,-15} - {1,0}", "Company", V.ParseCompany());
            Console.WriteLine("{0,-15} - {1,0}", "Trademark", V.ParseTrademark());
            Console.WriteLine("{0,-15} - {1,0}", "Copyright", V.ParseCopyright());
            Console.WriteLine("{0,-15} - {1,0}", "Configuration", V.ParseConfiguration());
            Console.WriteLine("{0,-15} - {1,0}", "Description", V.ParseDescription());

        }

    }
}
