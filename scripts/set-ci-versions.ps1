# Sets the versions in the AssemblyInfo.cs files.
# This is used in our pipeline to mark builds with a build number and a commit hash.

param(
  [Parameter(Position = 0, Mandatory = $true)][String]$BuildNumber,
  [Parameter(Position = 1, Mandatory = $true)][String]$Revision
)

$assemblyInfos = Get-ChildItem -Filter "AssemblyInfo.cs" -Recurse | ForEach-Object {$_.FullName}

$fileVersionRegex = New-Object -TypeName System.Text.RegularExpressions.Regex -ArgumentList '^\[assembly: AssemblyFileVersion\("(\d+)"\)\]$'
$informationalVersionRegex = New-Object -TypeName System.Text.RegularExpressions.Regex -ArgumentList '^\[assembly: AssemblyInformationalVersion\("([\d\w]+)"\)\]$'

# iterate over every AssemblyInfo.cs file that was found
foreach ($file in $assemblyInfos) {
  $lines = Get-Content -Encoding UTF8 $file
  $outLines = @()

  # iterate over every line in the current AssemblyInfo.cs file
  foreach ($line in $lines) {
    # check for AssemblyFileVersion attribute
    $fileVersionMatch = $fileVersionRegex.Match($line)
    if ($fileVersionMatch.Success) {
      $outLines += "[assembly: AssemblyFileVersion(""$BuildNumber"")]"
    } else {
      # check for AssemblyInformationalVersion attribute only if it's not already a AssemblyFileVersion
      $informationalVersionMatch = $informationalVersionRegex.Match($line)
      if($informationalVersionMatch.Success){
        $outLines += "[assembly: AssemblyInformationalVersion(""$Revision"")]"
      } else {
        $outLines += $line
      }
    }
  }

  # write modified lines to the original file
  $txt = $outLines | Out-String
  Set-Content -Encoding UTF8 -Path $file -Value $txt
}
