# Requirements
# Visual Studio 2017+ (with Desktop Kit + 3.5 Developer Pack and 4.7.2)

param(
  [String]$Culture="en",
  [String]$BuildTarget="2016 RTM",
  [String]$SlnPath="Geta.sln",
  [String]$LogLevel="minimal", # https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference
  [String]$ExchangeLibrariesPath="c:\exchange-libs"
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
$exchangeVersions = Get-ChildItem -Path $ExchangeLibrariesPath
$exchangeFolders = $exchangeVersions | Where-Object {$_ -match $exchangeVersionRegex}
$regexMatch = $exchangeFolders | Where-Object {$_ -match $BuildTarget + "$"}

$useLibraryPath = "$ExchangeLibrariesPath\$BuildTarget"

try {
  if ($regexMatch.Length -eq 0){
    throw "You don't have the libraries for the build target: $BuildTarget. Please make sure that the directory $useLibraryPath does exist."
  } elseif($regexMatch.Length -gt 1) {
    throw "There where found multiple exchange versions for target $(BuildTarget) => $regexMatch"
  }
} 
catch {
  Write-Error $_.Exception.Message
  exit 1
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

if ($LastExitCode > 0) {
	# populate error code
	exit $LastExitCode
}

# clean and build with msbuild
$msbuildArgs = @("-nologo", "-maxcpucount", "-verbosity:$logLevel", "-property:ExchangeVersion=""$BuildTarget""", "-property:ExchangeLibraryPath=""$useLibraryPath"""))
Write-Host "Running msbuild with arguments: $msbuildArgs"
& $msbuildExe $msbuildArgs "/t:clean" $SlnPath

if ($LastExitCode > 0) {
	# populate error code
	exit $LastExitCode
}

& $msbuildExe $msbuildArgs "/t:build" $SlnPath

if ($LastExitCode > 0 ) {
	# populate error code
	exit $LastExitCode
}

exit 0