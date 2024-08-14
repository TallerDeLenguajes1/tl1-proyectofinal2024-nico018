using System;
using System.Collections.Generic;

namespace HarryPotterApp
{
    public static class MostrarHabilidades
    {
        public static void Mostrar(Personaje personaje){
          {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Personaje: " + personaje.Nombre);
            Console.WriteLine("Varita: " + personaje.Varita);
            Console.WriteLine("Magia: " + personaje.Magia);
            Console.WriteLine("Nivel: " + personaje.Nivel);
            Console.WriteLine("Efectividad: " + personaje.Efectividad);
            Console.WriteLine("Hechizo de defensa: " + personaje.HechizoDefensa);
            Console.WriteLine("Reflejos: " + personaje.Reflejos);
            Console.WriteLine("Salud: " + personaje.Salud);
            Console.WriteLine("\n");

            // Mostrar datos adicionales
            Console.WriteLine("Casa: " + personaje.Casa);
            Console.WriteLine("Ascendencia: " + personaje.Ascendencia);
            Console.WriteLine("Fecha de Nacimiento: " + personaje.FechaNacimiento);
            Console.WriteLine("Patronus: " + personaje.Patronus);
            Console.WriteLine("--------------------------------");

            }
          }
        }

}