echo off
rem Make folder links from the UnitySdk to this test project
cd %~dp0

rmdir PlayFabSdk
mklink /D PlayFabSdk C:\Users\Eric\Desktop\UnitySDK\Source\PlayFabSDK
rmdir Plugins
mklink /D Plugins C:\Users\Eric\Desktop\UnitySDK\Source\Plugins

pause