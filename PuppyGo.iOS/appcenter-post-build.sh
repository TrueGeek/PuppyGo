#!/usr/bin/env bash

# Post Build Script

set -e # Exit immediately if a command exits with a non-zero status (failure)

echo "**************************************************************************************************"
echo "Post Build Script"
echo "**************************************************************************************************"

##################################################
# Start UI Tests
##################################################

echo "> Run UI test command"
appcenter test run uitest --app "LivePersonBrad/PuppyGo-1" --devices e7a1a0a7 --app-path $APPCENTER_OUTPUT_DIRECTORY/PuppyGo.ipa --test-series "master" --locale "en_US" --build-dir $APPCENTER_SOURCE_DIRECTORY/PuppyGo.UITests/bin/Debug

echo ""
echo "**************************************************************************************************"
echo "Post Build Script complete"
echo "**************************************************************************************************"


