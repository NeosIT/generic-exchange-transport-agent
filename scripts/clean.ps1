$folders = @()
$folders += Get-ChildItem -Directory -Filter "bin" -Recurse | Where-Object {$_.Parent -like "Geta*"}
$folders += Get-ChildItem -Directory -Filter "obj" -Recurse | Where-Object {$_.Parent -like "Geta*"}
$folders += Get-ChildItem -Directory -Path "packages"

$folders | Select-Object -ExpandProperty FullName | Remove-Item -Force -Recurse