using System;
using System.Collections.Generic;

// Definición de la clase base Persona (Abstracción)
class Persona
{
    public string Nombre { get; private set; } // Encapsulamiento
    public int Edad { get; private set; } // Encapsulamiento

    public Persona(string nombre, int edad)
    {
        Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
        Edad = edad;
    }

    // Método virtual que será sobrescrito en clases derivadas (Polimorfismo)
    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}");
    }
}

// Clase Empleado hereda de Persona (Herencia)
class Empleado : Persona
{
    public string Cargo { get; private set; } // Encapsulamiento
    private double salario; // Encapsulamiento

    public Empleado(string nombre, int edad, string cargo, double salario)
        : base(nombre, edad) // Llamada al constructor de la clase base
    {
        Cargo = cargo ?? throw new ArgumentNullException(nameof(cargo));
        this.salario = salario > 0 ? salario : throw new ArgumentOutOfRangeException(nameof(salario));
    }

    // Método para modificar el salario con control de acceso (Encapsulamiento)
    public void AsignarSalario(double cantidad)
    {
        if (cantidad > 0)
        {
            salario = cantidad;
        }
    }

    // Método para obtener el salario de forma controlada (Encapsulamiento)
    public double ObtenerSalario()
    {
        return salario;
    }

    // Sobreescritura del método MostrarInformacion (Polimorfismo)
    public override void MostrarInformacion()
    {
        Console.WriteLine($"Empleado: {Nombre}, Cargo: {Cargo}, Salario: {salario:C}");
    }
}

// Clase Gerente hereda de Empleado (Herencia y especialización)
class Gerente : Empleado
{
    public string Departamento { get; private set; } // Encapsulamiento

    public Gerente(string nombre, int edad, string cargo, double salario, string departamento)
        : base(nombre, edad, cargo, salario) // Llamada al constructor de la clase base
    {
        Departamento = departamento ?? throw new ArgumentNullException(nameof(departamento));
    }

    // Método específico de Gerente (Especialización de la clase derivada)
    public void TomarDecision()
    {
        Console.WriteLine($"{Nombre} está tomando una decisión en el departamento {Departamento}.");
    }
}

// Clase Empresa para gestionar una lista de empleados y gerentes
class Empresa
{
    private readonly List<Persona> personal; // Lista polimórfica para almacenar empleados y gerentes

    public Empresa()
    {
        personal = new List<Persona>();
    }

    // Método para agregar personas a la empresa (Encapsulamiento)
    public void AgregarPersona(Persona persona)
    {
        if (persona == null) throw new ArgumentNullException(nameof(persona));
        personal.Add(persona);
    }

    // Método para mostrar la información de todos los empleados (Polimorfismo)
    public void MostrarPersonal()
    {
        foreach (var persona in personal)
        {
            persona.MostrarInformacion(); // Llamada polimórfica
        }
    }
}

class Program
{
    static void Main()
    {
        Empresa miEmpresa = new Empresa();

        // Creación de instancias de Empleado y Gerente (Herencia y polimorfismo)
        Empleado desarrolladora = new Empleado("Ana", 30, "Desarrolladora", 4000);
        Gerente directorTI = new Gerente("Luis", 45, "Director TI", 8000, "Tecnología");

        // Agregar objetos a la lista de la empresa (Abstracción y Encapsulamiento)
        miEmpresa.AgregarPersona(desarrolladora);
        miEmpresa.AgregarPersona(directorTI);

        // Mostrar información de los empleados y gerentes (Polimorfismo)
        miEmpresa.MostrarPersonal();
        directorTI.TomarDecision();

        // Demostración de variables por valor y por referencia
        int a = 10;
        int b = a; // Copia el valor de 'a' en 'b'
        b = 20;
        Console.WriteLine(a); // 10, porque los valores son independientes

        // Demostración de referencia en objetos
        Empleado diseñador = new Empleado("Carlos", 32, "Diseñador", 3500);
        Empleado diseñadorReferencia = diseñador; // Ambos apuntan al mismo objeto en memoria
        diseñadorReferencia.AsignarSalario(5000);
        Console.WriteLine(diseñador.ObtenerSalario()); // 5000, porque es por referencia
    }
}

