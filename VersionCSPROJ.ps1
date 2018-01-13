<#
- Take argument, "-BuildNumber", an int
- Take argument, "-csprojPath", a string
- Get Project/PropertyGroup/Version from csproj
  - Ensure this works with *Any* property group
- Tokenize into Major, Minor, Patch version
   -Major and Minor are ints, Patch version is a string
- NumericPatch obtained by tokenizing Patch on "-" and taking [0]
  - ensure this works with both "3-beta" and "3"
- Inject build number into .NET versions: Major.Minor.Build.NumericPatch

#>

Param
(
    [Parameter(Mandatory)][int]$BuildNumber,
    [Parameter(Mandatory)][string]$csprojPath
)

"Build number: $BuildNumber"

"csproj = $csprojPath"

if (!(Test-Path $csprojPath))
{
    Throw "csproj file """ + $csprojPath + """ does not exist."
}
