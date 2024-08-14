using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace HarryPotterApp
{
    public class ApiPersonaje
    {
        private static readonly string urlApi = "https://hp-api.onrender.com/api/characters"; // URL de la API

        public static async Task<Personaje> ObtenerPersonaje(string nombre)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Solicitar datos a la API
                    HttpResponseMessage response = await client.GetAsync(urlApi);
                    response.EnsureSuccessStatusCode();

                    // Leer y parsear la respuesta
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JArray personajesArray = JArray.Parse(responseBody);

                    // Buscar el personaje por nombre
                    foreach (var item in personajesArray)
                    {
                        if (item["name"].ToString().Equals(nombre, StringComparison.OrdinalIgnoreCase))
                        {
                            // Crear y devolver el personaje con la información obtenida
                            return new Personaje
                            {   // Valores predeterminados si no se encuentran
                                Nombre = item["name"].ToString(),
                                Magia = 50, 
                                Nivel = 1,  
                                Efectividad = 70, 
                                Reflejos = 60, 
                                Salud = 100, 
                                Casa = item["house"]?.ToString() ?? "Desconocida",
                                Ascendencia = item["ancestry"]?.ToString() ?? "Desconocida",
                                FechaNacimiento = item["dateOfBirth"]?.ToString() ?? "Desconocida",
                                Patronus = item["patronus"]?.ToString() ?? "Desconocido"
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al obtener datos de la API: {ex.Message}");
                }
            }

            // Retornar null si no se encontró el personaje o si hubo un error
            return null;
        }
    }
}
