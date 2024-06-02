# Pacagroup.Ecommerce - Estructura del Proyecto

## Aplicacion
La carpeta `Aplicacion` contiene la capa de aplicaci�n del sistema, encargada de manejar la l�gica de aplicaci�n, los casos de uso y los flujos de trabajo. Esta capa se encarga de orquestar las tareas entre las diferentes capas del sistema y coordina las acciones del usuario, delegando las solicitudes a la capa de dominio.

## Dominio
La carpeta `Dominio` contiene la l�gica de negocio central del sistema. Aqu� se encuentran las entidades de dominio, los servicios de dominio y los repositorios que representan el n�cleo del negocio. Esta capa es independiente de cualquier tecnolog�a o infraestructura espec�fica y encapsula las reglas de negocio fundamentales.

## Infraestructura
La carpeta `Infraestructura` proporciona soporte t�cnico a las otras capas. Maneja la persistencia de datos, la comunicaci�n con otros sistemas y la gesti�n de dependencias. Incluye las implementaciones concretas de repositorios, servicios de mensajer�a, y otros componentes necesarios para la infraestructura t�cnica del sistema.

## Servicio
La carpeta `Servicio` contiene la l�gica de negocio espec�fica que se expone como microservicios o servicios dentro de la arquitectura. Puede incluir controladores y otros componentes que gestionen las solicitudes del API Gateway o directamente de los clientes, permitiendo la interacci�n con los microservicios del sistema.

## Transversal
La carpeta `Transversal` maneja aspectos que afectan a todas las capas del sistema, conocidos como preocupaciones transversales. Esto incluye la seguridad, el logging, la gesti�n de excepciones, la configuraci�n y otros servicios compartidos. El proyecto `Pacagroup.Ecommerce.Transversal.Common` est� ubicado aqu� y contiene estos componentes reutilizables.

### Pacagroup.Ecommerce.Transversal.Common
Este proyecto dentro de la carpeta `Transversal` incluye funcionalidades comunes y reutilizables que afectan a m�ltiples capas del sistema. Estas pueden ser componentes de seguridad, logging, gesti�n de excepciones, configuraci�n y otros servicios transversales que son esenciales para el funcionamiento coherente y seguro de la aplicaci�n.
