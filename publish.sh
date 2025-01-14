#!/bin/bash
SCRIPTPATH="$( cd "$(dirname "$0")" >/dev/null 2>&1 ; pwd -P )"

PROJECTDIR="$(basename $SCRIPTPATH)"

JSONFILE="${SCRIPTPATH}/src/${PROJECTDIR}/obj/project.assets.json"

dotnet build --configuration Release
dotnet pack --configuration Release

# Github source add: dotnet nuget add source --username USER --password $GITHUBPAT --store-password-in-clear-text --name github "https://nuget.pkg.github.com/TirsvadCLI/index.json"
# where USER is your github username and $GITHUBPAT is your password. See more at https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token
# In this environment the password value is exported so it can be accessed from script
dotnet nuget push "src/${PROJECTDIR}/bin/Release/$(jq -r '.project.restore.projectName' $JSONFILE).$(jq -r '.project.version' $JSONFILE).nupkg"  --api-key $GITHUBPAT --source https://nuget.pkg.github.com/TirsvadCLI/index.json --skip-duplicate
dotnet nuget push "src/${PROJECTDIR}/bin/Release/$(jq -r '.project.restore.projectName' $JSONFILE).$(jq -r '.project.version' $JSONFILE).nupkg"  --api-key $NUGETPAT --source https://api.nuget.org/v3/index.json --skip-duplicate
