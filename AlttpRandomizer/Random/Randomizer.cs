using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlttpRandomizer.IO;
using AlttpRandomizer.Net;
using AlttpRandomizer.Properties;
using AlttpRandomizer.Rom;

namespace AlttpRandomizer.Random
{
    public enum RandomizerDifficulty
    {
        None = 0xFF,
        Casual = 0x00,
        Glitched = 0x01,
    }

    public enum HeartBeepSpeed
    {
        Off = 0x00,
        Normal = 0x20,
        Half = 0x40,
        Quarter = 0x80,
    }

    public class RandomizerOptions
    {
        public string Filename { get; set; }
        public bool SpoilerOnly { get; set; }
        public bool SramTrace { get; set; }
        public bool ShowComplexity { get; set; }
        public RandomizerDifficulty Difficulty { get; set; }
        public HeartBeepSpeed HeartBeepSpeed { get; set; } 
        public bool NoRandomization { get; set; }

        public RandomizerOptions()
        {
            Filename = "";
            SpoilerOnly = false;
            SramTrace = false;
            ShowComplexity = true;
            Difficulty = RandomizerDifficulty.None;
            HeartBeepSpeed = HeartBeepSpeed.Normal;
            NoRandomization = false;
        }
    }

    public class Randomizer
    {
        private static SeedRandom random;
        private List<InventoryItemType> haveItems;
        private List<InventoryItemType> itemPool;
        private readonly int seed;
        private readonly IRomLocations romLocations;
        private readonly RandomizerLog log;
        private int complexity;
        
        public int GetComplexity()
        {
            return complexity;
        }

        public Randomizer(int seed, IRomLocations romLocations, RandomizerLog log)
        {
            random = new SeedRandom(seed);
            this.romLocations = romLocations;
            this.seed = seed;
            this.log = log;
        }

        public string CreateRom(RandomizerOptions options)
        {
            try
            {
                String filePath = FileName.Fix(options.Filename, string.Format(romLocations.SeedFileString, seed), complexity);
                if (filePath.Contains("\\") && !Directory.Exists(filePath.Substring(0, filePath.LastIndexOf('\\'))))
                {
                    Directory.CreateDirectory(filePath.Substring(0, filePath.LastIndexOf('\\')));
                }

                if (!options.NoRandomization)
                {
                    GenerateItemList();
                    RandomizeQuestItems();
                    GenerateItemPositions();

                    if (log != null || options.ShowComplexity)
                    {
                        CalculateComplexity();
                    }

                    if (RandomizerVersion.Debug)
                    {
                        SetupTestItems(romLocations.Locations);
                    }

                    if (options.SpoilerOnly)
                    {
                        return log?.GetLogOutput();
                    }
                }
                WriteRom(options);

                return "";
            }
            catch (Exception ex)
            {
                var newEx = new RandomizationException(string.Format("Error creating seed: {0}.", string.Format(romLocations.SeedFileString, seed)), ex);

                throw newEx;
            }
        }

        private void RandomizeQuestItems()
        {
            RandomizePendants();
            RandomizeCrystals();
            RandomizeSwords();
        }

        private void RandomizeSwords()
        {
            var swords = new List<InventoryItemType>
                         {
                             InventoryItemType.L2Sword,
                             InventoryItemType.L3Sword,
                             InventoryItemType.L4Sword,
                         };

            swords = random.RandomizeList(swords);

            romLocations.SpecialLocation("Sword - Pedestal").Item = new InventoryItem(swords[0] == InventoryItemType.L2Sword ? InventoryItemType.L2SwordPedestal : swords[0]);
            romLocations.SpecialLocation("Sword - Smithy").Item = new InventoryItem(swords[1]);
            romLocations.SpecialLocation("Sword - Fairy").Item = new InventoryItem(swords[2]);
        }

        private void RandomizeCrystals()
        {
            var crystals = new List<CrystalItemType>
                         {
                             CrystalItemType.Crystal1,
                             CrystalItemType.Crystal2,
                             CrystalItemType.Crystal3,
                             CrystalItemType.Crystal4,
                             CrystalItemType.Crystal5,
                             CrystalItemType.Crystal6,
                             CrystalItemType.Crystal7,
                         };

            crystals = random.RandomizeList(crystals);

            romLocations.SpecialLocation("Crystal - Dark Palace").Item = new CrystalItem(crystals[0]);
            romLocations.SpecialLocation("Crystal - Swamp Palace").Item = new CrystalItem(crystals[1]);
            romLocations.SpecialLocation("Crystal - Skull Woods").Item = new CrystalItem(crystals[2]);
            romLocations.SpecialLocation("Crystal - Thieves' Town").Item = new CrystalItem(crystals[3]);
            romLocations.SpecialLocation("Crystal - Ice Palace").Item = new CrystalItem(crystals[4]);
            romLocations.SpecialLocation("Crystal - Misery Mire").Item = new CrystalItem(crystals[5]);
            romLocations.SpecialLocation("Crystal - Turtle Rock").Item = new CrystalItem(crystals[6]);
        }

        private void RandomizePendants()
        {
            var pendants = new List<PendantItemType>
                         {
                             PendantItemType.GreenPendant,
                             PendantItemType.RedPendant,
                             PendantItemType.BluePendant,
                         };

            pendants = random.RandomizeList(pendants);

            romLocations.SpecialLocation("Pendant - Eastern Palace").Item = new PendantItem(pendants[0]);
            romLocations.SpecialLocation("Pendant - Desert Palace").Item = new PendantItem(pendants[1]);
            romLocations.SpecialLocation("Pendant - Tower of Hera").Item = new PendantItem(pendants[2]);
        }

        private void WriteRngItems(FileStream rom)
        {
            for (int address = 0x178000; address <= 0x1783ff; address++)
            {
                var randomValue = (byte)random.Next(0x100);
                rom.WriteBytes(address, randomValue);
            }
        }

        /// <summary>
        /// This is a setup method for placing items where they can be tested easily. It should only be run in debug mode.
        /// </summary>
        /// <param name="locations"></param>
        private void SetupTestItems(List<Location> locations)
        {
            //// add red boomerang 
            //var location = locations.First(x => x.Name == "[cave-022-B1] Thief's hut [top chest]");
            //location.Item = new InventoryItem(InventoryItemType.RedBoomerang);

            //// add blue boomerang 
            //location = locations.First(x => x.Name == "[cave-022-B1] Thief's hut [top left chest]");
            //location.Item = new InventoryItem(InventoryItemType.Boomerang);

            //// add powder
            //location = locations.First(x => x.Name == "[cave-022-B1] Thief's hut [top right chest]");
            //location.Item = new InventoryItem(InventoryItemType.Powder);

            //// add flute
            //location = locations.First(x => x.Name == "[cave-022-B1] Thief's hut [bottom left chest]");
            //location.Item = new InventoryItem(InventoryItemType.OcarinaInactive);

            //// add mushroom
            //location = locations.First(x => x.Name == "[cave-022-B1] Thief's hut [bottom right chest]");
            //location.Item = new InventoryItem(InventoryItemType.Mushroom);

            //// add shovel
            //location = locations.First(x => x.Name == "Bottle Vendor");
            //location.Item = new InventoryItem(InventoryItemType.Shovel);

            //// Link's House
            //var location = locations.First(x => x.Name == "[cave-040] Link's House");
            //location.Item = new InventoryItem(InventoryItemType.Bottle);

            //// After Sword
            //location = locations.First(x => x.Name == "[cave-034] Hyrule Castle secret entrance");
            //location.Item = new InventoryItem(InventoryItemType.BottleWithRedPotion);
        }

        private void WriteRom(RandomizerOptions options)
        {
            string usedFilename = FileName.Fix(options.Filename, string.Format(romLocations.SeedFileString, seed), complexity);

            using (var rom = new FileStream(usedFilename, FileMode.OpenOrCreate))
            {
                rom.Write(Resources.RomImage, 0, 2097152);

                if (options.NoRandomization) { return; }

                foreach (var location in romLocations.Locations)
                {
                    var newItem = (byte)location.Item.HexValue;
                    rom.WriteBytes(location.Address, newItem);
                    location.WriteItemCheck?.Invoke(rom, location.Item);
                }
                foreach (var location in romLocations.SpecialLocations)
                {
                    if (location.Address != default(int))
                    {
                        var newItem = (byte)location.Item.HexValue;
                        rom.WriteBytes(location.Address, newItem);
                    }
                    location.WriteItemCheck?.Invoke(rom, location.Item);
                }

                WriteSeedInRom(rom, options);
                WriteRngItems(rom);
                rom.WriteBytes(0x180033, (byte)options.HeartBeepSpeed);
                rom.WriteBytes(0x180040, (byte)random.Next(0x20));

                if (options.SramTrace)
                {
                    WriteSramTraceToRom(rom);
                }

                if (RandomizerVersion.Debug)
                {
                    WriteDebugModeToRom(rom);
                }

                rom.Close();
            }

            log?.WriteLog(usedFilename);
        }

        private void WriteSramTraceToRom(FileStream rom)
        {
            rom.WriteBytes(0x180030, 0x01);
        }

        private void WriteDebugModeToRom(FileStream rom)
        {
            rom.WriteBytes(0x65b88, 0xEA, 0xEA);
            rom.WriteBytes(0x65b91, 0xEA, 0xEA);
        }

        private void WriteSeedInRom(FileStream rom, RandomizerOptions options)
        {
            string seedStr = string.Format(romLocations.SeedRomString, RandomizerVersion.Current, seed.ToString().PadLeft(7, '0')).PadRight(21).Substring(0, 21);
            rom.WriteBytes(0x7fc0, StringToByteArray(seedStr));
            rom.WriteBytes(0x180210, (byte)options.Difficulty , 0x00, GetWarningFlags(options.Difficulty));
        }

        private byte GetWarningFlags(RandomizerDifficulty difficulty)
        {
            switch (difficulty)
            {
                case RandomizerDifficulty.Casual:
                    return 0x00;
                case RandomizerDifficulty.Glitched:
                    return 0x40;
            }

            return 0x00;
        }

        private static byte[] StringToByteArray(string input)
        {
            var retVal = new byte[input.Length];
            var i = 0;

            foreach (var ch in input)
            {
                retVal[i] = (byte)ch;
                i++;
            }

            return retVal;
        }

        private void GenerateItemPositions()
        {
            var handledDungeons = new List<Region>
            {
                Region.Progression,
                Region.LightWorld,
                Region.DarkWorld,
            };

            PlaceItems(handledDungeons, itemPool, Region.Progression);

            var unavailableLocations = romLocations.GetUnavailableLocations(haveItems);

            foreach (var unavailableLocation in unavailableLocations)
            {
                unavailableLocation.Item = new InventoryItem(InventoryItemType.Nothing);
            }

            log?.AddGeneratedItems(romLocations.Locations);
            log?.AddSpecialLocations(romLocations.SpecialLocations);
        }

        private void PlaceItems(List<Region> handledDungeons, List<InventoryItemType> insertedItemPool, Region region)
        {
            do
            {
                List<Location> currentLocations;
                if (region == Region.Progression)
                {
                    currentLocations = romLocations.GetAvailableLocations(haveItems);

                    if (romLocations.Locations.Count(x => x.Item == null) == 0)
                    {
                        throw new RandomizationException("Ran out of places to put items! (WTF?)");
                    }

                    if (currentLocations.Count == 0)
                    {
                        throw new RandomizationException("Hit a roadblock in item generation...");
                    }
                }
                else
                {
                    currentLocations = romLocations.GetAvailableLocations(haveItems, region);

                    if (romLocations.Locations.Count(x => x.Item == null) == 0)
                    {
                        throw new RandomizationException("Ran out of places to put items! (WTF?)");
                    }

                    if (currentLocations.Count == 0)
                    {
                        return;
                    }
                }

                if (handledDungeons.Count == 1 || haveItems.Count == 0)
                {
                    var itemsHandled = HandleForcedItems(currentLocations, insertedItemPool);
                    if (itemsHandled)
                    {
                        continue;
                    }
                }

                var candidateItemList = new List<InventoryItemType>();

                // Generate candidate item list
                foreach (var candidateItem in insertedItemPool)
                {
                    if (!Item.OmitAccessibleCheck(candidateItem)) // Can ommit the following logic for most items, as it doesn't do any thing
                    {
                        haveItems.Add(candidateItem);

                        var newLocations = region == Region.Progression ? romLocations.GetAvailableLocations(haveItems) : romLocations.GetAvailableLocations(haveItems, region);

                        if (newLocations.Count > currentLocations.Count)
                        {
                            romLocations.TryInsertCandidateItem(currentLocations, candidateItemList, candidateItem);
                        }

                        haveItems.Remove(candidateItem);
                    }
                }

                if (region == Region.Progression)
                {
                    AdjustCandidateItems(candidateItemList, haveItems, romLocations);
                }

                // Grab an item from the candidate list if there are any, otherwise, grab a random item
                if (candidateItemList.Count > 0)
                {
                    var insertedItemList = random.RandomizeList(candidateItemList);

                    foreach (var insertedItem in insertedItemList)
                    {
                        var itemPlaced = PlaceItem(handledDungeons, insertedItemPool, currentLocations, insertedItem, true);

                        if (itemPlaced)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    var excludeLocations = currentLocations.Where(x => x.NeverItems.Any(insertedItemPool.Contains)).ToList();
                    if (excludeLocations.Count > 0)
                    {
                        var placeItems = new List<InventoryItemType>();

                        foreach (var location in excludeLocations)
                        {
                            currentLocations.Remove(location);

                            foreach (var item in location.NeverItems)
                            {
                                if (!placeItems.Contains(item) && insertedItemPool.Contains(item))
                                {
                                    placeItems.Add(item);
                                }
                            }
                        }

                        if (currentLocations.Count == 0)
                        {
                            return;
                        }

                        var insertedItemList = random.RandomizeList(placeItems);

                        foreach (var insertedItem in insertedItemList)
                        {
                            var itemPlaced = PlaceItem(handledDungeons, insertedItemPool, currentLocations, insertedItem);

                            if (itemPlaced)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            bool itemPlaced;

                            do
                            {
                                var insertedItem = romLocations.GetInsertedItem(currentLocations, insertedItemPool, random);
                                itemPlaced = PlaceItem(handledDungeons, insertedItemPool, currentLocations, insertedItem);
                            } while (!(itemPlaced || currentLocations.Count == 0));
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            if (RandomizerVersion.Debug)
                            {
                                using (var writer = new StreamWriter(string.Format("unavailableLocations - {0}.txt", string.Format(romLocations.SeedFileString, seed))))
                                {
                                    var unavailable = romLocations.GetUnavailableLocations(haveItems);

                                    writer.WriteLine("Unavailable Locations");
                                    writer.WriteLine("---------------------");

                                    foreach (var location in unavailable.OrderBy(x => x.Name))
                                    {
                                        writer.WriteLine(location.Name);
                                    }

                                    writer.WriteLine();
                                    writer.WriteLine("Have Items");
                                    writer.WriteLine("----------");

                                    foreach (var item in haveItems)
                                    {
                                        writer.WriteLine(item);
                                    }

                                    writer.WriteLine();
                                    writer.WriteLine("Item Pool");
                                    writer.WriteLine("---------");

                                    foreach (var item in insertedItemPool)
                                    {
                                        writer.WriteLine(item);
                                    }
                                }
                            }
                            throw;
                        }
                    }
                }
            } while (insertedItemPool.Count > 0);
        }

        private bool HandleForcedItems(List<Location> currentLocations, List<InventoryItemType> insertedItemPool)
        {
            var retVal = false;
            var forcedLocations = currentLocations.Where(x => x.ForceItems.Count > 0).ToList();

            foreach (var forcedLocation in forcedLocations)
            {
                var availableForcedItems = forcedLocation.ForceItems.Where(insertedItemPool.Contains).ToList();

                if (availableForcedItems.Count > 0)
                {
                    var insertedItem = availableForcedItems[random.Next(availableForcedItems.Count)];
                    forcedLocation.Item = new InventoryItem(insertedItem);
                    insertedItemPool.Remove(insertedItem);
                    haveItems.Add(insertedItem);
                    retVal = true;
                }

                currentLocations.Remove(forcedLocation);
            }

            return retVal;
        }

        private bool PlaceItem(List<Region> handledDungeons, List<InventoryItemType> insertedItemPool, List<Location> currentLocations, InventoryItemType insertedItem, bool logOrderedItem = false)
        {
            if (currentLocations.All(x => x.NeverItems.Contains(insertedItem)))
            {
                return false;
            }

            int insertedLocationIndex = romLocations.GetInsertedLocation(currentLocations, insertedItem, random);
            var insertedLocation = currentLocations[insertedLocationIndex];
            bool itemPlaced;

            if (!handledDungeons.Contains(insertedLocation.Region))
            {
                itemPlaced = GenerateDungeonItems(insertedLocation.Region, insertedItem, logOrderedItem);

                if (itemPlaced)
                {
                    handledDungeons.Add(insertedLocation.Region);
                }
            }
            else
            {
                itemPlaced = true;
                insertedLocation.Item = new InventoryItem(insertedItem);
            }

            if (itemPlaced)
            {
                insertedItemPool.Remove(insertedItem);
                haveItems.Add(insertedItem);

                if (logOrderedItem)
                {
                    log?.AddOrderedItem(currentLocations[insertedLocationIndex]);
                }
            }
            return itemPlaced;
        }

        private bool GenerateDungeonItems(Region region, InventoryItemType insertedItem, bool logInsertedItem = false)
        {
            var retVal = false;
            var tempItemPool = GetDungeonItemPool(region);
            tempItemPool.Add(insertedItem);

            PlaceItems(new List<Region> { region }, tempItemPool, region);

            haveItems.RemoveAll(x => x == InventoryItemType.BigKey);
            haveItems.RemoveAll(x => x == InventoryItemType.Compass);
            haveItems.RemoveAll(x => x == InventoryItemType.Key);
            haveItems.RemoveAll(x => x == InventoryItemType.Map);

            if (tempItemPool.Count > 0 || !romLocations.CanDefeatDungeon(region, haveItems))
            {
                romLocations.ResetRegion(region);
                log?.RemoveOrderedItems(region);
            }
            else
            {
                if (logInsertedItem)
                {
                    var insertedLocation = romLocations.Locations.First(x => x.Region == region && x.Item != null && ((InventoryItem)x.Item).Type == insertedItem);
                    log?.AddOrderedItem(insertedLocation);
                }
                retVal = true;
            }

            // we're going to add this back a little later anyway
            haveItems.Remove(insertedItem);

            return retVal;
        }

        private List<InventoryItemType> GetDungeonItemPool(Region region)
        {
            switch (region)
            {
                case Region.HyruleCastleEscape:
                    return new List<InventoryItemType>
                    {
                        InventoryItemType.Key,
                        InventoryItemType.Map,
                    };
                case Region.EasternPalace:
                case Region.DesertPalace:
                case Region.TowerOfHera:
                    return new List<InventoryItemType>
                    {
                        InventoryItemType.BigKey,
                        InventoryItemType.Compass,
                        InventoryItemType.Map,
                    };
                case Region.HyruleCastleTower:
                    return new List<InventoryItemType>
                    {
                        InventoryItemType.Key,
                        InventoryItemType.Key,
                    };
                case Region.DarkPalace:
                    return new List<InventoryItemType>
                    {
                        InventoryItemType.BigKey,
                        InventoryItemType.Compass,
                        InventoryItemType.Key,
                        InventoryItemType.Key,
                        InventoryItemType.Key,
                        InventoryItemType.Key,
                        InventoryItemType.Key,
                        InventoryItemType.Key,
                        InventoryItemType.Map,
                    };
                case Region.SwampPalace:
                case Region.ThievesTown:
                    return new List<InventoryItemType>
                    {
                        InventoryItemType.BigKey,
                        InventoryItemType.Compass,
                        InventoryItemType.Key,
                        InventoryItemType.Map,
                    };
                case Region.SkullWoods:
                case Region.MiseryMire:
                case Region.GanonsTower:
                    return new List<InventoryItemType>
                    {
                        InventoryItemType.BigKey,
                        InventoryItemType.Compass,
                        InventoryItemType.Key,
                        InventoryItemType.Key,
                        InventoryItemType.Key,
                        InventoryItemType.Map,
                    };
                case Region.IcePalace:
                    return new List<InventoryItemType>
                    {
                        InventoryItemType.BigKey,
                        InventoryItemType.Compass,
                        InventoryItemType.Key,
                        InventoryItemType.Key,
                        InventoryItemType.Map,
                    };
                case Region.TurtleRock:
                    return new List<InventoryItemType>
                    {
                        InventoryItemType.BigKey,
                        InventoryItemType.Compass,
                        InventoryItemType.Key,
                        InventoryItemType.Key,
                        InventoryItemType.Key,
                        InventoryItemType.Key,
                        InventoryItemType.Map,
                    };
                default:
                    return new List<InventoryItemType>();
            }
        }

        private static void AdjustCandidateItems(List<InventoryItemType> candidateItemList, List<InventoryItemType> haveItems, IRomLocations romLocations)
        {
            // require Boots before Titan's Mitt
            if (candidateItemList.Contains(InventoryItemType.TitansMitt) && !haveItems.Contains(InventoryItemType.PegasusBoots))
            {
                candidateItemList.Remove(InventoryItemType.TitansMitt);
            }

            // stop double-item-needed deadlocks
            if (candidateItemList.Count == 0)
            {
                var trockMedallion = romLocations.GetItemAtLocation<InventoryItem>(romLocations.SpecialLocations, "Required Medallion - Turtle Rock").Type;
                AddUnownedItem(candidateItemList, haveItems, trockMedallion);
                AddUnownedItem(candidateItemList, haveItems, InventoryItemType.FireRod);
            }
        }

        private static void AddUnownedItem(List<InventoryItemType> candidateItemList, List<InventoryItemType> haveItems, InventoryItemType item)
        {
            if (!haveItems.Contains(item))
            {
                candidateItemList.Add(item);
            }
        }

        private void GenerateItemList()
        {
            romLocations.ResetLocations();
            haveItems = new List<InventoryItemType>();
            itemPool = romLocations.GetItemPool(random);
            var unavailableLocations = romLocations.GetUnavailableLocations(itemPool);

            for (int i = itemPool.Count; i < 100 - unavailableLocations.Count; i++)
            {
                itemPool.Add(InventoryItemType.Nothing);
            }
        }

        private void CalculateComplexity()
        {
            var have = new List<InventoryItemType>();
            var remainingLocations = romLocations.Locations.Where(x => x.Item is InventoryItem).ToList();
            remainingLocations.AddRange(romLocations.SpecialLocations.Where(x => x.Item is CrystalItem || x.Item is PendantItem).ToList());
            var newReachableLocations = remainingLocations.Where(x => x.CanAccess(have)).ToList();
            complexity = 0;

            while (newReachableLocations.Any())
            {
                log?.AddReachableKeyItems(newReachableLocations.Where(x => x.Item is CrystalItem || x.Item is PendantItem || Item.IsKeyItem(((InventoryItem)x.Item).Type)).ToList());
                have.AddRange(newReachableLocations.Where(x => x.Item is InventoryItem).ToList().ConvertAll(x => ((InventoryItem)x.Item).Type));
                remainingLocations = remainingLocations.Except(newReachableLocations).ToList();
                complexity++;
                newReachableLocations = remainingLocations.Where(x => x.CanAccess(have)).ToList();
            }
        }
    }
}
