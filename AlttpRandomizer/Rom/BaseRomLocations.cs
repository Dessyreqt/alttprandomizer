using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlttpRandomizer.IO;
using AlttpRandomizer.Random;

namespace AlttpRandomizer.Rom
{
    public abstract class BaseRomLocations
    {
        internal List<InventoryItemType> lateGameItems;
        
        public virtual List<Location> Locations { get; set; }
        public virtual List<Location> SpecialLocations { get; set; }

        private static int RegionCount = System.Enum.GetValues(typeof(Region)).Length;

        public bool[] DungeonHasBigKey = new bool[RegionCount];

        private static void WeightLocations(List<Location> retVal)
        {
            var currentWeight = (from item in retVal orderby item.Weight descending select item.Weight).First() + 1;

            foreach (var item in retVal.Where(item => item.Weight == 0))
            {
                item.Weight = currentWeight;
            }

            var addedItems = new List<List<Location>>();
            for (int i = 1; i < currentWeight; i++)
            {
                addedItems.Add(retVal.Where(x => x.Weight > i).ToList());
            }

            foreach (var list in addedItems)
            {
                retVal.AddRange(list);
            }
        }

        internal bool HasBottle(List<InventoryItemType> have)
        {
            return have.Contains(InventoryItemType.Bottle)
                || have.Contains(InventoryItemType.BottleWithBee)
                || have.Contains(InventoryItemType.BottleWithBluePotion)
                || have.Contains(InventoryItemType.BottleWithFairy)
                || have.Contains(InventoryItemType.BottleWithGoldBee)
                || have.Contains(InventoryItemType.BottleWithGreenPotion)
                || have.Contains(InventoryItemType.BottleWithRedPotion);

        }
        internal static bool CanLiftLightRocks(List<InventoryItemType> have)
        {
            return have.Contains(InventoryItemType.PowerGlove)
                || have.Contains(InventoryItemType.TitansMitt);
        }

        internal bool CanLightTorches(List<InventoryItemType> have)
        {
            return have.Contains(InventoryItemType.Lamp)
                || have.Contains(InventoryItemType.FireRod);
        }

        internal static void WriteSpecialItemCheck(FileStream rom, InventoryItemType item, int address)
        {
            var checkLocation = Item.GetCheckLocation(item);

            if (checkLocation[0] == 0x00)
            {
                rom.WriteBytes(address, 0x00, 0x00, 0x00, 0x00);
            }
            else
            {
                var itemLevel = Item.GetItemLevel(item);
                rom.WriteBytes(address, itemLevel[0], checkLocation[0], 0xF3, 0x7E);
            }
        }

        public T GetItemAtLocation<T>(List<Location> locations, string locationName) where T : Item
        {
            return ((T)locations.First(x => x.Name == locationName).Item);
        }

        private bool IsLateGameItem(InventoryItemType item)
        {
            return lateGameItems.Contains(item);
        }

        public void ResetRegion(Region region)
        {
            var locations = (from Location location in Locations where (location.Region == region) select location).ToList();

            DungeonHasBigKey[(int)region] = false;

            foreach (var location in locations)
            {
                location.Item = null;
            }
        }

        public List<Location> GetAvailableLocations(List<InventoryItemType> haveItems)
        {
            var retVal = (from Location location in Locations where (location.Item == null) && location.CanAccess(haveItems) select location).ToList();
            if (retVal.Count > 0)
            {
                WeightLocations(retVal);
            }

            return retVal;
        }

        public List<Location> GetAvailableLocations(List<InventoryItemType> haveItems, Region region)
        {
            var retVal = (from Location location in Locations where (location.Item == null) && (location.Region == region) && location.CanAccess(haveItems) select location).ToList();

            return retVal;
        }

        public List<Location> GetUnavailableLocations(List<InventoryItemType> haveItems)
        {
            return (from Location location in Locations where (location.Item == null) && !location.CanAccess(haveItems) select location).ToList();
        }

        internal bool LocationHasItem(string locationName, InventoryItemType item)
        {
            var itemAtLocation = GetItemAtLocation<InventoryItem>(Locations, locationName);

            return itemAtLocation?.Type == item;
        }

        internal bool CrystalAtLocation(string locationName, CrystalItemType item)
        {
            var itemAtLocation = GetItemAtLocation<CrystalItem>(SpecialLocations, locationName);

            return itemAtLocation?.Type == item;
        }

        internal bool PendantAtLocation(string locationName, PendantItemType item)
        {
            var itemAtLocation = GetItemAtLocation<PendantItem>(SpecialLocations, locationName);

            return itemAtLocation?.Type == item;
        }

        public void TryInsertCandidateItem(List<Location> currentLocations, List<InventoryItemType> candidateItemList, InventoryItemType candidateItem)
        {
            var badLateGameItem = IsLateGameItem(candidateItem) && !currentLocations.Any(x => x.LateGameItem);
            var badFirstItem = IsBadFirstItem(candidateItem) && currentLocations.All(x => x.Name == "[cave-040] Link's House");

            if (!badLateGameItem && !badFirstItem)
            {
                candidateItemList.Add(candidateItem);
            }
        }

        private static bool IsBadFirstItem(InventoryItemType item)
        {
            return (item == InventoryItemType.PowerGlove || item == InventoryItemType.TitansMitt || item == InventoryItemType.RedShield || item == InventoryItemType.MirrorShield);
        }

        public int GetInsertedLocation(List<Location> currentLocations, InventoryItemType insertedItem, SeedRandom random)
        {
            var randomLocations = random.RandomizeList(currentLocations);

            foreach (var location in randomLocations)
            {
                var badLateGameItemSpot = IsLateGameItem(insertedItem) && !location.LateGameItem;
                var badFirstItemSpot = IsBadFirstItem(insertedItem) && location.Name == "[cave-040] Link's House";
                var badNeverItemSpot = location.NeverItems.Contains(insertedItem);

                if (!(badLateGameItemSpot || badFirstItemSpot || badNeverItemSpot))
                {
                    if (insertedItem == InventoryItemType.BigKey)
                    {
                        DungeonHasBigKey[(int)currentLocations[0].Region] = true;
                    }

                    return currentLocations.IndexOf(location);
                }
            }

            throw new RandomizationException(string.Format("GetInsertedLocation: Couldn't find a good place for {0}.", insertedItem));
        }

        public InventoryItemType GetInsertedItem(List<Location> currentLocations, List<InventoryItemType> itemPool, SeedRandom random)
        {
            var randomItems = random.RandomizeList(itemPool);

            foreach (var item in randomItems)
            {
                var badLateGameItem = IsLateGameItem(item) && !currentLocations.Any(x => x.LateGameItem);
                var preferLateGameItem = !IsLateGameItem(item) && currentLocations.Any(x => x.LateGameItem) && itemPool.Any(IsLateGameItem);

                if (!(badLateGameItem || preferLateGameItem))
                {
                    return item;
                }
            }

            throw new RandomizationException("GetInsertedItem: Couldn't find a good item.");
        }

        internal void SetSpecialLocations(SeedRandom random)
        {
            SetBottles(random);
            SetMedallions(random);
        }

        private void SetMedallions(SeedRandom random)
        {
            var medallionTypes = new List<InventoryItemType>
                                 {
                                     InventoryItemType.Bombos,
                                     InventoryItemType.Ether,
                                     InventoryItemType.Quake,
                                 };

            var mireMedallion = SpecialLocation("Required Medallion - Misery Mire");
            mireMedallion.Item = new InventoryItem(medallionTypes[random.Next(medallionTypes.Count)]);
            var trockMedallion = SpecialLocation("Required Medallion - Turtle Rock");
            trockMedallion.Item = new InventoryItem(medallionTypes[random.Next(medallionTypes.Count)]);
        }

        private void SetBottles(SeedRandom random)
        {
            var bottleTypes = new List<InventoryItemType>
                              {
                                  InventoryItemType.BottleWithRedPotion,
                                  InventoryItemType.BottleWithGreenPotion,
                                  InventoryItemType.BottleWithBluePotion,
                                  InventoryItemType.BottleWithBee,
                                  InventoryItemType.BottleWithFairy,
                                  InventoryItemType.BottleWithGoldBee,
                              };

            var waterfallItem = SpecialLocation("Bottle Item - Waterfall");
            waterfallItem.Item = new InventoryItem(bottleTypes[random.Next(bottleTypes.Count)]);
            var pyramidItem = SpecialLocation("Bottle Item - Pyramid");
            pyramidItem.Item = new InventoryItem(bottleTypes[random.Next(bottleTypes.Count)]);
        }

        internal void WriteCrystal(FileStream rom, Region region, CrystalItemType itemType)
        {
            var regionAddresses = GetRegionAddresses(region);
            var crystalValues = GetCrystalValues(itemType);

            for (int i = 0; i < regionAddresses.Count; i++)
            {
                rom.WriteBytes(regionAddresses[i], crystalValues[i]);
            }

            var crystalAddress = GetCrystalAddress(itemType);
            var regionValue = GetRegionValue(region);

            rom.WriteBytes(crystalAddress, regionValue);
        }

        internal void WritePendant(FileStream rom, Region region, PendantItemType itemType)
        {
            var regionAddresses = GetRegionAddresses(region);
            var pendantValues = GetPendantValues(itemType);

            for (int i = 0; i < regionAddresses.Count; i++)
            {
                rom.WriteBytes(regionAddresses[i], pendantValues[i]);
            }
        }

        private byte GetRegionValue(Region region)
        {
            var regionAddresses = new Dictionary<Region, byte>
                {
                    { Region.EasternPalace, 0xC8 },
                    { Region.DesertPalace, 0x33 },
                    { Region.TowerOfHera, 0x07 },
                    { Region.DarkPalace, 0x5A },
                    { Region.SwampPalace, 0x06 },
                    { Region.SkullWoods, 0x29 },
                    { Region.ThievesTown, 0xAC },
                    { Region.IcePalace, 0xDE },
                    { Region.MiseryMire, 0x90 },
                    { Region.TurtleRock, 0xA4 },
                };

            return regionAddresses[region];
        }

        private int GetCrystalAddress(CrystalItemType itemType)
        {
            var crystalAddresses = new Dictionary<CrystalItemType, int>
                {
                    { CrystalItemType.Crystal1, 0x10860 },
                    { CrystalItemType.Crystal2, 0x1085E },
                    { CrystalItemType.Crystal3, 0x10862 },
                    { CrystalItemType.Crystal4, 0x1086A },
                    { CrystalItemType.Crystal5, 0x10866 },
                    { CrystalItemType.Crystal6, 0x10864 },
                    { CrystalItemType.Crystal7, 0x10868 },
                };

            return crystalAddresses[itemType];
        }

        private List<int> GetRegionAddresses(Region region)
        {
            var regionAddresses = new Dictionary<Region, List<int>>
                {
                    { Region.EasternPalace, new List<int> { 0x545B8, 0x1209D, 0x53EF8, 0x180052, 0xC6FE } },
                    { Region.DesertPalace, new List<int> { 0x545BA, 0x1209E, 0x53F1C, 0x180053, 0xC6FF } },
                    { Region.TowerOfHera, new List<int> { 0x545B9, 0x120A5, 0x53F0A, 0x18005A, 0xC706 } },
                    { Region.DarkPalace, new List<int> { 0x545D1, 0x120A1, 0x5452D, 0x180056, 0xC702 } },
                    { Region.SwampPalace, new List<int> { 0x545D7, 0x120A0, 0x54527, 0x180055, 0xC701 } },
                    { Region.SkullWoods, new List<int> { 0x545D2, 0x120A3, 0x5452C, 0x180058, 0xC704 } },
                    { Region.ThievesTown, new List<int> { 0x545D4, 0x120A6, 0x5452A, 0x18005B, 0xC707 } },
                    { Region.IcePalace, new List<int> { 0x545D6, 0x120A4, 0x54528, 0x180059, 0xC705 } },
                    { Region.MiseryMire, new List<int> { 0x545D5, 0x120A2, 0x54529, 0x180057, 0xC703 } },
                    { Region.TurtleRock, new List<int> { 0x545D3, 0x120A7, 0x5452B, 0x18005C, 0xC708 } },
                };

            return regionAddresses[region];
        }

        private List<byte> GetPendantValues(PendantItemType itemType)
        {
            var pendantValues = new Dictionary<PendantItemType, List<byte>>
                {
                    { PendantItemType.GreenPendant, new List<byte> { 0x04, 0x04, 0x38, 0x00, 0x01 } },
                    { PendantItemType.RedPendant, new List<byte> { 0x01, 0x01, 0x32, 0x00, 0x03 } },
                    { PendantItemType.BluePendant, new List<byte> { 0x02, 0x02, 0x34, 0x00, 0x02 } },
                };

            return pendantValues[itemType];
        }

        private List<byte> GetCrystalValues(CrystalItemType itemType)
        {
            var crystalValues = new Dictionary<CrystalItemType, List<byte>>
                {
                    { CrystalItemType.Crystal1, new List<byte> { 0x02, 0x02, 0x7F, 0x40, 0x06 } },
                    { CrystalItemType.Crystal2, new List<byte> { 0x10, 0x10, 0x79, 0x40, 0x06 } },
                    { CrystalItemType.Crystal3, new List<byte> { 0x40, 0x40, 0x6C, 0x40, 0x06 } },
                    { CrystalItemType.Crystal4, new List<byte> { 0x20, 0x20, 0x6D, 0x40, 0x06 } },
                    { CrystalItemType.Crystal5, new List<byte> { 0x04, 0x04, 0x6E, 0x40, 0x06 } },
                    { CrystalItemType.Crystal6, new List<byte> { 0x01, 0x01, 0x6F, 0x40, 0x06 } },
                    { CrystalItemType.Crystal7, new List<byte> { 0x08, 0x08, 0x7C, 0x40, 0x06 } },
                };

            return crystalValues[itemType];
        }

        public Location Location(string name)
        {
            return Locations.FirstOrDefault(x => x.Name == name);
        }

        public Location SpecialLocation(string name)
        {
            return SpecialLocations.FirstOrDefault(x => x.Name == name);
        }

        public bool CanDefeatDungeon(Region region, List<InventoryItemType> have)
        {
            switch (region)
            {
                case Region.HyruleCastleEscape:
                    return CanDefeatHyruleCastleEscape(have);
                case Region.EasternPalace:
                    return CanDefeatEasternPalace(have);
                case Region.DesertPalace:
                    return CanDefeatDesertPalace(have);
                case Region.TowerOfHera:
                    return CanDefeatTowerOfHera(have);
                case Region.DarkPalace:
                    return CanDefeatDarkPalace(have);
                case Region.SwampPalace:
                    return CanDefeatSwampPalace(have);
                case Region.SkullWoods:
                    return CanDefeatSkullWoods(have);
                case Region.ThievesTown:
                    return CanDefeatThievesTown(have);
                case Region.IcePalace:
                    return CanDefeatIcePalace(have);
                case Region.MiseryMire:
                    return CanDefeatMiseryMire(have);
                case Region.TurtleRock:
                    return CanDefeatTurtleRock(have);
                case Region.GanonsTower:
                    return CanDefeatGanonsTower(have);
                default:
                    return true;
            }
        }

        protected abstract bool CanDefeatHyruleCastleEscape(List<InventoryItemType> have);
        protected abstract bool CanDefeatEasternPalace(List<InventoryItemType> have);
        protected abstract bool CanDefeatDesertPalace(List<InventoryItemType> have);
        protected abstract bool CanDefeatTowerOfHera(List<InventoryItemType> have);
        protected abstract bool CanDefeatDarkPalace(List<InventoryItemType> have);
        protected abstract bool CanDefeatSwampPalace(List<InventoryItemType> have);
        protected abstract bool CanDefeatSkullWoods(List<InventoryItemType> have);
        protected abstract bool CanDefeatThievesTown(List<InventoryItemType> have);
        protected abstract bool CanDefeatIcePalace(List<InventoryItemType> have);
        protected abstract bool CanDefeatMiseryMire(List<InventoryItemType> have);
        protected abstract bool CanDefeatTurtleRock(List<InventoryItemType> have);
        protected abstract bool CanDefeatGanonsTower(List<InventoryItemType> have);
    }
}
