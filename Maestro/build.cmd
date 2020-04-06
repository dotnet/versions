@echo off
setlocal

set _VSWHERE="%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe"
if exist %_VSWHERE% (
  for /f "usebackq tokens=*" %%i in (`%_VSWHERE% -latest -prerelease -property installationPath`) do set _VSCOMNTOOLS=%%i\Common7\Tools
)
if not exist "%_VSCOMNTOOLS%" set _VSCOMNTOOLS=%VS150COMNTOOLS%
if not exist "%_VSCOMNTOOLS%" (
    echo Error: Visual Studio 2017+ required.
    echo        Please see https://github.com/dotnet/corefx/blob/master/Documentation/project-docs/developer-guide.md for build instructions.
    exit /b 1
)

set nuGetVersion=v3.4.4
set cachedNuGetDir=%LocalAppData%\NuGet\%nuGetVersion%
set cachedNuGet=%cachedNuGetDir%\NuGet.exe
set logFile="%~dp0build.log"
set solutionPath="%~dp0Microsoft.DotNet.Maestro.sln"
set buildArgs=/nologo /maxcpucount /nodeReuse:false /v:minimal /clp:Summary /flp:Verbosity=detailed;LogFile=%logFile%;Append %*

REM Add msbuild to the path for the current process.
call "%_VSCOMNTOOLS%\VsDevCmd.bat"

if not exist %cachedNuGet% (
  echo Downloading NuGet.exe %nuGetVersion%.
  if not exist %cachedNuGetDir% mkdir %cachedNuGetDir%
  @powershell -NoProfile -ExecutionPolicy unrestricted -Command "$ProgressPreference = 'SilentlyContinue'; Invoke-WebRequest 'https://dist.nuget.org/win-x86-commandline/%nuGetVersion%/NuGet.exe' -OutFile '%cachedNuGet%'"
)

echo Restoring packages for %solutionPath%
%cachedNuGet% restore %solutionPath%

echo Building %solutionPath%
echo msbuild %solutionPath% %buildArgs%> %logFile%
echo.>> %logFile%

msbuild %solutionPath% %buildArgs%
