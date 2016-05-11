using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlttpRandomizer.Rom
{
    public enum Region
    {
        Unknown,
        LightWorld,
        DarkWorld,
        HyruleCastleEscape,
        EasternPalace,
        DesertPalace,
        TowerOfHera,
        HyruleCastleTower,
        DarkPalace,
        SwampPalace,
        SkullWoods,
        ThievesTown,
        IcePalace,
        MiseryMire,
        TurtleRock,
        GanonsTower,
    }

    public delegate bool Access(List<ItemType> have);

    public class Location
    {
		public bool TitansMittOkay { get; set; }
        public string Name { get; set; }
        public long Address { get; set; }
        public Access CanAccess { get; set; }
        public Item Item { get; set; }
		public int KeysNeeded { get; set; }
		public bool BigKeyNeeded { get; set; }
        public Region Region { get; set; }
    }
}
