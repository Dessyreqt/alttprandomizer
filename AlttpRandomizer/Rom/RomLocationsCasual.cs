﻿using System;
using System.Collections.Generic;
using System.Linq;
using AlttpRandomizer.IO;
using AlttpRandomizer.Random;

namespace AlttpRandomizer.Rom
{
    public class RomLocationsCasual : BaseRomLocations, IRomLocations
    {
        public override List<Location> Locations { get; set; }
        public override List<Location> SpecialLocations { get; set; }
        public string DifficultyName => "Casual";
        public string SeedFileString => "C{0:0000000}";
        public string SeedRomString => "Z3Rv{0} C{1}";

        public void ResetLocations()
        {
            Locations = new List<Location>
            {
                new Location
                {
                    LateGameItem = false,
                    Region = Region.HyruleCastleEscape,
                    Name = "[dungeon-C-B1] Escape - first B1 room",
                    Address = 0xE96E,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-034] Hyrule Castle secret entrance",
                    Address = 0xE971,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.HyruleCastleEscape,
                    Name = "[dungeon-C-B1] Hyrule Castle - boomerang room",
                    Address = 0xE974,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.EasternPalace,
                    Name = "[dungeon-L1-1F] Eastern Palace - compass room",
                    Address = 0xE977,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-018] Graveyard - top right grave",
                    Address = 0xE97A,
                    CanAccess =
                        have =>
                        have.Contains(InventoryItemType.PegasusBoots)
                        && (have.Contains(InventoryItemType.TitansMitt)
                            || (CanAccessNorthWestDarkWorld(have)
                                && have.Contains(InventoryItemType.MoonPearl)
                                && have.Contains(InventoryItemType.MagicMirror))),
                },
                new Location
                {             
                    LateGameItem = false,
                    Region = Region.EasternPalace,
                    Name = "[dungeon-L1-1F] Eastern Palace - big chest",
                    Address = 0xE97D,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SwampPalace,
                    Name = "[dungeon-D2-B1] Swamp Palace - map room",
                    Address = 0xE986,
                    CanAccess =
                        have =>
                        CanEnterSwampPalace(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SwampPalace,
                    Name = "[dungeon-D2-B1] Swamp Palace - big chest",
                    Address = 0xE989,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanEnterSwampPalace(have)
                        && have.Contains(InventoryItemType.Hammer)
                        && (have.Contains(InventoryItemType.Hookshot)
                            || (!LocationHasItem("[dungeon-D2-B2] Swamp Palace - flooded room [left chest]",InventoryItemType.BigKey)
                                && !LocationHasItem("[dungeon-D2-B2] Swamp Palace - flooded room [right chest]",InventoryItemType.BigKey)
                                && !LocationHasItem("[dungeon-D2-B2] Swamp Palace - hidden waterfall door room",InventoryItemType.BigKey))),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-047] Dam",
                    Address = 0xE98C,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.DesertPalace,
                    Name = "[dungeon-L2-B1] Desert Palace - big chest",
                    Address = 0xE98F,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanEnterDesertPalace(have)
                        && (have.Contains(InventoryItemType.PegasusBoots)
                            || LocationHasItem("[dungeon-L2-B1] Desert Palace - Map room", InventoryItemType.BigKey)),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SkullWoods,
                    Name = "[dungeon-D3-B1] Skull Woods - Compass room",
                    Address = 0xE992,
                    CanAccess =
                        have =>
                        CanEnterSkullWoods(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.IcePalace,
                    Name = "[dungeon-D5-B4] Ice Palace - above Blue Mail room",
                    Address = 0xE995,
                    CanAccess =
                        have =>
                        CanEnterIcePalace(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SkullWoods,
                    Name = "[dungeon-D3-B1] Skull Woods - big chest",
                    Address = 0xE998,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanEnterSkullWoods(have) 
                        && (have.Contains(InventoryItemType.FireRod) 
                            || !LocationHasItem("[dungeon-D3-B1] Skull Woods - Entrance to part 2", InventoryItemType.BigKey)),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SkullWoods,
                    Name = "[dungeon-D3-B1] Skull Woods - east of Fire Rod room",
                    Address = 0xE99B,
                    CanAccess =
                        have =>
                        CanEnterSkullWoods(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SkullWoods,
                    Name = "[dungeon-D3-B1] Skull Woods - Big Key room",
                    Address = 0xE99E,
                    CanAccess =
                        have =>
                        CanEnterSkullWoods(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SkullWoods,
                    Name = "[dungeon-D3-B1] Skull Woods - Gibdo/Stalfos room",
                    Address = 0xE9A1,
                    CanAccess =
                        have =>
                        CanEnterSkullWoods(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.IcePalace,
                    Name = "[dungeon-D5-B1] Ice Palace - Big Key room",
                    Address = 0xE9A4,
                    CanAccess =
                        have =>
                        CanEnterIcePalace(have)
                        && have.Contains(InventoryItemType.Hammer)
                        && (have.Contains(InventoryItemType.Hookshot)
                            || ((LocationHasItem("[dungeon-D5-B3] Ice Palace - spike room", InventoryItemType.BigKey)
                                    || LocationHasItem("[dungeon-D5-B2] Ice Palace - map room", InventoryItemType.BigKey)
                                    || LocationHasItem("[dungeon-D5-B1] Ice Palace - Big Key room", InventoryItemType.BigKey))
                                && (LocationHasItem("[dungeon-D5-B1] Ice Palace - compass room", InventoryItemType.Key)
                                    || LocationHasItem("[dungeon-D5-B4] Ice Palace - above Blue Mail room", InventoryItemType.Key)
                                    || LocationHasItem("[dungeon-D5-B5] Ice Palace - b5 up staircase", InventoryItemType.Key)))),
                },

                new Location
                {
                    LateGameItem = true,
                    Region = Region.IcePalace,
                    Name = "[dungeon-D5-B5] Ice Palace - big chest",
                    Address = 0xE9AA,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanEnterIcePalace(have)
                        && (LocationHasItem("[dungeon-D5-B1] Ice Palace - compass room", InventoryItemType.BigKey)
                            || LocationHasItem("[dungeon-D5-B4] Ice Palace - above Blue Mail room", InventoryItemType.BigKey)
                            || LocationHasItem("[dungeon-D5-B5] Ice Palace - b5 up staircase", InventoryItemType.BigKey)
                            || (LocationHasItem("[dungeon-D5-B3] Ice Palace - spike room", InventoryItemType.BigKey)
                                && (have.Contains(InventoryItemType.Hookshot)
                                    || ((LocationHasItem("[dungeon-D5-B3] Ice Palace - spike room", InventoryItemType.BigKey) 
                                            || LocationHasItem("[dungeon-D5-B2] Ice Palace - map room", InventoryItemType.BigKey)
                                            || LocationHasItem("[dungeon-D5-B1] Ice Palace - Big Key room", InventoryItemType.BigKey))
                                        && (LocationHasItem("[dungeon-D5-B1] Ice Palace - compass room", InventoryItemType.Key)
                                            || LocationHasItem("[dungeon-D5-B4] Ice Palace - above Blue Mail room", InventoryItemType.Key)
                                            || LocationHasItem("[dungeon-D5-B5] Ice Palace - b5 up staircase", InventoryItemType.Key)))))
                            || ((LocationHasItem("[dungeon-D5-B2] Ice Palace - map room", InventoryItemType.BigKey)
                                    || LocationHasItem("[dungeon-D5-B1] Ice Palace - Big Key room", InventoryItemType.BigKey))
                                && have.Contains(InventoryItemType.Hammer)
                                && (have.Contains(InventoryItemType.Hookshot)
                                    || ((LocationHasItem("[dungeon-D5-B3] Ice Palace - spike room", InventoryItemType.BigKey) 
                                            || LocationHasItem("[dungeon-D5-B2] Ice Palace - map room", InventoryItemType.BigKey)
                                            || LocationHasItem("[dungeon-D5-B1] Ice Palace - Big Key room", InventoryItemType.BigKey))
                                        && (LocationHasItem("[dungeon-D5-B1] Ice Palace - compass room", InventoryItemType.Key)
                                            || LocationHasItem("[dungeon-D5-B4] Ice Palace - above Blue Mail room", InventoryItemType.Key)
                                            || LocationHasItem("[dungeon-D5-B5] Ice Palace - b5 up staircase", InventoryItemType.Key)))))),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.TowerOfHera,
                    Name = "[dungeon-L3-2F] Tower of Hera - Entrance",
                    Address = 0xE9AD,
                    CanAccess =
                        have =>
                        CanEnterTowerOfHera(have),
                },

                new Location
                {
                    LateGameItem = false,
                    Region = Region.EasternPalace,
                    Name = "[dungeon-L1-1F] Eastern Palace - big ball room",
                    Address = 0xE9B3,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.DesertPalace,
                    Name = "[dungeon-L2-B1] Desert Palace - Map room",
                    Address = 0xE9B6,
                    CanAccess =
                        have =>
                        CanEnterDesertPalace(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.EasternPalace,
                    Name = "[dungeon-L1-1F] Eastern Palace - Big key",
                    Address = 0xE9B9,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-040] Link's House",
                    Address = 0xE9BC,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-012-1F] Death Mountain - wall of caves - left cave",
                    Address = 0xE9BF,
                    CanAccess =
                        have =>
                        CanClimbDeathMountain(have)
                        && ((have.Contains(InventoryItemType.MagicMirror)
                                && have.Contains(InventoryItemType.Hammer))
                            || have.Contains(InventoryItemType.Hookshot)),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.DesertPalace,
                    Name = "[dungeon-L2-B1] Desert Palace - Big key room",
                    Address = 0xE9C2,
                    CanAccess =
                        have =>
                        CanEnterDesertPalace(have)
                        && have.Contains(InventoryItemType.PegasusBoots),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.LightWorld,
                    Name = "[cave-013] Mimic cave (from Turtle Rock)",
                    Address = 0xE9C5,
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && have.Contains(InventoryItemType.MagicMirror)
                        && (have.Contains(InventoryItemType.FireRod)
                            || (LocationHasItem("[dungeon-D7-1F] Turtle Rock - compass room", InventoryItemType.Key)
                                && LocationHasItem("[dungeon-D7-1F] Turtle Rock - Chain chomp room", InventoryItemType.Key))),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SkullWoods,
                    Name = "[dungeon-D3-B1] Skull Woods - south of Fire Rod room",
                    Address = 0xE9C8,
                    ForceItems = { InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanEnterSkullWoods(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.DesertPalace,
                    Name = "[dungeon-L2-B1] Desert Palace - compass room",
                    Address = 0xE9CB,
                    CanAccess =
                        have =>
                        CanEnterDesertPalace(have)
                        && have.Contains(InventoryItemType.PegasusBoots),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-031] Tavern",
                    Address = 0xE9CE,
                    CanAccess =
                        have =>
                        true,
                },

                new Location
                {
                    LateGameItem = true,
                    Region = Region.IcePalace,
                    Name = "[dungeon-D5-B1] Ice Palace - compass room",
                    Address = 0xE9D4,
                    CanAccess =
                        have =>
                        CanEnterIcePalace(have),
                },

                new Location
                {
                    LateGameItem = true,
                    Region = Region.MiseryMire,
                    Name = "[dungeon-D6-B1] Misery Mire - spike room",
                    Address = 0xE9DA,
                    CanAccess =
                        have =>
                        CanEnterMiseryMire(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.IcePalace,
                    Name = "[dungeon-D5-B2] Ice Palace - map room",
                    Address = 0xE9DD,
                    CanAccess =
                        have =>
                        CanEnterIcePalace(have)
                        && have.Contains(InventoryItemType.Hammer)
                        && (have.Contains(InventoryItemType.Hookshot)
                            || ((LocationHasItem("[dungeon-D5-B3] Ice Palace - spike room", InventoryItemType.BigKey)
                                    || LocationHasItem("[dungeon-D5-B2] Ice Palace - map room", InventoryItemType.BigKey)
                                    || LocationHasItem("[dungeon-D5-B1] Ice Palace - Big Key room", InventoryItemType.BigKey))
                                && (LocationHasItem("[dungeon-D5-B1] Ice Palace - compass room", InventoryItemType.Key)
                                    || LocationHasItem("[dungeon-D5-B4] Ice Palace - above Blue Mail room", InventoryItemType.Key)
                                    || LocationHasItem("[dungeon-D5-B5] Ice Palace - b5 up staircase", InventoryItemType.Key)))),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.IcePalace,
                    Name = "[dungeon-D5-B3] Ice Palace - spike room",
                    Address = 0xE9E0,
                    CanAccess =
                        have =>
                        CanEnterIcePalace(have)
                        && (have.Contains(InventoryItemType.Hookshot)
                            || ((LocationHasItem("[dungeon-D5-B3] Ice Palace - spike room", InventoryItemType.BigKey)
                                    || LocationHasItem("[dungeon-D5-B2] Ice Palace - map room", InventoryItemType.BigKey)
                                    || LocationHasItem("[dungeon-D5-B1] Ice Palace - Big Key room", InventoryItemType.BigKey))
                                && (LocationHasItem("[dungeon-D5-B1] Ice Palace - compass room", InventoryItemType.Key)
                                    || LocationHasItem("[dungeon-D5-B4] Ice Palace - above Blue Mail room", InventoryItemType.Key)
                                    || LocationHasItem("[dungeon-D5-B5] Ice Palace - b5 up staircase", InventoryItemType.Key)))),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.IcePalace,
                    Name = "[dungeon-D5-B5] Ice Palace - b5 up staircase",
                    Address = 0xE9E3,
                    CanAccess =
                        have =>
                        CanEnterIcePalace(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.TowerOfHera,
                    Name = "[dungeon-L3-1F] Tower of Hera - first floor",
                    Address = 0xE9E6,
                    CanAccess =
                        have =>
                        CanEnterTowerOfHera(have)
                        && CanLightTorches(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-026] chicken house",
                    Address = 0xE9E9,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-063] doorless hut",
                    Address = 0xE9EC,
                    CanAccess =
                        have =>
                        CanAccessNorthWestDarkWorld(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-062] C-shaped house",
                    Address = 0xE9EF,
                    CanAccess =
                        have =>
                        CanAccessNorthWestDarkWorld(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-044] Aginah's cave",
                    Address = 0xE9F2,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.EasternPalace,
                    Name = "[dungeon-L1-1F] Eastern Palace - map room",
                    Address = 0xE9F5,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.TowerOfHera,
                    Name = "[dungeon-L3-4F] Tower of Hera - big chest",
                    Address = 0xE9F8,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanEnterTowerOfHera(have)
                        && (CanLightTorches(have)
                            || LocationHasItem("[dungeon-L3-2F] Tower of Hera - Entrance", InventoryItemType.BigKey)),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.TowerOfHera,
                    Name = "[dungeon-L3-4F] Tower of Hera - 4F [small chest]",
                    Address = 0xE9FB,
                    NeverItems = { InventoryItemType.BigKey },
                    CanAccess =
                        have =>
                        CanEnterTowerOfHera(have)
                        && (CanLightTorches(have)
                            || LocationHasItem("[dungeon-L3-2F] Tower of Hera - Entrance", InventoryItemType.BigKey)),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SkullWoods,
                    Name = "[dungeon-D3-B1] Skull Woods - Entrance to part 2",
                    Address = 0xE9FE,
                    CanAccess =
                        have =>
                        CanEnterSkullWoods2(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.ThievesTown,
                    Name = "[dungeon-D4-B1] Thieves' Town - Bottom left of huge room [top left chest]",
                    Address = 0xEA01,
                    CanAccess =
                        have =>
                        CanEnterThievesTown(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.ThievesTown,
                    Name = "[dungeon-D4-B1] Thieves' Town - Bottom left of huge room [bottom right chest]",
                    Address = 0xEA04,
                    CanAccess =
                        have =>                                                                                                                                                                    
                        CanEnterThievesTown(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.ThievesTown,
                    Name = "[dungeon-D4-B1] Thieves' Town - Bottom right of huge room",
                    Address = 0xEA07,
                    CanAccess =
                        have =>
                        CanEnterThievesTown(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.ThievesTown,
                    Name = "[dungeon-D4-B1] Thieves' Town - Top left of huge room",
                    Address = 0xEA0A,
                    CanAccess =
                        have =>
                        CanEnterThievesTown(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.ThievesTown,
                    Name = "[dungeon-D4-1F] Thieves' Town - Room above boss",
                    Address = 0xEA0D,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanEnterThievesTown(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.ThievesTown,
                    Name = "[dungeon-D4-B2] Thieves' Town - big chest",
                    Address = 0xEA10,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanEnterThievesTown(have)
                        && have.Contains(InventoryItemType.Hammer),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.ThievesTown,
                    Name = "[dungeon-D4-B2] Thieves' Town - next to Blind",
                    Address = 0xEA13,
                    NeverItems = { InventoryItemType.BigKey },
                    CanAccess =
                        have =>
                        CanEnterThievesTown(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.TurtleRock,
                    Name = "[dungeon-D7-1F] Turtle Rock - Chain chomp room",
                    Address = 0xEA16,
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && CanAccessTurtleRock2(have)
                        && (have.Contains(InventoryItemType.FireRod)
                            || LocationHasItem("[dungeon-D7-1F] Turtle Rock - compass room", InventoryItemType.Key)),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.TurtleRock,
                    Name = "[dungeon-D7-B1] Turtle Rock - big chest",
                    Address = 0xEA19,
                    NeverItems = { InventoryItemType.BigKey },
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && CanAccessTurtleRock2(have)
                        && (have.Contains(InventoryItemType.FireRod)
                            || (LocationHasItem("[dungeon-D7-1F] Turtle Rock - compass room", InventoryItemType.Key)
                                && LocationHasItem("[dungeon-D7-1F] Turtle Rock - Chain chomp room", InventoryItemType.Key)
                                && LocationHasItem("[dungeon-D7-B1] Turtle Rock - big key room", InventoryItemType.BigKey))),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.TurtleRock,
                    Name = "[dungeon-D7-1F] Turtle Rock - Map room [left chest]",
                    Address = 0xEA1C,
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && have.Contains(InventoryItemType.FireRod),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.TurtleRock,
                    Name = "[dungeon-D7-1F] Turtle Rock - Map room [right chest]",
                    Address = 0xEA1F,
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && have.Contains(InventoryItemType.FireRod),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.TurtleRock,
                    Name = "[dungeon-D7-1F] Turtle Rock - compass room",
                    Address = 0xEA22,
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.TurtleRock,
                    Name = "[dungeon-D7-B1] Turtle Rock - big key room",
                    Address = 0xEA25,
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && CanAccessTurtleRock2(have)
                        && (have.Contains(InventoryItemType.FireRod)
                            || (LocationHasItem("[dungeon-D7-1F] Turtle Rock - compass room", InventoryItemType.Key)
                                && LocationHasItem("[dungeon-D7-1F] Turtle Rock - Chain chomp room", InventoryItemType.Key))),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.TurtleRock,
                    Name = "[dungeon-D7-B2] Turtle Rock - Eye bridge room [top right chest]",
                    Address = 0xEA28,
                    NeverItems = { InventoryItemType.BigKey },
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && CanAccessTurtleRock2(have)
                        && have.Contains(InventoryItemType.Lamp)
                        && (have.Contains(InventoryItemType.FireRod)
                            || (LocationHasItem("[dungeon-D7-1F] Turtle Rock - compass room", InventoryItemType.Key)
                                && LocationHasItem("[dungeon-D7-1F] Turtle Rock - Chain chomp room", InventoryItemType.Key)
                                && LocationHasItem("[dungeon-D7-B1] Turtle Rock - big key room", InventoryItemType.BigKey))),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.TurtleRock,
                    Name = "[dungeon-D7-B2] Turtle Rock - Eye bridge room [top left chest]",
                    Address = 0xEA2B,
                    NeverItems = { InventoryItemType.BigKey },
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && CanAccessTurtleRock2(have)
                        && have.Contains(InventoryItemType.Lamp)
                        && (have.Contains(InventoryItemType.FireRod)
                            || (LocationHasItem("[dungeon-D7-1F] Turtle Rock - compass room", InventoryItemType.Key)
                                && LocationHasItem("[dungeon-D7-1F] Turtle Rock - Chain chomp room", InventoryItemType.Key)
                                && LocationHasItem("[dungeon-D7-B1] Turtle Rock - big key room", InventoryItemType.BigKey))),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.TurtleRock,
                    Name = "[dungeon-D7-B2] Turtle Rock - Eye bridge room [bottom right chest]",
                    Address = 0xEA2E,
                    NeverItems = { InventoryItemType.BigKey },
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && CanAccessTurtleRock2(have)
                        && have.Contains(InventoryItemType.Lamp)
                        && (have.Contains(InventoryItemType.FireRod)
                            || (LocationHasItem("[dungeon-D7-1F] Turtle Rock - compass room", InventoryItemType.Key)
                                && LocationHasItem("[dungeon-D7-1F] Turtle Rock - Chain chomp room", InventoryItemType.Key)
                                && LocationHasItem("[dungeon-D7-B1] Turtle Rock - big key room", InventoryItemType.BigKey))),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.TurtleRock,
                    Name = "[dungeon-D7-B2] Turtle Rock - Eye bridge room [bottom left chest]",
                    Address = 0xEA31,
                    NeverItems = { InventoryItemType.BigKey },
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && CanAccessTurtleRock2(have)
                        && have.Contains(InventoryItemType.Lamp)
                        && (have.Contains(InventoryItemType.FireRod)
                            || (LocationHasItem("[dungeon-D7-1F] Turtle Rock - compass room", InventoryItemType.Key)
                                && LocationHasItem("[dungeon-D7-1F] Turtle Rock - Chain chomp room", InventoryItemType.Key)
                                && LocationHasItem("[dungeon-D7-B1] Turtle Rock - big key room", InventoryItemType.BigKey))),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.TurtleRock,
                    Name = "[dungeon-D7-B1] Turtle Rock - Roller switch room",
                    Address = 0xEA34,
                    NeverItems = { InventoryItemType.BigKey },
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && CanAccessTurtleRock2(have)
                        && have.Contains(InventoryItemType.Lamp)
                        && (have.Contains(InventoryItemType.FireRod)
                            || (LocationHasItem("[dungeon-D7-1F] Turtle Rock - compass room", InventoryItemType.Key)
                                && LocationHasItem("[dungeon-D7-1F] Turtle Rock - Chain chomp room", InventoryItemType.Key)
                                && LocationHasItem("[dungeon-D7-B1] Turtle Rock - big key room", InventoryItemType.BigKey))),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-1F] Dark Palace - big key room",
                    Address = 0xEA37,
                    ForceItems = { InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanEnterDarkPalace(have) 
                        && ((LocationHasItem("[dungeon-D1-B1] Dark Palace - shooter room", InventoryItemType.Key)
                                && (LocationHasItem("[dungeon-D1-1F] Dark Palace - jump room [left chest]", InventoryItemType.Key) 
                                    || LocationHasItem("[dungeon-D1-B1] Dark Palace - turtle stalfos room", InventoryItemType.Key))) 
                            || (have.Contains(InventoryItemType.Bow) 
                                && (LocationHasItem("[dungeon-D1-1F] Dark Palace - statue push room", InventoryItemType.Key) 
                                    || LocationHasItem("[dungeon-D1-1F] Dark Palace - jump room [right chest]", InventoryItemType.Key)))
                            || (have.Contains(InventoryItemType.Bow) 
                                && have.Contains(InventoryItemType.Hammer)
                                && (LocationHasItem("[dungeon-D1-1F] Dark Palace - statue push room", InventoryItemType.Key) 
                                    || LocationHasItem("[dungeon-D1-1F] Dark Palace - jump room [right chest]", InventoryItemType.Key) 
                                    || LocationHasItem("[dungeon-D1-1F] Dark Palace - jump room [left chest]", InventoryItemType.Key) 
                                    || LocationHasItem("[dungeon-D1-B1] Dark Palace - turtle stalfos room", InventoryItemType.Key)))),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-1F] Dark Palace - jump room [right chest]",
                    Address = 0xEA3A,
                    CanAccess =
                        have =>
                        CanEnterDarkPalace(have)
                        && have.Contains(InventoryItemType.Bow),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-1F] Dark Palace - jump room [left chest]",
                    Address = 0xEA3D,
                    CanAccess =
                        have =>
                        CanEnterDarkPalace(have)
                        && (LocationHasItem("[dungeon-D1-B1] Dark Palace - shooter room", InventoryItemType.Key)
                            || (have.Contains(InventoryItemType.Bow) 
                                && have.Contains(InventoryItemType.Hammer))
                            || (have.Contains(InventoryItemType.Bow) 
                                && (LocationHasItem("[dungeon-D1-1F] Dark Palace - statue push room", InventoryItemType.Key)
                                    || LocationHasItem("[dungeon-D1-1F] Dark Palace - jump room [right chest]", InventoryItemType.Key)))),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-1F] Dark Palace - big chest",
                    Address = 0xEA40,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanAccessLateDarkPalace(have)
                        && have.Contains(InventoryItemType.Lamp),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-1F] Dark Palace - compass room",
                    Address = 0xEA43,
                    CanAccess =
                        have =>
                        CanAccessLateDarkPalace(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-1F] Dark Palace - spike statue room",
                    Address = 0xEA46,
                    CanAccess =
                        have =>
                        CanAccessLateDarkPalace(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-B1] Dark Palace - turtle stalfos room",
                    Address = 0xEA49,
                    CanAccess =
                        have =>
                        CanEnterDarkPalace(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-B1] Dark Palace - room leading to Helmasaur [left chest]",
                    Address = 0xEA4C,
                    CanAccess =
                        have =>
                        CanAccessLateDarkPalace(have)
                        && have.Contains(InventoryItemType.Lamp),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-B1] Dark Palace - room leading to Helmasaur [right chest]",
                    Address = 0xEA4F,
                    CanAccess =
                        have =>
                        CanAccessLateDarkPalace(have)
                        && have.Contains(InventoryItemType.Lamp),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-1F] Dark Palace - statue push room",
                    Address = 0xEA52,
                    CanAccess =
                        have =>
                        CanEnterDarkPalace(have)
                        && have.Contains(InventoryItemType.Bow),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-1F] Dark Palace - maze room [top chest]",
                    Address = 0xEA55,
                    NeverItems = { InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanAccessLateDarkPalace(have)
                        && have.Contains(InventoryItemType.Lamp),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-1F] Dark Palace - maze room [bottom chest]",
                    Address = 0xEA58,
                    NeverItems = { InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanAccessLateDarkPalace(have)
                        && have.Contains(InventoryItemType.Lamp),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-B1] Dark Palace - shooter room",
                    Address = 0xEA5B,
                    CanAccess =
                        have =>
                        CanEnterDarkPalace(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.MiseryMire,
                    Name = "[dungeon-D6-B1] Misery Mire - big hub room",
                    Address = 0xEA5E,
                    CanAccess =
                        have =>
                        CanEnterMiseryMire(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.MiseryMire,
                    Name = "[dungeon-D6-B1] Misery Mire - end of bridge",
                    Address = 0xEA61,
                    CanAccess =
                        have =>
                        CanEnterMiseryMire(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.MiseryMire,
                    Name = "[dungeon-D6-B1] Misery Mire - compass",
                    Address = 0xEA64,
                    CanAccess =
                        have =>
                        CanEnterMiseryMire(have)
                        && CanLightTorches(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.MiseryMire,
                    Name = "[dungeon-D6-B1] Misery Mire - big chest",
                    Address = 0xEA67,
                    NeverItems = { InventoryItemType.BigKey },
                    CanAccess =
                        have =>
                        CanEnterMiseryMire(have)
                        && (CanLightTorches(have)
                            || (!LocationHasItem("[dungeon-D6-B1] Misery Mire - compass", InventoryItemType.BigKey)
                                && !LocationHasItem("[dungeon-D6-B1] Misery Mire - big key", InventoryItemType.BigKey))),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.MiseryMire,
                    Name = "[dungeon-D6-B1] Misery Mire - map room",
                    Address = 0xEA6A,
                    CanAccess =
                        have =>
                        CanEnterMiseryMire(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.MiseryMire,
                    Name = "[dungeon-D6-B1] Misery Mire - big key",
                    Address = 0xEA6D,
                    CanAccess =
                        have =>
                        CanEnterMiseryMire(have)
                        && CanLightTorches(have),
                },

                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-071] Misery Mire west area [left chest]",
                    Address = 0xEA73,
                    CanAccess =
                        have =>
                        have.Contains(InventoryItemType.OcarinaInactive)
                        && have.Contains(InventoryItemType.MoonPearl)
                        && have.Contains(InventoryItemType.TitansMitt),
               },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-071] Misery Mire west area [right chest]",
                    Address = 0xEA76,
                    CanAccess =
                        have =>
                        have.Contains(InventoryItemType.OcarinaInactive)
                        && have.Contains(InventoryItemType.MoonPearl)
                        && have.Contains(InventoryItemType.TitansMitt),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.HyruleCastleEscape,
                    Name = "[dungeon-C-1F] Sanctuary",
                    Address = 0xEA79,
                    CanAccess =
                        have =>
                        CanDefeatHyruleCastleEscape(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-057-1F] Dark World Death Mountain - cave from top to bottom [top chest]",
                    Address = 0xEA7C,
                    CanAccess =
                        have =>
                        CanAccessEastDarkWorldDeathMountain(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-057-1F] Dark World Death Mountain - cave from top to bottom [bottom chest]",
                    Address = 0xEA7F,
                    CanAccess =
                        have =>
                        CanAccessEastDarkWorldDeathMountain(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-035] Sahasrahla's Hut [left chest]",
                    Address = 0xEA82,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-035] Sahasrahla's Hut [center chest]",
                    Address = 0xEA85,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-035] Sahasrahla's Hut [right chest]",
                    Address = 0xEA88,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-055] Spike cave",
                    Address = 0xEA8B,
                    CanAccess =
                        have =>
                        CanClimbDeathMountain(have)
                        && CanLiftLightRocks(have)
                        && have.Contains(InventoryItemType.MoonPearl)
                        && have.Contains(InventoryItemType.Hammer)
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-021] Kakariko well [top chest]",
                    Address = 0xEA8E,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-021] Kakariko well [left chest row of 3]",
                    Address = 0xEA91,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-021] Kakariko well [center chest row of 3]",
                    Address = 0xEA94,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-021] Kakariko well [right chest row of 3]",
                    Address = 0xEA97,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-021] Kakariko well [bottom chest]",
                    Address = 0xEA9A,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SwampPalace,
                    Name = "[dungeon-D2-1F] Swamp Palace - first room",
                    Address = 0xEA9D,
                    ForceItems = { InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanEnterSwampPalace(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SwampPalace,
                    Name = "[dungeon-D2-B1] Swamp Palace - south of hookshot room",
                    Address = 0xEAA0,
                    CanAccess =
                        have =>
                        CanEnterSwampPalace(have)
                        && have.Contains(InventoryItemType.Hammer),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SwampPalace,
                    Name = "[dungeon-D2-B1] Swamp Palace - push 4 blocks room",
                    Address = 0xEAA3,
                    CanAccess =
                        have =>
                        CanEnterSwampPalace(have)
                        && have.Contains(InventoryItemType.Hammer),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SwampPalace,
                    Name = "[dungeon-D2-B1] Swamp Palace - big key room",
                    Address = 0xEAA6,
                    CanAccess =
                        have =>
                        CanEnterSwampPalace(have)
                        && have.Contains(InventoryItemType.Hammer),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SwampPalace,
                    Name = "[dungeon-D2-B2] Swamp Palace - flooded room [left chest]",
                    Address = 0xEAA9,
                    CanAccess =
                        have =>
                        CanEnterSwampPalace(have)
                        && CanAccessLateSwampPalace(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SwampPalace,
                    Name = "[dungeon-D2-B2] Swamp Palace - flooded room [right chest]",
                    Address = 0xEAAC,
                    CanAccess =
                        have =>
                        CanEnterSwampPalace(have)
                        && CanAccessLateSwampPalace(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SwampPalace,
                    Name = "[dungeon-D2-B2] Swamp Palace - hidden waterfall door room",
                    Address = 0xEAAF,
                    CanAccess =
                        have =>
                        CanEnterSwampPalace(have)
                        && CanAccessLateSwampPalace(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.HyruleCastleTower,
                    Name = "[dungeon-A1-3F] Hyrule Castle Tower - maze room",
                    Address = 0xEAB2,
                    Item = new InventoryItem(InventoryItemType.Key),
                    CanAccess =
                        have =>
                        CanEnterHyruleCastleTower(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.HyruleCastleTower,
                    Name = "[dungeon-A1-2F] Hyrule Castle Tower - 2 knife guys room",
                    Address = 0xEAB5,
                    Item = new InventoryItem(InventoryItemType.Key),
                    CanAccess =
                        have =>
                        CanEnterHyruleCastleTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - north of gap room [top left chest]",
                    Address = 0xEAB8,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - north of gap room [top right chest]",
                    Address = 0xEABB,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - north of gap room [bottom left chest]",
                    Address = 0xEABE,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - north of gap room [bottom right chest]",
                    Address = 0xEAC1,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - west of teleport room [top left chest]",
                    Address = 0xEAC4,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - west of teleport room [top right chest]",
                    Address = 0xEAC7,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - west of teleport room [bottom left chest]",
                    Address = 0xEACA,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - west of teleport room [bottom right chest]",
                    Address = 0xEACD,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - north of teleport room",
                    Address = 0xEAD0,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - map room",
                    Address = 0xEAD3,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - big chest",
                    Address = 0xEAD6,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - down right staircase from entrance [left chest]",
                    Address = 0xEAD9,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - down right staircase from entrance [right chest]",
                    Address = 0xEADC,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - above Armos",
                    Address = 0xEADF,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - east of down right staircase from entrace",
                    Address = 0xEAE2,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - compass room [top left chest]",
                    Address = 0xEAE5,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - compass room [top right chest]",
                    Address = 0xEAE8,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - compass room [bottom left chest]",
                    Address = 0xEAEB,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-1F] Ganon's Tower - compass room [bottom right chest]",
                    Address = 0xEAEE,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-B1] Ganon's Tower - north of Armos room [bottom chest]",
                    Address = 0xEAF1,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-B1] Ganon's Tower - north of Armos room [left chest]",
                    Address = 0xEAF4,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-B1] Ganon's Tower - north of Armos room [right chest]",
                    Address = 0xEAF7,
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },

                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-6F] Ganon's Tower - north of falling floor four torches [top left chest]",
                    Address = 0xEAFD,
                    NeverItems = { InventoryItemType.BigKey },
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-6F] Ganon's Tower - north of falling floor four torches [top right chest]",
                    Address = 0xEB00,
                    NeverItems = { InventoryItemType.BigKey },
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-6F] Ganon's Tower - before Moldorm",
                    Address = 0xEB03,
                    NeverItems = { InventoryItemType.BigKey },
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.GanonsTower,
                    Name = "[dungeon-A2-6F] Ganon's Tower - Moldorm room",
                    Address = 0xEB06,
                    NeverItems = { InventoryItemType.BigKey },
                    CanAccess =
                        have =>
                        CanEnterGanonsTower(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.HyruleCastleEscape,
                    Name = "[dungeon-C-B3] Hyrule Castle - next to Zelda",
                    Address = 0xEB09,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.HyruleCastleEscape,
                    Name = "[dungeon-C-B1] Hyrule Castle - map room",
                    Address = 0xEB0C,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-022-B1] Thief's hut [top chest]",
                    Address = 0xEB0F,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-022-B1] Thief's hut [top left chest]",
                    Address = 0xEB12,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-022-B1] Thief's hut [top right chest]",
                    Address = 0xEB15,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-022-B1] Thief's hut [bottom left chest]",
                    Address = 0xEB18,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-022-B1] Thief's hut [bottom right chest]",
                    Address = 0xEB1B,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-073] cave northeast of swamp palace [top chest]",
                    Address = 0xEB1E,
                    CanAccess =
                        have =>
                        CanAccessSouthDarkWorld(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-073] cave northeast of swamp palace [top middle chest]",
                    Address = 0xEB21,
                    CanAccess =
                        have =>
                        CanAccessSouthDarkWorld(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-073] cave northeast of swamp palace [bottom middle chest]",
                    Address = 0xEB24,
                    CanAccess =
                        have =>
                        CanAccessSouthDarkWorld(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-073] cave northeast of swamp palace [bottom chest]",
                    Address = 0xEB27,
                    CanAccess =
                        have =>
                        CanAccessSouthDarkWorld(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-009-1F] Death Mountain - wall of caves - right cave [top left chest]",
                    Address = 0xEB2A,
                    CanAccess =
                        have =>
                        CanClimbDeathMountain(have)
                        && ((have.Contains(InventoryItemType.MagicMirror)
                                && have.Contains(InventoryItemType.Hammer))
                            || have.Contains(InventoryItemType.Hookshot)),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-009-1F] Death Mountain - wall of caves - right cave [top left middle chest]",
                    Address = 0xEB2D,
                    CanAccess =
                        have =>
                        CanClimbDeathMountain(have)
                        && ((have.Contains(InventoryItemType.MagicMirror)
                                && have.Contains(InventoryItemType.Hammer))
                            || have.Contains(InventoryItemType.Hookshot)),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-009-1F] Death Mountain - wall of caves - right cave [top right middle chest]",
                    Address = 0xEB30,
                    CanAccess =
                        have =>
                        CanClimbDeathMountain(have)
                        && ((have.Contains(InventoryItemType.MagicMirror)
                                && have.Contains(InventoryItemType.Hammer))
                            || have.Contains(InventoryItemType.Hookshot)),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-009-1F] Death Mountain - wall of caves - right cave [top right chest]",
                    Address = 0xEB33,
                    CanAccess =
                        have =>
                        CanClimbDeathMountain(have)
                        && ((have.Contains(InventoryItemType.MagicMirror)
                                && have.Contains(InventoryItemType.Hammer))
                            || have.Contains(InventoryItemType.Hookshot)),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-009-1F] Death Mountain - wall of caves - right cave [bottom chest]",
                    Address = 0xEB36,
                    CanAccess =
                        have =>
                        CanClimbDeathMountain(have)
                        && ((have.Contains(InventoryItemType.MagicMirror)
                                && have.Contains(InventoryItemType.Hammer))
                            || have.Contains(InventoryItemType.Hookshot)),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-009-B1] Death Mountain - wall of caves - right cave [left chest]",
                    Address = 0xEB39,
                    CanAccess =
                        have =>
                        CanClimbDeathMountain(have)
                        && ((have.Contains(InventoryItemType.MagicMirror)
                                && have.Contains(InventoryItemType.Hammer))
                            || have.Contains(InventoryItemType.Hookshot)),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-009-B1] Death Mountain - wall of caves - right cave [right chest]",
                    Address = 0xEB3C,
                    CanAccess =
                        have =>
                        CanClimbDeathMountain(have)
                        && ((have.Contains(InventoryItemType.MagicMirror)
                                && have.Contains(InventoryItemType.Hammer))
                            || have.Contains(InventoryItemType.Hookshot)),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-016] cave under rocks west of Santuary",
                    Address = 0xEB3F,
                    CanAccess =
                        have =>
                        have.Contains(InventoryItemType.PegasusBoots),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-050] cave southwest of Lake Hylia [bottom left chest]",
                    Address = 0xEB42,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-050] cave southwest of Lake Hylia [top left chest]",
                    Address = 0xEB45,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-050] cave southwest of Lake Hylia [top right chest]",
                    Address = 0xEB48,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-050] cave southwest of Lake Hylia [bottom right chest]",
                    Address = 0xEB4B,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-051] Ice Cave",
                    Address = 0xEB4E,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-056] Dark World Death Mountain - cave under boulder [top right chest]",
                    Address = 0xEB51,
                    CanAccess =
                        have =>
                        CanAccessEastDarkWorldDeathMountain(have)
                        && have.Contains(InventoryItemType.Hookshot),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-056] Dark World Death Mountain - cave under boulder [top left chest]",
                    Address = 0xEB54,
                    CanAccess =
                        have =>
                        CanAccessEastDarkWorldDeathMountain(have)
                        && have.Contains(InventoryItemType.Hookshot),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-056] Dark World Death Mountain - cave under boulder [bottom left chest]",
                    Address = 0xEB57,
                    CanAccess =
                        have =>
                        CanAccessEastDarkWorldDeathMountain(have)
                        && have.Contains(InventoryItemType.Hookshot),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-056] Dark World Death Mountain - cave under boulder [bottom right chest]",
                    Address = 0xEB5A,
                    CanAccess =
                        have =>
                        CanAccessEastDarkWorldDeathMountain(have)
                        && (have.Contains(InventoryItemType.Hookshot)
                            || have.Contains(InventoryItemType.PegasusBoots))
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.HyruleCastleEscape,
                    Name = "[dungeon-C-B1] Escape - final basement room [left chest]",
                    Address = 0xEB5D,
                    CanAccess =
                        have =>
                        CanLiftLightRocks(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.HyruleCastleEscape,
                    Name = "[dungeon-C-B1] Escape - final basement room [middle chest]",
                    Address = 0xEB60,
                    CanAccess =
                        have =>
                        CanLiftLightRocks(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.HyruleCastleEscape,
                    Name = "[dungeon-C-B1] Escape - final basement room [right chest]",
                    Address = 0xEB63,
                    CanAccess =
                        have =>
                        CanLiftLightRocks(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "Piece of Heart (Treasure Chest Game)",
                    Address = 0xEDA8,
                    CanAccess =
                        have =>
                        CanAccessNorthWestDarkWorld(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Bottle Vendor",
                    Address = 0x2EB18,
                    CanAccess =
                        have =>
                        true
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Sahasrahla",
                    Address = 0x2F1FC,
                    CanAccess =
                        have =>
                        (PendantAtLocation("Pendant - Eastern Palace", PendantItemType.GreenPendant) && CanDefeatEasternPalace(have))
                        || (PendantAtLocation("Pendant - Desert Palace", PendantItemType.GreenPendant) && CanDefeatDesertPalace(have))
                        || (PendantAtLocation("Pendant - Tower of Hera", PendantItemType.GreenPendant) && CanDefeatTowerOfHera(have)),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.DarkWorld,
                    Name = "Flute Boy",
                    Address = 0x330C7,
                    CanAccess =
                        have =>
                        CanAccessSouthDarkWorld(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Sick Kid",
                    Address = 0x339CF,
                    CanAccess =
                        have =>
                        HasBottle(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Purple Chest",
                    Address = 0x33D68,
                    CanAccess =
                        have =>
                        CanAccessNorthWestDarkWorld(have)
                        && have.Contains(InventoryItemType.TitansMitt)
                        && have.Contains(InventoryItemType.MagicMirror),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Hobo",
                    Address = 0x33E7D,
                    CanAccess =
                        have =>
                        have.Contains(InventoryItemType.Flippers),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.DarkWorld,
                    Name = "Catfish",
                    Address = 0xEE185,
                    CanAccess =
                        have =>
                        CanAccessPyramid(have)
                        && have.Contains(InventoryItemType.MoonPearl)
                        && CanLiftLightRocks(have),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            var itemType = ((InventoryItem)item).Type;
                            WriteSpecialItemCheck(rom, itemType , 0x180204);
                        }
                },
                // Zora's appearance is based on if you have flippers or not
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "King Zora",
                    Address = 0xEE1C3,
                    CanAccess =
                        have =>
                        CanAccessZorasRiver(have),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            var itemType = ((InventoryItem)item).Type;
                            WriteSpecialItemCheck(rom, itemType, 0x180200);
                            rom.WriteBytes(0x76A85, Item.GetCreditsName(itemType));
                        }
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Old mountain man",
                    Address = 0xF69FA,
                    CanAccess =
                        have =>
                        CanClimbDeathMountain(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Piece of Heart (Thieves' Forest Hideout)",
                    Address = 0x180000,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Piece of Heart (Lumberjack Tree)",
                    Address = 0x180001,
                    CanAccess =
                        have =>
                        CanDefeatAgahnim1(have)
                        && have.Contains(InventoryItemType.PegasusBoots),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Piece of Heart (Spectacle Rock Cave)",
                    Address = 0x180002,
                    CanAccess =
                        have =>
                        CanClimbDeathMountain(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Piece of Heart (south of Haunted Grove)",
                    Address = 0x180003,
                    CanAccess =
                        have =>
                        CanAccessSouthDarkWorld(have)
                        && have.Contains(InventoryItemType.MagicMirror),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Piece of Heart (Graveyard)",
                    Address = 0x180004,
                    CanAccess =
                        have =>
                        CanAccessNorthWestDarkWorld(have)
                        && have.Contains(InventoryItemType.MagicMirror),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Piece of Heart (Desert - northeast corner)",
                    Address = 0x180005,
                    CanAccess =
                        have =>
                        have.Contains(InventoryItemType.OcarinaInactive)
                        && have.Contains(InventoryItemType.MagicMirror)
                        && have.Contains(InventoryItemType.TitansMitt),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.DarkWorld,
                    Name = "Piece of Heart (Dark World blacksmith pegs)",
                    Address = 0x180006,
                    CanAccess =
                        have =>
                        CanAccessNorthWestDarkWorld(have)
                        && have.Contains(InventoryItemType.TitansMitt)
                        && have.Contains(InventoryItemType.Hammer),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-050] cave southwest of Lake Hylia - generous guy",
                    Address = 0x180010,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.DarkWorld,
                    Name = "[cave-073] cave northeast of swamp palace - generous guy",
                    Address = 0x180011,
                    CanAccess =
                        have =>
                        CanAccessSouthDarkWorld(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Library",
                    Address = 0x180012,
                    CanAccess =
                        have =>
                        have.Contains(InventoryItemType.PegasusBoots),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Mushroom",
                    Address = 0x180013,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Witch",
                    Address = 0x180014,
                    CanAccess =
                        have =>
                        have.Contains(InventoryItemType.Mushroom),
                },
                new Location
                {
                    Name = "Magic Bat",
                    Region = Region.LightWorld,
                    Address = 0x180015,
                    CanAccess =
                        have =>
                        have.Contains(InventoryItemType.Powder)
                        && (have.Contains(InventoryItemType.Hammer)
                            || (have.Contains(InventoryItemType.TitansMitt)
                                && have.Contains(InventoryItemType.MagicMirror)
                                && have.Contains(InventoryItemType.MoonPearl))),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Ether",
                    Address = 0x180016,
                    CanAccess =
                        have =>
                        CanEnterTowerOfHera(have)
                        && CanUpgradeSword(have)
                        && have.Contains(InventoryItemType.BookOfMudora),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            var itemType = ((InventoryItem)item).Type;
                            rom.WriteBytes(0x44AA9, (byte)itemType);
                        }
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Bombos",
                    Address = 0x180017,
                    CanAccess =
                        have =>
                        CanAccessSouthDarkWorld(have)
                        && CanUpgradeSword(have)
                        && have.Contains(InventoryItemType.BookOfMudora)
                        && have.Contains(InventoryItemType.MagicMirror),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            var itemType = ((InventoryItem)item).Type;
                            rom.WriteBytes(0x44AAE, (byte)itemType);
                        }
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Piece of Heart (Spectacle Rock)",
                    Address = 0x180140,
                    CanAccess =
                        have =>
                        CanClimbDeathMountain(have)
                        && have.Contains(InventoryItemType.MagicMirror),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Piece of Heart (Death Mountain - floating island)",
                    Address = 0x180141,
                    CanAccess =
                        have =>
                        CanAccessEastDarkWorldDeathMountain(have)
                        && have.Contains(InventoryItemType.MagicMirror),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Piece of Heart (Maze Race)",
                    Address = 0x180142,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Piece of Heart (Desert - west side)",
                    Address = 0x180143,
                    CanAccess =
                        have =>
                        CanEnterDesertPalace(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Piece of Heart (Lake Hylia)",
                    Address = 0x180144,
                    CanAccess =
                        have =>
                        have.Contains(InventoryItemType.Flippers)
                        && have.Contains(InventoryItemType.MagicMirror)
                        && have.Contains(InventoryItemType.MoonPearl)
                        && (have.Contains(InventoryItemType.TitansMitt)
                            || CanDefeatAgahnim1(have)
                            || (have.Contains(InventoryItemType.Hammer)
                                && have.Contains(InventoryItemType.PowerGlove))),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Piece of Heart (Dam)",
                    Address = 0x180145,
                    CanAccess =
                        have =>
                        true,
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.DarkWorld,
                    Name = "Piece of Heart (Dark World - bumper cave)",
                    Address = 0x180146,
                    CanAccess =
                        have =>
                        CanAccessNorthWestDarkWorld(have)
                        && CanLiftLightRocks(have)
                        && have.Contains(InventoryItemType.Cape),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.DarkWorld,
                    Name = "Piece of Heart (Pyramid)",
                    Address = 0x180147,
                    CanAccess =
                        have =>
                        CanAccessPyramid(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.DarkWorld,
                    Name = "Piece of Heart (Digging Game)",
                    Address = 0x180148,
                    CanAccess =
                        have =>
                        CanAccessSouthDarkWorld(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Piece of Heart (Zora's River)",
                    Address = 0x180149,
                    CanAccess =
                        have =>
                        CanAccessZorasRiver(have)
                        && have.Contains(InventoryItemType.Flippers),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Haunted Grove item",
                    Address = 0x18014A,
                    CanAccess =
                        have =>
                        have.Contains(InventoryItemType.Shovel),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.EasternPalace,
                    Name = "Heart Container (Armos Knights)",
                    Address = 0x180150,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanDefeatEasternPalace(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.DesertPalace,
                    Name = "Heart Container (Lanmolas)",
                    Address = 0x180151,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanDefeatDesertPalace(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.TowerOfHera,
                    Name = "Heart Container (Moldorm)",
                    Address = 0x180152,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanDefeatTowerOfHera(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.DarkPalace,
                    Name = "Heart Container (Helmasaur King)",
                    Address = 0x180153,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanDefeatDarkPalace(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.SwampPalace,
                    Name = "Heart Container (Arrghus)",
                    Address = 0x180154,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanDefeatSwampPalace(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.SkullWoods,
                    Name = "Heart Container (Mothula)",
                    Address = 0x180155,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanDefeatSkullWoods(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.ThievesTown,
                    Name = "Heart Container (Blind)",
                    Address = 0x180156,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanDefeatThievesTown(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.IcePalace,
                    Name = "Heart Container (Kholdstare)",
                    Address = 0x180157,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanDefeatIcePalace(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.MiseryMire,
                    Name = "Heart Container (Vitreous)",
                    Address = 0x180158,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanDefeatMiseryMire(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.TurtleRock,
                    Name = "Heart Container (Trinexx)",
                    Address = 0x180159,
                    NeverItems = { InventoryItemType.BigKey, InventoryItemType.Key },
                    CanAccess =
                        have =>
                        CanDefeatTurtleRock(have),
                },
            };

            SpecialLocations = new List<Location>
            {
                new Location
                {
                    Name = "Pendant - Eastern Palace",
                    Item = new PendantItem(PendantItemType.GreenPendant),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            var itemType = ((PendantItem)item).Type;
                            WritePendant(rom, Region.EasternPalace, itemType);
                        },
                    CanAccess =
                        have =>
                        CanDefeatEasternPalace(have),
                },
                new Location
                {
                    Name = "Pendant - Desert Palace",
                    Item = new PendantItem(PendantItemType.BluePendant),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            var itemType = ((PendantItem)item).Type;
                            WritePendant(rom, Region.DesertPalace, itemType);
                        },
                    CanAccess =
                        have =>
                        CanDefeatDesertPalace(have),
                },
                new Location
                {
                    Name = "Pendant - Tower of Hera",
                    Item = new PendantItem(PendantItemType.RedPendant),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            var itemType = ((PendantItem)item).Type;
                            WritePendant(rom, Region.TowerOfHera, itemType);
                        },
                    CanAccess =
                        have =>
                        CanDefeatTowerOfHera(have),
                },
                new Location
                {
                    Name = "Crystal - Swamp Palace",
                    Item = new CrystalItem(CrystalItemType.Crystal2),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            var itemType = ((CrystalItem)item).Type;
                            WriteCrystal(rom, Region.SwampPalace, itemType);
                        },
                    CanAccess =
                        have =>
                        CanDefeatSwampPalace(have),
                },
                new Location
                {
                    Name = "Crystal - Dark Palace",
                    Item = new CrystalItem(CrystalItemType.Crystal1),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            var itemType = ((CrystalItem)item).Type;
                            WriteCrystal(rom, Region.DarkPalace, itemType);
                        },
                    CanAccess =
                        have =>
                        CanDefeatDarkPalace(have),
                },
                new Location
                {
                    Name = "Crystal - Misery Mire",
                    Item = new CrystalItem(CrystalItemType.Crystal6),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            var itemType = ((CrystalItem)item).Type;
                            WriteCrystal(rom, Region.MiseryMire, itemType);
                        },
                    CanAccess =
                        have =>
                        CanDefeatMiseryMire(have),
                },
                new Location
                {
                    Name = "Crystal - Skull Woods",
                    Item = new CrystalItem(CrystalItemType.Crystal3),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            var itemType = ((CrystalItem)item).Type;
                            WriteCrystal(rom, Region.SkullWoods, itemType);
                        },
                    CanAccess =
                        have =>
                        CanDefeatSkullWoods(have),
                },
                new Location
                {
                    Name = "Crystal - Ice Palace",
                    Item = new CrystalItem(CrystalItemType.Crystal5),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            var itemType = ((CrystalItem)item).Type;
                            WriteCrystal(rom, Region.IcePalace, itemType);
                        },
                    CanAccess =
                        have =>
                        CanDefeatIcePalace(have),
                },
                new Location
                {
                    Name = "Crystal - Thieves' Town",
                    Item = new CrystalItem(CrystalItemType.Crystal4),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            var itemType = ((CrystalItem)item).Type;
                            WriteCrystal(rom, Region.ThievesTown, itemType);
                        },
                    CanAccess =
                        have =>
                        CanDefeatThievesTown(have),
                },
                new Location
                {
                    Name = "Crystal - Turtle Rock",
                    Item = new CrystalItem(CrystalItemType.Crystal7),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            var itemType = ((CrystalItem)item).Type;
                            WriteCrystal(rom, Region.TurtleRock, itemType);
                        },
                    CanAccess =
                        have =>
                        CanDefeatTurtleRock(have),
                },
                new Location
                {
                    Name = "Bottle Item - Waterfall",
                    Address = 0x348FF,
                },
                new Location
                {
                    Name = "Bottle Item - Pyramid",
                    Address = 0x3493B,
                },
                new Location
                {
                    Name = "Required Medallion - Misery Mire",
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            var itemType = ((InventoryItem)item).Type;

                            if (itemType == InventoryItemType.Bombos)
                            {
                                rom.WriteBytes(0x4FF2, 0x31);
                                rom.WriteBytes(0x50D1, 0x80);
                                rom.WriteBytes(0x51B0, 0x00);
                                rom.WriteBytes(0x180022, 0x00);
                            }
                            else if (itemType == InventoryItemType.Ether)
                            {
                                rom.WriteBytes(0x180022, 0x01);
                            }
                            else if (itemType == InventoryItemType.Quake)
                            {
                                rom.WriteBytes(0x4FF2, 0x31);
                                rom.WriteBytes(0x50D1, 0x88);
                                rom.WriteBytes(0x51B0, 0x00);
                                rom.WriteBytes(0x180022, 0x02);
                            }
                        }
                },
                new Location
                {
                    Name = "Required Medallion - Turtle Rock",
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            var itemType = ((InventoryItem)item).Type;

                            if (itemType == InventoryItemType.Bombos)
                            {
                                rom.WriteBytes(0x5020, 0x31);
                                rom.WriteBytes(0x50FF, 0x90);
                                rom.WriteBytes(0x51DE, 0x00);
                                rom.WriteBytes(0x180023, 0x00);
                            }
                            else if (itemType == InventoryItemType.Ether)
                            {
                                rom.WriteBytes(0x5020, 0x31);
                                rom.WriteBytes(0x50FF, 0x98);
                                rom.WriteBytes(0x51DE, 0x00);
                                rom.WriteBytes(0x180023, 0x01);
                            }
                            else if (itemType == InventoryItemType.Quake)
                            {
                                rom.WriteBytes(0x180023, 0x02);
                            }
                        }
                },
                new Location
                {
                    Name = "Sword - Pedestal",
                    Address = 0x289B0,
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            byte itemType = (byte)((InventoryItem)item).Type;
                            rom.WriteBytes(0x44435, itemType);
                        },
                },
                new Location
                {
                    Name = "Sword - Smithy",
                    Address = 0x3355C,
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            int itemType = (int)((InventoryItem)item).Type + 1;
                            rom.WriteBytes(0x3348E, (byte)(itemType % 0x4F));
                        }
                },
                new Location
                {
                    Name = "Sword - Fairy",
                    Address = 0x180028,
                },
            };
        }

        protected override bool CanDefeatHyruleCastleEscape(List<InventoryItemType> have)
        {
            return LocationHasItem("[dungeon-C-B1] Escape - first B1 room", InventoryItemType.Key)
                || LocationHasItem("[dungeon-C-B1] Hyrule Castle - boomerang room", InventoryItemType.Key)
                || LocationHasItem("[dungeon-C-B1] Hyrule Castle - map room", InventoryItemType.Key)
                || LocationHasItem("[dungeon-C-B3] Hyrule Castle - next to Zelda", InventoryItemType.Key);
        }

        private bool CanAccessLateDarkPalace(List<InventoryItemType> have)
        {
            return CanEnterDarkPalace(have) 
                && ((LocationHasItem("[dungeon-D1-B1] Dark Palace - shooter room", InventoryItemType.Key) 
                        && LocationHasItem("[dungeon-D1-1F] Dark Palace - big key room", InventoryItemType.Key) 
                        && (LocationHasItem("[dungeon-D1-1F] Dark Palace - jump room [left chest]", InventoryItemType.Key) 
                            || LocationHasItem("[dungeon-D1-B1] Dark Palace - turtle stalfos room", InventoryItemType.Key)))
                    || (have.Contains(InventoryItemType.Bow) 
                        && LocationHasItem("[dungeon-D1-1F] Dark Palace - big key room", InventoryItemType.Key) 
                        && (LocationHasItem("[dungeon-D1-1F] Dark Palace - statue push room", InventoryItemType.Key) 
                            || LocationHasItem("[dungeon-D1-1F] Dark Palace - jump room [right chest]", InventoryItemType.Key)))
                    || (have.Contains(InventoryItemType.Bow) 
                        && have.Contains(InventoryItemType.Hammer) 
                        && LocationHasItem("[dungeon-D1-1F] Dark Palace - big key room", InventoryItemType.Key) 
                        && (LocationHasItem("[dungeon-D1-1F] Dark Palace - statue push room", InventoryItemType.Key) 
                            || LocationHasItem("[dungeon-D1-1F] Dark Palace - jump room [right chest]", InventoryItemType.Key) 
                            || LocationHasItem("[dungeon-D1-1F] Dark Palace - jump room [left chest]", InventoryItemType.Key) 
                            || LocationHasItem("[dungeon-D1-B1] Dark Palace - turtle stalfos room", InventoryItemType.Key))));
        }

        private bool CanAccessLateSwampPalace(List<InventoryItemType> have)
        {
            return (have.Contains(InventoryItemType.Hammer)
                    && (LocationHasItem("[dungeon-D2-B1] Swamp Palace - big key room", InventoryItemType.BigKey)
                        || LocationHasItem("[dungeon-D2-B1] Swamp Palace - map room", InventoryItemType.BigKey)
                        || LocationHasItem("[dungeon-D2-B1] Swamp Palace - push 4 blocks room", InventoryItemType.BigKey)
                        || LocationHasItem("[dungeon-D2-B1] Swamp Palace - south of hookshot room", InventoryItemType.BigKey)
                        || (have.Contains(InventoryItemType.Hookshot)
                            && !LocationHasItem("[dungeon-D2-B1] Swamp Palace - big chest", InventoryItemType.Hookshot))));
        }

        private bool CanAccessZorasRiver(List<InventoryItemType> have)
        {
            return CanLiftLightRocks(have)
                || have.Contains(InventoryItemType.Flippers);
        }

        private bool CanEnterHyruleCastleTower(List<InventoryItemType> have)
        {
            return CanGetMasterSword(have) // should be CanUpgradeSword but StackOverflows lie down this path
                || have.Contains(InventoryItemType.Cape);
                //|| CanGetTemperedSword(have) --this is a StackOverflow if I do this, so even though it's true, it also doesn't really matter since you'll probably be able to access anywhere you can get to with the Pyramid if you can get the Tempered Sword.
        }

        private bool CanUpgradeSword(List<InventoryItemType> have)
        {
            return CanGetMasterSword(have)
                || CanGetTemperedSword(have)
                || CanGetGoldSword(have);
        }

        private bool CanGetGoldSword(List<InventoryItemType> have)
        {
            Dictionary<string, Func<List<InventoryItemType>, bool>> dungeons = new Dictionary<string, Func<List<InventoryItemType>, bool>>
            {
                { "Crystal - Dark Palace", CanDefeatDarkPalace },
                { "Crystal - Swamp Palace", CanDefeatSwampPalace },
                { "Crystal - Skull Woods", CanDefeatSkullWoods },
                { "Crystal - Thieves' Town", CanDefeatThievesTown },
                { "Crystal - Ice Palace", CanDefeatIcePalace },
                { "Crystal - Misery Mire", CanDefeatMiseryMire },
                { "Crystal - Turtle Rock", CanDefeatTurtleRock },
            };

            // return true if crystals 5 and 6 are accessible
            return dungeons.Keys.Where(key => CrystalAtLocation(key, CrystalItemType.Crystal5) || CrystalAtLocation(key, CrystalItemType.Crystal6)).All(key => dungeons[key](have))
                && have.Contains(InventoryItemType.MoonPearl)
                && (have.Contains(InventoryItemType.Hammer)
                    || (CanDefeatAgahnim1(have) 
                        && have.Contains(InventoryItemType.MagicMirror)));
        }

        private bool CanGetMasterSword(List<InventoryItemType> have)
        {
            return CanDefeatEasternPalace(have)
                && CanDefeatDesertPalace(have)
                && CanDefeatTowerOfHera(have);
        }

        private bool CanGetTemperedSword(List<InventoryItemType> have)
        {
            return CanAccessNorthWestDarkWorld(have)
                && have.Contains(InventoryItemType.TitansMitt)
                && have.Contains(InventoryItemType.MagicMirror);
        }

        private bool CanAccessEastDarkWorldDeathMountain(List<InventoryItemType> have)
        {
            return CanClimbDeathMountain(have)
                && have.Contains(InventoryItemType.MoonPearl)
                && have.Contains(InventoryItemType.TitansMitt) 
                && (have.Contains(InventoryItemType.Hookshot)
                    || (have.Contains(InventoryItemType.Hammer)
                        && have.Contains(InventoryItemType.MagicMirror)));
        }

        private bool CanClimbDeathMountain(List<InventoryItemType> have)
        {
            return CanLiftLightRocks(have)
                || have.Contains(InventoryItemType.OcarinaInactive);
        }

        private bool CanEnterGanonsTower(List<InventoryItemType> have)
        {
            return CanDefeatDarkPalace(have)
                && CanDefeatSwampPalace(have)
                && CanDefeatSkullWoods(have)
                && CanDefeatThievesTown(have)
                && CanDefeatIcePalace(have)
                && CanDefeatMiseryMire(have)
                && CanDefeatTurtleRock(have);
        }

        protected override bool CanDefeatDarkPalace(List<InventoryItemType> have)
        {
            return CanEnterDarkPalace(have)
                && have.Contains(InventoryItemType.Bow)
                && have.Contains(InventoryItemType.Hammer)
                && have.Contains(InventoryItemType.Lamp)
                && LocationHasItem("[dungeon-D1-1F] Dark Palace - big key room", InventoryItemType.Key)
                && ((LocationHasItem("[dungeon-D1-1F] Dark Palace - statue push room", InventoryItemType.Key)
                        && LocationHasItem("[dungeon-D1-1F] Dark Palace - jump room [right chest]", InventoryItemType.Key)
                        && LocationHasItem("[dungeon-D1-1F] Dark Palace - jump room [left chest]", InventoryItemType.Key))
                    || (LocationHasItem("[dungeon-D1-1F] Dark Palace - statue push room", InventoryItemType.Key)
                        && LocationHasItem("[dungeon-D1-1F] Dark Palace - jump room [right chest]", InventoryItemType.Key)
                        && LocationHasItem("[dungeon-D1-B1] Dark Palace - turtle stalfos room", InventoryItemType.Key))
                    || (LocationHasItem("[dungeon-D1-1F] Dark Palace - jump room [right chest]", InventoryItemType.Key)
                        && LocationHasItem("[dungeon-D1-1F] Dark Palace - jump room [left chest]", InventoryItemType.Key)
                        && LocationHasItem("[dungeon-D1-B1] Dark Palace - turtle stalfos room", InventoryItemType.Key))
                    || (LocationHasItem("[dungeon-D1-1F] Dark Palace - statue push room", InventoryItemType.Key)
                        && LocationHasItem("[dungeon-D1-1F] Dark Palace - jump room [left chest]", InventoryItemType.Key)
                        && LocationHasItem("[dungeon-D1-B1] Dark Palace - turtle stalfos room", InventoryItemType.Key)));
        }

        protected override bool CanDefeatSwampPalace(List<InventoryItemType> have)
        {
            return CanEnterSwampPalace(have)
                && have.Contains(InventoryItemType.Hookshot)
                && have.Contains(InventoryItemType.Hammer);
        }

        protected override bool CanDefeatSkullWoods(List<InventoryItemType> have)
        {
            return CanEnterSkullWoods2(have);
        }

        protected override bool CanDefeatThievesTown(List<InventoryItemType> have)
        {
            return CanEnterThievesTown(have);
        }

        protected override bool CanDefeatIcePalace(List<InventoryItemType> have)
        {
            return CanEnterIcePalace(have)
                && have.Contains(InventoryItemType.Hammer)
                && ((LocationHasItem("[dungeon-D5-B1] Ice Palace - compass room", InventoryItemType.BigKey)
                        && LocationHasItem("[dungeon-D5-B4] Ice Palace - above Blue Mail room", InventoryItemType.Key)
                        && LocationHasItem("[dungeon-D5-B5] Ice Palace - b5 up staircase", InventoryItemType.Key))
                    || (LocationHasItem("[dungeon-D5-B4] Ice Palace - above Blue Mail room", InventoryItemType.BigKey)
                        && LocationHasItem("[dungeon-D5-B1] Ice Palace - compass room", InventoryItemType.Key)
                        && LocationHasItem("[dungeon-D5-B5] Ice Palace - b5 up staircase", InventoryItemType.Key))
                    || (LocationHasItem("[dungeon-D5-B5] Ice Palace - b5 up staircase", InventoryItemType.BigKey)
                        && LocationHasItem("[dungeon-D5-B1] Ice Palace - compass room", InventoryItemType.Key)
                        && LocationHasItem("[dungeon-D5-B4] Ice Palace - above Blue Mail room", InventoryItemType.Key))
                    || (have.Contains(InventoryItemType.Hookshot)
                        && (LocationHasItem("[dungeon-D5-B1] Ice Palace - compass room", InventoryItemType.BigKey)
                            || LocationHasItem("[dungeon-D5-B4] Ice Palace - above Blue Mail room", InventoryItemType.BigKey)
                            || LocationHasItem("[dungeon-D5-B5] Ice Palace - b5 up staircase", InventoryItemType.BigKey))) 
                    || ((LocationHasItem("[dungeon-D5-B2] Ice Palace - map room", InventoryItemType.BigKey)
                            || LocationHasItem("[dungeon-D5-B1] Ice Palace - Big Key room", InventoryItemType.BigKey)
                            || LocationHasItem("[dungeon-D5-B5] Ice Palace - big chest", InventoryItemType.BigKey))
                        && (have.Contains(InventoryItemType.Hookshot)
                            || LocationHasItem("[dungeon-D5-B1] Ice Palace - compass room", InventoryItemType.Key)
                            || LocationHasItem("[dungeon-D5-B4] Ice Palace - above Blue Mail room", InventoryItemType.Key)
                            || LocationHasItem("[dungeon-D5-B5] Ice Palace - b5 up staircase", InventoryItemType.Key))));
        }

        protected override bool CanDefeatMiseryMire(List<InventoryItemType> have)
        {
            return CanEnterMiseryMire(have)
                && have.Contains(InventoryItemType.CaneOfSomaria)
                && have.Contains(InventoryItemType.Lamp)
                && MiseryMireKeysOkay();
        }

        private bool MiseryMireKeysOkay()
        {
            return LocationHasItem("[dungeon-D6-B1] Misery Mire - spike room", InventoryItemType.BigKey)
                || LocationHasItem("[dungeon-D6-B1] Misery Mire - spike room", InventoryItemType.Key)
                || LocationHasItem("[dungeon-D6-B1] Misery Mire - end of bridge", InventoryItemType.BigKey)
                || LocationHasItem("[dungeon-D6-B1] Misery Mire - end of bridge", InventoryItemType.Key);
        }

        protected override bool CanDefeatTurtleRock(List<InventoryItemType> have)
        {
            return CanEnterTurtleRock(have)
                && CanAccessTurtleRock2(have)
                && TurtleRockKeysOkay()
                && have.Contains(InventoryItemType.Lamp)
                && have.Contains(InventoryItemType.FireRod)
                && have.Contains(InventoryItemType.IceRod);
        }

        private bool TurtleRockKeysOkay()
        {
            var keyCount = 0;

            if (LocationHasItem("[dungeon-D7-B2] Turtle Rock - Eye bridge room [bottom left chest]", InventoryItemType.Key)) { keyCount++; }
            if (LocationHasItem("[dungeon-D7-B2] Turtle Rock - Eye bridge room [bottom right chest]", InventoryItemType.Key)) { keyCount++; }
            if (LocationHasItem("[dungeon-D7-B2] Turtle Rock - Eye bridge room [top left chest]", InventoryItemType.Key)) { keyCount++; }
            if (LocationHasItem("[dungeon-D7-B2] Turtle Rock - Eye bridge room [top right chest]", InventoryItemType.Key)) { keyCount++; }

            return keyCount < 2;
        }

        protected override bool CanDefeatGanonsTower(List<InventoryItemType> have)
        {
            return LocationHasItem("[dungeon-A2-1F] Ganon's Tower - above Armos", InventoryItemType.Key)
                || LocationHasItem("[dungeon-A2-1F] Ganon's Tower - down right staircase from entrance [left chest]", InventoryItemType.Key)
                || LocationHasItem("[dungeon-A2-1F] Ganon's Tower - down right staircase from entrance [right chest]", InventoryItemType.Key)
                || LocationHasItem("[dungeon-A2-1F] Ganon's Tower - east of down right staircase from entrace", InventoryItemType.Key)
                || LocationHasItem("[dungeon-A2-1F] Ganon's Tower - map room", InventoryItemType.Key)
                || LocationHasItem("[dungeon-A2-1F] Ganon's Tower - north of gap room [bottom left chest]", InventoryItemType.Key)
                || LocationHasItem("[dungeon-A2-1F] Ganon's Tower - north of gap room [bottom right chest]", InventoryItemType.Key)
                || LocationHasItem("[dungeon-A2-1F] Ganon's Tower - north of gap room [top left chest]", InventoryItemType.Key)
                || LocationHasItem("[dungeon-A2-1F] Ganon's Tower - north of gap room [top right chest]", InventoryItemType.Key)
                || LocationHasItem("[dungeon-A2-B1] Ganon's Tower - north of Armos room [bottom chest]", InventoryItemType.Key)
                || LocationHasItem("[dungeon-A2-B1] Ganon's Tower - north of Armos room [left chest]", InventoryItemType.Key)
                || LocationHasItem("[dungeon-A2-B1] Ganon's Tower - north of Armos room [right chest]", InventoryItemType.Key);
        }

        private bool CanEnterTurtleRock(List<InventoryItemType> have)
        {
            return CanAccessEastDarkWorldDeathMountain(have)
                && have.Contains(InventoryItemType.MoonPearl)
                && have.Contains(InventoryItemType.Hammer)
                && have.Contains(GetItemAtLocation<InventoryItem>(SpecialLocations, "Required Medallion - Turtle Rock").Type)
                && have.Contains(InventoryItemType.CaneOfSomaria);
        }

        private bool CanAccessTurtleRock2(List<InventoryItemType> have)
        {
            var keyCount = 0;

            if (LocationHasItem("[dungeon-D7-1F] Turtle Rock - compass room", InventoryItemType.Key)) { keyCount ++; }
            if (LocationHasItem("[dungeon-D7-1F] Turtle Rock - Map room [left chest]", InventoryItemType.Key)) { keyCount++; }
            if (LocationHasItem("[dungeon-D7-1F] Turtle Rock - Map room [right chest]", InventoryItemType.Key)) { keyCount++; }
            if (LocationHasItem("[dungeon-D7-1F] Turtle Rock - Chain chomp room", InventoryItemType.Key)) { keyCount++; }

            return keyCount > 1;
        }

        private bool CanEnterMiseryMire(List<InventoryItemType> have)
        {
            return have.Contains(InventoryItemType.OcarinaInactive)
                && have.Contains(InventoryItemType.MoonPearl)
                && have.Contains(InventoryItemType.TitansMitt)
                && have.Contains(GetItemAtLocation<InventoryItem>(SpecialLocations, "Required Medallion - Misery Mire").Type)
                && (have.Contains(InventoryItemType.PegasusBoots)
                    || have.Contains(InventoryItemType.Hookshot));
        }

        private bool CanEnterIcePalace(List<InventoryItemType> have)
        {
            return have.Contains(InventoryItemType.Flippers)
                && have.Contains(InventoryItemType.MoonPearl)
                && have.Contains(InventoryItemType.TitansMitt)
                && (have.Contains(InventoryItemType.FireRod)
                    || have.Contains(InventoryItemType.Bombos));
        }

        private bool CanEnterThievesTown(List<InventoryItemType> have)
        {
            return CanAccessNorthWestDarkWorld(have);
        }

        private bool CanEnterSkullWoods2(List<InventoryItemType> have)
        {
            return CanEnterSkullWoods(have)
                && have.Contains(InventoryItemType.FireRod);
        }

        private bool CanEnterSkullWoods(List<InventoryItemType> have)
        {
            return CanAccessNorthWestDarkWorld(have);
        }

        private bool CanEnterSwampPalace(List<InventoryItemType> have)
        {
            return CanAccessSouthDarkWorld(have)
                && have.Contains(InventoryItemType.Flippers)
                && have.Contains(InventoryItemType.MagicMirror);
        }

        private bool CanAccessSouthDarkWorld(List<InventoryItemType> have)
        {
            return ((CanAccessPyramid(have)
                        && (have.Contains(InventoryItemType.Hammer)
                            || (have.Contains(InventoryItemType.Hookshot)
                                && (have.Contains(InventoryItemType.Flippers)
                                    || CanLiftLightRocks(have)))))
                    || (have.Contains(InventoryItemType.Hammer)
                        && CanLiftLightRocks(have))
                    || have.Contains(InventoryItemType.TitansMitt))
                && have.Contains(InventoryItemType.MoonPearl);
        }

        private bool CanAccessNorthWestDarkWorld(List<InventoryItemType> have)
        {
            return have.Contains(InventoryItemType.MoonPearl)
            && ((have.Contains(InventoryItemType.Hammer)
                    && CanLiftLightRocks(have))
                || have.Contains(InventoryItemType.TitansMitt)
                || ((CanGetMasterSword(have)
                        // || CanGetGoldSword(have) // this is true but probably irrelevant here
                        || have.Contains(InventoryItemType.Cape))
                    && ((have.Contains(InventoryItemType.Hookshot)
                            && (CanLiftLightRocks(have)
                                || have.Contains(InventoryItemType.Hammer)
                                || have.Contains(InventoryItemType.Flippers))))));
        }

        private bool CanEnterDarkPalace(List<InventoryItemType> have)
        {
            return CanAccessPyramid(have)
                && have.Contains(InventoryItemType.MoonPearl);
        }

        private bool CanAccessPyramid(List<InventoryItemType> have)
        {
            return CanDefeatAgahnim1(have)
                || (((have.Contains(InventoryItemType.Hammer)
                            && CanLiftLightRocks(have))
                        || (have.Contains(InventoryItemType.TitansMitt)
                            && have.Contains(InventoryItemType.Flippers)))
                    && have.Contains(InventoryItemType.MoonPearl));
        }

        private bool CanDefeatAgahnim1(List<InventoryItemType> have)
        {
            return CanEnterHyruleCastleTower(have);
        }

        protected override bool CanDefeatTowerOfHera(List<InventoryItemType> have)
        {
            return CanEnterTowerOfHera(have)
                && ((LocationHasItem("[dungeon-L3-1F] Tower of Hera - first floor", InventoryItemType.BigKey)
                        && CanLightTorches(have))
                   || LocationHasItem("[dungeon-L3-2F] Tower of Hera - Entrance", InventoryItemType.BigKey));
        }

        protected override bool CanDefeatDesertPalace(List<InventoryItemType> have)
        {
            return have.Contains(InventoryItemType.PegasusBoots) 
                && CanLightTorches(have) 
                && ((have.Contains(InventoryItemType.BookOfMudora) 
                        && CanLiftLightRocks(have)) 
                    || (have.Contains(InventoryItemType.OcarinaInactive) 
                        && have.Contains(InventoryItemType.TitansMitt) 
                        && have.Contains(InventoryItemType.MagicMirror)));
        }

        protected override bool CanDefeatEasternPalace(List<InventoryItemType> have)
        {
            return have.Contains(InventoryItemType.Bow);
        }

        private bool CanEnterTowerOfHera(List<InventoryItemType> have)
        {
            return CanClimbDeathMountain(have)
                && (have.Contains(InventoryItemType.MagicMirror)
                    || (have.Contains(InventoryItemType.Hookshot)
                        && have.Contains(InventoryItemType.Hammer)));
        }

        private bool CanEnterDesertPalace(List<InventoryItemType> have)
        {
            return have.Contains(InventoryItemType.BookOfMudora)
                || (have.Contains(InventoryItemType.OcarinaInactive)
                    && have.Contains(InventoryItemType.TitansMitt)
                    && have.Contains(InventoryItemType.MagicMirror));
        }

        public List<InventoryItemType> GetItemPool(SeedRandom random)
        {
            SetLateGameItems();
            SetSpecialLocations(random);
            
            var retVal = new List<InventoryItemType>
            {
                // advancement items
                InventoryItemType.Bombos,
                InventoryItemType.BookOfMudora,
                InventoryItemType.Bow,
                InventoryItemType.CaneOfSomaria,
                InventoryItemType.Ether,
                InventoryItemType.FireRod,
                InventoryItemType.Flippers,
                InventoryItemType.Hammer,
                InventoryItemType.Hookshot,
                InventoryItemType.IceRod,
                InventoryItemType.Lamp,
                InventoryItemType.MagicMirror,
                InventoryItemType.MoonPearl,
                InventoryItemType.OcarinaInactive,
                InventoryItemType.PegasusBoots,
                InventoryItemType.PowerGlove,
                InventoryItemType.Quake,
                InventoryItemType.TitansMitt,
                
                // nice-to-have items
                InventoryItemType.BlueMail,
                InventoryItemType.Boomerang,
                InventoryItemType.BugCatchingNet,
                InventoryItemType.Cape,
                InventoryItemType.FiftyBombCap,
                InventoryItemType.HeartContainer,
                InventoryItemType.HeartContainerNoRefill,
                InventoryItemType.HeartContainerNoRefill,
                InventoryItemType.HeartContainerNoRefill,
                InventoryItemType.HeartContainerNoRefill,
                InventoryItemType.HeartContainerNoRefill,
                InventoryItemType.HeartContainerNoRefill,
                InventoryItemType.HeartContainerNoRefill,
                InventoryItemType.HeartContainerNoRefill,
                InventoryItemType.HeartContainerNoRefill,
                InventoryItemType.HeartContainerNoRefill,
                InventoryItemType.MirrorShield,
                InventoryItemType.Mushroom,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.PieceOfHeart,
                InventoryItemType.Powder,
                InventoryItemType.RedBoomerang,
                InventoryItemType.RedMail,
                InventoryItemType.RedShield,
                InventoryItemType.SeventyArrowCap,
                InventoryItemType.Shovel,
                InventoryItemType.StaffOfByrna,
                
                // other treasure box contents
                InventoryItemType.Arrow,
                InventoryItemType.TenArrows,
                InventoryItemType.TenArrows,
                InventoryItemType.TenArrows,
                InventoryItemType.TenArrows,
                InventoryItemType.TenArrows,
                InventoryItemType.TenArrows,
                InventoryItemType.TenArrows,
                InventoryItemType.TenArrows,
                InventoryItemType.TenArrows,
                InventoryItemType.TenArrows,
                InventoryItemType.TenArrows,

                InventoryItemType.ThreeBombs,
                InventoryItemType.ThreeBombs,
                InventoryItemType.ThreeBombs,
                InventoryItemType.ThreeBombs,
                InventoryItemType.ThreeBombs,
                InventoryItemType.ThreeBombs,
                InventoryItemType.ThreeBombs,
                InventoryItemType.ThreeBombs,
                InventoryItemType.ThreeBombs,
                InventoryItemType.ThreeBombs,
                InventoryItemType.ThreeBombs,
                InventoryItemType.ThreeBombs,
                InventoryItemType.ThreeBombs,
                InventoryItemType.ThreeBombs,
                InventoryItemType.ThreeBombs,
                InventoryItemType.ThreeBombs,

                InventoryItemType.OneRupee,
                InventoryItemType.OneRupee,
                InventoryItemType.FiveRupees,
                InventoryItemType.FiveRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.TwentyRupees,
                InventoryItemType.FiftyRupees,
                InventoryItemType.FiftyRupees,
                InventoryItemType.FiftyRupees,
                InventoryItemType.FiftyRupees,
                InventoryItemType.FiftyRupees,
                InventoryItemType.FiftyRupees,
                InventoryItemType.FiftyRupees,
                InventoryItemType.OneHundredRupees,
                InventoryItemType.OneHundredRupees,
                InventoryItemType.OneHundredRupees,
                InventoryItemType.OneHundredRupees,
                InventoryItemType.OneHundredRupees,
                InventoryItemType.OneHundredRupees,
                InventoryItemType.ThreeHundredRupees,
                InventoryItemType.ThreeHundredRupees,
                InventoryItemType.ThreeHundredRupees,
                InventoryItemType.ThreeHundredRupees,
            };

            var bottleTypes = new List<InventoryItemType>
                {
                    InventoryItemType.Bottle,
                    InventoryItemType.BottleWithRedPotion,
                    InventoryItemType.BottleWithGreenPotion,
                    InventoryItemType.BottleWithBluePotion,
                    InventoryItemType.BottleWithBee,
                    InventoryItemType.BottleWithFairy,
                    InventoryItemType.BottleWithGoldBee,
                };

            //Bottles
            for (int x = 0; x < 4; x++)
            {
                 retVal.Add(bottleTypes[random.Next(bottleTypes.Count)]);
            }

            var magicBatItemTypes = new List<InventoryItemType>
                {
                    InventoryItemType.HalfMagic,
                    InventoryItemType.QuarterMagic,
                };

            retVal.Add(magicBatItemTypes[random.Next(magicBatItemTypes.Count)]);

            return retVal;
        }

        private void SetLateGameItems()
        {
            var coreLateGameItems = new List<InventoryItemType>
                {
                    InventoryItemType.RedMail,
                    InventoryItemType.MirrorShield,
                };

            lateGameItems = new List<InventoryItemType>();
            lateGameItems.AddRange(coreLateGameItems);
        }
    }
}
