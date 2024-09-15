Microservicio de Gestión de Productos | ECommerce Products
Este proyecto es un microservicio desarrollado en .NET Core para gestionar productos mediante operaciones CRUD (Crear, Leer, Actualizar y Eliminar). Almacena los datos en una base de datos simulada utilizando Entity Framework con InMemoryDatabase para fines de desarrollo y pruebas.

Características
    Operaciones CRUD para la entidad Producto.
    Base de datos simulada en memoria (InMemoryDatabase) utilizando Entity Framework Core.
    Seeding automático de categorías en la base de datos al iniciar la aplicación.
    Arquitectura basada en principios de Clean Architecture.

Estructura del Proyecto
Este proyecto sigue una arquitectura basada en Clean Architecture para mantener la separación de responsabilidades.

Domain: Contiene las entidades principales como Product y Category.
Application: Interfaces y lógica de aplicación.
Infrastructure: Implementación de repositorios, configuración de la base de datos y seeding de datos.
API: Controladores que exponen los endpoints.
Endpoints

El microservicio expone los siguientes endpoints para gestionar productos:

GET /api/products
Devuelve la lista de productos.

GET /api/products/{id}
Devuelve un producto específico por su ID.

POST /api/products
Crea un nuevo producto. Requiere un cuerpo con la información del producto en formato JSON.

PUT /api/products/{id}
Actualiza un producto existente.

DELETE /api/products/{id}
Elimina un producto por su ID.

Seeding de Datos
El servicio se inicializa con datos predeterminados de categorías mediante un seeder que se ejecuta al iniciar la API. Estas categorías incluyen:

1.  Electrodomésticos
2.  Tecnología y Electrónica
3.  Moda y Accesorios
4.  Hogar y Decoración
5.  Salud y Belleza
6.  Deportes y Ocio
7.  Juguetes y Juegos
8.  Alimentos y Bebidas
9.  Libros y Material Educativo
10. Jardinería y Bricolaje