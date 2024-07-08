# Sistema de Control de Vendedores para Cadena de Locales de Ropa

Este proyecto es una aplicación ASP.NET MVC desarrollada para que la gerencia pueda realizar el seguimiento de los vendedores. Permite al gerente realizar un seguimiento de ventas de cada vendedor por unidades y montos en sus respectivas sucursales, y a encargados dar de alta dicha información. Además, incluye funcionalidad de búsqueda y validaciones para garantizar la integridad de los datos.

## Características

- **Gestión de Sucursales**: Crear, leer, actualizar y eliminar información sobre las sucursales de la cadena.
- **Gestión de Vendedores**: Crear, leer, actualizar y eliminar información sobre los empleados (vendedores).
- **Relaciones entre Entidades**: Relación uno a muchos entre vendedores y ventas y relación muchos a muchos entre sucursales y vendedores.
- **Buscador**: Filtrado de ventas por vendedor.
- **Autenticación y Autorización**: Implementación de ASP.NET Identity para la autenticación de usuarios y autorización basada en roles (Administrador, Gerente, Encargado).
- **Inyección de Dependencias**: Uso de servicios inyectados para la gestión de datos.
- **Funcionalidad de Negocio**: Registro y gestión de ventas.
- **Interfaz de Usuario**: Uso de Bootstrap para una interfaz limpia y responsiva.

## Tecnologías Utilizadas

- **ASP.NET MVC**
- **Entity Framework con SQLite**
- **ASP.NET Identity**
- **Bootstrap**

## Requisitos del Sistema

- .NET Core SDK 7.0
- Visual Studio 2022 (o cualquier IDE compatible con .NET)
- SQL Lite (o cualquier base de datos compatible con Entity Framework Core)

## Instalación y Configuración

1. **Clonar el repositorio**:
    ```bash
    git clone https://github.com/BrendaSConde/Final.git
    ```
2. **Navegar al directorio del proyecto**:
    ```bash
    cd Final
    ```
3. **Restaurar paquetes NuGet**:
    ```bash
    dotnet restore
    ```
4. **Aplicar migraciones de la base de datos**:
    ```bash
    dotnet ef database update
    ```
5. **Compilar y ejecutar la aplicación**:
    ```bash
    dotnet run
    ```
    
## Uso

1. **Autenticación y Roles**:
    - Registrate e inicia sesión para acceder a las funcionalidades según el rol asignado (Administrador, Gerente, Encargado).
2. **Navegación**:
    - Utiliza el menú principal para navegar entre las vistas de gestión de sucursales, vendedores y ventas.
3. **Gestión de Ventas y Vendedores**:
    - Desde las vistas de ventas y vendedores, podes agregar nuevos registros, editar o eliminar existentes y utilizar el buscador para filtrar los resultados.


## Contribuciones

Las contribuciones son bienvenidas. Por favor, sigue los siguientes pasos:

1. Realiza un fork del proyecto.
2. Crea una nueva rama (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza los cambios necesarios y realiza commits (`git commit -am 'Agregar nueva funcionalidad'`).
4. Sube los cambios a tu fork (`git push origin feature/nueva-funcionalidad`).
5. Abre un Pull Request en el repositorio original.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT. Ver el archivo [LICENSE](LICENSE) para más detalles.

---

## Contacto

Para más información, puedes contactarte a mi mail [mokasalvatore@gmail.com](mailto:mokasalvatore@gmail.com) o a través de mi perfil de GitHub: [BrendaSConde](https://github.com/BrendaSConde).
