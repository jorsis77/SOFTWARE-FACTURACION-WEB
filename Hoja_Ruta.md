******************* PAUTAS Y AYUDAS ************************

1.SACFFOLD A BD EN .NET CORE(Databse First)

    con usuario y password
  
  Scaffold-DbContext "Data Source=LAPTOP-NAEARRFA\INMOBEST;user="ususuaas";password="dsfasd";Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models  
  
  Scaffold-DbContext "Data Source=LAPTOP-NAEARRFA\INMOBEST;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models

2.MULTITENANT 
  BASADO inicialmente en este video
    VIDEO => https://www.youtube.com/watch?v=ngb1YqpWfJs
    GIT => https://github.com/irandeniya/dotnet-multitenant-example.git(Mi git https://github.com/jorsis77/Tenan-1.git)




# INFO_NET-CORE

********************************
  //Modificar modelo de identity  tablas y hacer migración
     1.  https://iberasync.es/usuarios-personalizados-con-identity-en-asp-net-core/
     2. basado en esta de microsoft 
          https://docs.microsoft.com/es-es/aspnet/core/security/authentication/add-user-data?view=aspnetcore-6.0&tabs=visual-studio.
      
     3. Confirmación de las cuentas y recuperación de contraseñas en ASP.NET Core
        https://docs.microsoft.com/es-es/aspnet/core/security/authentication/accconfirm?view=aspnetcore-6.0&tabs=visual-studio#require-email-confirmation
     4  aGRAGAR IDENTITY A UN PROYECTO EXISTENTE 
         https://docs.microsoft.com/es-es/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-6.0&tabs=visual-studio#full
         
  7. ***  ROLEES  PAGINA PARA ADMINISTRAR ROLES  *********
    https://aspnetcoremaster.com/little-aspnetcore-book/chapters/security-and-identity/authorization-with-roles.html#autorizaci%C3%B3n-con-roles          

8. FILTRO TENANT (DOC MUTLTITENAT MICROSOFT)
 https://docs.microsoft.com/en-us/ef/core/miscellaneous/multitenancy

SUPER PAGINA ==> https://aspnetcoremaster.com/little-aspnetcore-book/chapters/add-external-packages/index.html
Usar Humanizer en la vista
INFORMACION IMPORTANTE DE .NET CORE 


ver comentarios enUpload

Configuring Dbcontext as Transient
En el Onconfiguring se reescribe y se puede cambiar el conectionString

El lifetime Transient es recomendado por microsoft en un entorno multitenant con multiples bases de datos en donde el LifeTime Transient garantiza la creacion de la instancia del DBCONTEXT cada vez que en ConexionStrinting es solicitado , with the that if the user change TENAT , it is guaranteed that connectionstring is updated.

Una vez ya se sabe cual es el Tenant aqui se puede actualizar el conexion string al del tenat actual.

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
string connection_string = ""; //connection string from appsettings.json
optionsBuilder.UseSqlServer(connection_string);
}

Usar LifeTime Asi:

Scope : single Databe
Transient : Multi Database
