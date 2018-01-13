<#
    Given -buildNumber and -csprojPath on the command line:
    - Takes the SemVer format version in the csproj <Version> property and breaks out into Major, Minor, and Patch version
    - Re-formats the AssemblyVersion and FileVersion as Major.Minor.BuildNumber.NumericPatch
    - Exports the following into the environment:
      - $env:semVer (e.g. "1.2.3-alpha")
      - $env:majorVersion (e.g. "1" if semVer is "1.2.3-alpha")
      - $env:minorVersion (e.g. "2" if semVer is "1.2.3-alpha")
      - $env:patchVersion (e.g. "3-alpha" if semVer is "1.2.3-alpha")
      - $env:patchVersionNumeric (e.g. "3" if semVer is "1.2.3-alpha")
    - Saves AssemblyVersion, FileVersion, and InformationalVersion
#>

Param
(
    [Parameter(Mandatory)][int]$buildNumber,
    [Parameter(Mandatory)][string]$csprojPath
)

"Build number: $buildNumber"

$csprojFile = Get-Item $csprojPath

if (!($csprojFile.Exists))
{
    Throw "csproj file """ + $csprojFile.FullName + """ does not exist."
}

$csprojFileFullName = $csprojFile.FullName

"csproj = $csprojFileFullName"

$xml = [xml](get-content $csprojPath)

$propertyGroup = $xml.Project.PropertyGroup | Where {$_.Version}
$version = $propertyGroup.Version
$versionParts = $version.Split("{.}")

[int]$majorVersion = $versionParts[0]
[int]$minorVersion = $versionParts[1]
[string]$patchVersion = $versionParts[2]
[int]$patchVersionNumeric = $patchVersion.Split("{-}")[0]

"Major version: $majorVersion"
"Minor version: $minorVersion"
"Patch version: $patchVersion"
"Patch version (numeric part): $patchVersionNumeric"

$assemblyVersion = "${majorVersion}.${minorVersion}.${buildNumber}.${patchVersionNumeric}"

"New assembly/file version: $assemblyVersion"

$assemblyVersionNode = $propertyGroup.AssemblyVersion
$fileVersionNode = $propertyGroup.FileVersion
$informationalVersionNode = $propertyGroup.InformationalVersion

if($assemblyVersionNode)
{
    $propertyGroup.AssemblyVersion = $assemblyVersion
}
else
{
    "No AssemblyVersion property in the project.  Would have set to '${assemblyVersion}'"
}

if($fileVersionNode)
{
    $propertyGroup.FileVersion = $assemblyVersion
}
else
{
    "No FileVersion property in the project.  Would have set to '${assemblyVersion}'"
}

$informationalVersion = "Version $version (Build: $buildNumber)"

if($informationalVersionNode)
{
    $propertyGroup.InformationalVersion = $informationalVersion
}
else
{
    "No InformationalVersion property in the project.  Would have set to '${informationalVersion}'"
}

# Clear environment variables first
$env:semVer = ""
$env:majorVersion = ""
$env:minorVersion = ""
$env:patchVersion = ""
$env:patchVersionNumeric = ""

$env:semVer = $version
$env:majorVersion = $majorVersion
$env:minorVersion = $minorVersion
$env:patchVersion = $patchVersion
$env:patchVersionNumeric = $patchVersionNumeric

$xml.Save($csprojFile.FullName)
