## CHALLENGE 2: Kanye, no llores (5min)

Vamos a agregar dos validaciones personalizadas al controlador de Autores

- Lanzar error a la vista al intentar agregar (Create) o establecer como nombre a un autor existente (Edit) "Kanye West". No hay de qué, futuros usuarios.
- Lanzar error a la vista al intentar agregar (Create) o establecer como nombre a un autor existente (Edit) un nombre que ya existe en la base de datos.



> Es necesario que ambas operaciones sean case-insensitive y que también consideren cadenas que contengan la palabra aunque no sean idénticas (Kanye Western, no te libras)

