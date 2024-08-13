using System;

namespace HarryPotterApp
{
    public static class CrearPersonaje
    {
        public static Personaje Crear(string nombre)
        {
            Random random = new Random();
            return new Personaje
            {
                Nombre = nombre,
                Varita = random.Next(1, 11),
                Magia = random.Next(10, 50),
                Nivel = random.Next(1, 20),
                Efectividad = random.Next(10, 100),
                HechizoDefensa = random.Next(20, 50),
                Reflejos = random.Next(1, 11),
                Salud = 100,
            };
        }
    }
}

