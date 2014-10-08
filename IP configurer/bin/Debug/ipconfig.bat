:checkPrivileges
NET FILE 1>NUL 2>NUL
if '%errorlevel%' == '0' ( goto gotPrivileges ) else ( goto getPrivileges)
:getPrivileges 
if '%1'=='ELEV' (shift & goto gotPrivileges) 
 setlocal DisableDelayedExpansion
set "batchPath=%~0"
setlocal EnableDelayedExpansion
ECHO Set UAC = CreateObject^("Shell.Application"^) > "%temp%\OEgetPrivileges.vbs" 
ECHO UAC.ShellExecute "!batchPath!", "ELEV", "", "runas", 1 >> "%temp%\OEgetPrivileges.vbs" 
"%temp%\OEgetPrivileges.vbs" 
exit /B 
:gotPrivileges
setlocal & pushd
netsh interface ip set address name="Ethernet" static 10.9.21.20 255.255.192.0 10.9.0.254
netsh interface ipv4 add dnsserver "Ethernet" address=202.141.81.2 index=1
netsh interface ipv4 add dnsserver "Ethernet" address=202.141.80.9 index=2
pause