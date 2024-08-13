namespace HarryPotterApp
{
    public static class Combatir
    {
        public static string RealizarCombate(Personaje personaje1, Personaje contrincante)
        {
            // Calcular daño basado en la magia, efectividad y reflejos
            int danioPersonaje1 = CalcularDanio.Calcular(personaje1, contrincante);
            int danioContrincante = CalcularDanio.Calcular(contrincante, personaje1);

            // Turno del personaje 1 atacando
            Console.WriteLine($"{personaje1.Nombre} ataca a {contrincante.Nombre}!");
            Console.WriteLine($"{contrincante.Nombre} recibe {danioPersonaje1} puntos de daño.");
            contrincante.Salud -= danioPersonaje1;
            Console.WriteLine($"{contrincante.Nombre} tiene ahora {contrincante.Salud} puntos de salud.\n");

            // Verificar si el contrincante ha sido derrotado
            if (contrincante.Salud <= 0)
            {
                return $"{personaje1.Nombre} ha ganado el combate!";
            }

            // Turno del contrincante atacando
            Console.WriteLine($"{contrincante.Nombre} contraataca a {personaje1.Nombre}!");
            Console.WriteLine($"{personaje1.Nombre} recibe {danioContrincante} puntos de daño.");
            personaje1.Salud -= danioContrincante;
            Console.WriteLine($"{personaje1.Nombre} tiene ahora {personaje1.Salud} puntos de salud.\n");

            // Verificar si el personaje1 ha sido derrotado
            if (personaje1.Salud <= 0)
            {
                return $"{contrincante.Nombre} ha ganado el combate!";
            }

            // Si ninguno ha sido derrotado, el combate continúa
            return "Ambos personajes siguen en pie. El combate continúa!";
        }
    }
}
