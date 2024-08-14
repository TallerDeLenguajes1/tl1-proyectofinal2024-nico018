namespace HarryPotterApp
{
    public static class Combatir
    {
        public static string RealizarCombate(Personaje personaje1, Personaje contrincante)
        {
            // Calcular daño basado en la magia, efectividad y reflejos
            int AtaquePersonaje1 = CalcularAtaque.Ataque(personaje1, contrincante);
            // Calcular defensa basado efectividad y reflejos
            int DefensaContrincante = CalcularAtaque.Defensa(contrincante, personaje1);

            // Turno del personaje 1 atacando
            Console.WriteLine($"{personaje1.Nombre} ataca a {contrincante.Nombre}!");
            Console.WriteLine($"{contrincante.Nombre} recibe {AtaquePersonaje1} puntos de daño.");
            contrincante.Salud -= AtaquePersonaje1;
            Console.WriteLine($"{contrincante.Nombre} tiene ahora {contrincante.Salud} puntos de salud.\n");

            // Verificar si el contrincante ha sido derrotado
            if (contrincante.Salud <= 0)
            {
                return $"{personaje1.Nombre} ha ganado el combate!";
            }

            // Turno del contrincante atacando
            Console.WriteLine($"{contrincante.Nombre} contraataca a {personaje1.Nombre}!");
            Console.WriteLine($"{personaje1.Nombre} recibe {DefensaContrincante} puntos de daño.");
            personaje1.Salud -= DefensaContrincante;
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
