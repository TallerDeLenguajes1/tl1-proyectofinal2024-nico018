using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace HarryPotterApp
{
    public static class LeerGanadores
    {
        // Método para leer la lista de personajes ganadores e información importante desde un archivo JSON
        public static List<Registro> Guardar(string nombreArchivo)
        {
            if (!File.Exists(nombreArchivo))
            {
                return new List<Registro>();
            }

            string json = File.ReadAllText(nombreArchivo);
            return JsonConvert.DeserializeObject<List<Registro>>(json);
        }

        // Método para verificar si un archivo existe y contiene los datos
        public static bool Existe(string nombreArchivo)
        {
            return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
        }
    }
}
