@ECHO OFF 
:stop
   net stop mssqlserver /y
    net start mssqlserver 
   net start SQLSERVERAGENT
   goto end
:end