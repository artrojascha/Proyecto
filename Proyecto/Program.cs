// En la opción de "Incluir Estudiantes" debe leer por teclado lo siguiente: cedula, nombre, promedio y condición del estudiante

// Creamos una clase estudiante con las 4 variables anteriores, la parametrizamos con get y set: https://www.youtube.com/watch?v=8FmE_-QXg3Y

using System.Runtime.ConstrainedExecution;
using static System.Net.WebRequestMethods;

class Estudiantes
{
    public string Cedula { get; set; } //esta es la propiedad (Cedula) y va en mayuscula, la propiedad combina aspecto de campo y metodo (comparte el nombre del campo)
    public string Nombre { get; set; }
    public float Promedio { get; set; }
    public string Condicion_Estudiante { get; set; }

    //Vamos a darle valores:
    public Estudiantes (string cedula, string nombre, float promedio)//Condicion_Estudiante no se coloca por que es un mensaje que depende de condiciones, con lo que, lo haremos con una funcion o metodo
    {
        Cedula = cedula;
        Nombre = nombre;
        Promedio = promedio;
        CondicionEstudiante();
    }
    // Hacemos una funcion o metodo: https://www.youtube.com/watch?v=jt6XLUB6_l8
    private void CondicionEstudiante () 
    
        // si el promedio es mayor o igual a 70 la condición es APROBADO; si el promedio es menor a 70 y mayor o igual a 60 la condición es REPROBADO; si el promedio es menor a 60 condición es REPROBADO.
    {
        if (Promedio >= 70)
            Condicion_Estudiante = "APROBADO";
        else if (Promedio >= 60)
            Condicion_Estudiante = "REPROBADO";
        else
            Condicion_Estudiante = "REPROBADO";
    }
    public override string ToString() //para imprimir https://www.youtube.com/shorts/g0HkGDat5XI
    {
        return $"{Cedula} {Nombre} {Promedio} {Condicion_Estudiante}";
    }
}

//1.Hacer un programa con vectores de 10 posiciones
class Programa
{
    static Estudiantes[] estudiantes =new Estudiantes[10];// inicializacion
    static int cantidad_estudiantes_incluidos = 0; //se va a requerir contar los ingresados para limitarlo
    static void Main(string[] args) //Punto de entrada de la aplicacion https://learn.microsoft.com/es-es/dotnet/csharp/fundamentals/program-structure/main-command-line
    {
        int seleccion;
        do
        {
            Console.WriteLine("==============================");
            Console.WriteLine("             Menú             ");
            Console.WriteLine("==============================");
            Console.WriteLine("1. Inicializar Vectores       ");
            Console.WriteLine("2. Incluir Estudiantes        ");
            Console.WriteLine("3. Consultar Estudiantes      ");
            Console.WriteLine("4. Modificar Estudiantes      ");
            Console.WriteLine("5. Eliminar Estudiantes       ");
            Console.WriteLine("6. Submenú Reportes           ");
            Console.WriteLine("7. Salir                      ");
            Console.WriteLine("Realice su selección marcando el número de 1 a 7");
            seleccion=int.Parse(Console.ReadLine());

            switch(seleccion) //casos: https://www.w3schools.com/cs/cs_switch.php
            {
                case 1://Inicializar vectores, usamos una funcion o metodo
                    Inicializar_Vectores();
                    break;
                case 2://Incluir Estudiantes
                    Incluir_Estudiantes();
                    break;
                case 3:
                    Consultar_Estudiante();
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    Console.WriteLine("Ha salido");
                    break;
            }

        }while (seleccion!=7);
    }

    static void Inicializar_Vectores()// 1. Inicializar vectores: utilizamos lo visto en la revision de la tarea del companero con un new, ademas de reiniciar la cantidad de estudiantes 
    {
        estudiantes = new Estudiantes[10];
        cantidad_estudiantes_incluidos = 0;
        Console.WriteLine("Se ha inicializado el vector");
    }
    static void Incluir_Estudiantes() //2. Incluir estudiantes
    {
        if (cantidad_estudiantes_incluidos < 10)//Se revisa que no se haya alcanzado el maximo para este ejercicio
        {
            // Se solicitan los insumos para lo solicitado en el proyecto: Cedula, Nombre, Promedio
            Console.WriteLine("Digite la cédula del estudiante: ");
            string cedula=Console.ReadLine();
            Console.WriteLine("Digite el nombre del estudiante: ");
            string nombre=Console.ReadLine();
            Console.WriteLine("Digite el promedio del estudiante: ");
            float promedio=float.Parse(Console.ReadLine());

            estudiantes[cantidad_estudiantes_incluidos]=new Estudiantes(cedula, nombre, promedio);//borrará los datos cada vez que se trata de ingresar?
            cantidad_estudiantes_incluidos++;
            Console.WriteLine("Se ha incluido el estudiante");
        }
        else 
        {
            Console.WriteLine("No es posible ingresar más de 10 estudiantes");
        }
    }

    static void Consultar_Estudiante()//3.Consultar Estudiantes con la cedula
    {
        Console.Write("Ingrese la cédula del estudiante a consultar: ");
        string cedula = Console.ReadLine();
        bool encontrado = false;

        for (int i = 0; i < estudiantes.Length; i++)
        {
            var estudiante = estudiantes[i];
            if (estudiante != null && estudiante.Cedula == cedula)
            {
                MostrarEstudiante(estudiante);
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
                Console.WriteLine("Estudiante no encontrado.");
        }
    static void MostrarEstudiante(Estudiantes estudiante)// Cambiar el formato para que se haga como indica el documento del proyecto
    {
        Console.WriteLine("Estudiante encontrado:");
        Console.WriteLine($"Cédula: {estudiante.Cedula}");
        Console.WriteLine($"Nombre: {estudiante.Nombre}");
        Console.WriteLine($"Promedio: {estudiante.Promedio}");
        Console.WriteLine($"Condición: {estudiante.Condicion_Estudiante}");
    }
}










