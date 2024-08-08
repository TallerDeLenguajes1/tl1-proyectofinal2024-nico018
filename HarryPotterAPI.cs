using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace HarryPotterApp
{
    public class HarryPotterAPI
    {
        public async Task<DatosAdicionales> ObtenerDatosPersonaje(string nombre)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://hp-api.onrender.com/api/characters";
                string json = await client.GetStringAsync(url);
                JArray personajes = JArray.Parse(json);

                var personaje = personajes.FirstOrDefault(p => (string)p["name"] == nombre);
                if (personaje != null)
                {
                    return new DatosAdicionales
                    {
                        Casa = (string)personaje["house"],
                        FechaDeNacimiento = (string)personaje["dateOfBirth"],
                        Ascendencia = (string)personaje["ancestry"],
                        Patronus = (string)personaje["patronus"]
                    };
                }
            }
            return null;
        }
    }

    public class DatosAdicionales
    {
        public string Casa { get; set; }
        public string FechaDeNacimiento { get; set; }
        public string Ascendencia { get; set; }
        public string Patronus { get; set; }
    }
}
