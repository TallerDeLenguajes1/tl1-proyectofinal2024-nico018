using System;

namespace HarryPotterApp
{
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
}
