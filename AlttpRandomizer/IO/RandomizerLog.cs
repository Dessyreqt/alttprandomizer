using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlttpRandomizer.Net;
using AlttpRandomizer.Rom;

namespace AlttpRandomizer.IO
{
	public class RandomizerLog
	{
		private readonly List<Location> generatedItems;
		private readonly List<Location> orderedItems;
		private readonly string seed;

		public RandomizerLog(string seed)
		{
			generatedItems = new List<Location>();
			orderedItems = new List<Location>();
			this.seed = seed;
		}

		public void AddOrderedItem(Location Location)
		{
			orderedItems.Add(Location);
		}

		public void AddGeneratedItems(List<Location> Locations)
		{
			generatedItems.AddRange(Locations);
		}

		public void WriteLog(string filename)
		{
			using (var writer = new StreamWriter(string.Format("{0}.spoilers.txt", filename)))
			{
				writer.WriteLine("A Link to the Past Randomizer Log");
				writer.WriteLine("---------------------------------");
				writer.WriteLine("Version: {0}", RandomizerVersion.Current);
				writer.WriteLine("Creation Date: {0}", DateTime.Now);
				writer.WriteLine("Seed: {0}", seed);
				writer.WriteLine();
				writer.WriteLine("Generated Item Order");
				writer.WriteLine("--------------------");
				foreach (var Location in orderedItems)
				{
					writer.WriteLine("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item));
				}
				writer.WriteLine();
				writer.WriteLine();
				writer.WriteLine();
				writer.WriteLine("Light World");
				writer.WriteLine("-----------");
				foreach (var Location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.LightWorld).OrderBy(x => x.Name))
				{
					writer.WriteLine("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item));
				}
				writer.WriteLine();
				writer.WriteLine("Dark World");
				writer.WriteLine("----------");
				foreach (var Location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.DarkWorld).OrderBy(x => x.Name))
				{
					writer.WriteLine("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item));
				}
				writer.WriteLine();
				writer.WriteLine("Hyrule Castle Escape");
				writer.WriteLine("--------------------");
				foreach (var Location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.HyruleCastleEscape).OrderBy(x => x.Name))
				{
					writer.WriteLine("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item));
				}
				writer.WriteLine();
				writer.WriteLine("Eastern Palace");
				writer.WriteLine("--------------");
				foreach (var Location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.EasternPalace).OrderBy(x => x.Name))
				{
					writer.WriteLine("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item));
				}
				writer.WriteLine();
				writer.WriteLine("Desert Palace");
				writer.WriteLine("-------------");
				foreach (var Location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.DesertPalace).OrderBy(x => x.Name))
				{
					writer.WriteLine("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item));
				}
				writer.WriteLine();
				writer.WriteLine("Tower of Hera");
				writer.WriteLine("-------------");
				foreach (var Location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.TowerOfHera).OrderBy(x => x.Name))
				{
					writer.WriteLine("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item));
				}
				writer.WriteLine();
				writer.WriteLine("Hyrule Castle Tower");
				writer.WriteLine("-------------------");
				foreach (var Location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.HyruleCastleTower).OrderBy(x => x.Name))
				{
					writer.WriteLine("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item));
				}
				writer.WriteLine();
				writer.WriteLine("Dark Palace");
				writer.WriteLine("-----------");
				foreach (var Location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.DarkPalace).OrderBy(x => x.Name))
				{
					writer.WriteLine("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item));
				}
				writer.WriteLine();
				writer.WriteLine("Swamp Palace");
				writer.WriteLine("------------");
				foreach (var Location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.SwampPalace).OrderBy(x => x.Name))
				{
					writer.WriteLine("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item));
				}
				writer.WriteLine();
				writer.WriteLine("Skull Woods");
				writer.WriteLine("-----------");
				foreach (var Location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.SkullWoods).OrderBy(x => x.Name))
				{
					writer.WriteLine("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item));
				}
				writer.WriteLine();
				writer.WriteLine("Thieves Town");
				writer.WriteLine("------------");
				foreach (var Location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.ThievesTown).OrderBy(x => x.Name))
				{
					writer.WriteLine("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item));
				}
				writer.WriteLine();
				writer.WriteLine("Ice Palace");
				writer.WriteLine("----------");
				foreach (var Location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.IcePalace).OrderBy(x => x.Name))
				{
					writer.WriteLine("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item));
				}
				writer.WriteLine();
				writer.WriteLine("Misery Mire");
				writer.WriteLine("-----------");
				foreach (var Location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.MiseryMire).OrderBy(x => x.Name))
				{
					writer.WriteLine("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item));
				}
				writer.WriteLine();
				writer.WriteLine("Turtle Rock");
				writer.WriteLine("-----------");
				foreach (var Location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.TurtleRock).OrderBy(x => x.Name))
				{
					writer.WriteLine("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item));
				}
				writer.WriteLine();
				writer.WriteLine("Ganon's Tower");
				writer.WriteLine("-------------");
				foreach (var Location in generatedItems.Where(x => x.Item.Type != ItemType.Nothing && x.Region == Region.GanonsTower).OrderBy(x => x.Name))
				{
					writer.WriteLine("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item));
				}
				writer.WriteLine();
			}
		}

		private string GetItemName(Item item)
		{
			switch (item.Type)
			{
				case ItemType.L1SwordAndShield:
					return "L1 Sword & Shield";
				case ItemType.MirrorShield:
					return "Mirror Shield";
				case ItemType.FireRod:
					return "Fire Rod";
				case ItemType.IceRod:
					return "Ice Rod";
				case ItemType.Hammer:
					return "Hammer";
				case ItemType.Hookshot:
					return "Hookshot";
				case ItemType.Bow:
					return "Bow";
				case ItemType.Boomerang:
					return "Boomerang / 10 Arrows";
				case ItemType.Ether:
					return "Ether";
				case ItemType.Quake:
					return "Quake";
				case ItemType.Lamp:
					return "Lamp / 5 rupees";
				case ItemType.Shovel:
					return "Shovel";
				case ItemType.OcarinaInactive:
					return "Ocarina";
				case ItemType.CaneOfSomaria:
					return "Cane of Somaria";
				case ItemType.Bottle:
					return "Bottle";
				case ItemType.PieceOfHeart:
					return "Piece of Heart";
				case ItemType.StaffOfByrna:
					return "Staff of Byrna";
				case ItemType.Cape:
					return "Cape";
				case ItemType.MagicMirror:
					return "Magic Mirror";
				case ItemType.PowerGlove:
					return "Power Glove";
				case ItemType.TitansMitt:
					return "Titan's Mitt";
				case ItemType.BookOfMudora:
					return "Book of Mudora";
				case ItemType.Flippers:
					return "Flippers";
				case ItemType.MoonPearl:
					return "Moon Pearl";
				case ItemType.BugCatchingNet:
					return "Bug-Catching Net";
				case ItemType.BlueMail:
					return "Blue Mail";
				case ItemType.RedMail:
					return "Red Mail";
				case ItemType.Key:
					return "Key";
				case ItemType.Compass:
					return "Compass";
				case ItemType.ThreeBombs:
					return "3 Bombs";
				case ItemType.RedBoomerang:
					return "Red Boomerang / 300 Rupees";
				case ItemType.BigKey:
					return "Big Key";
				case ItemType.Map:
					return "Map";
				case ItemType.OneRupee:
					return "1 Rupee";
				case ItemType.FiveRupees:
					return "5 Rupees";
				case ItemType.TwentyRupees:
					return "20 Rupees";
				case ItemType.HeartContainer:
					return "Heart Container";
				case ItemType.OneHundredRupees:
					return "100 Rupees";
				case ItemType.FiftyRupees:
					return "50 Rupees";
				case ItemType.Arrow:
					return "1 Arrow";
				case ItemType.TenArrows:
					return "10 Arrows";
				case ItemType.ThreeHundredRupees:
					return "300 Rupees";
				case ItemType.PegasusBoots:
					return "Pegasus Boots";
				default:
					throw new ArgumentException("Couldn't get item type!", "item");
			}
		}
	}
}
