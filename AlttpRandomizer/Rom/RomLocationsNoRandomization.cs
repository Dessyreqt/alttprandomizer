using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlttpRandomizer.Random;

namespace AlttpRandomizer.Rom
{
    public class RomLocationsNoRandomization : BaseRomLocations, IRomLocations
    {
        public string DifficultyName => "No Randomization";
        public string SeedFileString => "NORAND";
        public string SeedRomString => "Z3Rv{0} NORAND";

        public List<InventoryItemType> GetItemPool(SeedRandom random)
        {
            throw new NotImplementedException();
        }

        public void ResetLocations()
        {
            throw new NotImplementedException();
        }

        protected override bool CanDefeatDarkPalace(List<InventoryItemType> have)
        {
            throw new NotImplementedException();
        }

        protected override bool CanDefeatDesertPalace(List<InventoryItemType> have)
        {
            throw new NotImplementedException();
        }

        protected override bool CanDefeatEasternPalace(List<InventoryItemType> have)
        {
            throw new NotImplementedException();
        }

        protected override bool CanDefeatGanonsTower(List<InventoryItemType> have)
        {
            throw new NotImplementedException();
        }

        protected override bool CanDefeatHyruleCastleEscape(List<InventoryItemType> have)
        {
            throw new NotImplementedException();
        }

        protected override bool CanDefeatIcePalace(List<InventoryItemType> have)
        {
            throw new NotImplementedException();
        }

        protected override bool CanDefeatMiseryMire(List<InventoryItemType> have)
        {
            throw new NotImplementedException();
        }

        protected override bool CanDefeatSkullWoods(List<InventoryItemType> have)
        {
            throw new NotImplementedException();
        }

        protected override bool CanDefeatSwampPalace(List<InventoryItemType> have)
        {
            throw new NotImplementedException();
        }

        protected override bool CanDefeatThievesTown(List<InventoryItemType> have)
        {
            throw new NotImplementedException();
        }

        protected override bool CanDefeatTowerOfHera(List<InventoryItemType> have)
        {
            throw new NotImplementedException();
        }

        protected override bool CanDefeatTurtleRock(List<InventoryItemType> have)
        {
            throw new NotImplementedException();
        }
    }
}
