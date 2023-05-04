# Compatible Powershell Versions: v1.0+

# The location to begin recursively searching for nupkg files
# you probably don't need to change this
$package_base = '.\'
# change this to the path of your nuget executable
$path = '..\Tools\Nuget\'
# Set the API key
$setapikey = 'ef2f8bcf-2359-4574-9f20-cd4a17969ed0'
# Location to push nuget packages
$nugetsource = 'https://www.myget.org/F/turborater-sdk/api/v2/package'

Get-ChildItem "$($package_base)*.nupkg" -Recurse | ForEach-Object { & "$($path)nuget.exe" "push" "$($_.FullName)" "-apikey" "$($setapikey)" "-Source" "$($nugetsource)" }
