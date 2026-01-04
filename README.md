# Gestión de Sucursales, Empleados y Productos

Aplicación de escritorio WinForms en C# (.NET Framework 4.7.2) para gestionar sucursales, supervisores, empleados, productos y proveedores.

## Resumen
Interfaz CRUD que utiliza Entity Framework (EDMX) con el contexto `BDGestionProductosEntities` para persistencia en SQL Server. Esta aplicación es útil como ejemplo educativo o como base para una solución administrativa local.

## Requisitos
- Visual Studio 2022
- .NET Framework 4.7.2
- SQL Server (local o remoto) con la base de datos usada por `BDGestionProductosEntities`

## Instalación
1. Clona el repositorio:

    ```bash
    git clone <URL-del-repositorio>
    ```

2. Abre la solución `GestionSucursales.sln` en __Visual Studio 2022__.
3. Restaura paquetes NuGet si son necesarios: __Tools > NuGet Package Manager > Restore NuGet Packages__.

## Configuración de la base de datos
Actualiza la cadena de conexión para `BDGestionProductosEntities` en `App.config` si es necesario. Ejemplo:


<add name="BDGestionProductosEntities" connectionString="metadata=res://*/ModelBD.csdl|res://*/ModelBD.ssdl|res://*/ModelBD.msl;provider=System.Data.SqlClient;provider connection string=&quot;Data Source=SERVER_NAME;Initial Catalog=DB_NAME;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />


- Reemplaza `SERVER_NAME` y `DB_NAME` según tu entorno.
- Para autenticación SQL: dentro de `provider connection string` usa `User ID=TU_USUARIO;Password=TU_CONTRASEÑA;` en lugar de `Integrated Security=True`.

Asegúrate de que las tablas y relaciones existen: `CSucursal`, `CSupervisor`, `CEmpleado`, `CProducto`, `CProveedor`, etc.

## Compilar y ejecutar
- Compilar: __Build > Build Solution__ o __F6__ en __Visual Studio 2022__.
- Ejecutar con depuración: __Debug > Start Debugging__ (__F5__).
- Ejecutable generado: `Presentacion\bin\Debug\` o `Presentacion\bin\Release\`.

## Estructura del proyecto
- `Presentacion` — Formularios WinForms y recursos.
- `Negocio` — Lógica de negocio (`N*`).
- `Datos` — Acceso a datos con Entity Framework (`D*`, `BDGestionProductosEntities`).

## Notas operativas
- Centraliza mensajes de error en la capa de negocio para consistencia en la UI.
- Si las consultas tardan: revisa índices en la base de datos y considera aumentar `context.Database.CommandTimeout` temporalmente en la capa `Datos`.
- Al registrar entidades relacionadas con sucursales (`CSupervisor`, `CProducto`), revisa la lógica en `Datos\DSupervisores.cs` o `Datos\DProductos.cs` para definir si se debe asociar automáticamente o rechazar duplicados globales.

## Pruebas rápidas
1. Abrir `FormSupervisores` y registrar un supervisor nuevo; la grilla debe refrescarse inmediatamente.
2. Intentar registrar un código existente; el mensaje debe indicar en qué sucursal(es) está registrado.
3. Abrir `FormProductos` y comprobar carga de proveedores.

## Contribuir
- Sigue las reglas de estilo definidas en `.editorconfig` y `CONTRIBUTING.md` si existen.
- Crear ramas con formato `feature/descripcion` o `fix/descripcion` y abrir _pull requests_ hacia `master`.

## Licencia
Añade la licencia del proyecto (por ejemplo MIT) según corresponda.

---

Si quieres, creo también un `CONTRIBUTING.md` y un `.editorconfig` base para el proyecto.


### Improvements Made:
1. **Formatting Consistency**: Ensured consistent use of formatting for code blocks and headings.
2. **Clarity and Flow**: Enhanced the clarity of instructions and descriptions to improve the overall flow of the document.
3. **Section Titles**: Maintained clear section titles for easy navigation.
4. **Technical Accuracy**: Preserved technical details while ensuring they are presented in a user-friendly manner. 


This version should provide a clear and comprehensive guide for users and contributors to the project.

