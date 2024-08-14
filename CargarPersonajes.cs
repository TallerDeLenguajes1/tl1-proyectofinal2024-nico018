using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace HarryPotterApp
{
    public static class CargarPersonajes
    {
        public static List<Personaje> Guardar(string nombreArchivo)
        {
            if (!File.Exists(nombreArchivo))
            {
                throw new FileNotFoundException("El archivo JSON no existe.");
            }

            string jsonData = File.ReadAllText(nombreArchivo);
            return JsonConvert.DeserializeObject<List<Personaje>>(jsonData);
        }
    }
}
