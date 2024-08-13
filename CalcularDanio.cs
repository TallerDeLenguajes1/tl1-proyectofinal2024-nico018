namespace HarryPotterApp
{
    public static class CalcularDanio
    {
        public static int Calcular(Personaje atacante, Personaje defensor)
        {
            // Fórmula de cálculo de daño
            int danio = atacante.Efectividad + atacante.Magia - defensor.HechizoDefensa - defensor.Reflejos;
            return danio > 0 ? danio : 0;
        }
    }
}
