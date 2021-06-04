## Assembly extensions

<table>
  <thead>
    <tr>
      <td width="50%">
        Method
      </td>
      <td> 
        Ru
      </td>
      <td>
        En
      </td>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        ParseLinkerInformationString(string key)
      </td>
      <td>
        Получает строку мета-информации из файла сборки
      </td>
      <td>
        Get meta-information row from assembly by key
      </td>
    </tr>
    <tr>
      <td>
        ParseLinkerUpdatesData();
      </td>
      <td>
        Получает информацию о версиях из мета-информации сборки
      </td>
      <td>
        Get Version information from assembly meta-information
      </td>
    </tr>    
    <tr>
      <td>
        ParseLinkerTime(bool CheckFileCrationIfNoData = false, string TimeFormat = "dd/MM/yyyy HH:mm")
      </td>
      <td>
        Забирает дату сборки из мета-информации
      </td>
      <td>
        Get DateTime of build from assembly meta-information
      </td>
    </tr>
    <tr>
      <td>
        ParseCompany()
      </td>
      <td>
        Получение информации о компании из сборки
      </td>
      <td>
        Get company data from assembly
      </td>
    </tr>
    <tr>
      <td>
        ParsePackageVersion()
      </td>
      <td>
        Получение информации о версии сборки
      </td>
      <td>
        Get PackageVersion data from assembly
      </td>
    </tr>
    <tr>
      <td>
        ParseConfiguration()
      </td>
      <td>
        Получение информации о Конфигурации из сборки
      </td>
      <td>
        Get Configuration data from assembly
      </td>
    </tr>
    <tr>
      <td>
        ParseCopyright()
      </td>
      <td>
        Получение информации о авторстве из сборки
      </td>
      <td>
        Get Copyright data from assembly
      </td>
    </tr>
    <tr>
      <td>
        ParseDescription()
      </td>
      <td>
        Получение информации о описании из сборки
      </td>
      <td>
        Get Description data from assembly
      </td>
    </tr>
    <tr>
      <td>
        ParseFileVersion()
      </td>
      <td>
        Получение информации о файловой версии сборки
      </td>
      <td>
        Get FileVersion data from assembly
      </td>
    </tr>
    <tr>
      <td>
        ParseProduct()
      </td>
      <td>
        Получение информации о продукте из сборки
      </td>
      <td>
        Get Product data from assembly
      </td>
    </tr>
    <tr>
      <td>
        ParseCreationTime(bool CheckMetaDataIfNoFile = false, string TimeFormat = "dd/MM/yyyy HH:mm")
      </td>
      <td>
        Получение информации о времени формирования файла сборки
      </td>
      <td>
        Get Creation time of assembly
      </td>
    </tr>
    <tr>
      <td>
        ParseTitle()
      </td>
      <td>
        Получение информации заголовка из сборки
      </td>
      <td>
        Get Title data from assembly
      </td>
    </tr>
    <tr>
      <td>
        ParseTrademark()
      </td>
      <td>
        Получение информации о торговой марке из сборки
      </td>
      <td>
        Get Trademark data from assembly
      </td>
    </tr>
  </tbody>
  </table>
