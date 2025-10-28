using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Resources; // NECESARIO para NeutralResourcesLanguage

// La información general de un ensamblado se controla mediante el siguiente 
// conjunto de atributos. Cambie estos valores de atributo para modificar la información
// asociada con un ensamblado.
[assembly: AssemblyTitle("Vista")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Vista")]
[assembly: AssemblyCopyright("Copyright © 2025")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// CORRECCIÓN: Esto establece el idioma por defecto (fallback) para los recursos.
// Si no encuentra el idioma específico, usará "es-AR". 
// Esto es CRÍTICO para resolver el MissingManifestResourceException si la cultura neutral falla.
[assembly: NeutralResourcesLanguage("es-AR")] // Se simplifica la línea

// Si establece ComVisible en false, los tipos de este ensamblado no estarán visibles 
// para los componentes COM.  Si es necesario obtener acceso a un tipo en este ensamblado desde 
// COM, establezca el atributo ComVisible en true en este tipo.
[assembly: ComVisible(false)]

// El siguiente GUID sirve como id. de typelib si este proyecto se expone a COM.
[assembly: Guid("0ec64e66-df46-4268-8765-664f47318a18")]

// La información de versión de un ensamblado consta de los cuatro valores siguientes:
//
//       Versión principal
//       Versión secundaria
//       Número de compilación
//       Revisión
//
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]