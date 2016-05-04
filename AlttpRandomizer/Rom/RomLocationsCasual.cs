using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlttpRandomizer.Random;
using AlttpRandomizer.Rom;

namespace AlttpRandomizer.Rom
{
    public class RomLocationsCasual : IRomLocations
    {
        public List<Location> Locations { get; set; }
        public string DifficultyName { get { return "Casual"; } }
        public string SeedFileString { get { return "C{0:0000000}"; } }
        public string SeedRomString { get { return "Z3Rv{0} C{1}"; } }

        public void ResetLocations()
        {
            Locations = new List<Location>();
        }

        public List<Location> GetAvailableLocations(List<ItemType> haveItems)
        {
            throw new NotImplementedException();
        }

        public List<Location> GetUnavailableLocations(List<ItemType> haveItems)
        {
            throw new NotImplementedException();
        }

        public void TryInsertCandidateItem(List<Location> currentLocations, List<ItemType> candidateItemList, ItemType candidateItem)
        {
            throw new NotImplementedException();
        }

        public int GetInsertedLocation(List<Location> currentLocations, ItemType insertedItem, SeedRandom random)
        {
            throw new NotImplementedException();
        }

        public ItemType GetInsertedItem(List<Location> currentLocations, List<ItemType> itemPool, SeedRandom random)
        {
            throw new NotImplementedException();
        }

        public List<ItemType> GetItemPool(SeedRandom random)
        {
            throw new NotImplementedException();
        }
    }
}
