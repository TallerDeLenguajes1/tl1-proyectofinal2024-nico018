namespace HarryPotterApp
{
    public static class CalcularAtaque
    {
        public static int Ataque(Personaje atacante, Personaje defensor)
        {
            // Fórmula de cálculo de daño
            int danio = atacante.Varita + atacante.Magia + atacante.Nivel;
            return danio > 0 ? danio : 0;
        }

        public static int Defensa(Personaje atacante, Personaje defensor)
        {
            // Fórmula de cálculo de daño
            int defensa = defensor.HechizoDefensa + defensor.Reflejos - defensor.Efectividad;
            return defensa > 0 ? defensa : 0;
        }
    }
}
