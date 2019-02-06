param(
  # Directory in which the dll files shall be added to the gac
  [String][Parameter(Mandatory=$true)]$Path,
  [string]$GacUtilPath="C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.7.2 Tools\"
)
$gacUtilPath = "$GacUtilPath\gacutil.exe"
$files = Get-ChildItem -Path $Path -Filter "*.dll" | Select-Object -ExpandProperty FullName

foreach($file in $files){
  Write-Host "Adding $file"
  & $gacUtilPath -nologo -if $file
}
