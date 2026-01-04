# Gestión de Sucursales, Empleados y Productos

Aplicación de escritorio WinForms en C# (. NET Framework 4.7.2) para gestionar sucursales, supervisores, empleados, productos y proveedores con autenticación de usuarios.

## Resumen
Interfaz CRUD que utiliza Entity Framework 6 (EDMX) con el contexto `BDGestionProductosEntities` para persistencia en SQL Server. Esta aplicación implementa una arquitectura en capas y es útil como ejemplo educativo o base para sistemas de gestión empresarial.

## Características principales
- **Gestión de usuarios**: Sistema de inicio de sesión y registro de usuarios
- **Gestión de sucursales**:  CRUD completo para administrar sucursales
- **Gestión de supervisores**:  Registro y administración de supervisores por sucursal
- **Gestión de empleados**: Control de empleados vinculados a sucursales
- **Gestión de productos**: Administración de productos con proveedores asociados
- **Reportes**: Módulo de generación de reportes

## Requisitos
- Visual Studio 2022
- .NET Framework 4.7.2
- SQL Server (local o remoto)
- Entity Framework 6.0

## Instalación
1. Clona el repositorio: 
   ```bash
   git clone https://github.com/AngieB26/GestionSucursales.git
   ```

2. Abre la solución `TF_FSI_Grupo2.sln` en **Visual Studio 2022**.

3. Restaura paquetes NuGet:  **Tools > NuGet Package Manager > Manage NuGet Packages for Solution** y haz clic en **Restore**.

## Configuración de la base de datos

### Actualizar cadena de conexión
Edita el archivo `Presentacion/App.config` y actualiza la cadena de conexión `BDGestionProductosEntities`:

```xml
<connectionStrings>
  <add name="BDGestionProductosEntities" 
       connectionString="metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;
                        provider=System.Data.SqlClient;
                        provider connection string=&quot;data source=TU_SERVIDOR;
                        initial catalog=BDGestionProductos;
                        integrated security=True;
                        MultipleActiveResultSets=True;
                        App=EntityFramework&quot;" 
       providerName="System.Data.EntityFramework" />
</connectionStrings>
```

**Ajusta según tu entorno:**
- **Autenticación Windows**: `Integrated Security=True` (mantener como está)
- **Autenticación SQL Server**:  Reemplaza con `User ID=TU_USUARIO;Password=TU_CONTRASEÑA;Integrated Security=False`
- **Servidor**: Cambia `TU_SERVIDOR` por el nombre de tu instancia SQL Server (ej: `localhost`, `.\SQLEXPRESS`, etc.)

### Crear la base de datos
Asegúrate de tener creada la base de datos `BDGestionProductos` con las siguientes tablas:
- `CSucursal`
- `CSupervisor`
- `CEmpleado`
- `CProducto`
- `CProveedor`
- `CUsuario`

**Nota**: El modelo Entity Framework se encuentra en `Datos/Model1.edmx`.

## Compilar y ejecutar

### Compilar
- Presiona **F6** o ve a **Build > Build Solution**

### Ejecutar
- Presiona **F5** o ve a **Debug > Start Debugging**
- El formulario de inicio de sesión (`FormIniciarSesion`) se abrirá primero

### Ejecutable generado
El archivo `.exe` se encuentra en: 
- Debug:  `Presentacion\bin\Debug\Presentacion.exe`
- Release: `Presentacion\bin\Release\Presentacion. exe`

## Estructura del proyecto

```
GestionSucursales/
│
├── Presentacion/              # Capa de presentación (WinForms)
│   ├── FormIniciarSesion      # Formulario de login
│   ├── FormRegistrarse        # Formulario de registro
│   ├── FormPrincipal          # Formulario principal
│   ├── FormMenu               # Menú de navegación
│   ├── FormSucursales         # Gestión de sucursales
│   ├── FormSupervisores       # Gestión de supervisores
│   ├── FormEmpleados          # Gestión de empleados
│   ├── FormProductos          # Gestión de productos
│   ├── FormReportes           # Módulo de reportes
│   └── App.config             # Configuración de conexión
│
├── Negocio/                   # Capa de lógica de negocio
│   └── N*. cs                  # Clases de negocio (validaciones y reglas)
│
├── Datos/                     # Capa de acceso a datos
│   ├── Model1.edmx            # Modelo Entity Framework
│   ├── D*.cs                  # Clases de acceso a datos
│   ├── C*.cs                  # Clases de entidad generadas por EF
│   └── App. Config             # Configuración EF
│
└── TF_FSI_Grupo2.sln          # Archivo de solución
```

## Notas operativas

### Mejores prácticas
- La lógica de negocio está centralizada en la capa `Negocio` para mantener consistencia
- Los mensajes de error se gestionan centralmente para uniformidad en la UI
- Se utiliza el patrón de arquitectura en tres capas (Presentación, Negocio, Datos)

### Rendimiento
- Si las consultas tardan:  revisa índices en SQL Server
- Para consultas lentas temporalmente: aumenta `context.Database.CommandTimeout` en la capa Datos

### Relaciones de entidades
- Al registrar supervisores o productos, verifica la lógica en `Datos/DSupervisores.cs` y `Datos/DProductos.cs`
- Las relaciones con sucursales se asocian automáticamente según la lógica implementada

## Pruebas rápidas

1. **Autenticación**:
   - Ejecuta la aplicación y registra un nuevo usuario en `FormRegistrarse`
   - Inicia sesión con las credenciales creadas

2. **Gestión de sucursales**:
   - Abre `FormSucursales` desde el menú principal
   - Registra una nueva sucursal
   - La grilla debe refrescarse automáticamente

3. **Gestión de supervisores**:  
   - Abre `FormSupervisores`
   - Registra un supervisor asociado a una sucursal
   - Intenta registrar un código duplicado (debe mostrar mensaje de error indicando la sucursal)

4. **Gestión de productos**:
   - Abre `FormProductos`
   - Verifica que la lista de proveedores se cargue correctamente
   - Registra un nuevo producto con proveedor asociado

## Contribuir

### Estándares de código
- Mantén la arquitectura en tres capas
- Documenta métodos públicos con comentarios XML
- Usa nombres descriptivos en español para variables y métodos

### Flujo de trabajo Git
1. Crea una rama con formato `feature/descripcion` o `fix/descripcion`
2. Realiza tus cambios y commits descriptivos
3. Abre un Pull Request hacia `master`

## Licencia
Este proyecto se desarrolló con fines educativos. 

---

**Autor**: AngieB26  
**Repositorio**: [AngieB26/GestionSucursales](https://github.com/AngieB26/GestionSucursales)

