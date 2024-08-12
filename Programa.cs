using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HarryPotterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Solicitar nombre de usuario
            Console.Write("Por favor, ingrese su nombre de usuario: ");
            string nombreUsuario = Console.ReadLine();

            // Crear una instancia de HabilidadesDePersonajes
            HabilidadesDePersonajes habilidadesDePersonajes = new HabilidadesDePersonajes();
            List<Personaje> personajes = new List<Personaje>();

            // Cargar personajes desde JSON
            try
            {
                personajes = PersonajesJson.CargarPersonajes("personajes.json");
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo cargar el archivo JSON. Asegúrate de que el archivo exista.");
                return;
            }

            // Mostrar el menú de elección de personajes
            MostrarMenuPersonajes(personajes);

            // Validar elección de personaje
            Personaje personaje1 = ValidarEleccion(personajes);
            personajes.Remove(personaje1);

            Console.WriteLine($"Has elegido a: {personaje1.Nombre}");
            MostrarHabilidades(personaje1);

            // Realizar enfrentamientos sucesivos
            while (personajes.Count > 0)
            {
                Personaje contrincante = personajes[0];
                personajes.RemoveAt(0);
                Console.WriteLine($"\n{personaje1.Nombre} se enfrentará a {contrincante.Nombre}");
                MostrarHabilidades(contrincante);

                // Realizar el combate
                string resultado = habilidadesDePersonajes.Combatir(personaje1, contrincante);
                Console.WriteLine(resultado);

                // Determinar el ganador
                personaje1 = personaje1.Salud > 0 ? personaje1 : contrincante;
                Console.WriteLine("\nHabilidades del personaje ganador después del combate:");
                MostrarHabilidades(personaje1);
            }

            // Declarar el ganador final
            Console.WriteLine("\n¡El ganador final y merecedor del Caliz de Fuego es:");
            MostrarHabilidades(personaje1);
            Console.WriteLine($"{personaje1.Nombre}, ¡felicitaciones!");

            // Guardar el ganador en el historial
            string nombreArchivoHistorial = "historial_ganadores.json";
            string informacion = $"{nombreUsuario} eligió a {personaje1.Nombre} y ganó la competencia.";
            RegistroJson.GuardarGanador(personaje1, informacion, nombreArchivoHistorial);

            // Leer y mostrar el historial de ganadores
            if (RegistroJson.Existe(nombreArchivoHistorial))
            {
                List<Registro> ganadores = RegistroJson.LeerGanadores(nombreArchivoHistorial);
                Console.WriteLine("\nHistorial de Ganadores:");
                foreach (var entry in ganadores)
                {
                    Console.WriteLine($"{entry.Fecha}: {entry.Nombre} - {entry.Informacion}");
                }
            }
        }

        static void MostrarMenuPersonajes(List<Personaje> personajes)
        {
            Console.WriteLine("****************************");
            Console.WriteLine("*  MENÚ DE ELECCIÓN DE PERSONAJE  *");
            Console.WriteLine("****************************");
            for (int i = 0; i < personajes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {personajes[i].Nombre}");
            }
            Console.WriteLine("****************************");
        }

        static Personaje ValidarEleccion(List<Personaje> personajes)
        {
            int eleccion;
            while (true)
            {
                Console.Write("Seleccione un número para elegir su personaje: ");
                if (int.TryParse(Console.ReadLine(), out eleccion) && eleccion > 0 && eleccion <= personajes.Count)
                {
                    return personajes[eleccion - 1];
                }
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido.");
            }
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
    }
}
