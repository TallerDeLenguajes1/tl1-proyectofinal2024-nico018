using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace HarryPotterApp
{
    public static class PersonajesJson
    {
        public static List<Personaje> CargarPersonajes(string nombreArchivo)
        {
            if (!File.Exists(nombreArchivo))
            {
                throw new FileNotFoundException("El archivo JSON no existe.");
            }

            string jsonData = File.ReadAllText(nombreArchivo);
            return JsonConvert.DeserializeObject<List<Personaje>>(jsonData);
        }

        public static void GuardarPersonajes(List<Personaje> personajes, string nombreArchivo)
        {
            string jsonData = JsonConvert.SerializeObject(personajes, Formatting.Indented);
            File.WriteAllText(nombreArchivo, jsonData);
        }
    }
}
