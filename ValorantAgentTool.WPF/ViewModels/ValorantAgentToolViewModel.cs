using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ValorantAgentTool.WPF.Stores;
using ValorantAgentTool.WPF.Commands;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ValorantAgentTool.WPF.Repositories;

namespace ValorantAgentTool.WPF.ViewModels
{
    class ValorantAgentToolViewModel : ViewModelBase
    {
        public ValorantAgentsListingViewModel ValorantAgentsListingViewModel { get; }
        public AgentDetailsViewModel AgentDetailsViewModel { get; }

        public ICommand SwitchDataLoadingCommand { get; }

        private string _buttonContent;
        public string ButtonContent
        {
            get => _buttonContent;
            set
            {
                _buttonContent = value;
                OnPropertyChanged(nameof(ButtonContent));
            }
        }

        private bool _useLocalRepository = true;


        public ValorantAgentToolViewModel(SelectedAgentStore selectedAgentStore)
        {
            ValorantAgentsListingViewModel = new ValorantAgentsListingViewModel(selectedAgentStore);
            AgentDetailsViewModel = new AgentDetailsViewModel(selectedAgentStore);

            SwitchDataLoadingCommand = new RelayCommand(param =>
            {
                _useLocalRepository = !_useLocalRepository;
                SwitchDataLoadingAsync(_useLocalRepository);
                    
                ButtonContent = _useLocalRepository ? "Switch to Remote Data" : "Switch to Local Data";
            });

            ButtonContent = "Switch to Remote Data";
        }

        private async void SwitchDataLoadingAsync(bool useLocalRepository)
        {
            await ValorantAgentsListingViewModel.RefreshAgents(useLocalRepository);
        }

    }
}
