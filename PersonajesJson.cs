using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace HarryPotterApp
{
    public static class PersonajesJson
    {
        public static void GuardarPersonajes(List<Personaje> personajes, string nombreArchivo)
        {
            string json = JsonConvert.SerializeObject(personajes, Formatting.Indented);
            File.WriteAllText(nombreArchivo, json);
        }

        public static List<Personaje> LeerPersonajes(string nombreArchivo)
        {
            string json = File.ReadAllText(nombreArchivo);
            return JsonConvert.DeserializeObject<List<Personaje>>(json);
        }

        public static bool Existe(string nombreArchivo)
        {
            return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
        }
    }
}
