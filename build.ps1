# Requirements
# Visual Studio 2017+ (with Desktop Kit + 3.5 Developer Pack and 4.7.2)

param(
  [String]$Culture="en",
  [String]$BuildTarget="2016 CU1",
  [String]$SlnPath="Geta.sln",
  [String]$LogLevel="minimal" # https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference
)

# Constants
$exchangeVersionRegex = "Exchange (([\d]{4})( SP[\d])?( CU[\d]+)?( Preview)?)"
$vswhereDirProp = "productPath: "
$vswhere = "$env:ProgramFiles (x86)\Microsoft Visual Studio\Installer\vswhere.exe"

## Validate params
# set language
$cultureInfo = [System.Globalization.CultureInfo]::GetCultureInfo($Culture)
if ($Culture -eq $null) { throw "CultureInfo " + $Culture + " not found" }

# validate build target
$exchangeVersions = Get-ChildItem -Path "libs" -Filter "Exchange*"
$exchangeFolders = $exchangeVersions | Where-Object {$_ -match $exchangeVersionRegex}
$regexMatch = $exchangeFolders | Where-Object {$_ -match $BuildTarget + "$"}
if ($regexMatch.Length -eq 0){
  throw "You don't have the libraries for the build target: $buildTarget"
} elseif($regexMatch.Length -gt 1) {
  throw "There where found multiple exchange versions for target $(BuildTarget) => $regexMatch"
}


$vsDir = Split-Path -Parent (& $vswhere | Select-String -Pattern $vswhereDirProp).Line.TrimStart($vswhereDirProp)
$msbuildExe = (Resolve-Path -Path ([io.path]::combine($vsDir, '..', '..', 'MSBuild', '15.0', 'Bin', 'MSBuild.exe').ToString())).Path


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
$msbuildArgs = @("-nologo", "-maxcpucount", "-verbosity:$logLevel", "-property:Configuration=""$BuildTarget""")
Write-Host "Running msbuild with arguments: $msbuildArgs"
& $msbuildExe $msbuildArgs "/t:clean" $SlnPath
& $msbuildExe $msbuildArgs "/t:build" $SlnPath