# CrashReportUnity
Test crash cases on different crash reporting tools in Unity environment.

# Build on Android
1. Make sure the platform is switched to Android.
2. Check the Development Build and Script Debugging.
3. In Player Setting, set the Package Name if needed.

# Build on iOS
Unity -> Xcode
1. Make sure the platform is switched to iOS.
2. Check the Development Build and Script Debugging.
3. In Player Setting, set the Bundle Identifier if needed.

Xcode -> ipa
1. In target setting, apply the Provision Profile for signing.
2. In Build Settings, set Apple LLVM - Language: C Language Dialect to GNU99 for supporting asm call.
3. Same, set Apple LLVM - Objective C: Enable Objective-C Exception to Yes for supporting objective C exception crash.
4. Copy following files in Assets/Plugins/iOS to Unity-iPhone/Libraries/Plugins/iOS:

CRLFramelessDWARF_arm32.S <br />
CRLFramelessDWARF_arm64.s <br />
CRLFramelessDWARF_i386.s <br />
CRLFramelessDWARF_x86_64.s <br />
