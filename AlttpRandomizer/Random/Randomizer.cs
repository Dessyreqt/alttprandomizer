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
        None,
		Casual,
	}

    public class RandomizerOptions
    {
        public string Filename { get; set; }
        public bool SpoilerOnly { get; set; }
        public bool SramTrace { get; set; }

        public RandomizerOptions()
        {
            Filename = "";
            SpoilerOnly = false;
            SramTrace = false;
        }
    }

	public class Randomizer
	{
		private static SeedRandom random;
		private List<ItemType> haveItems;
		private List<ItemType> itemPool;
		private readonly int seed;
		private readonly IRomLocations romLocations;
		private readonly RandomizerLog log;

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
		        if (options.Filename.Contains("\\") && !Directory.Exists(options.Filename.Substring(0, options.Filename.LastIndexOf('\\'))))
		        {
		            Directory.CreateDirectory(options.Filename.Substring(0, options.Filename.LastIndexOf('\\')));
		        }

                GenerateItemList();
                GenerateDungeonItems();
                GenerateItemPositions();

                if (RandomizerVersion.Debug)
                {
                    SetupTestItems(romLocations.Locations);
                }

                if (options.SpoilerOnly)
		        {
		            return log?.GetLogOutput();
		        }

                WriteRom(options.Filename, options.SramTrace);

		        return "";
		    }
            catch (Exception ex)
		    {
                var newEx = new RandomizationException(string.Format("Error creating seed: {0}.", string.Format(romLocations.SeedFileString, seed)), ex);

		        throw newEx;
		    }
		}

        private void WriteRngItems(FileStream rom)
        {
            for (int address = 0x178000; address <= 0x1783ff; address++)
            {
                var randomValue = (byte)random.Next(0x100);
                rom.Seek(address, SeekOrigin.Begin);
                rom.Write(new[] { randomValue }, 0, 1);
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
            //location.Item = new Item(ItemType.RedBoomerang);

            //// add blue boomerang 
            //location = locations.First(x => x.Name == "[cave-022-B1] Thief's hut [top left chest]");
            //location.Item = new Item(ItemType.Boomerang);

            //// add powder
            //location = locations.First(x => x.Name == "[cave-022-B1] Thief's hut [top right chest]");
            //location.Item = new Item(ItemType.Powder);

            //// add flute
            //location = locations.First(x => x.Name == "[cave-022-B1] Thief's hut [bottom left chest]");
            //location.Item = new Item(ItemType.OcarinaInactive);

            //// add mushroom
            //location = locations.First(x => x.Name == "[cave-022-B1] Thief's hut [bottom right chest]");
            //location.Item = new Item(ItemType.Mushroom);

            //// add shovel
            //location = locations.First(x => x.Name == "Bottle Vendor");
            //location.Item = new Item(ItemType.Shovel);

            //// Link's House
            //var location = locations.First(x => x.Name == "[cave-040] Link's House");
            //location.Item = new Item(ItemType.Bottle);

            //// After Sword
            //location = locations.First(x => x.Name == "[cave-034] Hyrule Castle secret entrance");
            //location.Item = new Item(ItemType.BottleWithRedPotion);
        }

        private void GenerateDungeonItems()
		{
			GenerateHyruleCastleEscapeItems();
			GenerateEasternPalaceItems();
			GenerateDesertPalaceItems();
			GenerateTowerOfHeraItems();
			GenerateHyruleCastleTowerItems();
			GenerateDarkPalaceItems();
			GenerateSwampPalaceItems();
			GenerateSkullWoodsItems();
			GenerateThievesTownItems();
			GenerateIcePalaceItems();
			GenerateMiseryMireItems();
			GenerateTurtleRockItems();
			GenerateGanonsTowerItems();
		}

        private static bool IsInKeyZone(Location location, int zone)
        {
            return location.Item == null && !location.Name.Contains("big chest") && location.KeyZone == zone;
        }

        private static bool IsInOrBeforeKeyZone(Location location, int zone)
        {
            return location.Item == null && !location.Name.Contains("big chest") && location.KeyZone <= zone;
        }

        private void GenerateHyruleCastleEscapeItems()
		{
			var locations = romLocations.Locations.Where(x => x.Region == Region.HyruleCastleEscape).ToList();

            // key zone 2: 1 key
            var currentLocations = locations.Where(x => IsInOrBeforeKeyZone(x, 2)).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Map);
		}

		private void GenerateEasternPalaceItems()
		{
			var locations = romLocations.Locations.Where(x => x.Region == Region.EasternPalace).ToList();

			var currentLocations = locations.Where(x => x.Item == null && !x.BigKeyNeeded).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.BigKey);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Map);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Compass);
		}

		private void GenerateDesertPalaceItems()
		{
			var locations = romLocations.Locations.Where(x => x.Region == Region.DesertPalace).ToList();

			var currentLocations = locations.Where(x => x.Item == null && !x.BigKeyNeeded).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.BigKey);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Map);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Compass);
		}

		private void GenerateTowerOfHeraItems()
		{
			var locations = romLocations.Locations.Where(x => x.Region == Region.TowerOfHera).ToList();

			var currentLocations = locations.Where(x => x.Item == null && !x.BigKeyNeeded).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.BigKey);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Map);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Compass);
		}

		private void GenerateHyruleCastleTowerItems()
		{
			var locations = romLocations.Locations.Where(x => x.Region == Region.HyruleCastleTower).ToList();

			// there are only keys in chests in this dungeon. Boring.
			foreach (var location in locations)
			{
				location.Item = new Item(ItemType.Key);
			}
		}

		private void GenerateDarkPalaceItems()
		{
			var locations = romLocations.Locations.Where(x => x.Region == Region.DarkPalace).ToList();

		    // key zone 0: 2 keys
            var currentLocations = locations.Where(x => IsInKeyZone(x, 0)).ToList();
            currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            currentLocations = locations.Where(x => IsInKeyZone(x, 0)).ToList();
            currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            // key zone 1: 2 keys
            currentLocations = locations.Where(x => IsInKeyZone(x, 1)).ToList();
            currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            currentLocations = locations.Where(x => IsInKeyZone(x, 1)).ToList();
            currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            // key zone 2: 1 key
            currentLocations = locations.Where(x => IsInKeyZone(x, 2)).ToList();
            currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            // key zone 3: 1 key
            currentLocations = locations.Where(x => IsInKeyZone(x, 3)).ToList();
            currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            currentLocations = locations.Where(x => x.Item == null && !x.BigKeyNeeded).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.BigKey);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Map);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Compass);
		}

	    private void GenerateSwampPalaceItems()
		{
			var locations = romLocations.Locations.Where(x => x.Region == Region.SwampPalace).ToList();

            // key zone 0: 1 key
            var currentLocations = locations.Where(x => IsInKeyZone(x, 0)).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

			currentLocations = locations.Where(x => x.Item == null && !x.BigKeyNeeded).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.BigKey);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Map);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Compass);
		}

		private void GenerateSkullWoodsItems()
		{
			var locations = romLocations.Locations.Where(x => x.Region == Region.SkullWoods).ToList();

            // key zone 0: 1 key
		    var currentLocations = locations.Where(x => IsInKeyZone(x, 0)).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            // key zone 1: 1 key
            currentLocations = locations.Where(x => IsInKeyZone(x, 1)).ToList();
            currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            // key zone 2: 1 key
            currentLocations = locations.Where(x => IsInKeyZone(x, 2)).ToList();
            currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            currentLocations = locations.Where(x => x.Item == null && !x.BigKeyNeeded).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.BigKey);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Map);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Compass);
		}

		private void GenerateThievesTownItems()
		{
			var locations = romLocations.Locations.Where(x => x.Region == Region.ThievesTown).ToList();

		    var currentLocations = locations.Where(x => IsInKeyZone(x, 0) && !x.BigKeyNeeded).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.BigKey);

            // key zone 1: 1 key
			currentLocations = locations.Where(x => IsInOrBeforeKeyZone(x, 1)).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Map);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Compass);
		}

		private void GenerateIcePalaceItems()
		{
			var locations = romLocations.Locations.Where(x => x.Region == Region.IcePalace).ToList();
			List<Location> currentLocations;

            // key zone 2: 2 keys
            currentLocations = locations.Where(x => IsInOrBeforeKeyZone(x, 2)).ToList();
            currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            currentLocations = locations.Where(x => IsInOrBeforeKeyZone(x, 2)).ToList();
            currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            currentLocations = locations.Where(x => x.Item == null && !x.BigKeyNeeded).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.BigKey);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Map);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Compass);
		}

		private void GenerateMiseryMireItems()
		{
			var locations = romLocations.Locations.Where(x => x.Region == Region.MiseryMire).ToList();

            // key zone 0: 2 keys
            var currentLocations = locations.Where(x => IsInKeyZone(x, 0)).ToList();
            currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            currentLocations = locations.Where(x => IsInKeyZone(x, 0)).ToList();
            currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            // key zone 1: 1 key
            currentLocations = locations.Where(x => IsInKeyZone(x, 0)).ToList();
            currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            currentLocations = locations.Where(x => x.Item == null && !x.BigKeyNeeded).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.BigKey);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Map);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Compass);
		}

		private void GenerateTurtleRockItems()
		{
			var locations = romLocations.Locations.Where(x => x.Region == Region.TurtleRock).ToList();

            // key zone 0: 1 key
		    var currentLocations = locations.Where(x => IsInKeyZone(x, 0)).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            // key zone 2: 1 key
			currentLocations = locations.Where(x => IsInOrBeforeKeyZone(x, 2)).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

			currentLocations = locations.Where(x => x.Item == null && !x.BigKeyNeeded).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.BigKey);

            // key zone 5: 1 key
            currentLocations = locations.Where(x => IsInOrBeforeKeyZone(x, 5)).ToList();
            currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            // key zone 6: 1 key
            currentLocations = locations.Where(x => IsInKeyZone(x, 6)).ToList();
            currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Map);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Compass);
		}

		private void GenerateGanonsTowerItems()
		{
			var locations = romLocations.Locations.Where(x => x.Region == Region.GanonsTower).ToList();

            // key zone 0: 1 key 
		    var currentLocations = locations.Where(x => IsInKeyZone(x, 0)).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            // key zone 1: 1 key
            currentLocations = locations.Where(x => IsInKeyZone(x, 1)).ToList();
            currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

            currentLocations = locations.Where(x => IsInKeyZone(x, 2) && !x.BigKeyNeeded).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.BigKey);

            // key zone 4: 1 key
			currentLocations = locations.Where(x => IsInOrBeforeKeyZone(x, 4)).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Map);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Compass);
		}

		private void WriteRom(string filename, bool sramTrace)
		{
			string usedFilename = FileName.Fix(filename, string.Format(romLocations.SeedFileString, seed));

			using (var rom = new FileStream(usedFilename, FileMode.OpenOrCreate))
			{
				rom.Write(Resources.RomImage, 0, 2097152);

                foreach (var location in romLocations.Locations)
                {
                    rom.Seek(location.Address, SeekOrigin.Begin);
                    var newItem = (byte)location.Item.HexValue;

                    rom.Write(new[] { newItem }, 0, 1);

                    location.WriteItemCheck?.Invoke(rom, location.Item.Type);
                }
                foreach (var location in romLocations.SpecialLocations)
                {
                    if (location.Address != default(int))
                    {
                        rom.Seek(location.Address, SeekOrigin.Begin);
                        var newItem = (byte) location.Item.HexValue;

                        rom.Write(new[] {newItem}, 0, 1);
                    }
                    location.WriteItemCheck?.Invoke(rom, location.Item.Type);
                }

                WriteSeedInRom(rom);
                WriteRngItems(rom);

                if (sramTrace)
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
            rom.Seek(0x57, SeekOrigin.Begin);
            rom.Write(new byte[] { 0x00, 0x80, 0x21 }, 0, 3);
        }

        private void WriteDebugModeToRom(FileStream rom)
        {
            rom.Seek(0x65b88, SeekOrigin.Begin);
            rom.Write(StringToByteArray("\xea\xea"), 0, 2);
            rom.Seek(0x65b91, SeekOrigin.Begin);
            rom.Write(StringToByteArray("\xea\xea"), 0, 2);
        }

        private void WriteSeedInRom(FileStream rom)
		{
			string seedStr = string.Format(romLocations.SeedRomString, RandomizerVersion.Current, seed.ToString().PadLeft(7, '0')).PadRight(21).Substring(0, 21);
            rom.Seek(0x7fc0, SeekOrigin.Begin);
            rom.Write(StringToByteArray(seedStr), 0, 21);
            rom.Seek(0x180210, SeekOrigin.Begin);
            rom.Write(StringToByteArray(romLocations.SeedFileString), 0, 1);
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
			do
			{
				var currentLocations = romLocations.GetAvailableLocations(haveItems);
				var candidateItemList = new List<ItemType>();

				// Generate candidate item list
				foreach (var candidateItem in itemPool)
				{
					haveItems.Add(candidateItem);
					var newLocations = romLocations.GetAvailableLocations(haveItems);

					if (newLocations.Count > currentLocations.Count)
					{
						romLocations.TryInsertCandidateItem(currentLocations, candidateItemList, candidateItem);
					}

					haveItems.Remove(candidateItem);
				}

			    AdjustCandidateItems(candidateItemList, haveItems, romLocations);

                // Grab an item from the candidate list if there are any, otherwise, grab a random item
                if (candidateItemList.Count > 0)
				{
					var insertedItem = candidateItemList[random.Next(candidateItemList.Count)];

					itemPool.Remove(insertedItem);
					haveItems.Add(insertedItem);

                    int insertedLocation = romLocations.GetInsertedLocation(currentLocations, insertedItem, random);
					currentLocations[insertedLocation].Item = new Item(insertedItem);

					log?.AddOrderedItem(currentLocations[insertedLocation]);
				}
				else
				{
				    try
				    {
                        ItemType insertedItem = romLocations.GetInsertedItem(currentLocations, itemPool, random);

                        itemPool.Remove(insertedItem);
                        haveItems.Add(insertedItem);

                        int insertedLocation = romLocations.GetInsertedLocation(currentLocations, insertedItem, random);
                        currentLocations[insertedLocation].Item = new Item(insertedItem);
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

                                foreach (var item in itemPool)
                                {
                                    writer.WriteLine(item);
                                }
                            }
                        }
				        throw;
				    }
				}
			} while (itemPool.Count > 0);

			var unavailableLocations = romLocations.GetUnavailableLocations(haveItems);

			foreach (var unavailableLocation in unavailableLocations)
			{
				unavailableLocation.Item = new Item(ItemType.Nothing);
			}

            log?.AddGeneratedItems(romLocations.Locations);
            log?.AddSpecialLocations(romLocations.SpecialLocations);
        }

        private void AdjustCandidateItems(List<ItemType> candidateItemList, List<ItemType> haveItems, IRomLocations romLocations)
        {
            // require Boots before Titan's Mitt
            if (candidateItemList.Contains(ItemType.TitansMitt) && !haveItems.Contains(ItemType.PegasusBoots))
            {
                candidateItemList.Remove(ItemType.TitansMitt);
            }

            // stop double-item-needed deadlocks
            if (candidateItemList.Count == 0)
            {
                var trockMedallion = romLocations.SpecialLocations.First(x => x.Name == "Turtle Rock Required Medallion").Item.Type;
                AddUnownedItem(candidateItemList, haveItems, trockMedallion);
                AddUnownedItem(candidateItemList, haveItems, ItemType.FireRod);
            }
        }

	    private static void AddUnownedItem(List<ItemType> candidateItemList, List<ItemType> haveItems, ItemType item)
	    {
	        if (!haveItems.Contains(item))
	        {
	            candidateItemList.Add(item);
	        }
	    }

	    private void GenerateItemList()
		{
			romLocations.ResetLocations();
			haveItems = new List<ItemType>();
			itemPool = romLocations.GetItemPool(random);
			var unavailableLocations = romLocations.GetUnavailableLocations(itemPool);

			for (int i = itemPool.Count; i < 100 - unavailableLocations.Count; i++)
			{
				itemPool.Add(ItemType.Nothing);
			}
		}
	}
}
