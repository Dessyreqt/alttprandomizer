using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlttpRandomizer.Rom
{
    public enum Region
    {
        Progression,
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

    public enum LocationType
    {
        Item,
        Bat,
        Health,
        Magic,
        Pendant,
        Crystal,
    }

    public delegate bool Access(List<InventoryItemType> have);

    public class Location
    {
        public Location()
        {
            ForceItems = new List<InventoryItemType>();
            NeverItems = new List<InventoryItemType>();
        }

        public string Name { get; set; }
        public int Address { get; set; }
        public bool LateGameItem { get; set; }
        public Access CanAccess { get; set; }
        public Action<FileStream, Item> WriteItemCheck { get; set; }
        public Item Item { get; set; }
        public Region Region { get; set; }
        public int Weight { get; set; }
        public List<InventoryItemType> ForceItems { get; set; }
        public List<InventoryItemType> NeverItems { get; set; }
    }
}
