# Pacagroup.Ecommerce - Estructura del Proyecto

## Aplicacion
Actualmente, la carpeta `Aplicacion` no contiene proyectos o archivos visibles. Esta capa debería manejar la lógica de aplicación, los casos de uso y los flujos de trabajo, coordinando las acciones del usuario y delegando las solicitudes a la capa de dominio.

## Dominio
La carpeta `Dominio` contiene la lógica de negocio central del sistema. Incluye:

- **Pacagroup.Ecommerce.Domain.Core**: Este proyecto contiene la lógica de negocio principal y la coordinación de las operaciones del dominio.
  - **CustomersDomain.cs**: Clase que maneja las operaciones de negocio relacionadas con los clientes. Incluye métodos sincrónicos y asincrónicos para insertar, actualizar, eliminar, obtener y listar clientes.

- **Pacagroup.Ecommerce.Domain.Entity**: Este proyecto contiene las entidades del dominio, que representan los objetos principales del negocio.
  - **Customers.cs**: Define la entidad `Customer`, que representa a un cliente en el dominio del e-commerce.

- **Pacagroup.Ecommerce.Domain.Interface**: Este proyecto define las interfaces del dominio, especificando los contratos que deben implementar las clases del dominio.
  - **ICustomersDomain.cs**: Define la interfaz para la lógica de negocio de los clientes.

## Infraestructura
La carpeta `Infraestructura` proporciona soporte técnico a las otras capas. Incluye varios proyectos para manejar la persistencia de datos y la comunicación con otros sistemas:

- **Pacagroup.Ecommerce.Infrastructure.Data**: Este proyecto maneja la conexión y la interacción con la base de datos.
  - **ConnectionFactory.cs**: Clase que maneja la creación de conexiones a la base de datos.

- **Pacagroup.Ecommerce.Infrastructure.Interface**: Este proyecto define las interfaces para los repositorios y otros servicios de infraestructura.
  - **ICustomersRepository.cs**: Define la interfaz para el repositorio de clientes, especificando las operaciones que pueden realizarse sobre los datos de clientes.

- **Pacagroup.Ecommerce.Infrastructure.Repository**: Este proyecto contiene las implementaciones de las interfaces definidas en `Infrastructure.Interface`.
  - **CustomersRepository.cs**: Implementación concreta de `ICustomersRepository`, manejando las operaciones de persistencia para los datos de clientes.

## Servicio
Actualmente, la carpeta `Servicio` no contiene proyectos o archivos visibles. Esta capa debería contener la lógica de negocio específica que se expone como microservicios o servicios dentro de la arquitectura.

## Transversal
La carpeta `Transversal` maneja aspectos que afectan a todas las capas del sistema. Incluye:

- **Pacagroup.Ecommerce.Transversal.Common**: Este proyecto contiene funcionalidades comunes y reutilizables que afectan a múltiples capas del sistema.
  - **ConnectionFactory.cs**: Clase reutilizable para la gestión de conexiones a la base de datos, compartida a través de diferentes proyectos y capas.

### Pacagroup.Ecommerce.Transversal.Common
Este proyecto dentro de la carpeta `Transversal` incluye componentes de uso común que pueden ser utilizados por múltiples partes del sistema. Las funcionalidades pueden incluir seguridad, logging, gestión de excepciones y configuración.

## Elementos de la solución
Actualmente, hay un archivo llamado `Info.md` que no se ha encontrado en el proyecto. Asegúrate de que este archivo esté correctamente vinculado o existente en el directorio del proyecto.
