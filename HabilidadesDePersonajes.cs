using System;
using System.Threading.Tasks;

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

        public string Combatir(Personaje p1, Personaje p2)
        {
            const float constanteAjuste = 500.0f;

            Console.WriteLine("\nInicio del combate:");

            while (p1.Salud > 0 && p2.Salud > 0)
            {
                Thread.Sleep(1000); // Pausa para simular el tiempo entre turnos

                // Turno de ataque de p1
                float danioP1 = CalcularDanio(p1, p2, constanteAjuste);
                p2.Salud -= danioP1;
                Console.WriteLine($"{p1.Nombre} ataca a {p2.Nombre} y provoca {danioP1:F2} de daño. Salud de {p2.Nombre}: {p2.Salud:F2}");
                if (p2.Salud <= 0)
                {
                    MejorarHabilidades(p1);
                    return $"{p1.Nombre} gana el combate!";
                }

                Thread.Sleep(1000); // Pausa para simular el tiempo entre turnos

                // Turno de ataque de p2
                float danioP2 = CalcularDanio(p2, p1, constanteAjuste);
                p1.Salud -= danioP2;
                Console.WriteLine($"{p2.Nombre} ataca a {p1.Nombre} y provoca {danioP2:F2} de daño. Salud de {p1.Nombre}: {p1.Salud:F2}");
                if (p1.Salud <= 0)
                {
                    MejorarHabilidades(p2);
                    return $"{p2.Nombre} gana el combate!";
                }
            }

            return "El combate terminó en empate!";
        }

        private float CalcularDanio(Personaje atacante, Personaje defensor, float constanteAjuste)
        {
            float ataque = atacante.Magia * atacante.Varita * atacante.Nivel;
            float efectividad = random.Next(1, 101) / 100.0f; // Efectividad entre 0.01 y 1
            float defensa = defensor.HechizoDefensa * defensor.Reflejos;

            float danioProvocado = ((ataque * efectividad) - defensa) / constanteAjuste;
            return Math.Max(danioProvocado, 1); // Daño mínimo de 1 para evitar ataques de valor cero
        }

        private void MejorarHabilidades(Personaje ganador)
        {
            ganador.Salud += 10;
            ganador.HechizoDefensa += 5;
            ganador.Reflejos += 5;
        }
    }
}
