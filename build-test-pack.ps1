# Build and test script
$ErrorActionPreference = "Stop"

$thisPath=$(Get-Location).Path

# Build the solution
dotnet build "$thisPath/src/"

# Test
dotnet test `
  --logger "junit;LogFilePath=$thisPath/artifacts/junitresults.xml" `
  --collect:"XPlat Code Coverage" `
  --results-directory:"$thisPath/artifacts/" `
  $thisPath/src/NetChris.Core.UnitTests/

# coverlet/Cobertura right now include a GUID in the path to the output
# https://github.com/microsoft/vstest/issues/2378
# This is a ham-fisted way to get that file to a known location
Move-Item $thisPath/artifacts/**/coverage.cobertura.xml $thisPath/artifacts/

# Package
dotnet pack src/NetChris.Core/NetChris.Core.csproj -o $thisPath/artifacts/
