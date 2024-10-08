using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HarryPotterApp;


namespace HarryPotterApp
{ 
    class Program
    {
        static async Task Main(string[] args)
        {
            // Mostrar el arte ASCII inicial
            ArteASCII.MostrarArteInicial();

            // Solicitar nombre de usuario
            Console.Write("Por favor, ingrese su nombre de usuario: ");
            string nombreUsuario = Console.ReadLine();

            // Crear una instancia de HabilidadesDePersonajes
            HabilidadesDePersonajes habilidadesDePersonajes = new HabilidadesDePersonajes();
            List<Personaje> personajes = new List<Personaje>();

            // Cargar personajes desde JSON
            try
            {
                personajes = CargarPersonajes.Guardar("personajes.json");
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudo cargar el archivo JSON. Asegúrate de que el archivo exista.");
                return;
            }

            // Mostrar el menú de elección de personajes
            MenuPersonajes.MostrarMenuPersonajes(personajes);

            // Validar elección de personaje
            Personaje personaje1 = ValidarEleccion.Validar(personajes);
            personajes.Remove(personaje1);
            
            // Obtener y mostrar datos adicionales del personaje elegido
            Personaje personajeConDatosAdicionales = await ApiPersonaje.ObtenerPersonaje(personaje1.Nombre);
            if (personajeConDatosAdicionales != null)
            {
                personaje1 = personajeConDatosAdicionales; // Actualizar el personaje con datos de la API
            }

            Console.WriteLine($"Has elegido a: {personaje1.Nombre}");
            MostrarHabilidades.Mostrar(personaje1);
            

            // Realizar enfrentamientos sucesivos
            while (personajes.Count > 0)
            {
                
                Personaje contrincante = await ApiPersonaje.ObtenerPersonaje(personajes[0].Nombre);
                if (contrincante == null)
                {
                    contrincante = personajes[0]; // Usa datos del JSON si la API falla
                }

                personajes.RemoveAt(0);
                Console.WriteLine($"\n{personaje1.Nombre} se enfrentará a {contrincante.Nombre}");
                MostrarHabilidades.Mostrar(contrincante);

                // Mostrar arte ASCII antes del combate
                ArteASCII.MostrarArteCombate();

                // Realizar el combate
                string resultado = Combatir.RealizarCombate(personaje1, contrincante);
                Console.WriteLine(resultado);

                // Determinar el ganador
                personaje1 = personaje1.Salud > 0 ? personaje1 : contrincante;
                Console.WriteLine("\nHabilidades del personaje ganador después del combate:");
                MejorarHabilidades.Mejorar(personaje1);
                MostrarHabilidades.Mostrar(personaje1);

                
            }

            // Declarar el ganador final
            Console.WriteLine("\n¡El ganador final y merecedor del Caliz de Fuego es:");
            // Mostrar arte ASCII final
            ArteASCII.MostrarArteFinal();
            MostrarHabilidades.Mostrar(personaje1);
            Console.WriteLine($"{personaje1.Nombre}, ¡felicitaciones!");

            // Guardar el ganador en el historial
            string nombreArchivoHistorial = "historial_ganadores.json";
            string informacion = $"{nombreUsuario} eligió a {personaje1.Nombre} y ganó la competencia.";
            GuardarGanador.Guardar(personaje1, informacion, nombreArchivoHistorial);

            // Leer y mostrar el historial de ganadores
            if (LeerGanadores.Existe(nombreArchivoHistorial))
            {
                List<Registro> ganadores = LeerGanadores.Guardar(nombreArchivoHistorial);
                Console.WriteLine("\nHistorial de Ganadores:");
                foreach (var entry in ganadores)
                {
                    Console.WriteLine($"{entry.Fecha}: {entry.Nombre} - {entry.Informacion}");
                }
            }
        }


    }

    internal class HabilidadesDePersonajes
    {
    }
}
