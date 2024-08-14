using System;
using System.Collections.Generic;

namespace HarryPotterApp
{
    public static class MenuPersonajes
    {
        public static void MostrarMenuPersonajes(List<Personaje> personajes){

        
        
            Console.WriteLine("\n");
            Console.WriteLine(" *********************************");
            Console.WriteLine(" * MENÚ DE ELECCIÓN DE PERSONAJE *");
            Console.WriteLine(" *********************************");
            for (int i = 0; i < personajes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {personajes[i].Nombre}");
            }
            Console.WriteLine(" ***********************************");
            Console.WriteLine("\n");
        

        {
          

          }
        

        }
        

        }

        }