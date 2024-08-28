using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ValorantAgentTool.WPF.Model
{
    public class AgentImages
    {
        [JsonProperty("displayIcon")]
        public string DisplayIcon { get; set; }

        [JsonProperty("displayIconSmall")]
        public string DisplayIconSmall { get; set; }

        [JsonProperty("bustPortrait")]
        public string BustPortrait { get; set; }

        [JsonProperty("fullPortrait")]
        public string FullPortrait { get; set; }

        [JsonProperty("killfeedPortrait")]
        public string KillfeedPortrait { get; set; }

        [JsonProperty("background")]
        public string Background { get; set; }
    }

    public class Role
    {
        [JsonProperty("displayName")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("displayIcon")]
        public string DisplayIcon { get; set; }
    }

    public class Ability
    {
        [JsonProperty("displayName")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("displayIcon")]
        public string DisplayIcon { get; set; }
    }

    public class Agent : INotifyPropertyChanged
    {
        private string name;
        private string description;
        private List<Ability> abilities;
        private Role role;
        private AgentImages images;

        [JsonProperty("displayName")]
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("description")]
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("abilities")]
        public List<Ability> Abilities
        {
            get => abilities;
            set
            {
                abilities = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("role")]
        public Role Role
        {
            get => role;
            set
            {
                role = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("displayIcon")]
        public string DisplayIcon
        {
            get => images?.DisplayIcon;
            set
            {
                if (images == null) images = new AgentImages();
                images.DisplayIcon = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("displayIconSmall")]
        public string DisplayIconSmall
        {
            get => images?.DisplayIconSmall;
            set
            {
                if (images == null) images = new AgentImages();
                images.DisplayIconSmall = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("bustPortrait")]
        public string BustPortrait
        {
            get => images?.BustPortrait;
            set
            {
                if (images == null) images = new AgentImages();
                images.BustPortrait = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("fullPortrait")]
        public string FullPortrait
        {
            get => images?.FullPortrait;
            set
            {
                if (images == null) images = new AgentImages();
                images.FullPortrait = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("killfeedPortrait")]
        public string KillfeedPortrait
        {
            get => images?.KillfeedPortrait;
            set
            {
                if (images == null) images = new AgentImages();
                images.KillfeedPortrait = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("background")]
        public string Background
        {
            get => images?.Background;
            set
            {
                if (images == null) images = new AgentImages();
                images.Background = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
