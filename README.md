
# 🛡️ TP Sistema de Gestión de Usuarios

Este repositorio contiene el proyecto del grupo de trabajo conformado por: **Damian Perez, Lautaro Logarzo, Alan Prieto, Lucas Gianturco y Arnaldo Vallejos** para la materia de algoritmos III del [Instituto superior de formación técnica N° 172, Alan Turing](https://isft172.edu.ar/). Es una aplicación desarrollada con fines académicos, orientada a la gestión de usuarios. Está desarrollado bajo el paradigma de **Programación Orientada a Objetos (POO)**, utilizando una arquitectura **N-Capas** que incluye: Vista, Lógica, Datos, Sesión, Servicios. La base de datos del sistema está construida en **SQL Server**, garantizando una gestión robusta de la información.

---

## 🧩 Características principales

### 🔐 Seguridad de acceso

- **Login con contraseña encriptada (SHA256)**.
- **Primera contraseña generada aleatoriamente**, obligando al usuario a cambiarla al ingresar por primera vez.
- **Preguntas de seguridad** obligatorias configurables al crear el usuario.
- **Recuperación de contraseña** mediante preguntas de seguridad y envío de una nueva contraseña temporal al correo registrado.
- **Políticas de seguridad configurables**:
  - Longitud mínima de la contraseña
  - Combinación de mayúsculas, minúsculas, números y caracteres especiales
  - Autenticación en dos pasos (2FA) vía correo electrónico
  - No permitir contraseñas repetidas
  - Verificación de que la contraseña no contenga datos personales
  - Cambios obligatorios cada X días

### 👤 Gestión de usuarios

- Formulario para **alta, baja y modificación de usuarios** (solo administradores).
- **Cambio de contraseña y preguntas de seguridad** para usuarios generales.
- Asignación de **roles y permisos** personalizados, agrupados por sector.

---

## 🏗️ Arquitectura

El sistema está dividido en capas bien definidas:

- **Capa Vista**: Interfaz gráfica del usuario
- **Capa Lógica**: Procesamiento de reglas del negocio
- **Capa Datos**: Acceso y persistencia en base de datos
- **Capa Sesión**: Control de la sesión del usuario
- **Capa Servicios**: Utilidades y operaciones auxiliares

---

## 🛠️ Tecnologías utilizadas

- **Lenguaje:** C# (.NET Framework)
- **Base de datos:** SQL Server
- **Criptografía:** SHA256
- **Metodología:** Scrum

---

## ✍️ Miembros del equipo

- *Arnaldo Vallejos* 
- *Damian Perez*
- *Alan Prieto* 
- *Lautaro Logarzo* 
- *Lucas Gianturco* 

