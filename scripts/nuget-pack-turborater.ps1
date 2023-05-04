# Compatible Powershell Versions: v1.0+

# The location to begin recursively searching for nuspec files
# you probably don't need to change this
$package_base = '..\'
# change this to the path of your nuget executable
$path = '..\Tools\Nuget\'
# Set the API key
$setapikey = 'ef2f8bcf-2359-4574-9f20-cd4a17969ed0'
# Location to push nuget packages
$nugetsource = 'https://www.myget.org/F/turborater-sdk/api/v2/package'
# Location to push nuget symbols
$symbolsource = ''

& "$($path)nuget.exe" "setapikey" "$($setapikey)"
Get-ChildItem "$($package_base)*.nuspec" -Recurse | ForEach-Object { & "$($path)nuget.exe" "pack" "$($_.FullName)" "-Symbols" }
