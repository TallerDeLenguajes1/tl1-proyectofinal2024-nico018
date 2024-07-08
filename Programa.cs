using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

class Program
{
    static async Task Main(string[] args)
    {
        // Solicitar nombre de usuario
        Console.Write("Por favor, ingrese su nombre de usuario: ");
        string nombreUsuario = Console.ReadLine();

        // Mostrar menú de personajes
        Console.WriteLine("Elija un personaje:");
        Console.WriteLine("1. Harry Potter");
        Console.WriteLine("2. Hermione Granger");
        Console.WriteLine("3. Ron Weasley");
        Console.WriteLine("4. Severus Snape");

        // Leer la elección del usuario
        int eleccion = Convert.ToInt32(Console.ReadLine());
        string personajeElegido = "";
        string[] personajes = { "Harry Potter", "Hermione Granger", "Ron Weasley", "Severus Snape" };

        // Asignar el personaje elegido según la opción seleccionada
        if (eleccion >= 1 && eleccion <= 4)
        {
            personajeElegido = personajes[eleccion - 1];
        }
        else
        {
            Console.WriteLine("Opción no válida");
            return;
        }

        // Crear una instancia de HabilidadesDePersonajes
        HabilidadesDePersonajes habilidadesDePersonajes = new HabilidadesDePersonajes();

        // Obtener y mostrar las habilidades del personaje elegido
        Personaje personaje = habilidadesDePersonajes.CrearPersonaje(personajeElegido);
        Console.WriteLine("\nHas elegido a: " + personaje.Nombre);
        MostrarHabilidades(personaje);

        // Mostrar las habilidades de los personajes no elegidos
        Console.WriteLine("\nHabilidades de los personajes no elegidos:");
        for (int i = 0; i < personajes.Length; i++)
        {
            if (i != eleccion - 1)
            {
                Personaje personajeNoElegido = habilidadesDePersonajes.CrearPersonaje(personajes[i]);
                MostrarHabilidades(personajeNoElegido);
            }
        }

        // Obtener y mostrar los datos adicionales del personaje elegido desde la API
        await MostrarDatosAdicionales(personajeElegido);
    }

    static void MostrarHabilidades(Personaje personaje)
    {
        Console.WriteLine("\nPersonaje: " + personaje.Nombre);
        Console.WriteLine("Varita: " + personaje.Varita);
        Console.WriteLine("Magia: " + personaje.Magia);
        Console.WriteLine("Nivel: " + personaje.Nivel);
        Console.WriteLine("Efectividad: " + personaje.Efectividad);
        Console.WriteLine("Hechizo de defensa: " + personaje.HechizoDefensa);
        Console.WriteLine("Reflejos: " + personaje.Reflejos);
        Console.WriteLine("Salud: " + personaje.Salud);
    }

    static async Task MostrarDatosAdicionales(string nombre)
    {
        using (HttpClient client = new HttpClient())
        {
            string url = "https://hp-api.onrender.com/api/characters";
            string json = await client.GetStringAsync(url);
            JArray personajes = JArray.Parse(json);

            var personaje = personajes.FirstOrDefault(p => (string)p["name"] == nombre);
            if (personaje != null)
            {
                Console.WriteLine("\nDatos adicionales del personaje elegido:");
                Console.WriteLine("Nombre: " + personaje["name"]);
                Console.WriteLine("Casa: " + personaje["house"]);
                Console.WriteLine("Fecha de nacimiento: " + personaje["dateOfBirth"]);
                Console.WriteLine("Ascendencia: " + personaje["ancestry"]);
                Console.WriteLine("Patronus: " + personaje["patronus"]);
            }
            else
            {
                Console.WriteLine("No se encontraron datos adicionales para el personaje seleccionado.");
            }
        }
    }
}

public class HabilidadesDePersonajes
{
    private Random random = new Random();

    public Personaje CrearPersonaje(string nombre)
    {
        return new Personaje
        {
            Nombre = nombre,
            Varita = random.Next(1, 11),
            Magia = random.Next(50, 101),
            Nivel = random.Next(1, 101),
            Efectividad = random.Next(1, 101),
            HechizoDefensa = random.Next(50, 101),
            Reflejos = random.Next(20, 51),
            Salud = 100.0f
        };
    }
}

public class Personaje
{
    public string Nombre { get; set; }
    public int Varita { get; set; }
    public int Magia { get; set; }
    public int Nivel { get; set; }
    public int Efectividad { get; set; }
    public int HechizoDefensa { get; set; }
    public int Reflejos { get; set; }
    public float Salud { get; set; }
}
