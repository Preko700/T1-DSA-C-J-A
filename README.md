# Sistema de Gestión de Empleados en C#

## Descripción
Este proyecto es una aplicación de consola en C# que implementa los principios fundamentales de la **Programación Orientada a Objetos (POO)**. La aplicación permite gestionar empleados y gerentes dentro de una empresa, aplicando conceptos como **abstracción, encapsulamiento, herencia y polimorfismo**.

## Características
- Definición de una clase base `Persona`.
- Implementación de `Empleado` y `Gerente` mediante **herencia**.
- Uso de **polimorfismo** con el método `MostrarInformacion()`.
- **Encapsulamiento** en atributos con `private set` y métodos controlados.
- Manejo de variables por **valor y referencia**.

## Tecnologías Utilizadas
- Lenguaje: **C#**
- Framework: **.NET**

## Instalación y Uso
1. Clona el repositorio:
   ```bash
   git clone https://github.com/tu-usuario/sistema-gestion-empleados.git
   ```
2. Abre el proyecto en Visual Studio.
3. Compila y ejecuta el programa.

## Código de Ejemplo
```csharp
static void Main() {
    Empresa miEmpresa = new Empresa();
    Empleado desarrolladora = new Empleado("Ana", 30, "Desarrolladora", 4000);
    Gerente directorTI = new Gerente("Luis", 45, "Director TI", 8000, "Tecnología");
    miEmpresa.AgregarPersona(desarrolladora);
    miEmpresa.AgregarPersona(directorTI);
    miEmpresa.MostrarPersonal();
    directorTI.TomarDecision();
}
```

## Contribuciones
Las contribuciones son bienvenidas. Para colaborar:
1. Haz un **fork** del repositorio.
2. Crea una nueva rama (`git checkout -b feature-nueva`).
3. Realiza tus cambios y haz **commit** (`git commit -m "Descripción del cambio"`).
4. Envía un **pull request**.

## Licencia
Este proyecto está bajo la licencia Apache License 2.0.

