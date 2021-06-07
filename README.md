# AssemblyDataParser
Пакеты для чтения данных о сборке

Install-PackageAssemblyDataParser -Version 1.0.0.1

Install-Package AssemblyDataParser.WPF -Version 1.0.0.1  `For WPF with UserControls and Converters`

### Quick start


### For back code.

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

### Storing Update Information

Use `VersionData` class structure to storing update informations 

```Json
[
  {
    "VersionNumber": "1.0.106.5",
    "Description": [
      "First comment",
      "Second comment"
    ]
  },
  {
    "VersionNumber": "1.0.106.1",
    "Description": [
      "First comment",
      "Second comment"
    ]
  }
]
```

Store information in the AssemblyInfo
if you use `Net5` or above, `Core`, `Standard` - fill the section in `*.csproj`
```XML
  <PropertyGroup>
    <SourceRevisionId>
      ^build_date$([System.DateTime]::UtcNow.ToString("yyyy-MM-ddTHH:mm:ss:fffZ"))
      ^update[
                  {
                              "VersionNumber": "1.0.0.0",
                              "Description": [
                                          "Change 1",
                                          "Change 2",
                                          ]
                  },
                  {
                              "VersionNumber": "1.0.0.5",
                              "Description": [
                                          "Change 1",
                                          "Change 2",
                                          ]
                  },
      ]
    </SourceRevisionId>
</PropertyGroup>
```

For `NetFramework` - fill the section in `AssemblyInfo.cs`
```C#
[assembly: AssemblyInformationalVersion(
    "^update"
    + "["
        + "{"
            + "\"VersionNumber\": \"1.0.0.1\","
            + "\"Description\": ["
            + "\"Добавлен класс AssemblyParser для получения информации из сборки\","
            + "\"Добавлен класс AssemblyParser для получения информации из сборки\","
            + "\"Добавлен класс AssemblyParser для получения информации из сборки\","
            + "]"
        + "},"
    + "]"
    )]
```

You can also store `any information in this section`, specify the `key`, and read the key information in the code, use the character `^` to search for the key
Sample:
```
  <PropertyGroup>
    <SourceRevisionId>
      ^Easter egg(This is some text)
    </SourceRevisionId>
</PropertyGroup>
```
```C#
var data = Assembly.GetAssembly(typeof(SomeClassInMyLibrary)).ParseLinkerInformationString("Easter egg")
Console.WriteLine(data) //"This is some text"
```
To display information about assembly updates, retrieve data from the assembly using the - method - `ParseLinkerUpdatesData();`

Print to console:
```C#
using Newtonsoft.Json.Linq;

private static void PrintVersionUpdateData(Assembly assembly)
{
     var data = assembly.ParseLinkerUpdatesData();
     foreach (var d in data)
         foreach (var pair in JObject.FromObject(d))
         {
              Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
         }
}
```

Show in window:
```XAML
xmlns:view="clr-namespace:AssemblyDataParser.WPF.View;assembly=AssemblyDataParser.WPF"

<view:AssemblyUpdateDataView DataContext="{Binding Assembly, Source={x:Type local:App}}"/>
```

![Demo](https://github.com/Platonenkov/AssemblyDataParser/blob/dev/Resources/UpdateData.jpg)

Show Assembly info (you can hide unnecessary fields):
```C#
xmlns:view="clr-namespace:AssemblyDataParser.WPF.View;assembly=AssemblyDataParser.WPF"

<view:AssemblyDataView DockPanel.Dock="Top" Margin="10,0" TrademarkVisibility="False"/>
```

![Demo](https://github.com/Platonenkov/AssemblyDataParser/blob/dev/Resources/AssemblyData.jpg)
