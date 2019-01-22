# Requirements
# Visual Studio 2017+ (with Desktop Kit + 3.5 Developer Pack)

# Variables to define
#
# $env:ProjectDir => Path to the project (where the .sln is located)
# $env:LogLevel => Verbosity level for msbuild https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference

param(
  [String]$culture="en"
)

$vswhereDirProp = 'productPath: '
$vswhere = "$env:ProgramFiles (x86)\Microsoft Visual Studio\Installer\vswhere.exe"
$slnPath = If ($env:ProjectDir) {Join-Path $env:ProjectDir 'Geta.sln'} else {'Geta.sln'}
$logLevel = If ($env:LogLevel) {$env:LogLevel} else {'minimal'}

$vsDir = Split-Path -Parent (& $vswhere | Select-String -Pattern $vswhereDirProp).Line.TrimStart($vswhereDirProp)
$msbuildExe = (Resolve-Path -Path ([io.path]::combine($vsDir, '..', '..', 'MSBuild', '15.0', 'Bin', 'MSBuild.exe').ToString())).Path

# set language
$cultureInfo = [System.Globalization.CultureInfo]::GetCultureInfo($culture)

if ($culture = $null) { throw "CultureInfo " + $culture + " not found" }

$currentThread = [System.Threading.Thread]::CurrentThread
$currentThread.CurrentCulture = $cultureInfo
$currentThread.CurrentUICulture = $cultureInfo

# get nuget
if(-Not (Test-Path nuget.exe)){
  Invoke-WebRequest -OutFile nuget.exe -Uri https://dist.nuget.org/win-x86-commandline/latest/nuget.exe
}
# restore
.\nuget.exe restore

# clean and build with msbuild
& $msbuildExe -nologo -maxcpucount -verbosity:$logLevel /t:clean $slnPath
& $msbuildExe -nologo -maxcpucount -verbosity:$logLevel /t:build $slnPath