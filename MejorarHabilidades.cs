namespace HarryPotterApp
{
    public static class MejorarHabilidades
    {
        public static void Mejorar(Personaje personaje)
        {
            // Mejora de habilidades después del combate
            personaje.Magia += 5;
            personaje.Nivel += 1;
            personaje.Efectividad += 3;
            personaje.HechizoDefensa += 2;
            personaje.Reflejos += 4;
            personaje.Salud += 20;
        }
    }
}
