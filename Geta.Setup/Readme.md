# GETA Installer

This project creates an installer for the GUI application and all dependencies (GETA itself). In order to run the installer you must meet the following requirements:

* Exchange Server installed (or `ExchangeInstallPath` systemwide environment variable set)
* **Windows 7** / **Windows Server 2008 R2** or newer
* **64 bit** OS.

## Requirements

* MSBuild 15.0 (Included in VS 2017)

## Build the msi

The .msi installer file is build directly after building the `Geta.Setup.csproj`. This takes longer than a usual project so do it only when needed.

```ps
# in Geta.Setup/
# path to msbuild may vary
& "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" Geta.Setup.csproj /restore /target:Compile /maxcpucount /verbosity:minimal
```

In order to create a localized version of the setup you must set your powershell culture to the desired culture before running the build process.

```ps1$
$cultureInfo = [System.Globalization.CultureInfo]::GetCultureInfo($culture)
$currentThread = [System.Threading.Thread]::CurrentThread
$currentThread.CurrentCulture = $cultureInfo
$currentThread.CurrentUICulture = $cultureInfo
```