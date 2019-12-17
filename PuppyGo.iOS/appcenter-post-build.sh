#!/usr/bin/env bash

# Post Build Script

set -e # Exit immediately if a command exits with a non-zero status (failure)

echo "**************************************************************************************************"
echo "Post Build Script"
echo "**************************************************************************************************"

##################################################
# Start UI Tests
##################################################

echo "> Build UI test project"
msbuild "$APPCENTER_SOURCE_DIRECTORY/PuppyGo.UITests/PuppyGo.UITests.csproj" /property:Configuration=debug

echo "> Contents of $APPCENTER_SOURCE_DIRECTORY/packages"
for entry in "$APPCENTER_SOURCE_DIRECTORY/packages"/*
do
    echo "$entry"
done

echo "> Contents of $APPCENTER_SOURCE_DIRECTORY/src/packages"
for entry in "$APPCENTER_SOURCE_DIRECTORY/src/packages"/*
do
    echo "$entry"
done

echo "> Run UI test command"
# appCenterLoginApiToken must be setup as an environment variable for this branch. see this link for how to get the token
# https://docs.microsoft.com/en-us/appcenter/api-docs/
appcenter test run uitest --app "LivePersonBrad/PuppyGo-1" --devices e7a1a0a7 --app-path $APPCENTER_OUTPUT_DIRECTORY/PuppyGo.ipa --test-series "master" --locale "en_US" --build-dir $APPCENTER_SOURCE_DIRECTORY/PuppyGo.UITests/bin/Debug --uitest-tools-dir $APPCENTER_SOURCE_DIRECTORY/packages/Xamarin.UITest.*/tools --token $appCenterLoginApiToken --debug

echo ""
echo "**************************************************************************************************"
echo "Post Build Script complete"
echo "**************************************************************************************************"


