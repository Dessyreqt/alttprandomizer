using System.Collections.Generic;
using AlttpRandomizer.Random;

namespace AlttpRandomizer.Rom
{
    public interface IRomLocations
    {
        List<Location> Locations { get; set; }
        List<Location> SpecialLocations { get; set; }
        string DifficultyName { get; }
        string SeedFileString { get; }
        string SeedRomString { get; }

        void ResetLocations();
        bool CanDefeatDungeon(Region region, List<InventoryItemType> have);
        void ResetRegion(Region region);
        List<Location> GetAvailableLocations(List<InventoryItemType> haveItems);
        List<Location> GetAvailableLocations(List<InventoryItemType> haveItems, Region region);
        List<Location> GetUnavailableLocations(List<InventoryItemType> haveItems);
        void TryInsertCandidateItem(List<Location> currentLocations, List<InventoryItemType> candidateItemList, InventoryItemType candidateItem);
        int GetInsertedLocation(List<Location> currentLocations, InventoryItemType insertedItem, SeedRandom random);
        InventoryItemType GetInsertedItem(List<Location> currentLocations, List<InventoryItemType> itemPool, SeedRandom random);
        List<InventoryItemType> GetItemPool(SeedRandom random);
        T GetItemAtLocation<T>(List<Location> locations, string locationName) where T : Item;
        Location Location(string name);
        Location SpecialLocation(string name);
    }
}
