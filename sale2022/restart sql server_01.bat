@ECHO OFF 
:stop
   net stop mssqlserver /y
      goto end
:end