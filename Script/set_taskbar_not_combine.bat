rem @echo off
 
rem set_taskbar_not_combine

rem echo %1 
rem not primeter,%1 == ''
set aa=%1
rem set aa= %aa%0

if exist %USERPROFILE%\downloads\set_taskbar_not_combine goto haveSet
echo.>%USERPROFILE%\downloads\set_taskbar_not_combine

rem combine 
if "%aa%" equ "0" (
reg add "HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /t REG_DWORD /f /v "TaskbarGlomLevel" /d "00000000"

rem search box:2  
reg add "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search" /t REG_DWORD /f /v "SearchboxTaskbarMode" /d "00000002"
echo 00
 )  else (
echo 22
reg add "HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /t REG_DWORD /f /v "TaskbarGlomLevel" /d "00000002"

rem search button :1 
reg add "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search" /t REG_DWORD /f /v "SearchboxTaskbarMode" /d "00000001"
)

rem copy "\\Fxchvh02-v11\d$\Users\v-shacui\Desktop\test\dbg_file\qi ta\1   dbg_file.lnk"  %USERPROFILE%\downloads /y


taskkill  /f /im explorer.exe
rem start explorer.exe /e, %~d0%~p0

timeout 5
rem need,start taskbar
start explorer.exe
rem resource manager
start explorer.exe

rem Recursion
rem start explorer.exe %0  

rem pause

echo now set
goto end0

:haveSet
echo ever have set

:end0  

