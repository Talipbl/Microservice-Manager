using Services.Enums;
using System.Text.Json.Serialization;

namespace Services
{
    public class Microservice
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Path { get; set; }
        [JsonIgnore]
        public string ListeningUrl { get; set; }
        public bool IsFavorite { get; set; }
        [JsonIgnore]
        public ServiceStatus CurrentAction { get; set; }
        [JsonIgnore]
        public int RestartCount{ get; set; }

        public void ResetRestartCount()
        {
            RestartCount = 0;
        }
    }
}
