#!/usr/bin/env bash
set -euo pipefail
IFS=$'\n\t'

# echo commands
set -x

export BUILDCONFIGURATION=Release

if [ "$UITEST_TEST_MODE_NAME" == 'Snapshots' ];
then
	export TEST_FILTERS="FullyQualifiedName ~ SamplesApp.UITests.Snap"

	export SCREENSHOTS_FOLDERNAME=android-$ANDROID_SIMULATOR_APILEVEL-$TARGETPLATFORM_NAME-Snap

elif [ "$UITEST_TEST_MODE_NAME" == 'Automated' ];
then
	export TEST_FILTERS="\
		Namespace !~ SamplesApp.UITests.Snap\
		& FullyQualifiedName !~ SamplesApp.UITests.Runtime.BenchmarkDotNetTests\
		& FullyQualifiedName !~ SamplesApp.UITests.Runtime.RuntimeTests\
		& Category~testBucket:$UNO_UITEST_BUCKET_ID
	";

	export SCREENSHOTS_FOLDERNAME=android-$ANDROID_SIMULATOR_APILEVEL-$TARGETPLATFORM_NAME

elif [ "$UITEST_TEST_MODE_NAME" == 'RuntimeTests' ];
then
	export TEST_FILTERS="FullyQualifiedName ~ SamplesApp.UITests.Runtime.RuntimeTests"

	export SCREENSHOTS_FOLDERNAME=android-$ANDROID_SIMULATOR_APILEVEL-$TARGETPLATFORM_NAME
fi

export UNO_UITEST_SCREENSHOT_PATH=$BUILD_ARTIFACTSTAGINGDIRECTORY/screenshots/$SCREENSHOTS_FOLDERNAME
export UNO_UITEST_PLATFORM=Android
export UNO_UITEST_ANDROIDAPK_PATH=$BUILD_SOURCESDIRECTORY/build/$SAMPLEAPP_ARTIFACT_NAME/android/uno.platform.unosampleapp-Signed.apk
export IsUiAutomationMappingEnabled=true
export UITEST_RUNTIME_TEST_GROUP=${UITEST_RUNTIME_TEST_GROUP=automated}
export UNO_TESTS_LOCAL_TESTS_FILE=$BUILD_SOURCESDIRECTORY/src/SamplesApp/SamplesApp.UITests
export UNO_ORIGINAL_TEST_RESULTS=$BUILD_SOURCESDIRECTORY/build/TestResult-original.xml
export UNO_TESTS_FAILED_LIST=$BUILD_SOURCESDIRECTORY/build/uitests-failure-results/failed-tests-android-$ANDROID_SIMULATOR_APILEVEL-$SCREENSHOTS_FOLDERNAME-$UNO_UITEST_BUCKET_ID-$UITEST_RUNTIME_TEST_GROUP-$TARGETPLATFORM_NAME.txt
export UNO_TESTS_RESPONSE_FILE=$BUILD_SOURCESDIRECTORY/build/nunit.response
export UNO_UITEST_RUNTIMETESTS_RESULTS_FILE_PATH=$BUILD_SOURCESDIRECTORY/build/RuntimeTestResults-android-automated-$ANDROID_SIMULATOR_APILEVEL-$TARGETPLATFORM_NAME.xml

mkdir -p $UNO_UITEST_SCREENSHOT_PATH

if [ -f "$UNO_TESTS_FAILED_LIST" ] && [ `cat "$UNO_TESTS_FAILED_LIST"` = "invalid-test-for-retry" ];
then
	# The test results file only contains the re-run marker and no
	# other test to rerun. We can skip this run.
	echo "The file $UNO_TESTS_FAILED_LIST does not contain tests to re-run, skipping."
	exit 0
fi

cd $BUILD_SOURCESDIRECTORY/build

# This block allows to override the Android SDK
# disabled until hosted agents move to macOS 11
#
export ANDROID_HOME=$BUILD_SOURCESDIRECTORY/build/android-sdk
export ANDROID_SDK_ROOT=$BUILD_SOURCESDIRECTORY/build/android-sdk
export CMDLINETOOLS=commandlinetools-mac-8512546_latest.zip
mkdir -p $ANDROID_HOME
wget https://dl.google.com/android/repository/$CMDLINETOOLS
unzip $CMDLINETOOLS -d $ANDROID_HOME/cmdline-tools
rm $CMDLINETOOLS
mv $ANDROID_SDK_ROOT/cmdline-tools/cmdline-tools $ANDROID_SDK_ROOT/cmdline-tools/latest

# uncomment the following lines to override the installed Xamarin.Android SDK
# wget -nv https://jenkins.mono-project.com/view/Xamarin.Android/job/xamarin-android-d16-2/49/Azure/processDownloadRequest/xamarin-android/xamarin-android/bin/BuildRelease/Xamarin.Android.Sdk-OSS-9.4.0.59_d16-2_6d9b105.pkg
# sudo installer -verbose -pkg Xamarin.Android.Sdk-OSS-9.4.0.59_d16-2_6d9b105.pkg -target /

AVD_NAME=xamarin_android_emulator
AVD_CONFIG_FILE=~/.android/avd/$AVD_NAME.avd/config.ini

if [[ ! -f $AVD_CONFIG_FILE ]];
then
	# Install AVD files
	echo "y" | $ANDROID_HOME/cmdline-tools/latest/bin/sdkmanager --sdk_root=${ANDROID_HOME} --install 'tools'| tr '\r' '\n' | uniq
	echo "y" | $ANDROID_HOME/cmdline-tools/latest/bin/sdkmanager --sdk_root=${ANDROID_HOME} --install 'platform-tools'  | tr '\r' '\n' | uniq
	echo "y" | $ANDROID_HOME/cmdline-tools/latest/bin/sdkmanager --sdk_root=${ANDROID_HOME} --install 'build-tools;33.0.0' | tr '\r' '\n' | uniq
	echo "y" | $ANDROID_HOME/cmdline-tools/latest/bin/sdkmanager --sdk_root=${ANDROID_HOME} --install 'platforms;android-28' | tr '\r' '\n' | uniq
	echo "y" | $ANDROID_HOME/cmdline-tools/latest/bin/sdkmanager --sdk_root=${ANDROID_HOME} --install 'extras;android;m2repository' | tr '\r' '\n' | uniq
	echo "y" | $ANDROID_HOME/cmdline-tools/latest/bin/sdkmanager --sdk_root=${ANDROID_HOME} --install 'system-images;android-28;google_apis_playstore;x86_64' | tr '\r' '\n' | uniq
	echo "y" | $ANDROID_HOME/cmdline-tools/latest/bin/sdkmanager --sdk_root=${ANDROID_HOME} --install "system-images;android-$ANDROID_SIMULATOR_APILEVEL;google_apis_playstore;x86_64" | tr '\r' '\n' | uniq

	if [[ -f $ANDROID_HOME/platform-tools/platform-tools/adb ]]
	then
		# It appears that the platform-tools 29.0.6 are extracting into an incorrect path
		mv $ANDROID_HOME/platform-tools/platform-tools/* $ANDROID_HOME/platform-tools
	fi

	# Create emulator
	echo "no" | $ANDROID_HOME/cmdline-tools/latest/bin/avdmanager create avd -n "$AVD_NAME" --abi "x86_64" -k "system-images;android-$ANDROID_SIMULATOR_APILEVEL;google_apis_playstore;x86_64" --sdcard 128M --force

	# based on https://docs.microsoft.com/en-us/azure/devops/pipelines/agents/hosted?view=azure-devops&tabs=yaml#hardware
	# >> Agents that run macOS images are provisioned on Mac pros with a 3 core CPU, 14 GB of RAM, and 14 GB of SSD disk space.
	echo "hw.cpu.ncore=3" >> $AVD_CONFIG_FILE

	# Bump the heap size as the tests are stressing the application
	echo "vm.heapSize=256M" >> $AVD_CONFIG_FILE

	echo $ANDROID_HOME/emulator/emulator -list-avds

	echo "Checking for hardware acceleration"
	$ANDROID_HOME/emulator/emulator -accel-check

	echo "Starting emulator"

	# kickstart ADB
	$ANDROID_HOME/platform-tools/adb devices

	# Start emulator in background
	nohup $ANDROID_HOME/emulator/emulator -avd "$AVD_NAME" -skin 1280x800 -memory 4096 -no-window -gpu swiftshader_indirect -no-snapshot -noaudio -no-boot-anim > $BUILD_ARTIFACTSTAGINGDIRECTORY/screenshots/$SCREENSHOTS_FOLDERNAME/android-emulator-log-$UNO_UITEST_BUCKET_ID-$UITEST_TEST_MODE_NAME.txt 2>&1 &

	# Wait for the emulator to finish booting
	source $BUILD_SOURCESDIRECTORY/build/test-scripts/android-uitest-wait-systemui.sh 500

else
	# Restart the emulator to avoid running first-time tasks
	$ANDROID_HOME/platform-tools/adb reboot

	# Wait for the emulator to finish booting
	source $BUILD_SOURCESDIRECTORY/build/test-scripts/android-uitest-wait-systemui.sh 500
fi

# list active devices
$ANDROID_HOME/platform-tools/adb devices

# Workaround for https://github.com/microsoft/appcenter/issues/1451
$ANDROID_HOME/platform-tools/adb shell settings put global hidden_api_policy 1

echo "Emulator started"

cp $UNO_UITEST_ANDROIDAPK_PATH $BUILD_ARTIFACTSTAGINGDIRECTORY

cd $BUILD_SOURCESDIRECTORY/build

# Move to the screenshot directory so that the output path is the proper one, as
# required by Xamarin.UITest
cd $UNO_UITEST_SCREENSHOT_PATH

if [ -f "$UNO_TESTS_FAILED_LIST" ]; then
    UNO_TESTS_FILTER=`cat $UNO_TESTS_FAILED_LIST`
else
    UNO_TESTS_FILTER=$TEST_FILTERS
fi

echo "Test Parameters:"
echo "  Timeout=$UITEST_TEST_TIMEOUT"
echo "  Test filters: $UNO_TESTS_FILTER"

cd $UNO_TESTS_LOCAL_TESTS_FILE

## Run NUnit tests
dotnet test \
	-c Release \
	-l:"console;verbosity=normal" \
	--logger "nunit;LogFileName=$UNO_ORIGINAL_TEST_RESULTS" \
	--filter "$UNO_TESTS_FILTER" \
	--blame-hang-timeout 120m \
	-v m \
	|| true

## Dump the emulator's system log
$ANDROID_HOME/platform-tools/adb shell logcat -d > $BUILD_ARTIFACTSTAGINGDIRECTORY/screenshots/$SCREENSHOTS_FOLDERNAME/android-device-log-$UNO_UITEST_BUCKET_ID-$UITEST_RUNTIME_TEST_GROUP-$UITEST_TEST_MODE_NAME.txt

if [ ! -f "$UNO_ORIGINAL_TEST_RESULTS" ]; then
	echo "ERROR: The test results file $UNO_ORIGINAL_TEST_RESULTS does not exist (did nunit crash ?)"
	return 1
fi

## Export the failed tests list for reuse in a pipeline retry
pushd $BUILD_SOURCESDIRECTORY/src/Uno.NUnitTransformTool
mkdir -p $(dirname ${UNO_TESTS_FAILED_LIST})
dotnet run list-failed $UNO_ORIGINAL_TEST_RESULTS $UNO_TESTS_FAILED_LIST
popd
