# Pacagroup.Ecommerce - Estructura del Proyecto

## Aplicacion
La carpeta `Aplicacion` maneja la l�gica de aplicaci�n, los casos de uso y los flujos de trabajo, coordinando las acciones del usuario y delegando las solicitudes a la capa de dominio. Contiene los siguientes proyectos:

- **Pacagroup.Ecommerce.Application.DTO**: Define los objetos de transferencia de datos (DTOs) utilizados para transferir datos entre las capas de la aplicaci�n.
  - **CustomersDto.cs**: Define el DTO para la entidad `Customer`.
  - **UsersDto.cs**: Define el DTO para la entidad `User`.

- **Pacagroup.Ecommerce.Application.Interface**: Define las interfaces para los servicios de aplicaci�n.
  - **ICustomersApplication.cs**: Define la interfaz para la l�gica de negocio de los clientes en la capa de aplicaci�n.
  - **IUsersApplication.cs**: Define la interfaz para la l�gica de negocio de los usuarios en la capa de aplicaci�n.

- **Pacagroup.Ecommerce.Application.Main**: Implementa la l�gica de negocio y coordina las operaciones de la aplicaci�n.
  - **CustomersApplication.cs**: Implementa `ICustomersApplication` y maneja las operaciones de negocio para los clientes, utilizando `ICustomersDomain` y `IMapper` para las operaciones sincr�nicas y asincr�nicas.
  - **UsersApplication.cs**: Implementa `IUsersApplication` y maneja las operaciones de negocio para los usuarios.

## Dominio
La carpeta `Dominio` contiene la l�gica de negocio central del sistema. Incluye:

- **Pacagroup.Ecommerce.Domain.Core**: Contiene la l�gica de negocio principal y la coordinaci�n de las operaciones del dominio.
  - **CustomersDomain.cs**: Clase que maneja las operaciones de negocio relacionadas con los clientes. Incluye m�todos sincr�nicos y asincr�nicos para insertar, actualizar, eliminar, obtener y listar clientes.
  - **UsersDomain.cs**: Clase que maneja las operaciones de negocio relacionadas con los usuarios.

- **Pacagroup.Ecommerce.Domain.Entity**: Contiene las entidades del dominio, que representan los objetos principales del negocio.
  - **Customers.cs**: Define la entidad `Customer`, que representa a un cliente en el dominio del e-commerce.
  - **Users.cs**: Define la entidad `User`, que representa a un usuario en el dominio del e-commerce.

- **Pacagroup.Ecommerce.Domain.Interface**: Define las interfaces del dominio, especificando los contratos que deben implementar las clases del dominio.
  - **ICustomersDomain.cs**: Define la interfaz para la l�gica de negocio de los clientes.
  - **IUsersDomain.cs**: Define la interfaz para la l�gica de negocio de los usuarios.

## Infraestructura
La carpeta `Infraestructura` proporciona soporte t�cnico a las otras capas. Incluye varios proyectos para manejar la persistencia de datos y la comunicaci�n con otros sistemas:

- **Pacagroup.Ecommerce.Infrastructure.Data**: Maneja la conexi�n y la interacci�n con la base de datos.
  - **ConnectionFactory.cs**: Clase que maneja la creaci�n de conexiones a la base de datos.

- **Pacagroup.Ecommerce.Infrastructure.Interface**: Define las interfaces para los repositorios y otros servicios de infraestructura.
  - **ICustomersRepository.cs**: Define la interfaz para el repositorio de clientes, especificando las operaciones que pueden realizarse sobre los datos de clientes.
  - **IUsersRepository.cs**: Define la interfaz para el repositorio de usuarios.

- **Pacagroup.Ecommerce.Infrastructure.Repository**: Contiene las implementaciones de las interfaces definidas en `Infrastructure.Interface`.
  - **CustomersRepository.cs**: Implementaci�n concreta de `ICustomersRepository`, manejando las operaciones de persistencia para los datos de clientes.
  - **UsersRepository.cs**: Implementaci�n concreta de `IUsersRepository`, manejando las operaciones de persistencia para los datos de usuarios.

## Servicio
La carpeta `Servicio` contiene los controladores de la API y otros servicios relacionados con la exposici�n de la l�gica de negocio a trav�s de endpoints HTTP.

- **Pacagroup.Ecommerce.Services.WebApi**: Proyecto que expone los servicios del e-commerce a trav�s de una API web.
  - **Controllers**
    - **CustomersController.cs**: Controlador que maneja las solicitudes HTTP relacionadas con los clientes.
    - **UsersController.cs**: Controlador que maneja las solicitudes HTTP relacionadas con los usuarios.
  - **Helpers**
    - **AppSettings.cs**: Clase que contiene configuraciones de la aplicaci�n.
  - **appsettings.json**: Archivo de configuraci�n de la aplicaci�n.
  - **Program.cs**: Punto de entrada de la aplicaci�n.

## Transversal
La carpeta `Transversal` maneja aspectos que afectan a todas las capas del sistema. Incluye:

- **Pacagroup.Ecommerce.Transversal.Common**: Contiene funcionalidades comunes y reutilizables que afectan a m�ltiples capas del sistema.
  - **ConnectionFactory.cs**: Clase reutilizable para la gesti�n de conexiones a la base de datos, compartida a trav�s de diferentes proyectos y capas.
  - **Response.cs**: Clase que representa la estructura de la respuesta est�ndar utilizada en toda la aplicaci�n.
  - **IAppLogger.cs**: Interfaz para la abstracci�n del sistema de logging.
  - **LoggerAdapter.cs**: Implementaci�n concreta de `IAppLogger`.

- **Pacagroup.Ecommerce.Transversal.Mapper**: Contiene las configuraciones de mapeo utilizando `AutoMapper`.
  - **MappingsProfile.cs**: Define los perfiles de mapeo entre entidades de dominio y DTOs. Ejemplo de configuraci�n:
    ```csharp
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Customers, CustomersDto>()
                .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
                .ForMember(destination => destination.CompanyName, source => source.MapFrom(src => src.CompanyName))
                .ForMember(destination => destination.ContactName, source => source.MapFrom(src => src.ContactName))
                .ForMember(destination => destination.ContactTitle, source => source.MapFrom(src => src.ContactTitle))
                .ForMember(destination => destination.Address, source => source.MapFrom(src => src.Address))
                .ForMember(destination => destination.City, source => source.MapFrom(src => src.City))
                .ForMember(destination => destination.Region, source => source.MapFrom(src => src.Region))
                .ForMember(destination => destination.PostalCode, source => source.MapFrom(src => src.PostalCode))
                .ForMember(destination => destination.Country, source => source.MapFrom(src => src.Country))
                .ForMember(destination => destination.Phone, source => source.MapFrom(src => src.Phone))
                .ForMember(destination => destination.Fax, source => source.MapFrom(src => src.Fax))
                .ReverseMap();

            CreateMap<Users, UsersDto>()
                .ForMember(destination => destination.UserId, source => source.MapFrom(src => src.UserId))
                .ForMember(destination => destination.UserName, source => source.MapFrom(src => src.UserName))
                .ForMember(destination => destination.Email, source => source.MapFrom(src => src.Email))
                .ForMember(destination => destination.Password, source => source.MapFrom(src => src.Password))
                .ReverseMap();
        }
    }
    ```

## Elementos de la soluci�n
Actualmente, hay un archivo llamado `Info.md` que no se ha encontrado en el proyecto. Aseg�rate de que este archivo est� correctamente vinculado o existente en el directorio del proyecto.

### Nuevos Cambios
La capa de Aplicaci�n ahora incluye la implementaci�n de la l�gica de negocio para `Customers` y `Users` en `CustomersApplication.cs` y `UsersApplication.cs` respectivamente, proporcionando m�todos sincr�nicos y asincr�nicos para operaciones CRUD utilizando `ICustomersDomain`, `IUsersDomain`, y `IMapper`.
