#!/bin/sh
#aguardando 90 segundos para aguardar o provisionamento e start do banco
echo "AQUI!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"
sleep 30s

#rodar o comando para criar o banco
/opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U SA -P "Secret1234" -i banco.sql