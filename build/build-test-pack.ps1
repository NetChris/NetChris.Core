# Build and test script
# Schema v202008151207
# Ensure you run this from project root, not from build/

$ErrorActionPreference = "Stop"

# Get app-specific settings
. "build/app.ps1"

# If GitLab's CI_PIPELINE_IID is present, set patchVersion to that
if (Test-Path env:CI_PIPELINE_IID) { 
  $patchVersion = $env:CI_PIPELINE_IID
}
else {
  # Otherwise, assume we're running locally.
  # If you want to set another patch version locally,
  # set the CI_PIPELINE_IID environment variable.
  $patchVersion = 0
}

# VersionSuffix
if (!(Test-Path env:CI_COMMIT_REF_SLUG)) {
  # If CI_COMMIT_REF_SLUG is not present (i.e. not running in GitLab),
  # Assume local development, so get current branch
    # The version suffix must start with a letter for NuGet, so hard-code "pr-" (for "pre-release") as a prefix.
    $versionSuffix = "pr-$(git branch --show-current)"
} else {
  # CI_COMMIT_REF_SLUG present, but not master...
  if ($env:CI_COMMIT_REF_SLUG -ne "master") {
    # The version suffix must start with a letter for NuGet, so hard-code "pr-" (for "pre-release") as a prefix.
    # See this as an example of the error:
    # https://gitlab.com/cssl/NetChris/framework/logging/NetChris.Logging/-/jobs/687868397
    $versionSuffix = "pr-$env:CI_COMMIT_REF_SLUG"
  }
}

$versionPrefix = "$majorVersion.$minorVersion.$patchVersion"

$thisPath = $(Get-Location).Path

$artifacts = "$thisPath/build/artifacts"

if (Test-Path $artifacts) {
  "Clearing pre-existing artifacts ..."
  Remove-Item -Recurse -Force $artifacts
}

# Build the solution
dotnet build

# Test
# Assumes the test project references:
# - JUnitTestLogger
# - coverlet.collector
dotnet test `
  --logger "junit;LogFilePath=$artifacts/junitresults.xml" `
  --collect:"XPlat Code Coverage" `
  --results-directory:"$artifacts/" `
  $testProject

# coverlet/Cobertura right now include a GUID in the path to the output
# https://github.com/microsoft/vstest/issues/2378
# This is a ham-fisted way to get that file to a known location
Move-Item $artifacts/**/coverage.cobertura.xml $artifacts/

# Package
foreach ($packProject in $packProjects) {
  Write-Output "Packing $packProject"
  dotnet pack "$packProject" /p:VersionPrefix=$versionPrefix /p:VersionSuffix=$versionSuffix -o $artifacts/
}
