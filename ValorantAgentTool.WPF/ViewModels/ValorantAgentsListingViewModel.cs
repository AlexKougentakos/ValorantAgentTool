using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ValorantAgentTool.WPF.Model;
using ValorantAgentTool.WPF.Stores;
using ValorantAgentTool.WPF.Repositories;
using System.Windows.Input;

namespace ValorantAgentTool.WPF.ViewModels
{
    class ValorantAgentsListingViewModel : ViewModelBase
    {
        private readonly SelectedAgentStore _selectedAgentStore;
        private List<Agent> _agents;
        private Agent _selectedAgent;

        public IRepository ActiveRepository { get; set; } = new LocalRepository();


        public List<Agent> Agents
        {
            get => _agents;
            set
            {
                _agents = value;
                OnPropertyChanged();
            }
        }

        public Agent SelectedAgent
        {
            get => _selectedAgent;
            set
            {
                _selectedAgent = value;
                OnPropertyChanged();
                SelectAgent(value);
            }
        }

        public ValorantAgentsListingViewModel(SelectedAgentStore selectedAgentStore)
        {
            _selectedAgentStore = selectedAgentStore;

            InitializeAsync();
            
        }


        private async void InitializeAsync()
        {
            await RefreshAgents();

            if (Agents.Count > 0)
            {
                SelectedAgent = Agents[0]; // Set the first agent as selected
            }
        }


        public async Task RefreshAgents(bool useLocalRepository = true)
        {
            if (useLocalRepository)
            {
                ActiveRepository = new LocalRepository();
            }
            else
            {
                ActiveRepository = new RemoteRepository();
            }

            Agents = await ActiveRepository.GetAgentsAsync();

            if (Agents.Count > 0)
            {
                SelectedAgent = Agents[0]; // Set the first agent as selected
            }
        }

        private void SelectAgent(Agent agent)
        {
            _selectedAgentStore.SelectedAgent = agent;
        }
    }
}
