using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using PM02API.Models;

namespace PM02API.Controllers
{
    public class ControllerPlace
    {
      
        public async static Task<List<Models.Posts>> GetPosts()
        {
            List<Models.Posts> posts = new List<Models.Posts>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage? responseMessage = null;
                    responseMessage = await client.GetAsync(Config.ConfigProcess.endpointPosts);

                    if (responseMessage != null)
                    {
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            var result = responseMessage.Content.ReadAsStringAsync().Result;
                            posts = JsonConvert.DeserializeObject<List<Models.Posts>>(result);
                        }
                    }
                }

                return posts;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async static Task<List<Models.Posts>> BuscarNombreApi(string subregion)
        {
            List<Models.Posts> posts = new List<Models.Posts>();

            try
            {

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage responseMessage = await client.GetAsync($"https://restcountries.com/v3.1/region/{subregion}");

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var result = responseMessage.Content.ReadAsStringAsync().Result;
                        posts = JsonConvert.DeserializeObject<List<Models.Posts>>(result);
                    }
                }

                return posts;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error al buscar países por subregión: {ex.Message}");
                return null;
            }
        }

    }
}
