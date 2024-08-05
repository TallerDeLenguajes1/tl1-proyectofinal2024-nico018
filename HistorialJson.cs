using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace HarryPotterApp
{
    public static class HistorialJson
    {
        // Método para guardar el personaje ganador y la información relevante
        public static void GuardarGanador(Personaje ganador, string informacion, string nombreArchivo)
        {
            List<HistorialEntry> historial;
            if (File.Exists(nombreArchivo))
            {
                historial = LeerGanadores(nombreArchivo);
            }
            else
            {
                historial = new List<HistorialEntry>();
            }

            HistorialEntry entry = new HistorialEntry
            {
                Nombre = ganador.Nombre,
                Informacion = informacion,
                Fecha = DateTime.Now
            };

            historial.Add(entry);
            string json = JsonConvert.SerializeObject(historial, Formatting.Indented);
            File.WriteAllText(nombreArchivo, json);
        }

        // Método para leer la lista de personajes ganadores e información relevante desde un archivo JSON
        public static List<HistorialEntry> LeerGanadores(string nombreArchivo)
        {
            if (!File.Exists(nombreArchivo))
            {
                return new List<HistorialEntry>();
            }

            string json = File.ReadAllText(nombreArchivo);
            return JsonConvert.DeserializeObject<List<HistorialEntry>>(json);
        }

        // Método para verificar si un archivo existe y contiene datos
        public static bool Existe(string nombreArchivo)
        {
            return File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0;
        }
    }

    // Clase para representar una entrada en el historial
    public class HistorialEntry
    {
        public string Nombre { get; set; }
        public string Informacion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
