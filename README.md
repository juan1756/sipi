# Seminario de Integracion I

## Requisitos

Para poder desarrollar en este proyecto se requiere lo siguiente:

- Visual studio 2015+
- .Net Framework 4.5.2
- Base de datos (SQLExpress, SQLServer, MySQL)

## Logins

La URL para acceder al login manualmente es `~/cuenta/login`. 

Para desloguear manualmente la URL es: `~/cuenta/logout`.

Existen diferentes perfiles necesarios para acceder al sistema, estos son:

- **Miembro**: `miembro@mail.com`
- **Operador Contenido**: `operador_contenido@mail.com`
- **Operador Packaging**: `operador_packaging@mail.com`
- **Operador Vendedor**: `operador_vendedor@mail.com`

La contraseña es `1234` para todos.

## Inicialización

### Base de datos

#### Conexión

Crear un archivo dentro de la carpeta: `src\SIPI.Presentation.Website` con el siguiente nombre: `Web.ConnectionStrings.config` t agregarle el siguiente contenido:

	<connectionStrings>
	  <add name="SIPI" connectionString="Data Source=(local);User ID=<userdb>;Initial Catalog=SIPI;Password=<pwduserdb>;" providerName="System.Data.SqlClient" />
	</connectionStrings>

#### Creación/Actualización 

Con la conexión lista, en el Visual Studio, con el proyecto `SIPI.Presentation.Website` seteado como **Statup Project (se tiene que ver en negrita en el VS)**, abrir el **Package Manager Console**, dentro setear el proyecto default ("Default project") en `SIPI.Data.EF` y escribir el siguiente comando: `update-database -verbose`

Si no da errores, la base de datos ya debería estar generada y/o actualizada a la última versión.

#### Modificación/Alteración

**IMPORTANTE**: *Antes de cambiar algo en el modelo, hacer push y pull, ya que de otra manera los migrations pueden quedar en desorden y es dificil de arreglar.*

Para modificar la base de datos (tiene que estar en la última versión), sólo hay que modificar el modelo y ejecutar el siguiente comando para generar el migration: `add-migration <nombre_migration>` (usar sólo caracteres alfanumericos), si se esta conforme con lo que generó entonces se puede aplicar con el comando `update-database -verbose`.

Si no da errores, la base de datos ya debería reflejar las modificaciones realizadas.

## Sistema

### Proyectos

El sistema se divide en 3 proyectos:

- **SIPI.Presentation.Website**: Es la presentación del sistema, es donde va a estar todo el HTML, CSS y Js, está capa no debe tener mucha lógica, sólo la necesaria en cuanto a la interacción de los usuarios. Es en este proyecto donde van a estar los Models, Views y Controllers de MVC.
- **SIPI.Core**: Es el negocio del sistema, es donde estan los controladores, entidades de negocio y las vistas del sistema. Además se define cómo va a ser el acceso a datos.
- **SIPI.Data.EF**: Es la capa de datos del sistema, es donde se implementan los diferentes mappers que obtienen las entidades para poder mostrarlas en pantalla. En este proyecto es donde es utiliza EntityFramework

### Responsabilidades

En **SIPI.Core** las clases controlador, tienen la responsabilidad de orquestar el acceso a datos **(a través de un IMapper)** con el negocio y la posterior persistencia **(a través del IDataContext)** en caso de que sea necesario.

## Desarrollo

### Convenciones

#### SIPI.Core

- Todas las clases controlador deben finalizar con la palabra `Controlador`, de otra manera el sistema no las detectará y dará errores en ejecución.

#### SIPI.Data.EF

- Todas las clases Mapper deben finalizar con la palabra `Mapper`, de otra manera el sistema no las detectará y dará errores en ejecución.

