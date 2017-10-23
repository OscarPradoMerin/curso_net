CHALLENGE 3: Ojo que viene Plusdede (15min)



1. Vamos a agregar un poco de seguridad basada en roles a nuestra aplicación
   - Los usuarios pueden crear contenido o verlo
   - Los moderadores pueden hacer lo mismo que los usuarios, pero además pueden editar y borrar contenido
   - Los administradores pueden hacer lo mismo que usuarios y moderadores, pero además pueden acceder al controlador de Stats. Además de que no deje acceder, queremos que no se vea el menú Stats si no somos Admin. Corazón que no ve, corazón que no siente.

1. Además, queremos un menú de "My songs" y otro de "My videos" en los que solo aparezcan nuestras canciones y vídeos.
2. Finalmente, vamos a hacer que StatsController haga algo útil de una vez. En lugar del texto plano que envía ahora, queremos que nos devuelva las canciones+vídeos subidos por todos los usuarios de la plataforma el último día, la última semana y los últimos treinta días.



Pistas

Para contar registros que cumplen determinada condición

    context.Authors.Count(a => a.Name == "Kanye West")



Para saber si un usuario está en un rol

    Roles.IsInRole("username", "rolename")



Operaciones con fechas

Fecha (día) de hoy, hora 00:00:00

    DateTime.Today

Agregar o quitar días

    AddDays(days);

Fecha y hora en este momento

    DateTime.Now

Se pueden realizar sumas y restas de fechas con operadores + y -, el resultado es un intervalo de tiempo (Timespan)

Timespan interval = date1 - date2;

Para usar directamente en LINQ to entities (método traducible a SQL)

    DbFunctions.DiffDays(x.DataTimeStart)






