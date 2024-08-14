using System;
using System.Collections.Generic;

namespace HarryPotterApp
{
    public static class ValidarEleccion
    {
        public static Personaje Validar(List<Personaje> personajes){
          {
            int eleccion;
            while (true)
            {
                Console.Write("Seleccione un número para elegir su personaje: ");
                if (int.TryParse(Console.ReadLine(), out eleccion) && eleccion > 0 && eleccion <= personajes.Count)
                {
                    return personajes[eleccion - 1];
                }
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido.");
            }

            }
          }
        }

}