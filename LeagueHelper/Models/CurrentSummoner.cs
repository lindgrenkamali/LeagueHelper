using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueHelper.Models
{
    public class CurrentSummoner
    {
        public ulong AccountID { get; set; }
        public string DisplayName { get; set; }

        public string InternalName { get; set; }
        
        public bool NameChangeFlag { get; set; }

        public byte PercentCompleteForNextLevel { get; set; }

        public string Privacy { get; set; }

        public ushort ProfileIconID { get; set; }

        public string PUUID { get; set; }

        [JsonProperty("rerollPoints")]
        RerollPoints RerollPoints { get; set; }

        public uint SummonerID { get; set; }

        public ushort SummonerLevel { get; set; }

        public bool Unnamed { get; set; }

        public ushort XpSinceLastlevel { get; set; }

        public ushort XpUntilNextLevel { get; set; }

    }
}
