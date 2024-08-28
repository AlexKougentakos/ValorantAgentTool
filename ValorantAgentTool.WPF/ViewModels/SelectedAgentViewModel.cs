using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValorantAgentTool.WPF.Model;

namespace ValorantAgentTool.WPF.ViewModels
{
    internal class SelectedAgentViewModel : ViewModelBase
    {
        public Agent Agent { get;}

        public SelectedAgentViewModel(Agent agent)
        {
            Agent = agent;
        }
    }
}
