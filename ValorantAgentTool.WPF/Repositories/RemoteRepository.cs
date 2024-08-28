using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ValorantAgentTool.WPF.Model;

namespace ValorantAgentTool.WPF.Repositories
{
    
    public class RemoteRepository : IRepository
    {


        private static readonly HttpClient _client = new HttpClient();

        public async Task<List<Agent>> GetAgentsAsync()
        {
            const string apiUrl = "https://valorant-api.com/v1/agents";

            try
            {
                // Asynchronously call the API and wait for the response
                HttpResponseMessage response = await _client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                // Read the response as a string
                string responseBody = await response.Content.ReadAsStringAsync();

                // Parse the JSON string
                JObject jsonData = JObject.Parse(responseBody);
                JArray agentsArray = (JArray)jsonData["data"];

                // Filter out non-playable agents
                var playableAgentsArray = new JArray(agentsArray
                    .Where(agent => agent["isPlayableCharacter"].Value<bool>()));

                // Deserialize the filtered JSON array into Agent objects
                List<Agent> agents = playableAgentsArray.ToObject<List<Agent>>();

                // Return the list of agents
                return agents;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return new List<Agent>();
            }
        }
    }
}
