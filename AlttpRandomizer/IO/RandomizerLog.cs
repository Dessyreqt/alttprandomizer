using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AlttpRandomizer.Net;
using AlttpRandomizer.Rom;

namespace AlttpRandomizer.IO
{
    public class RandomizerLog
    {
        private readonly List<Location> generatedItems;
        private readonly List<Location> orderedItems;
        private readonly List<Location> specialLocations;
        private readonly List<List<Location>> reachableKeyItems;
        private readonly string seed;

        public RandomizerLog(string seed)
        {
            generatedItems = new List<Location>();
            orderedItems = new List<Location>();
            specialLocations = new List<Location>();
            reachableKeyItems = new List<List<Location>>();
            this.seed = seed;
        }

        public void AddOrderedItem(Location location)
        {
            var minorItems = new List<InventoryItemType>
                             {
                                 InventoryItemType.BigKey,
                                 InventoryItemType.Compass,
                                 InventoryItemType.Key,
                                 InventoryItemType.Map,
                             };
            var inventoryItem = location.Item as InventoryItem;

            if (inventoryItem == null)
            {
                return;
            }

            if (minorItems.Contains(inventoryItem.Type))
            {
                return;
            }

            var extantLocation = orderedItems.FirstOrDefault(x => x.Name == location.Name);

            if (extantLocation != null)
            {
                orderedItems.Remove(extantLocation);
            }

            orderedItems.Add(location);
        }

        public void RemoveOrderedItems(Region region)
        {
            orderedItems.RemoveAll(x => x.Region == region);
        }

        public void AddGeneratedItems(List<Location> locations)
        {
            generatedItems.AddRange(locations);
        }

        public void AddSpecialLocations(List<Location> locations)
        {
            specialLocations.AddRange(locations);
        }
 
        public void AddReachableKeyItems(List<Location> Location)
        {
            reachableKeyItems.Add(Location);
        }

        public void WriteLog(string filename)
        {
            using (var writer = new StreamWriter(string.Format("{0}.spoilers.txt", filename)))
            {
                writer.Write(GetLogOutput());
            }
        }

        public string GetLogOutput()
        {
            var writer = new StringBuilder();

            AppendHeader(writer);
            AppendComplexityAnalysis(writer);
            AppendGeneratedItemOrder(writer);
            AppendInventoryItems(writer);
            AppendSpecialItems(writer);
            AppendMagicUpgrade(writer);

            return writer.ToString();
        }

        private void AppendInventoryItems(StringBuilder writer)
        {
            AppendLightWorldItems(writer);
            AppendDarkWorldItems(writer);
            AppendLightWorldDungeonItems(writer);
            AppendDarkWorldDungeonItems(writer);
            writer.AppendLine();
            writer.AppendLine();
        }

        private void AppendMagicUpgrade(StringBuilder writer)
        {
            foreach (var Location in generatedItems.Where(x => x.Item.HexValue != 0xFF && GetItemName(x.Item).StartsWith("1/")))
            {
                writer.AppendLine(string.Format("{0}{1}", "Magic Upgrade".PadRight(90, '.'), GetItemName(Location.Item)));
            }
            writer.AppendLine();
        }

        private void AppendSpecialItems(StringBuilder writer)
        {
            writer.AppendLine("Special Locations");
            writer.AppendLine("-----------------");
            foreach (var Location in specialLocations.Where(x => x.Item.HexValue != 0xFF).OrderBy(x => x.Name))
            {
                writer.AppendLine(string.Format("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item)));
            }
            writer.AppendLine();
        }

        private void AppendDarkWorldDungeonItems(StringBuilder writer)
        {
            writer.AppendLine("Dark Palace");
            writer.AppendLine("-----------");
            foreach (var Location in generatedItems.Where(x => x.Item.HexValue != 0xFF && x.Region == Region.DarkPalace).OrderBy(x => x.Name))
            {
                writer.AppendLine(string.Format("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item)));
            }
            writer.AppendLine();
            writer.AppendLine("Swamp Palace");
            writer.AppendLine("------------");
            foreach (var Location in generatedItems.Where(x => x.Item.HexValue != 0xFF && x.Region == Region.SwampPalace).OrderBy(x => x.Name))
            {
                writer.AppendLine(string.Format("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item)));
            }
            writer.AppendLine();
            writer.AppendLine("Skull Woods");
            writer.AppendLine("-----------");
            foreach (var Location in generatedItems.Where(x => x.Item.HexValue != 0xFF && x.Region == Region.SkullWoods).OrderBy(x => x.Name))
            {
                writer.AppendLine(string.Format("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item)));
            }
            writer.AppendLine();
            writer.AppendLine("Thieves Town");
            writer.AppendLine("------------");
            foreach (var Location in generatedItems.Where(x => x.Item.HexValue != 0xFF && x.Region == Region.ThievesTown).OrderBy(x => x.Name))
            {
                writer.AppendLine(string.Format("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item)));
            }
            writer.AppendLine();
            writer.AppendLine("Ice Palace");
            writer.AppendLine("----------");
            foreach (var Location in generatedItems.Where(x => x.Item.HexValue != 0xFF && x.Region == Region.IcePalace).OrderBy(x => x.Name))
            {
                writer.AppendLine(string.Format("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item)));
            }
            writer.AppendLine();
            writer.AppendLine("Misery Mire");
            writer.AppendLine("-----------");
            foreach (var Location in generatedItems.Where(x => x.Item.HexValue != 0xFF && x.Region == Region.MiseryMire).OrderBy(x => x.Name))
            {
                writer.AppendLine(string.Format("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item)));
            }
            writer.AppendLine();
            writer.AppendLine("Turtle Rock");
            writer.AppendLine("-----------");
            foreach (var Location in generatedItems.Where(x => x.Item.HexValue != 0xFF && x.Region == Region.TurtleRock).OrderBy(x => x.Name))
            {
                writer.AppendLine(string.Format("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item)));
            }
            writer.AppendLine();
            writer.AppendLine("Ganon's Tower");
            writer.AppendLine("-------------");
            foreach (var Location in generatedItems.Where(x => x.Item.HexValue != 0xFF && x.Region == Region.GanonsTower).OrderBy(x => x.Name))
            {
                writer.AppendLine(string.Format("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item)));
            }
            writer.AppendLine();
        }

        private void AppendLightWorldDungeonItems(StringBuilder writer)
        {
            writer.AppendLine("Hyrule Castle Escape");
            writer.AppendLine("--------------------");
            foreach (var Location in generatedItems.Where(x => x.Item.HexValue != 0xFF && x.Region == Region.HyruleCastleEscape).OrderBy(x => x.Name))
            {
                writer.AppendLine(string.Format("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item)));
            }
            writer.AppendLine();
            writer.AppendLine("Eastern Palace");
            writer.AppendLine("--------------");
            foreach (var Location in generatedItems.Where(x => x.Item.HexValue != 0xFF && x.Region == Region.EasternPalace).OrderBy(x => x.Name))
            {
                writer.AppendLine(string.Format("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item)));
            }
            writer.AppendLine();
            writer.AppendLine("Desert Palace");
            writer.AppendLine("-------------");
            foreach (var Location in generatedItems.Where(x => x.Item.HexValue != 0xFF && x.Region == Region.DesertPalace).OrderBy(x => x.Name))
            {
                writer.AppendLine(string.Format("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item)));
            }
            writer.AppendLine();
            writer.AppendLine("Tower of Hera");
            writer.AppendLine("-------------");
            foreach (var Location in generatedItems.Where(x => x.Item.HexValue != 0xFF && x.Region == Region.TowerOfHera).OrderBy(x => x.Name))
            {
                writer.AppendLine(string.Format("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item)));
            }
            writer.AppendLine();
            writer.AppendLine("Hyrule Castle Tower");
            writer.AppendLine("-------------------");
            foreach (var Location in generatedItems.Where(x => x.Item.HexValue != 0xFF && x.Region == Region.HyruleCastleTower).OrderBy(x => x.Name))
            {
                writer.AppendLine(string.Format("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item)));
            }
            writer.AppendLine();
        }

        private void AppendDarkWorldItems(StringBuilder writer)
        {
            writer.AppendLine("Dark World");
            writer.AppendLine("----------");
            foreach (var Location in generatedItems.Where(x => x.Item.HexValue != 0xFF && x.Region == Region.DarkWorld).OrderBy(x => x.Name))
            {
                writer.AppendLine(string.Format("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item)));
            }
            writer.AppendLine();
        }

        private void AppendLightWorldItems(StringBuilder writer)
        {
            writer.AppendLine("Light World");
            writer.AppendLine("-----------");
            foreach (var Location in generatedItems.Where(x => x.Item.HexValue != 0xFF && x.Region == Region.LightWorld).OrderBy(x => x.Name))
            {
                writer.AppendLine(string.Format("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item)));
            }
            writer.AppendLine();
        }

        private void AppendHeader(StringBuilder writer)
        {
            writer.AppendLine("A Link to the Past Randomizer Log");
            writer.AppendLine("---------------------------------");
            writer.AppendLine(string.Format("Version: {0}", RandomizerVersion.CurrentDisplay));
            writer.AppendLine(string.Format("Creation Date: {0}", DateTime.Now));
            writer.AppendLine(string.Format("Complexity: {0}", reachableKeyItems.Count));
            writer.AppendLine(string.Format("Seed: {0}", seed));
            writer.AppendLine();
            writer.AppendLine();
            writer.AppendLine();
        }

        private void AppendGeneratedItemOrder(StringBuilder writer)
        {
            writer.AppendLine("Generated Item Order");
            writer.AppendLine("--------------------");
            foreach (var Location in orderedItems)
            {
                writer.AppendLine(string.Format("{0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item)));
            }
            writer.AppendLine();
            writer.AppendLine();
            writer.AppendLine();
        }

        private void AppendComplexityAnalysis(StringBuilder writer)
        {
            writer.AppendLine("Complexity Analysis");
            writer.AppendLine("-------------------");
            for (int i = 0; i < reachableKeyItems.Count; i++)
            {
                if (i == 0)
                {
                    writer.AppendLine("Step 1 - Items reachable from start:");
                }
                else
                {
                    writer.AppendLine(string.Format("Step {0} - Items reachable after collecting all items from Step {1}:", i + 1, i));
                }

                if (reachableKeyItems[i].Count == 0)
                {
                    writer.AppendLine("  (minor items only)");
                }
                else
                {
                    foreach (var Location in reachableKeyItems[i].OrderBy(x => x.Name))
                    {
                        writer.AppendLine(string.Format("  {0}{1}", Location.Name.PadRight(90, '.'), GetItemName(Location.Item)));
                    }
                }
                writer.AppendLine();
            }
            writer.AppendLine();
            writer.AppendLine();
        }

        private string GetItemName(Item item)
        {
            var inventoryItem = item as InventoryItem;
            if (inventoryItem != null)
            {
                switch (inventoryItem.Type)
                {
                    case InventoryItemType.L2SwordPedestal:
                    case InventoryItemType.L2Sword:
                        return "Master Sword";
                    case InventoryItemType.L3Sword:
                        return "Tempered Sword";
                    case InventoryItemType.L4Sword:
                        return "Gold Sword";
                    case InventoryItemType.RedShield:
                        return "Red Shield";
                    case InventoryItemType.MirrorShield:
                        return "Mirror Shield";
                    case InventoryItemType.FireRod:
                        return "Fire Rod";
                    case InventoryItemType.IceRod:
                        return "Ice Rod";
                    case InventoryItemType.Hammer:
                        return "Hammer";
                    case InventoryItemType.Hookshot:
                        return "Hookshot";
                    case InventoryItemType.Bow:
                        return "Bow";
                    case InventoryItemType.Boomerang:
                        return "Boomerang";
                    case InventoryItemType.Powder:
                        return "Magic Powder";
                    case InventoryItemType.Bombos:
                        return "Bombos";
                    case InventoryItemType.Ether:
                        return "Ether";
                    case InventoryItemType.Quake:
                        return "Quake";
                    case InventoryItemType.Lamp:
                        return "Lamp";
                    case InventoryItemType.Shovel:
                        return "Shovel";
                    case InventoryItemType.OcarinaInactive:
                        return "Ocarina";
                    case InventoryItemType.CaneOfSomaria:
                        return "Cane of Somaria";
                    case InventoryItemType.Bottle:
                        return "Bottle";
                    case InventoryItemType.PieceOfHeart:
                        return "Piece of Heart";
                    case InventoryItemType.StaffOfByrna:
                        return "Staff of Byrna";
                    case InventoryItemType.Cape:
                        return "Cape";
                    case InventoryItemType.MagicMirror:
                        return "Magic Mirror";
                    case InventoryItemType.PowerGlove:
                        return "Power Glove";
                    case InventoryItemType.TitansMitt:
                        return "Titan's Mitt";
                    case InventoryItemType.BookOfMudora:
                        return "Book of Mudora";
                    case InventoryItemType.Flippers:
                        return "Flippers";
                    case InventoryItemType.MoonPearl:
                        return "Moon Pearl";
                    case InventoryItemType.BugCatchingNet:
                        return "Bug-Catching Net";
                    case InventoryItemType.BlueMail:
                        return "Blue Mail";
                    case InventoryItemType.RedMail:
                        return "Red Mail";
                    case InventoryItemType.Key:
                        return "Key";
                    case InventoryItemType.Compass:
                        return "Compass";
                    case InventoryItemType.ThreeBombs:
                        return "3 Bombs";
                    case InventoryItemType.Mushroom:
                        return "Mushroom";
                    case InventoryItemType.RedBoomerang:
                        return "Red Boomerang";
                    case InventoryItemType.BottleWithRedPotion:
                    case InventoryItemType.RedPotion:
                        return "Bottle (Red Potion)";
                    case InventoryItemType.BottleWithGreenPotion:
                    case InventoryItemType.GreenPotion:
                        return "Bottle (Green Potion)";
                    case InventoryItemType.BottleWithBluePotion:
                    case InventoryItemType.BluePotion:
                        return "Bottle (Blue Potion)";
                    case InventoryItemType.BigKey:
                        return "Big Key";
                    case InventoryItemType.Map:
                        return "Map";
                    case InventoryItemType.OneRupee:
                        return "1 Rupee";
                    case InventoryItemType.FiveRupees:
                        return "5 Rupees";
                    case InventoryItemType.TwentyRupees:
                        return "20 Rupees";
                    case InventoryItemType.Bee:
                    case InventoryItemType.BottleWithBee:
                        return "Bottle (Bee)";
                    case InventoryItemType.BottleWithFairy:
                        return "Bottle (Fairy)";
                    case InventoryItemType.HeartContainerNoRefill:
                        return "Heart Container";
                    case InventoryItemType.HeartContainer:
                        return "Heart Container + Refill";
                    case InventoryItemType.OneHundredRupees:
                        return "100 Rupees";
                    case InventoryItemType.FiftyRupees:
                        return "50 Rupees";
                    case InventoryItemType.Arrow:
                        return "1 Arrow";
                    case InventoryItemType.TenArrows:
                        return "10 Arrows";
                    case InventoryItemType.ThreeHundredRupees:
                        return "300 Rupees";
                    case InventoryItemType.BottleWithGoldBee:
                        return "Bottle (Gold Bee)";
                    case InventoryItemType.PegasusBoots:
                        return "Pegasus Boots";
                    case InventoryItemType.HalfMagic:
                        return "1/2 Magic";
                    case InventoryItemType.QuarterMagic:
                        return "1/4 Magic";
                    case InventoryItemType.FiftyBombCap:
                        return "50 Bomb Cap";
                    case InventoryItemType.SeventyArrowCap:
                        return "70 Arrow Cap";
                    default:
                        throw new ArgumentException("Couldn't get item type!", "item");
                }
            }

            var pendantItem = item as PendantItem;
            if (pendantItem != null)
            {
                switch (pendantItem.Type)
                {
                    case PendantItemType.None:
                        return "No Pendant";
                    case PendantItemType.RedPendant:
                        return "Pendant of Wisdom (Red)";
                    case PendantItemType.BluePendant:
                        return "Pendant of Power (Blue)";
                    case PendantItemType.GreenPendant:
                        return "Pendant of Courage (Green)";
                    default:
                        throw new ArgumentException("Couldn't get item type!", "item");
                }
            }

            var crystalItem = item as CrystalItem;
            if (crystalItem != null)
            {
                switch (crystalItem.Type)
                {
                    case CrystalItemType.None:
                        return "No Crystal";
                    case CrystalItemType.Crystal6:
                        return "Crystal 6 (Green)";
                    case CrystalItemType.Crystal1:
                        return "Crystal 1 (Orange/Red)";
                    case CrystalItemType.Crystal5:
                        return "Crystal 5 (Green/Red)";
                    case CrystalItemType.Crystal7:
                        return "Crystal 7 (Zelda)";
                    case CrystalItemType.Crystal2:
                        return "Crystal 2 (Pink/White)";
                    case CrystalItemType.Crystal4:
                        return "Crystal 4 (Pink/Red)";
                    case CrystalItemType.Crystal3:
                        return "Crystal 3 (Yellow/Brown)";
                    default:
                        throw new ArgumentException("Couldn't get item type!", "item");
                }
            }

            throw new ArgumentException("Couldn't get item type!", "item");
        }
    }
}
