using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AlttpRandomizer.IO;
using AlttpRandomizer.Net;
using AlttpRandomizer.Properties;
using AlttpRandomizer.Rom;

namespace AlttpRandomizer.Random
{
	public enum RandomizerDifficulty
	{
		Casual = 0,
	}

	public class Randomizer
	{
		private static SeedRandom random;
		private List<ItemType> haveItems;
		private List<ItemType> itemPool;
		private readonly int seed;
		private readonly IRomLocations romLocations;
		private RandomizerLog log;

		public Randomizer(int seed, IRomLocations romLocations, RandomizerLog log)
		{
			random = new SeedRandom(seed);
			this.romLocations = romLocations;
			this.seed = seed;
			this.log = log;
		}

		public void CreateRom(string filename)
		{
			if (filename.Contains("\\") && !Directory.Exists(filename.Substring(0, filename.LastIndexOf('\\'))))
				Directory.CreateDirectory(filename.Substring(0, filename.LastIndexOf('\\')));

			GenerateItemList();
			GenerateDungeonItems();
			GenerateItemPositions();
			WriteRom(filename);
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

		private void GenerateHyruleCastleEscapeItems()
		{
			var locations = romLocations.Locations.Where(x => x.Region == Region.HyruleCastleEscape).ToList();
			var keys = 2;

			var currentLocations = locations.Where(x => x.Item == null && x.KeysNeeded <= keys).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);
			keys++;

			currentLocations = locations.Where(x => x.Item == null && x.KeysNeeded <= keys).ToList();
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
			var keys = 0;
			List<Location> currentLocations;

			for (int addKeys = 6; addKeys > 0; addKeys--)
			{
				currentLocations = locations.Where(x => x.Item == null && x.KeysNeeded <= keys).ToList();
				currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);
				keys++;
			}

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
			var keys = 0;

			var currentLocations = locations.Where(x => x.Item == null && x.KeysNeeded <= keys).ToList();
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
			var keys = 2;
			List<Location> currentLocations;

			for (int addKeys = 3; addKeys > 0; addKeys--)
			{
				currentLocations = locations.Where(x => x.Item == null && x.KeysNeeded <= keys).ToList();
				currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);
				keys++;
			}

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
			List<Location> currentLocations;

			currentLocations = locations.Where(x => x.Item == null && !x.BigKeyNeeded).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.BigKey);

			var keys = 2;

			currentLocations = locations.Where(x => x.Item == null && x.KeysNeeded <= keys).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Map);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Compass);
		}

		private void GenerateIcePalaceItems()
		{
			var locations = romLocations.Locations.Where(x => x.Region == Region.IcePalace).ToList();
			var keys = 3;
			List<Location> currentLocations;

			for (int addKeys = 2; addKeys > 0; addKeys--)
			{
				currentLocations = locations.Where(x => x.Item == null && x.KeysNeeded <= keys).ToList();
				currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);
				keys++;
			}

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
			var keys = 1;
			List<Location> currentLocations;

			for (int addKeys = 3; addKeys > 0; addKeys--)
			{
				currentLocations = locations.Where(x => x.Item == null && x.KeysNeeded <= keys).ToList();
				currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);
				keys++;
			}

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
			var keys = 0;
			List<Location> currentLocations;

			currentLocations = locations.Where(x => x.Item == null && x.KeysNeeded <= keys).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);
			keys += 2;

			currentLocations = locations.Where(x => x.Item == null && x.KeysNeeded <= keys).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);
			keys += 2;

			currentLocations = locations.Where(x => x.Item == null && !x.BigKeyNeeded).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.BigKey);

			for (int addKeys = 2; addKeys > 0; addKeys--)
			{
				currentLocations = locations.Where(x => x.Item == null && x.KeysNeeded <= keys).ToList();
				currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);
				keys++;
			}

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Map);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Compass);
		}

		private void GenerateGanonsTowerItems()
		{
			var locations = romLocations.Locations.Where(x => x.Region == Region.GanonsTower).ToList();
			var keys = 4;
			List<Location> currentLocations;

			for (int addKeys = 2; addKeys > 0; addKeys--)
			{
				currentLocations = locations.Where(x => x.Item == null && x.KeysNeeded <= keys && !x.BigKeyNeeded).ToList();
				currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);
				keys++;
			}

			currentLocations = locations.Where(x => x.Item == null && x.KeysNeeded <= keys && !x.BigKeyNeeded).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.BigKey);

			currentLocations = locations.Where(x => x.Item == null && x.KeysNeeded <= keys).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Key);
			keys++;

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Map);

			currentLocations = locations.Where(x => x.Item == null).ToList();
			currentLocations[random.Next(currentLocations.Count)].Item = new Item(ItemType.Compass);
		}

		private void WriteRom(string filename)
		{
			string usedFilename = FileName.Fix(filename, string.Format(romLocations.SeedFileString, seed));

			using (var rom = new FileStream(usedFilename, FileMode.OpenOrCreate))
			{
				rom.Write(Resources.RomImage, 0, 1048576);

				foreach (var location in romLocations.Locations)
				{
					rom.Seek(location.Address, SeekOrigin.Begin);
				    var newItem = (byte)location.Item.HexValue;

                    rom.Write(new [] { newItem }, 0, 1);
				}

				WriteSeedInRom(rom);

				rom.Close();
			}

			log?.WriteLog(usedFilename);
		}

		private void WriteSeedInRom(FileStream rom)
		{
			string seedStr = string.Format(romLocations.SeedRomString, RandomizerVersion.Current, seed.ToString().PadLeft(7, '0')).PadRight(21).Substring(0, 21);
			rom.Seek(0x7fc0, SeekOrigin.Begin);
			rom.Write(StringToByteArray(seedStr), 0, 21);
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
					var oldMasterSwordEligible = romLocations.CanGetMasterSword(haveItems);
					haveItems.Add(candidateItem);
					AddCollateralItems(haveItems, candidateItem);
					var newMasterSwordEligible = romLocations.CanGetMasterSword(haveItems);

					var newLocations = romLocations.GetAvailableLocations(haveItems);

					if (newLocations.Count > currentLocations.Count || oldMasterSwordEligible != newMasterSwordEligible)
					{
						romLocations.TryInsertCandidateItem(currentLocations, candidateItemList, candidateItem);
					}

					haveItems.Remove(candidateItem);
					RemoveCollateralItems(haveItems, candidateItem);
				}

				// Grab an item from the candidate list if there are any, otherwise, grab a random item
				if (candidateItemList.Count > 0)
				{
					var insertedItem = candidateItemList[random.Next(candidateItemList.Count)];

					itemPool.Remove(insertedItem);
					haveItems.Add(insertedItem);
					AddCollateralItems(haveItems, insertedItem);
					AddMasterSwordItems(haveItems);

					int insertedLocation = romLocations.GetInsertedLocation(currentLocations, insertedItem, random);
					currentLocations[insertedLocation].Item = new Item(insertedItem);

					log?.AddOrderedItem(currentLocations[insertedLocation]);
				}
				else
				{
					ItemType insertedItem = romLocations.GetInsertedItem(currentLocations, itemPool, random);

					itemPool.Remove(insertedItem);
					haveItems.Add(insertedItem);
					AddCollateralItems(haveItems, insertedItem);
					AddMasterSwordItems(haveItems);

					int insertedLocation = romLocations.GetInsertedLocation(currentLocations, insertedItem, random);
					currentLocations[insertedLocation].Item = new Item(insertedItem);
				}
			} while (itemPool.Count > 0);

			var unavailableLocations = romLocations.GetUnavailableLocations(haveItems);

			foreach (var unavailableLocation in unavailableLocations)
			{
				unavailableLocation.Item = new Item(ItemType.Nothing);
			}

			log?.AddGeneratedItems(romLocations.Locations);
		}

        private void AddMasterSwordItems(List<ItemType> haveItems)
        {
            if (romLocations.CanGetMasterSword(haveItems))
            {
                if (!haveItems.Contains(ItemType.Ether))
                {
                    haveItems.Add(ItemType.Ether);
                }
                if (!haveItems.Contains(ItemType.Bombos))
                {
                    haveItems.Add(ItemType.Bombos);
                }
            }
        }

        private void RemoveCollateralItems(List<ItemType> itemList, ItemType insertedItem)
		{
			switch (insertedItem)
			{
				case ItemType.PegasusBoots:
					itemList.Remove(ItemType.BookOfMudora);
					break;
                case ItemType.Shovel:
                    itemList.Remove(ItemType.OcarinaInactive);
                    break;
            }
        }

		private void AddCollateralItems(List<ItemType> itemList, ItemType insertedItem)
		{
			switch (insertedItem)
			{
				case ItemType.PegasusBoots:
					itemList.Add(ItemType.BookOfMudora);
					break;
                case ItemType.Shovel:
                    itemList.Add(ItemType.OcarinaInactive);
			        break;
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
