# NeosIT Generic Exchange Transport Agent

## How to build

- [.NET SDK >= 4.7.2](https://dotnet.microsoft.com/download/thank-you/net472-developer-pack) must be installed on build system
- Create a directory c:\exchange-libs
- For each Exchange version to compile against, create a directory `c:\exchange-libs\${EXCHANGE_VERSION}`, e.g. `c:\exchange-libs\2013`
- Copy all DLLs from the `\Bin` directory of your Exchange installation to the created directory
- Run (in powershell)

```ps1
.\build.ps1 -BuildTarget ${EXCHANGE_VERSION} -ExchangeLibrariesPath c:\exchange-libs
```

### Notes for 2013 SP1 CU4, 2016 or newer

### The Problem
Certain Exchange versions introduced new dependencies. As they bring even more sub-dependencies the development can get very annoying fighting with the [dependency hell](https://en.wikipedia.org/wiki/Dependency_hell).

As an example, **Exchange 2016 RTM**s `Microsoft.Exchange.Data.Transport.dll, Version 15.1.220` introduces a new dependency to `Microsoft.Exchange.Net.dll, Version 15.0.0` which introduces a dependency to `Microsoft.Data.Services.Client.dll, Version 5.6.0` and that requires a version of `Microsoft.WindowsAzure.Storage.dll, Version 4.3.0` but this package requires `Microsoft.Data.Services.Client.dll, Version 5.6.2`. As you may noticed now we require `Microsoft.Data.Services.Client.dll` at `5.6.0` and `5.6.2`. If you didn't yet notice here is a simple illustration of the dependency graph:

```none
Exchange.Data.Transport.dll@15.1.220
└──Exchange.Net.dll@15.0.0
   └──Data.Services.Client.dll@5.6.0       <----
      └──WindowsAzure.Storage.dll@4.3.0
         └──Data.Services.Client.dll@5.6.2 <----
```

Normally this is not a possible scenario. When you develop a simple .NET application you cannot target 2 versions of a dependency twice. But as dependencies can introduce their own dependencies its virtually impossible to restrict double usage of a library.

.NET comes with a **G**lobal**A**ssembly**C**ache. This is a systemwide available cache for all .NET applications to use common libraries. GAC can be used to work around the limitation of only referencing one version. There are [other ways](https://michaelscodingspot.com/2018/04/24/how-to-resolve-net-reference-and-nuget-package-version-conflicts/) but the GAC way worked the best for this project.

### The Solution

In order to use the GAC you have to copy all Exchange relevant dll files to it. You can use the `add-to-gac.ps1` script to add a complete folder to the GAC. For Exchange 2016 RTM you'll have to add the following .dll files from exchange to your GAC.

```none
Interop.NetFw.dll
Microsoft.Data.Edm.dll
Microsoft.Data.OData.dll
Microsoft.Data.Services.Client.dll
Microsoft.Exchange.Common.dll
Microsoft.Exchange.Common.IL.dll
Microsoft.Exchange.Compliance.dll
Microsoft.Exchange.Data.Common.dll
Microsoft.Exchange.Data.Transport.dll
Microsoft.Exchange.Diagnostics.dll
Microsoft.Exchange.Net.dll
Microsoft.Exchange.PswsClient.dll
Microsoft.RightsManagementServices.Core.dll
Microsoft.WindowsAzure.Storage.dll
```

Additionally they must be referenced in the execution project: `Geta.GuiApplication` (and `Geta.Tests`). In the given `.csproj` file (`Geta.GuiApplication.csproj`) there is a section called that looks like this:

```xml
<ItemGroup Condition="$(Configuration) == '2016 RTM'">
  ...
</ItemGroup>
```

here you have to reference the packages that should be deployed to the output folder. In the example of Exchange 2016 RTM it looks like this:

```xml
<Reference Include="Microsoft.Azure.KeyVault.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35">
  <HintPath>..\packages\Microsoft.Azure.KeyVault.Core.1.0.0\lib\net40\Microsoft.Azure.KeyVault.Core.dll</HintPath>
</Reference>
<Reference Include="Microsoft.WindowsAzure.Configuration, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35">
  <HintPath>..\packages\Microsoft.WindowsAzure.ConfigurationManager.1.8.0.0\lib\net35-full\Microsoft.WindowsAzure.Configuration.dll</HintPath>
</Reference>
<Reference Include="Microsoft.WindowsAzure.Storage, Version=4.3.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35">
  <HintPath>..\packages\WindowsAzure.Storage.4.3.0\lib\net40\Microsoft.WindowsAzure.Storage.dll</HintPath>
</Reference>
<Reference Include="Microsoft.Data.Edm, Version=5.6.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35">
  <HintPath>..\packages\Microsoft.Data.Edm.5.6.2\lib\net40\Microsoft.Data.Edm.dll</HintPath>
</Reference>
<Reference Include="Microsoft.Data.OData, Version=5.6.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35">
  <HintPath>..\packages\Microsoft.Data.OData.5.6.2\lib\net40\Microsoft.Data.OData.dll</HintPath>
</Reference>
<Reference Include="Microsoft.Data.Services.Client, Version=5.6.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35">
  <HintPath>..\packages\Microsoft.Data.Services.Client.5.6.2\lib\net40\Microsoft.Data.Services.Client.dll</HintPath>
</Reference>
<Reference Include="System.Spatial, Version=5.6.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35">
  <HintPath>..\packages\System.Spatial.5.6.2\lib\net40\System.Spatial.dll</HintPath>
</Reference>
```

As you can see here all referenced files are actually NuGet packages. This makes things easier instead of copying everything from you exchange servers `bin` folder.

That should be it. At this point you should be ready to start the GUI (or the tests).

#### Notes

- You don't have to do this on your Exchange machine. Only on your dev machine.
- There might be Exchange versions that don't require these steps.