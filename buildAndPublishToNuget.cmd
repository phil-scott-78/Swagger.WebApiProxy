@echo off

set MSBUILDDIR=C:\Program Files (x86)\MSBuild\12.0\bin\
IF EXIST "%MSBUILDDIR%msbuild.exe" goto RunIt

set MSBUILDDIR=C:\Program Files\MSBuild\12.0\bin\
IF EXIST %MSBUILDDIR%msbuild.exe goto RunIt

:: find msbuild and compile sln in root
reg.exe query "HKLM\SOFTWARE\Microsoft\MSBuild\ToolsVersions\4.0" /v MSBuildToolsPath > nul 2>&1
if ERRORLEVEL 1 goto MissingMSBuildRegistry

for /f "skip=2 tokens=2,*" %%A in ('reg.exe query "HKLM\SOFTWARE\Microsoft\MSBuild\ToolsVersions\4.0" /v MSBuildToolsPath') do SET MSBUILDDIR=%%B

IF NOT EXIST %MSBUILDDIR%nul goto MissingMSBuildToolsPath
IF NOT EXIST %MSBUILDDIR%msbuild.exe goto MissingMSBuildExe

:RunIt

echo %MSBUILDDIR%

:: restore packages for all sln files
for /f %%l in ('dir /b *.sln') do (    
    nuget restore  %%l
)

:: build all sln files in the root folder
for /f %%l in ('dir /b *.sln') do (    
    "%MSBUILDDIR%msbuild.exe"  %%l /m /p:Configuration=Release
)

:: remove all nupkg files
erase *.nupkg

:: pack everything in build folder
for /f %%l in ('dir /b build\*.nuspec') do (
    nuget pack build\%%l
)

:: publish all nupkg files created
for /f %%l in ('dir /b *.nupkg') do (
    nuget push %%l B1rchNug3t -Source http://nuget.birch.com
)

goto:eof


::ERRORS
::---------------------
:MissingMSBuildRegistry
echo Cannot obtain path to MSBuild tools from registry
goto:eof
:MissingMSBuildToolsPath
echo The MSBuild tools path from the registry '%MSBUILDDIR%' does not exist
goto:eof
:MissingMSBuildExe
echo The MSBuild executable could not be found at '%MSBUILDDIR%'
goto:eof


