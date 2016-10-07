@echo off
setlocal

if not exist "%VS140COMNTOOLS%VsMSBuildCmd.bat" (
  echo In order to run this tool you need either Visual Studio 2015 or
  echo Microsoft Build Tools 2015 tools installed.
  echo.
  echo Visit this page to download either:
  echo.
  echo https://www.visualstudio.com/downloads/
  echo.
  
  exit /b 1
)

set cachedNuGet=%LocalAppData%\NuGet\NuGet.exe
set logFile="%~dp0build.log"
set solutionPath="%~dp0Microsoft.DotNet.Maestro.sln"
set buildArgs=/nologo /maxcpucount /nodeReuse:false /v:minimal /clp:Summary /flp:Verbosity=detailed;LogFile=%logFile%;Append %*

REM Add msbuild to the path for the current process.
call "%VS140COMNTOOLS%\VsMSBuildCmd.bat"

if not exist %cachedNuGet% (
  echo Downloading latest version of NuGet.exe...
  if not exist %LocalAppData%\NuGet mkdir %LocalAppData%\NuGet
  @powershell -NoProfile -ExecutionPolicy unrestricted -Command "$ProgressPreference = 'SilentlyContinue'; Invoke-WebRequest 'https://www.nuget.org/nuget.exe' -OutFile '%cachedNuGet%'"
)

echo Restoring packages for %solutionPath%
%cachedNuGet% restore %solutionPath%

echo Building %solutionPath%
echo msbuild %solutionPath% %buildArgs%> %logFile%
echo.>> %logFile%

msbuild %solutionPath% %buildArgs%
