## Migrador de Aspel NOI 9.0 a Aspel NOI10.0

Este programa acelera la migracion de la version 9 a 10, lo que debe hacerse es instalar la version 10 de NOI, ingresar 
al Dacaspel de la version 9 de NOI y copiar el contenido de la carpeta "Datos" y pegarlo dentro de la carepta de version 10.
Despues copiamos el archivo Conexiones.ini y empresas.xml de la carpeta de la version 9 y lo pegamos dentro del la carpeta
de la version 10, respaldando prevaimente dichos archivos en el destino.

Despues mediante linea de comandos ejecutamos el .exe compilado de este proyecto agregando como argumento la ruta de la carpeta
de la version 10 de COI dentro de Dacaspel.

Quedando el comando de la siguiente manera: 

.\MIGNOI.exe "C:\Program Files (x86)\Common Files\Aspel\Sistemas Aspel\NOI10.00\"

Por ultimo renombramos el archvio resultante Conexiones9.ini a Conexiones.ini, respaldando el archivo previamente.
