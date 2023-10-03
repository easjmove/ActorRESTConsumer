using ActorRepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ActorRESTConsumer
{
    public class ActorWorker
    {
        private const string URL = "http://localhost:5216/api/Actors";

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<List<Actor>?> Get()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    
                    HttpResponseMessage response =
                       await client.GetAsync(URL);
                    if (response.IsSuccessStatusCode)
                    {
                        List<Actor>? actorList =
                            await response.Content.
                            ReadFromJsonAsync<List<Actor>>();
                        return actorList;
                    }
                    else if (response.StatusCode ==
                        System.Net.HttpStatusCode.BadRequest)
                    {
                        throw new ArgumentException("Serve sent bad request");
                    }
                    else { return null; }
                }
                catch (Exception ex)
                {
                    throw new Exception
                        ("Something bad happended: " + ex.Message);
                }
            }
        }

        public async Task<Actor?> GetById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(URL + "/" + id); 
                return await response.Content.ReadFromJsonAsync<Actor>();
            }
        }

    }
}
