using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValorantAgentTool.WPF.Model;
using ValorantAgentTool.WPF.Stores;

namespace ValorantAgentTool.WPF.ViewModels
{
    class AgentDetailsViewModel : ViewModelBase
    {
        private readonly SelectedAgentStore _selectedAgentStore;
        private Agent _selectedAgent;

        public Agent SelectedAgent
        {
            get => _selectedAgent;
            private set
            {
                _selectedAgent = value;
                OnPropertyChanged(nameof(SelectedAgent));
                SelectedAbilityIndex = 0;
            }
        }

        private int selectedAbilityIndex;
        public int SelectedAbilityIndex
        {
            get => selectedAbilityIndex;
            set
            {
                selectedAbilityIndex = value;
                OnPropertyChanged();
            }
        }

        public AgentDetailsViewModel(SelectedAgentStore selectedAgentStore)
        {
            _selectedAgentStore = selectedAgentStore;
            _selectedAgentStore.OnSelectedAgentChanged += SelectedAgentStore_OnSelectedAgentChanged;
            SelectedAgent = _selectedAgentStore.SelectedAgent;
        }

        private void SelectedAgentStore_OnSelectedAgentChanged()
        {
            SelectedAgent = _selectedAgentStore.SelectedAgent;
        }
    }
}
