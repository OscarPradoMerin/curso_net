# Guía del curso



## Creación del repositorio GIT

```
// Configuración del usuario
git config --global user.name "Oscar Prado"
git config --global user.email oscarpradomerin@gmail.com

// Inicializar repo
git init Powerdede
```



## Creación del proyecto MVC

Proyecto MVC con Identity (Individual User Accounts) y Unit Tests

###INITIAL COMMIT

```
git add .
git commit -m "Initial Commit"
```



## Creación de modelos con Data Annotations

Song.cs (Canciones)

```c#
public class Song {
  public int Id { get; set; }
  [StringLength(50, ErrorMessage = "El título no puede contener más de 50 caracteres")]
  [DisplayName("Título")]
  public string Title { get; set; }
  public string Link { get; set; }
  [DisplayName("Duración")]
  public int Duration { get; set; }
  [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
  public DateTime UploadTime { get; set; }
  public int AuthorId { get; set; }
  [ForeignKey("AuthorId")]
  public Author Author { get; set; }
  public int SongGenreId { get; set; }
  [ForeignKey("SongGenreId")]
  public SongGenre SongGenre { get; set; }
  public string UserId { get; set; }
  [ForeignKey("UserId")]
  public ApplicationUser User { get; set; }
  [DisplayName("Activo")]
  public bool Active { get; set; }
}
```



Author.cs (Autores)

```c#
public class Author
{
  public int Id { get; set; }
  [DisplayName("Nombre")]
  public string Name { get; set; }
  [DisplayName("Apellido")]
  public string Surname { get; set; }
  [DisplayName("Activo")]
  public bool Active { get; set; }
}
```



Video.cs (Vídeos)

```c#
public class Video {
  public int Id { get; set; }
  [DisplayName("Título")]
  public string Title { get; set; }
  [DisplayName("Descripción")]
  public string Description { get; set; }
  [DisplayName("Duración")]
  public int Duration { get; set; }
  [DisplayName("Fecha subida")]
  [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
  public DateTime UploadTime { get; set; }
  public string Link { get; set; }
  public int VideoGenreId { get; set; }
  [ForeignKey("VideoGenreId")]
  public VideoGenre VideoGenre { get; set; }
  public string UserId { get; set; }
  [ForeignKey("UserId")]
  public ApplicationUser User { get; set; }
  [DisplayName("Activo")]
  public bool Active { get; set; }
}
```



SongGenre.cs (Género)

```c#
public class SongGenre
{
  public int Id { get; set; }
  [DisplayName("Nombre")]
  public string Name { get; set; }
}
```



VideoGenre.cs (Género)

```c#
public class VideoGenre
{
  public int Id { get; set; }
  [DisplayName("Nombre")]
  public string Name { get; set; }
}
```



## Generación de la base de datos



Agregar a IdentityModels, explicar ApplicationDbContext

```c#
public IDbSet<Video> Videos { get; set; }
public IDbSet<Song> Songs { get; set; }
public IDbSet<VideoGenre> VideoGenres { get; set; }
public IDbSet<SongGenre> SongGenres { get; set; }
public IDbSet<Author> Authors { get; set; }
```



Abrir Package Manager Console (Tools/Nuget Package Manager/Package Manager Console)

```
PM> Enable-Migrations
```

Al ejecutar este comando, se generará una carpeta Migrations con un archivo Configuration.cs en su interior. Este archivo servirá para configurar algunos parámetros de las migraciones y para establecer los datos seed (semilla).



Cambiar AutomaticMigrationsEnabled a true (Migrations/Configuration.cs)

```
PM> Update-Database -Verbose
```





Podemos abrir la ventana de Server Explorer desde el menú View y entrar en la conexión "DefaultConnection". Al recuperar las tablas, observaremos que nuestros modelos se han mapeado correctamente a la base de datos.



## Generación de controladores

Crear StatsController para la monitorización de estadísticas de uso de la aplicación (MVC Empty Controller)

```c#
public class StatsController : Controller
{
	// GET: Stats
	public string Index()
	{
		return "hola";
	}
}
```



Ejecutar Proyecto

### Motor de rutas

Ir a RouteConfig.cs

Podemos cambiar la ruta por defecto de la aplicación

```c#
routes.MapRoute(
  name: "Default",
  url: "{controller}/{action}/{id}",
  defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
);
```



Agregar nueva ruta personalizada ANTES que la ruta Default

```c#
routes.MapRoute(
  name: "Stats",
  url: "estadisticas",
  defaults: new { controller = "Stats", action = "Index", id = UrlParameter.Optional }
);
```



Si la agregamos después no funcionará porque el motor de rutas trata de ir al controlador "pepe" y, dentro de él, a la acción predeterminada "Index", que no existen.

Por tanto, hay que ponerlo ANTES, puesto que así tiene más prioridad que la ruta "Default"



### Creación de vistas

Modificar Stats/Index

```c#
// GET: Stats
public ActionResult Index()
{
  return View();
}
```



Para agregar la vista Index: Segundo botón dentro de la acción Index, Add view.



Objeto ViewBag

> El objeto ViewBag es un contenedor utilizado para transportar datos adicionales desde el controlador hacia las vistas. Es importante no utilizarlo como único medio de transporte de información, ya que al ser un objeto dinámico, su trazabilidad es muy compleja y dificultaría la escalabilidad y mantenimiento de la aplicación. En su lugar, utilizaremos Models y ViewModels



### ViewModels

Crear clase StatsViewModel.cs en carpeta Models


```c#
// GET: Stats
public ActionResult Index() {
  // Set data using parameters
  var statsViewModel = new StatsViewModel{LastDayUpdates = 1, LastWeekUpdates = 5, 		LastMonthUpdates = 20};

  // Set data using properties
  statsViewModel.LastDayUpdates = 1;
  statsViewModel.LastWeekUpdates = 5;
  statsViewModel.LastMonthUpdates = 20;

  return View(statsViewModel);
}
```



Agregar modelo a la vista

```c#
@model Powerdede.Models.StatsViewModel

@{
    ViewBag.Title = "Estadísticas";
}

<h2>Estadísticas</h2>

<p>Subidas último mes: @Model.LastMonthUpdates</p>
<p>Subidas última semana: @Model.LastWeekUpdates</p>
<p>Subidas último día: @Model.LastDayUpdates</p>
```



### Entity Framework

Creamos SongGenresController

Agregamos la acción Index

Podemos obtener entidades de la base de datos a través de nuestros modelos gracias al ORM que Entity Framework nos proporciona.

Para ello, accedemos a las colecciones de objetos que hemos agregado en IdentityModels. cada una de las cuales representan las tablas de nuestra base de datos. 

Para realizar consultas, filtrados, inserciones, modificaciones, borrados... Utilizamos Linq, que nos permite utilizar expresiones lambda para escribir código C# que en tiempo de ejecución se traducirá a SQL. 

> Por esto, es especialmente importante cuidar la optimización del código C# en LINQ, ya que el código mal desarrollado luego se traducirá a consultas poco optimizadas a la base de datos, perjudicando el rendimiento de la aplicación



Vamos a obtener todos los registros de la tabla SongGenres

```c#
// GET: SongGenres
public ActionResult Index()
{
  var songGenres = new List<SongGenre>();

  using (var context = new ApplicationDbContext()) {
    songGenres = context.SongGenres.ToList();
  }

  return View(songGenres);
}
```



Creamos la vista con segundo botón (SongGenres/Index.cshtml)

```c#
@model List<Powerdede.Models.SongGenre>
@{
    ViewBag.Title = "SongGenres";
}

<h2>SongGenres</h2>

@foreach (var item in Model) {
    <p>ID: @item.Id</p>
    <p>Nombre: @item.Name</p>
}
```



Ejecutamos, comprobamos que no hay filas



Agregamos acción Create

```c#
// GET: SongGenres/Create
public ActionResult Create()
{
  var songGenre = new SongGenre{Name = "Test"};

  using (var context = new ApplicationDbContext()) {
    context.SongGenres.Add(songGenre);
    
    // Commit to database
    context.SaveChanges();
  }

  // Add id to ViewBag in order to display it into the view
  ViewBag.InsertedId = songGenre.Id;

  return View();
}
```



Creamos la vista SongGenres/Create.cshtml

```c#

@{
    ViewBag.Title = "Create";
}

<h2>Create</h2>

<p>ID insertado: @ViewBag.InsertedId</p>
```



####Seed_1

Copiamos el contenido del archivo Seed_1.cs en el método Seed() del archivo Migrations/Configuration.cs

Realizamos un Update-Database para ejecutarlo



Filtrar por nombre

```c#
// GET: SongGenres
        public ActionResult Index(string filter = "") {
            var songGenres = new List<SongGenre>();

            using (var context = new ApplicationDbContext()) {

                // Get filtered songs
                if (filter.IsEmpty()) {
                    songGenres = context.SongGenres.ToList();
                } else {
                    songGenres = context.SongGenres.Where(s => s.Name.ToLower().Contains(filter.ToLower())).ToList();
                }
                
            }

            return View(songGenres);
        }
```



Ejecutamos y filtramos por URL?filter=Pop



___

## CHALLENGE 1: Crear acciones Details, Delete y Update (10min)



### Delete

- Pasar id del modelo a borrar como parámetro en la URL (SongGenres/Delete/{id})

- Después de eliminar la entidad, redirigir a la acción Index 

  ```c#
  return RedirectToAction("Index");
  ```

> Pista
>
> ```c#
> context.SongGenres.Remove(songGenreToRemove);
> ```



### Details

- Pasar id del modelo a mostrar como parámetro en la URL (SongGenres/Details/{id})
- Mostrar información de ese modelo en la vista Details



> Pista
>
> ```c#
> var songGenre = context.SongGenres.Find(id);
> ```



### Update

- Pasar id del modelo a modificar como parámetro en la URL (SongGenres/Update/{id})

- Después de realizar la modificación, redirigir a la acción Index 

  ```c#
   return RedirectToAction("Index");
  ```

> Pista
>
> ```c#
> context.SongGenres.AddOrUpdate(songGenreToUpdate);
> ```



**Collejaca pal que se deje el context.SaveChanges()!**



___



### Details

Acción del controlador

```c#
// GET: SongGenres/Details/{id}
public ActionResult Details(int id)
{
  SongGenre songGenre = null;

  using (var context = new ApplicationDbContext())
  {
    songGenre = context.SongGenres.Find(id);
  }

  return View(songGenre);
}
```



Vista

```c#
@model Powerdede.Models.SongGenre

@{
    ViewBag.Title = "Details";
    Layout = "";
}

<h2>Details</h2>

<p>Id: @Model.Id</p>
<p>Name: @Model.Name</p>
```



### Delete

Acción del controlador

       // GET: SongGenres/Delete/{id}
       public ActionResult Delete(int id)
        {
            SongGenre songGenre;
    
            using (var context = new ApplicationDbContext())
            {
                songGenre = context.SongGenres.Find(id);
    
                context.SongGenres.Remove(songGenre);
    
                // Commit to database
                context.SaveChanges();
            }
    
            return RedirectToAction("Index");
        }


### Update

Acción del controlador

```c#
// GET: SongGenres/Update
public ActionResult Update(int id)
{
  SongGenre songGenre = null;

  using (var context = new ApplicationDbContext())
  {
    songGenre = context.SongGenres.Find(id);

    songGenre.Name = "Modificado";

    context.SongGenres.AddOrUpdate(songGenre);

    // Commit to database
    context.SaveChanges();
  }

  return RedirectToAction("Index");
}
```



###Create

Modificamos la vista Create agregando los datos necesarios

Para enviar los datos necesarios al controlador, vamos a generar un objeto en la vista rellenándolo con los datos del formulario.

Después, ese objeto se recibirá a través de los parámetros de la acción Create, en el controlador.

Para la construcción del formulario, usaremos Razor, ya que nos permite abstraernos del lenguaje de cliente, creando vistas mucho más reutilizables y mantenibles.



```c#
@model Powerdede.Models.SongGenre
@{
    ViewBag.Title = "Create";
}

<h2>Create</h2>

@using (Html.BeginForm("Create", "SongGenres", FormMethod.Post)) {
    @Html.LabelFor(s => s.Name)
    @Html.TextBoxFor(s => s.Name)

    <input type="submit" value="Create" />
}
```



Ejecutamos y comprobamos que sigue insertando igual que antes. Hay que cambiar el controlador.

```c#
// POST: SongGenres/Create
// Por defecto, las rutas se interpretan como [HttpGet]
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([Bind(Include = "Id,Name")] SongGenre songGenre) {

  using (var context = new ApplicationDbContext()) {
    context.SongGenres.Add(songGenre);

    // Commit to database
    context.SaveChanges();
  }

  // Add id to ViewBag in order to display it into the view
  //ViewBag.InsertedId = songGenre.Id;

  return RedirectToAction("Index");
}
```

Utilizamos la anotación [Bind("Prop1, Prop2")] para especificar qué parámetros queremos vincular a nuestro modelo. Esto es muy importante para casos en los que el modelo posea propiedades que no queremos que puedan ser modificadas por las vistas, ya que podrían verse modificadas si la petición se realiza desde un formulario modificado o desde algún HttpRequester.

También podemos utilizar la directiva [ValidateAntiForgeryToken] en el controlador y @Html.AntiForgeryToken() en el cliente para evitar ataques [CSRF (Cross-site request forgery)](https://es.wikipedia.org/wiki/Cross-site_request_forgery), ya que de este modo se genera un token en la vista que luego es validado desde el controlador. De esta forma, nos aseguramos de que el formulario que envía los datos es el que nosotros hemos desarrollado.



### Autogenerando controladores

1. AuthorsController
2. SongsController
3. VideosController
4. VideoGenresController (async actions)



> Al generar los controladores, puede que se genere una línea en ApplicationDbContext referenciando a ApplicationDbUsers. Esto es una confusión del sistema de generación, ya que ApplicationDbContext hereda de IdentityDbContext, que ya contiene dicha propiedad. Deberemos eliminar la fila de Models/IdentityModels.cs que haga referencia a ApplicationUsers y, después,  reemplazar todos los "ApplicationDbUsers" por "Users" en los controladores de canciones y vídeos (CTRL+H)



Comprobamos qué se ha generado. Podemos observar cómo las vistas se generan utilizando Bootstrap, lo que nos permite adaptarlas posteriormente de forma muy sencilla. También facilita la implementación de plantillas de terceros de forma rápida y sencilla, ya que la mayoría de ellas utilizan Bootstrap. 



###Fichero _Layout

Ejecutamos y comprobamos que las rutas funcionan. Ahora, vamos a agregar las vistas al menú principal, que se encuentra en el archivo Views/Shared/_Layout

También vamos a cambiar el nombre de la aplicación, el title y el footer

```c#
// Title
<title>@ViewBag.Title - Powerdede</title>

// Application name
@Html.ActionLink("Powerdede", "Index", "Home", new { area = "" }, new { @class = "navbar-brand" })
  
// Footer
<footer>
	<p>&copy; @DateTime.Now.Year - Powerdede</p>
</footer>

// Navbar
<div class="navbar-collapse collapse">
	<ul class="nav navbar-nav">
      <li>@Html.ActionLink("Home", "Index", "Home")</li>
      <li>@Html.ActionLink("Videos", "Index", "Videos")</li>
      <li>@Html.ActionLink("Songs", "Index", "Songs")</li>
      <li>@Html.ActionLink("Authors", "Index", "Authors")</li>
      <li>@Html.ActionLink("Video Genres", "Index", "VideoGenres")</li>
      <li>@Html.ActionLink("Song Genres", "Index", "SongGenres")</li>
      <li>@Html.ActionLink("Stats", "Index", "Stats")</li>
	</ul>
	@Html.Partial("_LoginPartial")
</div>
```

El fichero _Layout funciona como una plantilla en la que se "pegan" el resto de vistas. Podemos tener varios, por si queremos establecer un diseño o estructura diferentes a cada una de las áreas de la plataforma.

En él se importan todos los ficheros css y js que vamos a necesitar, además de definir el header y el footer.

Comparte el ViewBag con las vistas, es por eso que el elemento title contiene el valor indicado por ViewBag.Title en cada una de las vistas.  



###Validación de modelos

Todas las vistas se autogeneran utilizando los estilos de Bootstrap. Además, como hemos especificado que se incluyan las librerías de scripts, el modelo se valida con jQuery. 

Además, en el controlador se vuelve a validar gracias a la clase ModelState, que nos permite consultar el estado del modelo llamando a ModelState.isValid(), o agregar errores personalizados en tiempo de ejecución con ModelState.AddModelError("propertyName", "errorMessage")

Vamos a crear un error personalizado en el controlador de Vídeos cuando se intente agregar un vídeo de duración mayor que 200 minutos

```c#
Código ModelState.AddModelError
```

Observamos que si dejamos el primer parámetro vacío, el error se muestra en el resumen de errores (ErrorSummary), mientras que si escribimos el nombre de la propiedad (Duratopm), aparece justo debajo de ella. Esto nos permite definir errores genéricos o específicos.





------



## CHALLENGE 2: Kanye, no llores (5min)

Vamos a agregar dos validaciones personalizadas al controlador de Autores

* Lanzar error a la vista al intentar agregar (Create) o establecer como nombre a un autor existente (Edit) "Kanye West". No hay de qué, futuros usuarios.
* Lanzar error a la vista al intentar agregar (Create) o establecer como nombre a un autor existente (Edit) un nombre que ya existe en la base de datos.



> Es necesario que ambas operaciones sean case-insensitive y que también consideren cadenas que contengan la palabra aunque no sean idénticas (Kanye Western, no te libras)



------



### Seguridad

Registrar nuevo usuario utilizando el botón de Register del menú de la web

Desde AccountController podemos modificar el funcionamiento del registro y del inicio de sesión. Por ejemplo, vamos a hacer que el inicio de sesión sea a través de un nombre de usuario en lugar del correo. 

Para ello, primero deberemos modificar el ViewModel encargado de recoger los datos de las vistas de Registro y Login para que recoja un nombre de usuario además de un email.



AccountViewModels/RegisterViewModel

```c#
public class RegisterViewModel
{
  [Required]
  [Display(Name = "UserName")]
  public string UserName { get; set; }

  [Required]
  [EmailAddress]
  [Display(Name = "Email")]
  public string Email { get; set; }

  [Required]
  [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
  [DataType(DataType.Password)]
  [Display(Name = "Password")]
  public string Password { get; set; }

  [DataType(DataType.Password)]
  [Display(Name = "Confirm password")]
  [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
  public string ConfirmPassword { get; set; }
}
```



AccountViewModels/LoginViewModel

```c#
public class LoginViewModel
{
  [Required]
  [Display(Name = "UserName")]
  public string UserName { get; set; }

  [Required]
  [DataType(DataType.Password)]
  [Display(Name = "Password")]
  public string Password { get; set; }

  [Display(Name = "Remember me?")]
  public bool RememberMe { get; set; }
}
```



AccountController/Login

```c#
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
          if (!ModelState.IsValid)
          {
            return View(model);
          }

          // This doesn't count login failures towards account lockout
          // To enable password failures to trigger account lockout, change to shouldLockout: true
          var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
          switch (result)
          {
            case SignInStatus.Success:
              return RedirectToLocal(returnUrl);
            case SignInStatus.LockedOut:
              return View("Lockout");
            case SignInStatus.RequiresVerification:
              return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            case SignInStatus.Failure:
            default:
              ModelState.AddModelError("", "Invalid login attempt.");
              return View(model);
          }
```



AccountController/Register

```c#
//
// POST: /Account/Register
[HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
          if (ModelState.IsValid)
          {
            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
              await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

              // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
              // Send an email with this link
              // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
              // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
              // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

              return RedirectToAction("Index", "Home");
            }
            AddErrors(result);
          }

          // If we got this far, something failed, redisplay form
          return View(model);
        }
```



Ahora, debemos modificar las vistas para tener en cuenta la propiedad UserName (Views/Account/Login y Views/Account/Register)

Una vez hecho esto, registramos tres usuarios: nosotros, un pringao, y uno menospringao

Podemos comprobar que tanto el UserName como el Email deben ser únicos



### Users

Uso de [Authorize()] y [AllowAnonymous]

Permitir solo a "pringao" acceder a un controlador o acción

```c#
[Authorize(Users = "pringao")]
```



Permitir a cualquier usuario logueado acceder

```c#
[Authorize]
```



Permitir a "menospringao" y  a nosotros acceder

```c#
[Authorize(Users = "menospringao,oscarpm")]
```



Permitir solo a nosotros acceder a todo el controlador de Stats

```c#
[Authorize(Users = "oscarpm")]
```



> Es muy importante utilizar estas anotaciones tanto en la acción GET como en la POST en acciones como Create, Edit... Ya que, si solo limitamos el acceso a la acción GET, un usuario malintencionado podría utilizar algún HTTP Requester para enviar una petición manualmente a nuestra acción POST.



### Roles

Cuando tenemos multitud de usuarios que queremos que realicen el mismo tipo de acciones, los roles se vuelven imprescindibles.



La creación de roles la podemos realizar en el método Seed(), de forma que si migramos la base de datos, los roles se volverán a generar



####Seed_2

Copiamos el contenido del archivo Seed_2.cs en el método Seed() del archivo Migrations/Configuration.cs

Realizamos un Update-Database para ejecutarlo



Podemos asociar desde base de datos o desde código, esta vez lo haremos desde base de datos

Para ello, vamos a la tabla AspNetUserRoles desde el Server Explorer y agregamos un registro por cada uno de nuestros usuarios, relacionando su id con el del rol correspondiente.



------



## CHALLENGE 3: Ojo que viene Plusdede (15min)



1. Vamos a agregar un poco de seguridad basada en roles a nuestra aplicación
   * Los usuarios pueden crear contenido o verlo
   * Los moderadores pueden hacer lo mismo que los usuarios, pero además pueden editar y borrar contenido
   * Los administradores pueden hacer lo mismo que usuarios y moderadores, pero además pueden acceder al controlador de Stats. Además de que no deje acceder, queremos que no se vea el menú Stats si no somos Admin. Corazón que no ve, corazón que no siente.


2. Además, queremos un menú de "My songs" y otro de "My videos" en los que solo aparezcan nuestras canciones y vídeos.
3. Finalmente, vamos a hacer que StatsController haga algo útil de una vez. En lugar del texto plano que envía ahora, queremos que nos devuelva las canciones+vídeos subidos por todos los usuarios de la plataforma el último día, la última semana y los últimos treinta días.



Pistas

> Para contar registros que cumplen determinada condición
>
> ```
> context.Authors.Count(a => a.Name == "Kanye West")
> ```



> Para saber si un usuario está en un rol
>
> ```c#
> Roles.IsInRole("username", "rolename")
> ```



Operaciones con fechas

> Fecha (día) de hoy, hora 00:00:00
>
> ```c#
> DateTime.Today
> ```

> Agregar o quitar días
>
> ```c#
> AddDays(days);
> ```

>Fecha y hora en este momento
>
>```c#
>DateTime.Now
>```

> Se pueden realizar sumas y restas de fechas con operadores + y -, el resultado es un intervalo de tiempo (Timespan)
>
> Timespan interval = date1 - date2;

> Para usar directamente en LINQ to entities (método traducible a SQL)
>
> ```
> DbFunctions.DiffDays(x.DataTimeStart)
> ```



___



## Despliegue en AppHarbor

Para el despliegue tenemos diferentes opciones: Windows Server, Azure... Yo voy a utilizar AppHarbor porque creo que es lo más accesible para la mayoría de vosotros. Os recomiendo también probar la versión de estudiante de Azure, echadle un vistazo porque tiene mucho potencial.

Antes de nada, tenemos que asegurarnos de que las migraciones de nuestro proyecto se ejecutan al realizar el deploy para que nuestra base de datos se transfiera al SQL Server de AppHarbor, si no, nuestra aplicación no tendrá base de datos a la que acceder en el servidor remoto y nos saltará un error. Para ello, vamos a Migrations/Configuration.cs y pegamos el siguiente código dentro de la clase ApplicationDbContext:

```c#
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
  Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
  base.OnModelCreating(modelBuilder);
}
```



Hecho esto, vamos directamente a la web de [AppHarbor](https://appharbor.com/) y nos registramos. A continuación, creamos una nueva aplicación (sobra decir que yo la llamaré Powerdede).

###Agregando la base de datos

En el menú de nuestra aplicación a la izquierda pulsamos sobre Add-ons. En esta ventana, bajamos hasta llegar hasta *SQL Server Shared Microsoft SQL Server as a service* e instalamos la versión gratuita, que para este ejemplo nos servirá.

A continuación, pulsamos sobre *SQL Server* debajo de *Installed Add-ons* y, finalmente, en *Go to SQL Server*.

Pulsamos sobre *Edit database configuration*

En Alias, introducimos *DefaultConnection*, que es el nombre de la cadena de conexión en el archivo web.config de nuestra applicación. Así conseguiremos que AppHarbor pueda inyectar su propia cadena de conexión al hacer el deploy.

### Agregando el repositorio remoto de AppHarbor a nuestro propio respositorio

Para que nuestra aplicación se despliegue en AppHarbor, debemos agregar la url del repositorio remoto y después "pushear" nuestro proyecto a ese repositorio.

Desde la carpeta de nuestro repositorio, abrimos una consola de Git Bash (Segundo botón, Git Bash Here). 

Primero agregamos el repositorio remoto:

```
git remote add appharbor https://OscarPM@appharbor.com/powerdede.git
```

Para saber nuestra URL del repositorio, en la web de AppHarbor buscamos el botón de *Repository url* y copiamos la URL que aparece.

Una vez hecho esto, podemos hacer el push (recordad hacer el commit si aún no lo habéis hecho):

```
git push appharbor master
```



Y ya estaría! Ahora solo toca esperar a que AppHarbor termine la compilación y, pulsando en *Go to my application*, podremos ir a nuestra web.



