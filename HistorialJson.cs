using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace HarryPotterApp
{
    public static class RegistroJson
    {
        // Método para guardar el personaje ganador y la información importante
        public static void GuardarGanador(Personaje ganador, string informacion, string nombreArchivo)
        {
            List<Registro> historial;
            if (File.Exists(nombreArchivo))
            {
                historial = LeerGanadores(nombreArchivo);
            }
            else
            {
                historial = new List<Registro>();
            }

            Registro registro = new Registro
            {
                Nombre = ganador.Nombre,
                Informacion = informacion,
                Fecha = DateTime.Now
            };

            historial.Add(registro);
            string json = JsonConvert.SerializeObject(historial, Formatting.Indented);
            File.WriteAllText(nombreArchivo, json);
        }

        // Método para leer la lista de personajes ganadores e información importante desde un archivo JSON
        public static List<Registro> LeerGanadores(string nombreArchivo)
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

    // Clase para representar una registro en el historial
    public class Registro
    {
        public string Nombre { get; set; }
        public string Informacion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
