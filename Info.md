# Pacagroup.Ecommerce - Estructura del Proyecto

## Aplicacion
La carpeta `Aplicacion` contiene la capa de aplicación del sistema, encargada de manejar la lógica de aplicación, los casos de uso y los flujos de trabajo. Esta capa se encarga de orquestar las tareas entre las diferentes capas del sistema y coordina las acciones del usuario, delegando las solicitudes a la capa de dominio.

## Dominio
La carpeta `Dominio` contiene la lógica de negocio central del sistema. Aquí se encuentran las entidades de dominio, los servicios de dominio y los repositorios que representan el núcleo del negocio. Esta capa es independiente de cualquier tecnología o infraestructura específica y encapsula las reglas de negocio fundamentales.

## Infraestructura
La carpeta `Infraestructura` proporciona soporte técnico a las otras capas. Maneja la persistencia de datos, la comunicación con otros sistemas y la gestión de dependencias. Incluye las implementaciones concretas de repositorios, servicios de mensajería, y otros componentes necesarios para la infraestructura técnica del sistema.

## Servicio
La carpeta `Servicio` contiene la lógica de negocio específica que se expone como microservicios o servicios dentro de la arquitectura. Puede incluir controladores y otros componentes que gestionen las solicitudes del API Gateway o directamente de los clientes, permitiendo la interacción con los microservicios del sistema.

## Transversal
La carpeta `Transversal` maneja aspectos que afectan a todas las capas del sistema, conocidos como preocupaciones transversales. Esto incluye la seguridad, el logging, la gestión de excepciones, la configuración y otros servicios compartidos. El proyecto `Pacagroup.Ecommerce.Transversal.Common` está ubicado aquí y contiene estos componentes reutilizables.

### Pacagroup.Ecommerce.Transversal.Common
Este proyecto dentro de la carpeta `Transversal` incluye funcionalidades comunes y reutilizables que afectan a múltiples capas del sistema. Estas pueden ser componentes de seguridad, logging, gestión de excepciones, configuración y otros servicios transversales que son esenciales para el funcionamiento coherente y seguro de la aplicación.
