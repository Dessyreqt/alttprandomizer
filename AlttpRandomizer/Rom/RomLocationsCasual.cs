using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlttpRandomizer.Rom;

namespace AlttpRandomizer.Rom
{
    public class RomLocationsCasual : IRomLocations
    {
        public List<Location> Locations { get; set; }
        public string DifficultyName { get { return "Casual"; } }
        public string SeedFileString { get { return "C{0:0000000}"; } }
        public string SeedRomString { get { return "Z3Rv{0} C{1}"; } }

        public void ResetPlms()
        {
            Locations = new List<Location>();
        }

    }
}
