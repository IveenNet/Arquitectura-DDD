# Pacagroup.Ecommerce - Estructura del Proyecto

## Aplicacion
La carpeta `Aplicacion` maneja la lógica de aplicación, los casos de uso y los flujos de trabajo, coordinando las acciones del usuario y delegando las solicitudes a la capa de dominio. Contiene los siguientes proyectos:

- **Pacagroup.Ecommerce.Application.DTO**: Define los objetos de transferencia de datos (DTOs) utilizados para transferir datos entre las capas de la aplicación.
  - **CustomersDto.cs**: Define el DTO para la entidad `Customer`.

- **Pacagroup.Ecommerce.Application.Interface**: Define las interfaces para los servicios de aplicación.
  - **ICustomersApplication.cs**: Define la interfaz para la lógica de negocio de los clientes en la capa de aplicación.

- **Pacagroup.Ecommerce.Application.Main**: Implementa la lógica de negocio y coordina las operaciones de la aplicación.
  - **CustomersApplication.cs**: Implementa `ICustomersApplication` y maneja las operaciones de negocio para los clientes, utilizando `ICustomersDomain` y `IMapper` para las operaciones sincrónicas y asincrónicas.

## Dominio
La carpeta `Dominio` contiene la lógica de negocio central del sistema. Incluye:

- **Pacagroup.Ecommerce.Domain.Core**: Contiene la lógica de negocio principal y la coordinación de las operaciones del dominio.
  - **CustomersDomain.cs**: Clase que maneja las operaciones de negocio relacionadas con los clientes. Incluye métodos sincrónicos y asincrónicos para insertar, actualizar, eliminar, obtener y listar clientes.

- **Pacagroup.Ecommerce.Domain.Entity**: Contiene las entidades del dominio, que representan los objetos principales del negocio.
  - **Customers.cs**: Define la entidad `Customer`, que representa a un cliente en el dominio del e-commerce.

- **Pacagroup.Ecommerce.Domain.Interface**: Define las interfaces del dominio, especificando los contratos que deben implementar las clases del dominio.
  - **ICustomersDomain.cs**: Define la interfaz para la lógica de negocio de los clientes.

## Infraestructura
La carpeta `Infraestructura` proporciona soporte técnico a las otras capas. Incluye varios proyectos para manejar la persistencia de datos y la comunicación con otros sistemas:

- **Pacagroup.Ecommerce.Infrastructure.Data**: Maneja la conexión y la interacción con la base de datos.
  - **ConnectionFactory.cs**: Clase que maneja la creación de conexiones a la base de datos.

- **Pacagroup.Ecommerce.Infrastructure.Interface**: Define las interfaces para los repositorios y otros servicios de infraestructura.
  - **ICustomersRepository.cs**: Define la interfaz para el repositorio de clientes, especificando las operaciones que pueden realizarse sobre los datos de clientes.

- **Pacagroup.Ecommerce.Infrastructure.Repository**: Contiene las implementaciones de las interfaces definidas en `Infrastructure.Interface`.
  - **CustomersRepository.cs**: Implementación concreta de `ICustomersRepository`, manejando las operaciones de persistencia para los datos de clientes.

## Servicio
Actualmente, la carpeta `Servicio` no contiene proyectos o archivos visibles. Esta capa debería contener la lógica de negocio específica que se expone como microservicios o servicios dentro de la arquitectura.

## Transversal
La carpeta `Transversal` maneja aspectos que afectan a todas las capas del sistema. Incluye:

- **Pacagroup.Ecommerce.Transversal.Common**: Contiene funcionalidades comunes y reutilizables que afectan a múltiples capas del sistema.
  - **ConnectionFactory.cs**: Clase reutilizable para la gestión de conexiones a la base de datos, compartida a través de diferentes proyectos y capas.
  - **Response.cs**: Clase que representa la estructura de la respuesta estándar utilizada en toda la aplicación.

- **Pacagroup.Ecommerce.Transversal.Mapper**: Contiene las configuraciones de mapeo utilizando `AutoMapper`.
  - **MappingsProfile.cs**: Define los perfiles de mapeo entre entidades de dominio y DTOs. Ejemplo de configuración:
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
        }
    }
    ```

## Elementos de la solución
Actualmente, hay un archivo llamado `Info.md` que no se ha encontrado en el proyecto. Asegúrate de que este archivo esté correctamente vinculado o existente en el directorio del proyecto.

### Nuevos Cambios
La capa de Aplicación ahora incluye la implementación de la lógica de negocio para `Customers` en `CustomersApplication.cs`, que proporciona métodos sincrónicos y asincrónicos para operaciones CRUD utilizando `ICustomersDomain` y `IMapper`.
