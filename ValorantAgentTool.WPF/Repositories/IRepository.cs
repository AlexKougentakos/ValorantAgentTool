using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValorantAgentTool.WPF.Model;

namespace ValorantAgentTool.WPF.Repositories
{
    public interface IRepository
    {
        Task<List<Agent>> GetAgentsAsync();
    }
}
