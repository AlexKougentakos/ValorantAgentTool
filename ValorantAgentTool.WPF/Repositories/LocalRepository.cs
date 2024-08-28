using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValorantAgentTool.WPF.Model;

namespace ValorantAgentTool.WPF.Repositories
{
    public class LocalRepository : IRepository
    {
        public async Task<List<Agent>> GetAgentsAsync()
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream("ValorantAgentTool.WPF.Resources.Agents.json"))

            using (StreamReader reader = new StreamReader(stream))
            {
                string json = await reader.ReadToEndAsync();
                JObject jsonData = JObject.Parse(json);
                JArray agentsArray = (JArray)jsonData["data"];

                // Filter out non-playable agents
                var playableAgentsArray = new JArray(agentsArray
                    .Where(agent => agent["isPlayableCharacter"].Value<bool>()));

                // Deserialize the filtered JSON array into Agent objects
                return playableAgentsArray.ToObject<List<Agent>>();
            }
        }
    }
}
