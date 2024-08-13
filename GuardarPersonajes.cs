using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace HarryPotterApp
{
    public static class GuardarPersonajes
    {
        public static void Ejecutar(List<Personaje> personajes, string nombreArchivo)
        {
            string jsonData = JsonConvert.SerializeObject(personajes, Formatting.Indented);
            File.WriteAllText(nombreArchivo, jsonData);
        }
    }
}
