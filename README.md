# AssemblyDataParser
Пакеты для чтения данных о сборке

### Quick start


### For Net5, Core, Standard, or WPF back code.

Use `AssemblyParser` or `AssemblyParser<T>`

```C#
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
```
You also can use `Assembly extensions`:
```C#
Assembly.GetAssembly(typeof(AssemblyParser)).ParseTitle()
```

### [All Extension and methods](https://github.com/Platonenkov/AssemblyDataParser/blob/dev/AssemblyExtensions.md)

### For WPF XAML

Add link
```xaml
        xmlns:converters="clr-namespace:AssemblyDataParser.WPF.Converters;assembly=AssemblyDataParser.WPF"
        xmlns:assemblyDataParser="clr-namespace:AssemblyDataParser;assembly=AssemblyDataParser"
```
Add `converter` to Bindings
```xaml
  <TextBlock>
      <Run Text="Library name" />
      <Run Text=": " />
      <Run Text="{Binding Assembly, Source={x:Type local:App}, Converter={converters:AssemblyTitleConverter}, Mode=OneTime}" />
  </TextBlock>
```
### [All Converters](https://github.com/Platonenkov/AssemblyDataParser/blob/dev/AssemblyConverters.md)
