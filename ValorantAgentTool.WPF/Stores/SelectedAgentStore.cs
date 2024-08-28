using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValorantAgentTool.WPF.Model;

namespace ValorantAgentTool.WPF.Stores
{
    internal class SelectedAgentStore
    {
        private Agent _selectedAgent;
        public Agent SelectedAgent
        {
            get => _selectedAgent;
            set
            {
                _selectedAgent = value;
                OnSelectedAgentChanged?.Invoke();
            }
        }

        public event Action OnSelectedAgentChanged;
    }
}
