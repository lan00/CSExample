rem restart pro
rem cs 12:39 AM 8/7/2018

set pro=rdpclip.exe
rem in hte end , second 
set timeoutA=5  
set timeoutDelay=0

taskkill -im %pro% -f
timeout %timeoutDelay%
start %pro%

timeout %timeoutA%
