# script to add a desired version to the .sln and all .csproj files

param(
  [String][Parameter(Mandatory = $true)]$Target,
  [String]$SlnPath = "$PSScriptRoot\..\Geta.sln",
  [String]$TemplateVersion = "2010 SP3"
)

$SlnPath = [System.IO.Path]::GetFullPath($SlnPath)

$versionMatrix = @{}
Get-Content "$PSScriptRoot/add-version/version-matrix.csv" | ForEach-Object { $versionMatrix += @{$_.Split(';')[0] = $_.Split(';')[1]} }

function Update-Solution {
  $slnConfigurationRegex = '([\s]*)($TemplateVersion)\|(.+)\s*?=\s*?\2\|\3'
  $slnProjectConfigurationRegex = "{([\w\d-]+)}\.$TemplateVersion\|([\w\s]+)\.(ActiveCfg|Build.0)\s?=\s?$TemplateVersion\|([\w\d\s]+)"
  $slnConfigurationObj = New-Object regex $slnConfigurationRegex.Replace('$TemplateVersion', $TemplateVersion)
  $slnProjectExistsRegex = New-Object regex $slnConfigurationRegex.Replace('$TemplateVersion', $Target) # for checking whether the solution was already patched
  $slnProjectConfigurationObj = New-Object regex $slnProjectConfigurationRegex

  $slnContents = Get-Content $SlnPath
  $out = @()

  Write-Host "Patching Solution file ""$SlnPath"" => " -NoNewline

  try {
    foreach ($line in $slnContents) {
      $out += "$line"

      if ($slnProjectExistsRegex.IsMatch($line)) {
        Write-Host "Already patched"
        return
      }

      if ($slnConfigurationObj.IsMatch($line)) {
        $val = $slnConfigurationObj.Replace($line, '$1 ' + $Target + '|$3 = ' + $Target + '|$3')

        # removing one whitespace from start because we cannot concat $1 + $Target ==> Seems to be a powershell bug.
        $val = [regex]::Replace($val, '(\t\t) ', '$1', 0)

        $out += "$val"
      }
      elseif ($slnProjectConfigurationObj.IsMatch($line)) {
        $val = $slnProjectConfigurationObj.Replace($line, '{$1}.' + $Target + '|$2.$3 = ' + $Target + '|$4')
        $out += "$val"
      }
    }

    Set-Content -Path $SlnPath -Value $out -Encoding UTF8

    Write-Host "Done" -ForegroundColor Green -BackgroundColor Black
  }
  catch {
    Write-Host "Failed" -ForegroundColor Red -BackgroundColor Black
  }
}

function Test-Parameter {
  if (!$versionMatrix.ContainsKey($Target)) {
    Write-Error "Requested target ""$Target"" was not found in the version-matrix.csv"
    exit 1
  }
  if (!$versionMatrix.ContainsKey($TemplateVersion)) {
    Write-Error "Requested template ""$TemplateVersion"" was not found in the version-matrix.csv"
    exit 1
  }
}

Test-Parameter
Update-Solution