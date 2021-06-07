using System;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;

// Общие сведения об этой сборке предоставляются следующим набором
// набор атрибутов. Измените значения этих атрибутов, чтобы изменить сведения,
// связанные со сборкой.
[assembly: AssemblyTitle("Test WPF Application")]
[assembly: AssemblyDescription("This is test application for AssemblyParser")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("https://github.com/Platonenkov")]
[assembly: AssemblyProduct("VersionTestWPF")]
[assembly: AssemblyCopyright("Copyright ©  2021 Platonenkov")]
[assembly: AssemblyTrademark("AssemblyDataParser")]
[assembly: AssemblyCulture("")]

[assembly: AssemblyVersion("1.0.0.1")]
[assembly: AssemblyFileVersion("1.0.0.1")]

[assembly: AssemblyInformationalVersion(
    "^update"
    + "["
        + "{"
            + "\"VersionNumber\": \"1.0.0.1\","
            + "\"Description\": ["
            + "\"Добавлен класс AssemblyParser для получения информации из сборки\","
            + "]"
        + "},"
    + "]"
    )]


//^build_date$([System.DateTime]::UtcNow.ToString("yyyy-MM-ddTHH:mm:ss:fffZ"))
//^ update
//    [
//{
//    "VersionNumber": "1.0.0.0",
//    "Description": [
//    "Добавлен класс AssemblyParser для получения информации из сборки",
//    "Добавлено статическое расширение для класса Assebly, позволяющее быстро получить данные о сборки",
//    "Добавлена возможность обработки мета-информации в секции SourceRevisionId",
//        ]
//},]

// Установка значения False для параметра ComVisible делает типы в этой сборке невидимыми
// для компонентов COM. Если необходимо обратиться к типу в этой сборке через
// из модели COM, установите атрибут ComVisible для этого типа в значение true.
[assembly: ComVisible(false)]

//Чтобы начать создание локализуемых приложений, задайте
//<UICulture>CultureYouAreCodingWith</UICulture> в файле .csproj
//в <PropertyGroup>. Например, при использовании английского (США)
//в своих исходных файлах установите <UICulture> в en-US.  Затем отмените преобразование в комментарий
//атрибута NeutralResourceLanguage ниже.  Обновите "en-US" в
//строка внизу для обеспечения соответствия настройки UICulture в файле проекта.

//[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]


[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //где расположены словари ресурсов по конкретным тематикам
                                     //(используется, если ресурс не найден на странице,
                                     // или в словарях ресурсов приложения)
    ResourceDictionaryLocation.SourceAssembly //где расположен словарь универсальных ресурсов
                                              //(используется, если ресурс не найден на странице,
                                              // в приложении или в каких-либо словарях ресурсов для конкретной темы)
)]


