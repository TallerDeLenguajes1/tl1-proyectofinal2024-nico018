using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace HarryPotterApp
{
    public static class GuardarGanador
    {
        // Método para guardar el personaje ganador y la información importante
        public static void Guardar(Personaje ganador, string informacion, string nombreArchivo)
        {
            List<Registro> historial;
            if (File.Exists(nombreArchivo))
            {
                historial = LeerGanadores.Guardar(nombreArchivo);
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
    }
}
