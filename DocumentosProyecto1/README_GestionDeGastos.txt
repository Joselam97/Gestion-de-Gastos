
                                                                                                      GESTION DE GASTOS README



======================================================================================================
DESCRIPCIÓN GENERAL

Este proyecto es una aplicación de escritorio en C# con Windows Forms destinada a gestionar ingresos y egresos personales y grupales. Permite a los usuarios registrar gastos, crear grupos, calcular saldos netos, generar reportes y visualizar detalles financieros dentro de una interfaz amigable y sencilla.


==========================================
REQUISITOS DEL SISTEMA

- Sistema Operativo: Windows 10 o superior
- IDE: Visual Studio 2022 o superior
- .NET Framework 4.7.2 o superior
- Paquete Newtonsoft.Json (para manejo de archivos JSON)


==========================================
FUNCIONALIDADES PRINCIPALES


1. Registro de Usuarios:
   - Los usuarios pueden registrarse con nombre, correo, contraseña y avatar.
   - Solo se permite el acceso si el nombre, correo y contraseña coinciden exactamente.

2. Inicio de Sesión:
   - El usuario inicia sesión validando sus credenciales con los datos previamente registrados.

3. Grupos:
 - Los usuarios pueden crear nuevos grupos, asignandoles un nombre y seleccionando de una lista de usuarios registrados.

4. Gestión de Grupos:
   - Los usuarios pueden crear grupos, asignar usuarios, modificar integrantes y eliminar grupos. 

5. Ingresar Gastos:
   - Se pueden registrar gastos personales o grupales.
   - Cada gasto incluye: nombre, descripción, monto, fecha, grupo (opcional) y categoría.

6. Reporte de Gastos:
   - Visualiza gastos filtrados por tipo (personal o grupal), grupo específico y rango de fechas.
   - Muestra nombre, fecha, monto, descripción y categoría.
   - Calcula y muestra el total de gastos acumulados.

7. Cálculo de Saldo Neto:
   - Solicita presupuesto y compara contra los gastos realizados.
   - Permite filtrar por fechas y por grupo o gastos personales.
   - Genera un reporte visual detallado del resultado.


==========================================
DECISIONES DE DISEÑO

- Se optó por una arquitectura modular basada en MVC (Models, Views, Controllers).
- El almacenamiento de datos es mediante archivos JSON para facilitar la persistencia sin usar una base de datos.
- La interfaz está hecha con Windows Forms por simplicidad y rapidez de desarrollo.
- Se usa Newtonsoft.Json para serialización/deserialización.


==========================================
GUÍA DE USUARIO

1. Inicie la aplicación y registre un usuario.
2. Inicie sesión con los mismos datos.
3. Use la pantalla principal para:
   - Registrar nuevos gastos
   - Crear/modificar/eliminar grupos
   - Consultar reportes
   - Calcular saldos netos
4. Cierre sesión o cierre el programa para finalizar.


==========================================
ARCHIVOS IMPORTANTES

- usuarios.json: guarda los datos de usuarios registrados.
- gastos.json: contiene todos los gastos registrados.
- grupos.json: lista los grupos y sus miembros.


==========================================
AUTORES 

Desarrollado por Jose Luis Alvarez Morales como proyecto de Tecnicas de Programacion y para repositorio personal en Github.
