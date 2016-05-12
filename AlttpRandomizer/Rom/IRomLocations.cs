using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlttpRandomizer.Random;

namespace AlttpRandomizer.Rom
{
    public interface IRomLocations
    {
        List<Location> Locations { get; set; }
        string DifficultyName { get; }
        string SeedFileString { get; }
        string SeedRomString { get; }

        void ResetLocations();
        List<Location> GetAvailableLocations(List<ItemType> haveItems);
        List<Location> GetUnavailableLocations(List<ItemType> haveItems);
        void TryInsertCandidateItem(List<Location> currentLocations, List<ItemType> candidateItemList, ItemType candidateItem);
        int GetInsertedLocation(List<Location> currentLocations, ItemType insertedItem, SeedRandom random);
        ItemType GetInsertedItem(List<Location> currentLocations, List<ItemType> itemPool, SeedRandom random);
        List<ItemType> GetItemPool(SeedRandom random);
	    bool CanGetMasterSword(List<ItemType> haveItems);
    }
}
