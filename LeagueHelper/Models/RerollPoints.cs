using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueHelper.Models
{
    internal class RerollPoints
    {
        public ushort CurrentPoints { get; set; }
        public byte MaxRolls { get; set; }

        public byte NumberOfRolls { get; set; }

        public ushort PointsCostToRoll { get; set; }

        public ushort PointsToReroll { get; set; }
    }
}
