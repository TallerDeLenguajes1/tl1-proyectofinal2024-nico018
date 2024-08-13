using System;

namespace HarryPotterApp
{
    public static class DatosAdicionales
    {
        public static void MostrarDatosAdicionales(Personaje personaje)
        {
            Console.WriteLine("Casa: " + personaje.Casa);
            Console.WriteLine("Ascendencia: " + personaje.Ascendencia);
            Console.WriteLine("Fecha de Nacimiento: " + personaje.FechaNacimiento);
            Console.WriteLine("Patronus: " + personaje.Patronus);
        }
    }
}
