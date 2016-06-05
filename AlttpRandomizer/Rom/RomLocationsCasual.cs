using System;
using System.Collections.Generic;
using System.IO;
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
                    KeysNeeded = 2,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
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
                    KeysNeeded = 1,
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
                        CanEnterEasternPalace(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-018] Graveyard - top right grave",
                    Address = 0xE97A,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have)
                        && have.Contains(ItemType.PegasusBoots)
                        && (have.Contains(ItemType.TitansMitt)
                            || CanAccessLowerDarkWorld(have)),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.EasternPalace,
                    Name = "[dungeon-L1-1F] Eastern Palace - big chest",
                    Address = 0xE97D,
                    BigKeyNeeded = true,
                    CanAccess =
                        have =>
                        CanEnterEasternPalace(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SwampPalace,
                    Name = "[dungeon-D2-B1] Swamp Palace - map room",
                    Address = 0xE986,
                    KeysNeeded = 1,
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
                    KeysNeeded = 3,
                    BigKeyNeeded = true,
                    CanAccess =
                        have =>
                        CanEnterSwampPalace(have)
                        && have.Contains(ItemType.Hammer),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-047] Dam",
                    Address = 0xE98C,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.DesertPalace,
                    Name = "[dungeon-L2-B1] Desert Palace - big chest",
                    Address = 0xE98F,
                    BigKeyNeeded = true,
                    CanAccess =
                        have =>
                        CanEnterDesertPalace(have),
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
                    KeysNeeded = 2,
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
                    BigKeyNeeded = true,
                    CanAccess =
                        have =>
                        CanEnterSkullWoods(have),
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
                    KeysNeeded = 2,
                    CanAccess =
                        have =>
                        CanEnterIcePalace(have)
                        && have.Contains(ItemType.Hookshot),
                },

                new Location
                {
                    LateGameItem = true,
                    Region = Region.IcePalace,
                    Name = "[dungeon-D5-B5] Ice Palace - big chest",
                    Address = 0xE9AA,
                    KeysNeeded = 2,
                    BigKeyNeeded = true,
                    CanAccess =
                        have =>
                        CanEnterIcePalace(have),
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
                        CanEnterEasternPalace(have),
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
                    KeysNeeded = 1,
                    CanAccess =
                        have =>
                        CanEnterEasternPalace(have),
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
                        && ((CanBeInDarkWorld(have)
                                && have.Contains(ItemType.Hammer))
                            || have.Contains(ItemType.Hookshot)),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.DesertPalace,
                    Name = "[dungeon-L2-B1] Desert Palace - Big key room",
                    Address = 0xE9C2,
                    KeysNeeded = 1,
                    CanAccess =
                        have =>
                        CanEnterDesertPalace(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.LightWorld,
                    Name = "[cave-013] Mimic cave (from Turtle Rock)",
                    Address = 0xE9C5,
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SkullWoods,
                    Name = "[dungeon-D3-B1] Skull Woods - south of Fire Rod room",
                    Address = 0xE9C8,
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
                    KeysNeeded = 1,
                    CanAccess =
                        have =>
                        CanEnterDesertPalace(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-031] Tavern",
                    Address = 0xE9CE,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
                },

                new Location
                {
                    LateGameItem = true,
                    Region = Region.IcePalace,
                    Name = "[dungeon-D5-B1] Ice Palace - compass room",
                    Address = 0xE9D4,
                    KeysNeeded = 1,
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
                    KeysNeeded = 2,
                    CanAccess =
                        have =>
                        CanEnterIcePalace(have)
                        && have.Contains(ItemType.Hookshot),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.IcePalace,
                    Name = "[dungeon-D5-B3] Ice Palace - spike room",
                    Address = 0xE9E0,
                    KeysNeeded = 2,
                    CanAccess =
                        have =>
                        CanEnterIcePalace(have)
                        && have.Contains(ItemType.Hookshot),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.IcePalace,
                    Name = "[dungeon-D5-B5] Ice Palace - b5 up staircase",
                    Address = 0xE9E3,
                    KeysNeeded = 2,
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
                    KeysNeeded = 1,
                    CanAccess =
                        have =>
                        CanEnterTowerOfHera(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-026] chicken house",
                    Address = 0xE9E9,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-063] doorless hut",
                    Address = 0xE9EC,
                    CanAccess =
                        have =>
                        CanAccessLowerDarkWorld(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-062] C-shaped house",
                    Address = 0xE9EF,
                    CanAccess =
                        have =>
                        CanAccessLowerDarkWorld(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-044] Aginah's cave",
                    Address = 0xE9F2,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.EasternPalace,
                    Name = "[dungeon-L1-1F] Eastern Palace - map room",
                    Address = 0xE9F5,
                    CanAccess =
                        have =>
                        CanEnterEasternPalace(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.TowerOfHera,
                    Name = "[dungeon-L3-4F] Tower of Hera - big chest",
                    Address = 0xE9F8,
                    BigKeyNeeded = true,
                    CanAccess =
                        have =>
                        CanEnterTowerOfHera(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.TowerOfHera,
                    Name = "[dungeon-L3-4F] Tower of Hera - 4F [small chest]",
                    Address = 0xE9FB,
                    BigKeyNeeded = true,
                    CanAccess =
                        have =>
                        CanEnterTowerOfHera(have),
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
                    KeysNeeded = 2,
                    BigKeyNeeded = true,
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
                    KeysNeeded = 2,
                    BigKeyNeeded = true,
                    CanAccess =
                        have =>
                        CanEnterThievesTown(have)
                        && have.Contains(ItemType.Hammer),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.ThievesTown,
                    Name = "[dungeon-D4-B2] Thieves' Town - next to Blind",
                    Address = 0xEA13,
                    KeysNeeded = 1,
                    BigKeyNeeded = true,
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
                    KeysNeeded = 2,
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && have.Contains(ItemType.FireRod),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.TurtleRock,
                    Name = "[dungeon-D7-B1] Turtle Rock - big chest",
                    Address = 0xEA19,
                    KeysNeeded = 3,
                    BigKeyNeeded = true,
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && have.Contains(ItemType.FireRod),
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
                        && have.Contains(ItemType.FireRod),
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
                        && have.Contains(ItemType.FireRod),
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
                    KeysNeeded = 4,
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && have.Contains(ItemType.FireRod),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.TurtleRock,
                    Name = "[dungeon-D7-B2] Turtle Rock - Eye bridge room [top right chest]",
                    Address = 0xEA28,
                    KeysNeeded = 5,
                    BigKeyNeeded = true,
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && have.Contains(ItemType.MirrorShield)
                        && have.Contains(ItemType.FireRod),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.TurtleRock,
                    Name = "[dungeon-D7-B2] Turtle Rock - Eye bridge room [top left chest]",
                    Address = 0xEA2B,
                    KeysNeeded = 5,
                    BigKeyNeeded = true,
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && have.Contains(ItemType.MirrorShield)
                        && have.Contains(ItemType.FireRod),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.TurtleRock,
                    Name = "[dungeon-D7-B2] Turtle Rock - Eye bridge room [bottom right chest]",
                    Address = 0xEA2E,
                    KeysNeeded = 5,
                    BigKeyNeeded = true,
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && have.Contains(ItemType.MirrorShield)
                        && have.Contains(ItemType.FireRod),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.TurtleRock,
                    Name = "[dungeon-D7-B2] Turtle Rock - Eye bridge room [bottom left chest]",
                    Address = 0xEA31,
                    KeysNeeded = 5,
                    BigKeyNeeded = true,
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && have.Contains(ItemType.MirrorShield)
                        && have.Contains(ItemType.FireRod),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.TurtleRock,
                    Name = "[dungeon-D7-B1] Turtle Rock - Roller switch room",
                    Address = 0xEA34,
                    KeysNeeded = 4,
                    BigKeyNeeded = true,
                    CanAccess =
                        have =>
                        CanEnterTurtleRock(have)
                        && have.Contains(ItemType.FireRod),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-1F] Dark Palace - big key room",
                    Address = 0xEA37,
                    KeysNeeded = 2,
                    CanAccess =
                        have =>
                        CanEnterDarkPalace(have),
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
                        && have.Contains(ItemType.Bow),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-1F] Dark Palace - jump room [left chest]",
                    Address = 0xEA3D,
                    KeysNeeded = 1,
                    CanAccess =
                        have =>
                        CanEnterDarkPalace(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-1F] Dark Palace - big chest",
                    Address = 0xEA40,
                    KeysNeeded = 3,
                    BigKeyNeeded = true,
                    CanAccess =
                        have =>
                        CanEnterDarkPalace(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-1F] Dark Palace - compass room",
                    Address = 0xEA43,
                    KeysNeeded = 2,
                    CanAccess =
                        have =>
                        CanEnterDarkPalace(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-1F] Dark Palace - spike statue room",
                    Address = 0xEA46,
                    KeysNeeded = 3,
                    CanAccess =
                        have =>
                        CanEnterDarkPalace(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-B1] Dark Palace - turtle stalfos room",
                    Address = 0xEA49,
                    KeysNeeded = 1,
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
                    KeysNeeded = 2,
                    CanAccess =
                        have =>
                        CanEnterDarkPalace(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-B1] Dark Palace - room leading to Helmasaur [right chest]",
                    Address = 0xEA4F,
                    KeysNeeded = 2,
                    CanAccess =
                        have =>
                        CanEnterDarkPalace(have),
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
                        && have.Contains(ItemType.Bow),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-1F] Dark Palace - maze room [top chest]",
                    Address = 0xEA55,
                    KeysNeeded = 3,
                    CanAccess =
                        have =>
                        CanEnterDarkPalace(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkPalace,
                    Name = "[dungeon-D1-1F] Dark Palace - maze room [bottom chest]",
                    Address = 0xEA58,
                    KeysNeeded = 3,
                    CanAccess =
                        have =>
                        CanEnterDarkPalace(have),
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
                    KeysNeeded = 1,
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
                    KeysNeeded = 2,
                    CanAccess =
                        have =>
                        CanEnterMiseryMire(have)
                        && (have.Contains(ItemType.Lamp)
                            || have.Contains(ItemType.FireRod)),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.MiseryMire,
                    Name = "[dungeon-D6-B1] Misery Mire - big chest",
                    Address = 0xEA67,
                    KeysNeeded = 2,
                    BigKeyNeeded = true,
                    CanAccess =
                        have =>
                        CanEnterMiseryMire(have)
                        && (have.Contains(ItemType.Lamp)
                            || have.Contains(ItemType.FireRod)),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.MiseryMire,
                    Name = "[dungeon-D6-B1] Misery Mire - map room",
                    Address = 0xEA6A,
                    KeysNeeded = 1,
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
                    KeysNeeded = 2,
                    CanAccess =
                        have =>
                        CanEnterMiseryMire(have)
                        && (have.Contains(ItemType.Lamp)
                            || have.Contains(ItemType.FireRod)),
                },

                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-071] Misery Mire west area [left chest]",
                    Address = 0xEA73,
                    CanAccess =
                        have =>
                        have.Contains(ItemType.OcarinaActive)
                        && CanBeInDarkWorld(have)
                        && have.Contains(ItemType.TitansMitt),
               },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-071] Misery Mire west area [right chest]",
                    Address = 0xEA76,
                    CanAccess =
                        have =>
                        have.Contains(ItemType.OcarinaActive)
                        && CanBeInDarkWorld(have)
                        && have.Contains(ItemType.TitansMitt),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[dungeon-C-1F] Sanctuary",
                    Address = 0xEA79,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
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
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-035] Sahasrahla's Hut [center chest]",
                    Address = 0xEA85,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-035] Sahasrahla's Hut [right chest]",
                    Address = 0xEA88,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
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
                        && CanBeInDarkWorld(have)
                        && have.Contains(ItemType.Hammer)
                        // not actually required here, but stops some deadlocks
                        && have.Contains(ItemType.Quake),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-021] Kakariko well [top chest]",
                    Address = 0xEA8E,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-021] Kakariko well [left chest row of 3]",
                    Address = 0xEA91,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-021] Kakariko well [center chest row of 3]",
                    Address = 0xEA94,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-021] Kakariko well [right chest row of 3]",
                    Address = 0xEA97,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-021] Kakariko well [bottom chest]",
                    Address = 0xEA9A,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SwampPalace,
                    Name = "[dungeon-D2-1F] Swamp Palace - first room",
                    Address = 0xEA9D,
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
                    KeysNeeded = 3,
                    CanAccess =
                        have =>
                        CanEnterSwampPalace(have)
                        && have.Contains(ItemType.Hammer),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SwampPalace,
                    Name = "[dungeon-D2-B1] Swamp Palace - push 4 blocks room",
                    Address = 0xEAA3,
                    KeysNeeded = 4,
                    CanAccess =
                        have =>
                        CanEnterSwampPalace(have)
                        && have.Contains(ItemType.Hammer),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SwampPalace,
                    Name = "[dungeon-D2-B1] Swamp Palace - big key room",
                    Address = 0xEAA6,
                    KeysNeeded = 4,
                    CanAccess =
                        have =>
                        CanEnterSwampPalace(have)
                        && have.Contains(ItemType.Hammer),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SwampPalace,
                    Name = "[dungeon-D2-B2] Swamp Palace - flooded room [left chest]",
                    Address = 0xEAA9,
                    KeysNeeded = 4,
                    CanAccess =
                        have =>
                        CanEnterSwampPalace(have)
                        && have.Contains(ItemType.Hookshot),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SwampPalace,
                    Name = "[dungeon-D2-B2] Swamp Palace - flooded room [right chest]",
                    Address = 0xEAAC,
                    KeysNeeded = 4,
                    CanAccess =
                        have =>
                        CanEnterSwampPalace(have)
                        && have.Contains(ItemType.Hookshot)
                        && have.Contains(ItemType.Hammer),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.SwampPalace,
                    Name = "[dungeon-D2-B2] Swamp Palace - hidden waterfall door room",
                    Address = 0xEAAF,
                    KeysNeeded = 4,
                    CanAccess =
                        have =>
                        CanEnterSwampPalace(have)
                        && have.Contains(ItemType.Hookshot)
                        && have.Contains(ItemType.Hammer),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.HyruleCastleTower,
                    Name = "[dungeon-A1-3F] Hyrule Castle Tower - maze room",
                    Address = 0xEAB2,
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
                    KeysNeeded = 2,
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
                    KeysNeeded = 2,
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
                    KeysNeeded = 2,
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
                    KeysNeeded = 2,
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
                    KeysNeeded = 1,
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
                    KeysNeeded = 1,
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
                    BigKeyNeeded = true,
                    KeysNeeded = 2,
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
                    KeysNeeded = 2,
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
                    KeysNeeded = 1,
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
                    KeysNeeded = 1,
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
                    KeysNeeded = 1,
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
                    KeysNeeded = 1,
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
                    KeysNeeded = 2,
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
                    KeysNeeded = 2,
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
                    KeysNeeded = 2,
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
                    BigKeyNeeded = true,
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
                    BigKeyNeeded = true,
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
                    KeysNeeded = 1,
                    BigKeyNeeded = true,
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
                    KeysNeeded = 2,
                    BigKeyNeeded = true,
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
                    KeysNeeded = 2,
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
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-022-B1] Thief's hut [top left chest]",
                    Address = 0xEB12,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-022-B1] Thief's hut [top right chest]",
                    Address = 0xEB15,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-022-B1] Thief's hut [bottom left chest]",
                    Address = 0xEB18,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-022-B1] Thief's hut [bottom right chest]",
                    Address = 0xEB1B,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-073] cave northeast of swamp palace [top chest]",
                    Address = 0xEB1E,
                    CanAccess =
                        have =>
                        CanAccessLowerDarkWorld(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-073] cave northeast of swamp palace [top middle chest]",
                    Address = 0xEB21,
                    CanAccess =
                        have =>
                        CanAccessLowerDarkWorld(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-073] cave northeast of swamp palace [bottom middle chest]",
                    Address = 0xEB24,
                    CanAccess =
                        have =>
                        CanAccessLowerDarkWorld(have),
                },
                new Location
                {
                    LateGameItem = true,
                    Region = Region.DarkWorld,
                    Name = "[cave-073] cave northeast of swamp palace [bottom chest]",
                    Address = 0xEB27,
                    CanAccess =
                        have =>
                        CanAccessLowerDarkWorld(have),
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
                        && ((CanBeInDarkWorld(have)
                                && have.Contains(ItemType.Hammer))
                            || have.Contains(ItemType.Hookshot)),
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
                        && ((CanBeInDarkWorld(have)
                                && have.Contains(ItemType.Hammer))
                            || have.Contains(ItemType.Hookshot)),
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
                        && ((CanBeInDarkWorld(have)
                                && have.Contains(ItemType.Hammer))
                            || have.Contains(ItemType.Hookshot)),
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
                        && ((CanBeInDarkWorld(have)
                                && have.Contains(ItemType.Hammer))
                            || have.Contains(ItemType.Hookshot)),
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
                        && ((CanBeInDarkWorld(have)
                                && have.Contains(ItemType.Hammer))
                            || have.Contains(ItemType.Hookshot)),
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
                        && ((CanBeInDarkWorld(have)
                                && have.Contains(ItemType.Hammer))
                            || have.Contains(ItemType.Hookshot)),
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
                        && ((CanBeInDarkWorld(have)
                                && have.Contains(ItemType.Hammer))
                            || have.Contains(ItemType.Hookshot)),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-016] cave under rocks west of Santuary",
                    Address = 0xEB3F,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have)
                        && have.Contains(ItemType.PegasusBoots),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-050] cave southwest of Lake Hylia [bottom left chest]",
                    Address = 0xEB42,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-050] cave southwest of Lake Hylia [top left chest]",
                    Address = 0xEB45,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-050] cave southwest of Lake Hylia [top right chest]",
                    Address = 0xEB48,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-050] cave southwest of Lake Hylia [bottom right chest]",
                    Address = 0xEB4B,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "[cave-051] Ice Cave",
                    Address = 0xEB4E,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have),
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
                        && have.Contains(ItemType.Hookshot),
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
                        && have.Contains(ItemType.Hookshot),
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
                        && have.Contains(ItemType.Hookshot),
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
                        && have.Contains(ItemType.Hookshot),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.HyruleCastleEscape,
                    Name = "[dungeon-C-B1] Escape - final basement room [left chest]",
                    Address = 0xEB5D,
                    KeysNeeded = 4,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have)
                        && have.Contains(ItemType.PowerGlove),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.HyruleCastleEscape,
                    Name = "[dungeon-C-B1] Escape - final basement room [middle chest]",
                    Address = 0xEB60,
                    KeysNeeded = 4,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have)
                        && have.Contains(ItemType.PowerGlove),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.HyruleCastleEscape,
                    Name = "[dungeon-C-B1] Escape - final basement room [right chest]",
                    Address = 0xEB63,
                    KeysNeeded = 4,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have)
                        && have.Contains(ItemType.PowerGlove),
                },
                //// Getting anything other than the sword here can be bad for progress... may as well keep the sword here since you can't use it if you get it before the uncle.
                //new Location
                //{
                //    LateGameItem = false,
                //    UniqueItemOnly = true,
                //    Region = Region.LightWorld,
                //    Name = "Uncle",
                //    Address = 0x2DF45,
                //    CanAccess =
                //        have =>
                //        true,
                //},
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Bottle Vendor",
                    Address = 0x2EB18,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have)
                },
                new Location
                {
                    LateGameItem = false,
                    UniqueItemOnly = true,
                    Region = Region.LightWorld,
                    Name = "Sahasrahla",
                    Address = 0x2F1FC,
                    CanAccess =
                        have =>
                        CanDefeatEasternPalace(have),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            rom.Seek(0x2F178, SeekOrigin.Begin);
                            rom.Write(Item.GetCheckLocation(item), 0, 1);
                        }
                },
                new Location
                {
                    LateGameItem = false,
                    UniqueItemOnly = true,
                    Region = Region.DarkWorld,
                    Name = "Flute Boy",
                    Address = 0x330C7,
                    CanAccess =
                        have =>
                        CanAccessLowerDarkWorld(have),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            rom.Seek(0x31096, SeekOrigin.Begin);
                            rom.Write(Item.GetCheckLocation(item), 0, 1);
                            //rom.Seek(0x32F9C, SeekOrigin.Begin);
                            //rom.Write(Item.GetCheckLocation(item), 0, 1);
                            rom.Seek(0x33063, SeekOrigin.Begin);
                            rom.Write(Item.GetCheckLocation(item), 0, 1);

                            var compList = new List<ItemType>
                            {
                                ItemType.Bow,
                                ItemType.BowAndArrows,
                                ItemType.RedBoomerang,
                                ItemType.Powder,
                                ItemType.OcarinaInactive,
                                ItemType.MagicMirror,
                                ItemType.TitansMitt,
                                ItemType.RedShield,
                                ItemType.RedMail,
                            };

                            if (!compList.Contains(item))
                            {
                                rom.Seek(0x33067, SeekOrigin.Begin);
                                rom.Write(new []{ (byte)0x01 }, 0, 1);
                            }

                            if (item == ItemType.MirrorShield || item == ItemType.OcarinaActive ||  item == ItemType.Shovel)
                            {
                                rom.Seek(0x33067, SeekOrigin.Begin);
                                rom.Write(new []{ (byte)0x03 }, 0, 1);
                            }
                        }
                },
                new Location
                {
                    LateGameItem = false,
                    UniqueItemOnly = true,
                    Region = Region.LightWorld,
                    Name = "Sick Kid",
                    Address = 0x339CF,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have)
                        && have.Contains(ItemType.Bottle),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            rom.Seek(0x30D87, SeekOrigin.Begin);
                            rom.Write(Item.GetCheckLocation(item), 0, 1);
                        }
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Purple Chest",
                    Address = 0x33D68,
                    CanAccess =
                        have =>
                        CanAccessLowerDarkWorld(have)
                        && have.Contains(ItemType.TitansMitt),
                },
                new Location
                {
                    LateGameItem = false,
                    Region = Region.LightWorld,
                    Name = "Hobo",
                    Address = 0x33E7D,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have)
                        && have.Contains(ItemType.Flippers),
                },
                new Location
                {
                    LateGameItem = false,
                    UniqueItemOnly = true,
                    Region = Region.DarkWorld,
                    Name = "Catfish",
                    Address = 0xEE185,
                    CanAccess =
                        have =>
                        CanAccessPyramid(have)
                        && have.Contains(ItemType.PowerGlove)
                        && (have.Contains(ItemType.PegasusBoots)
                            || have.Contains(ItemType.TitansMitt)),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            rom.Seek(0xEE103, SeekOrigin.Begin);
                            rom.Write(Item.GetCheckLocation(item), 0, 1);
                            rom.Seek(0xEE11D, SeekOrigin.Begin);
                            rom.Write(Item.GetCheckLocation(item), 0, 1);
                        }
                },
                //// Zora's appearance is based on if you have flippers or not
                new Location
                {
                    LateGameItem = false,
                    UniqueItemOnly = true,
                    Region = Region.LightWorld,
                    Name = "King Zora",
                    Address = 0xEE1C3,
                    CanAccess =
                        have =>
                        CanEscapeCastle(have)
                        && ((have.Contains(ItemType.PowerGlove)
                                && (have.Contains(ItemType.PegasusBoots)
                                    || have.Contains(ItemType.TitansMitt)))
                            || have.Contains(ItemType.Flippers)),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            rom.Seek(0x30F17, SeekOrigin.Begin);
                            rom.Write(Item.GetCheckLocation(item), 0, 1);
                        }
                },
                new Location
                {
                    LateGameItem = false,
                    UniqueItemOnly = true,
                    Region = Region.LightWorld,
                    Name = "Old mountain man",
                    Address = 0xF69FA,
                    CanAccess =
                        have =>
                        CanClimbDeathMountain(have),
                    WriteItemCheck =
                        (rom, item) =>
                        {
                            // this is for the bit that lets you choose where to start in the light world
                            rom.Seek(0x100F3, SeekOrigin.Begin);
                            rom.Write(Item.GetCheckLocation(item), 0, 1);
                            // old man check
                            rom.Seek(0xF690B, SeekOrigin.Begin);
                            rom.Write(Item.GetCheckLocation(item), 0, 1);

                            var compList = new List<ItemType>
                            {
                                ItemType.Bow,
                                ItemType.BowAndArrows,
                                ItemType.RedBoomerang,
                                ItemType.Powder,
                                ItemType.OcarinaInactive,
                                ItemType.MagicMirror,
                                ItemType.TitansMitt,
                                ItemType.RedShield,
                                ItemType.RedMail,
                            };

                            if (!compList.Contains(item))
                            {
                                // this is for the bit that lets you choose where to start in the light world
                                rom.Seek(0x100F7, SeekOrigin.Begin);
                                rom.Write(new []{ (byte)0x01 }, 0, 1);
                                // old man check
                                rom.Seek(0xF690F, SeekOrigin.Begin);
                                rom.Write(new []{ (byte)0x01 }, 0, 1);
                            }

                            if (item == ItemType.MirrorShield || item == ItemType.OcarinaActive)
                            {
                                // this is for the bit that lets you choose where to start in the light world
                                rom.Seek(0x100F7, SeekOrigin.Begin);
                                rom.Write(new []{ (byte)0x03 }, 0, 1);
                                // old man check
                                rom.Seek(0xF690F, SeekOrigin.Begin);
                                rom.Write(new []{ (byte)0x03 }, 0, 1);
                            }
                        }
                },
            };
        }

        private bool CanEnterHyruleCastleTower(List<ItemType> have)
        {
            return (CanGetMasterSword(have))
                || (have.Contains(ItemType.Cape));
        }

        private bool CanGetMasterSword(List<ItemType> have)
        {
            return CanDefeatEasternPalace(have)
                && CanDefeatDesertPalace(have)
                && CanDefeatTowerOfHera(have);
        }

        private bool CanAccessEastDarkWorldDeathMountain(List<ItemType> have)
        {
            return CanClimbDeathMountain(have)
                && have.Contains(ItemType.Hammer)
                && have.Contains(ItemType.TitansMitt)
                && CanBeInDarkWorld(have);
        }

        private bool CanClimbDeathMountain(List<ItemType> have)
        {
            return CanEscapeCastle(have)
                && have.Contains(ItemType.PowerGlove);
        }

        private bool CanEnterGanonsTower(List<ItemType> have)
        {
            // items guaranteed here: Cane of Somaria, Ether, Fire Rod, Flippers, Hammer, Hookshot, Magic Mirror, Ocarina, Quake, Titan's Mitt
            return CanDefeatDarkPalace(have)
                && CanDefeatSwampPalace(have)
                && CanDefeatSkullWoods(have)
                && CanDefeatThievesTown(have)
                && CanDefeatIcePalace(have)
                && CanDefeatMiseryMire(have)
                && CanDefeatTurtleRock(have);
        }

        private bool CanDefeatDarkPalace(List<ItemType> have)
        {
            return CanEnterDarkPalace(have)
                && have.Contains(ItemType.Bow)
                && have.Contains(ItemType.Hammer);
        }

        private bool CanDefeatSwampPalace(List<ItemType> have)
        {
            return CanEnterSwampPalace(have)
                && have.Contains(ItemType.Hookshot);
        }

        private bool CanDefeatSkullWoods(List<ItemType> have)
        {
            return CanEnterSkullWoods2(have);
        }

        private bool CanDefeatThievesTown(List<ItemType> have)
        {
            return CanEnterThievesTown(have);
        }

        private bool CanDefeatIcePalace(List<ItemType> have)
        {
            return CanEnterIcePalace(have);
        }

        private bool CanDefeatMiseryMire(List<ItemType> have)
        {
            return CanEnterMiseryMire(have)
                && have.Contains(ItemType.CaneOfSomaria);
        }

        private bool CanDefeatTurtleRock(List<ItemType> have)
        {
            return CanEnterTurtleRock(have)
                && have.Contains(ItemType.FireRod)
                && have.Contains(ItemType.IceRod);
        }

        private bool CanEnterTurtleRock(List<ItemType> have)
        {
            return CanAccessEastDarkWorldDeathMountain(have)
                && have.Contains(ItemType.Hammer)
                && have.Contains(ItemType.Quake)
                && have.Contains(ItemType.CaneOfSomaria);
        }

        private bool CanEnterMiseryMire(List<ItemType> have)
        {
            return have.Contains(ItemType.OcarinaActive)
                && CanBeInDarkWorld(have)
                && have.Contains(ItemType.TitansMitt)
                && have.Contains(ItemType.Ether)
                && (have.Contains(ItemType.PegasusBoots)
                    || have.Contains(ItemType.Hookshot));
        }

        private bool CanBeInDarkWorld(List<ItemType> have)
        {
            return have.Contains(ItemType.MagicMirror)
                && have.Contains(ItemType.MoonPearl)
                && CanDefeatAgahnim1(have);
        }

        private bool CanEnterIcePalace(List<ItemType> have)
        {
            return have.Contains(ItemType.Flippers)
                && CanBeInDarkWorld(have)
                && have.Contains(ItemType.TitansMitt)
                && (have.Contains(ItemType.FireRod)
                    || have.Contains(ItemType.Bombos));
        }

        private bool CanEnterThievesTown(List<ItemType> have)
        {
            return CanAccessLowerDarkWorld(have);
        }

        private bool CanEnterSkullWoods2(List<ItemType> have)
        {
            return CanEnterSkullWoods(have)
            && have.Contains(ItemType.FireRod);
        }

        private bool CanEnterSkullWoods(List<ItemType> have)
        {
            return CanAccessLowerDarkWorld(have);
        }

        private bool CanEnterSwampPalace(List<ItemType> have)
        {
            return CanAccessLowerDarkWorld(have)
                && have.Contains(ItemType.Flippers);
        }

        private bool CanAccessLowerDarkWorld(List<ItemType> have)
        {
            return CanAccessPyramid(have)
                && (have.Contains(ItemType.Hammer)
					|| have.Contains(ItemType.Hookshot))
                && CanBeInDarkWorld(have);
        }

        private bool CanEnterDarkPalace(List<ItemType> have)
        {
            return CanAccessPyramid(have);
        }

        private bool CanAccessPyramid(List<ItemType> have)
        {
            return (CanDefeatAgahnim1(have)
                    || (have.Contains(ItemType.Hammer)
                        && have.Contains(ItemType.TitansMitt)))
                && CanBeInDarkWorld(have);
        }

        private bool CanDefeatAgahnim1(List<ItemType> have)
        {
            return CanEnterHyruleCastleTower(have);
        }

        private bool CanDefeatTowerOfHera(List<ItemType> have)
        {
            return CanEnterTowerOfHera(have);
        }

        private bool CanDefeatDesertPalace(List<ItemType> have)
        {
            return CanEnterDesertPalace(have)
                && have.Contains(ItemType.PowerGlove)
                && have.Contains(ItemType.Bow);
        }

        private bool CanDefeatEasternPalace(List<ItemType> have)
        {
            return CanEnterEasternPalace(have)
                && have.Contains(ItemType.Bow);
        }

        private bool CanEnterTowerOfHera(List<ItemType> have)
        {
            return CanEscapeCastle(have)
                && CanClimbDeathMountain(have)
                && have.Contains(ItemType.MagicMirror);
        }

        private bool CanEnterDesertPalace(List<ItemType> have)
        {
            return CanEscapeCastle(have)
                && have.Contains(ItemType.BookOfMudora)
                && have.Contains(ItemType.PegasusBoots);
        }

        private bool CanEnterEasternPalace(List<ItemType> have)
        {
            return CanEscapeCastle(have);
        }

        private bool CanEscapeCastle(List<ItemType> have)
        {
            return have.Contains(ItemType.Lamp);
        }

        public List<Location> GetAvailableLocations(List<ItemType> haveItems)
        {
            return (from Location location in Locations where (location.Item == null || location.Item.Type == ItemType.Progression) && location.CanAccess(haveItems) select location).ToList();
        }

        public List<Location> GetUnavailableLocations(List<ItemType> haveItems)
        {
            return (from Location location in Locations where (location.Item == null || location.Item.Type == ItemType.Progression) && !location.CanAccess(haveItems) select location).ToList();
        }

        public void TryInsertCandidateItem(List<Location> currentLocations, List<ItemType> candidateItemList, ItemType candidateItem)
        {
            var uniqueItems = GetUniqueItems();
            var badLateGameItem = IsLateGameItem(candidateItem) && !currentLocations.Any(x => x.LateGameItem);
            var needUniqueItem = !uniqueItems.Contains(candidateItem) && currentLocations.All(x => x.UniqueItemOnly);
            var badFirstItem = IsBadFirstItem(candidateItem) && currentLocations.Any(x => x.Name == "[cave-040] Link's House");

            if (!badLateGameItem && !needUniqueItem && !badFirstItem)
            {
                candidateItemList.Add(candidateItem);
            }
        }

        private static bool IsBadFirstItem(ItemType item)
        {
            return (item == ItemType.PowerGlove || item == ItemType.TitansMitt || item == ItemType.RedShield || item == ItemType.MirrorShield);
        }

        public int GetInsertedLocation(List<Location> currentLocations, ItemType insertedItem, SeedRandom random)
        {
            int retVal;
            var uniqueItems = GetUniqueItems();
            bool badLateGameItemSpot;
            bool badUniqueItemSpot;
            bool unusedUniqueItemSpot;

            do
            {
                retVal = random.Next(currentLocations.Count);

                badLateGameItemSpot = IsLateGameItem(insertedItem) && !currentLocations[retVal].LateGameItem;
                badUniqueItemSpot = !uniqueItems.Contains(insertedItem) && currentLocations[retVal].UniqueItemOnly;
                unusedUniqueItemSpot = uniqueItems.Contains(insertedItem) && !currentLocations[retVal].UniqueItemOnly && currentLocations.Any(x => x.UniqueItemOnly);
            } while (badLateGameItemSpot || badUniqueItemSpot || unusedUniqueItemSpot);

            return retVal;
        }

        private static bool IsLateGameItem(ItemType item)
        {
            return item == ItemType.TitansMitt || item == ItemType.RedMail || item == ItemType.MirrorShield;
        }

        public ItemType GetInsertedItem(List<Location> currentLocations, List<ItemType> itemPool, SeedRandom random)
        {
            ItemType retVal;
            var uniqueItems = GetUniqueItems();
            bool badLateGameItem;
            bool needUniqueItem;

            do
            {
                retVal = itemPool[random.Next(itemPool.Count)];

                badLateGameItem = IsLateGameItem(retVal) && !currentLocations.Any(x => x.LateGameItem);
                needUniqueItem = !uniqueItems.Contains(retVal) && currentLocations.All(x => x.UniqueItemOnly);
            } while (badLateGameItem || needUniqueItem);

            return retVal;
        }

        public List<ItemType> GetImplicitProgressionItems(List<ItemType> have)
        {
            var retVal = new List<ItemType>();

            if (CanDefeatEasternPalace(have) && !have.Contains(ItemType.BookOfMudora))
            {
                retVal.Add(ItemType.BookOfMudora);
            }
            if (CanGetMasterSword(have) && !have.Contains(ItemType.Bombos) && CanAccessLowerDarkWorld(have))
            {
                retVal.Add(ItemType.Bombos);
            }
            if (CanGetMasterSword(have) && !have.Contains(ItemType.Ether))
            {
                retVal.Add(ItemType.Ether);
            }
            if (CanEscapeCastle(have) && have.Contains(ItemType.Shovel))
            {
                retVal.Add(ItemType.OcarinaInactive);
                retVal.Add(ItemType.OcarinaActive);
            }

            return retVal;
        }

        public List<ItemType> GetUniqueItems()
        {
            // Please exclude late game items from this list
            return new List<ItemType>
            {
                // advancement items
                ItemType.Bow,
                ItemType.CaneOfSomaria,
                ItemType.FireRod,
                ItemType.Flippers,
                //ItemType.Hammer,
                ItemType.Hookshot,
                ItemType.IceRod,
                //ItemType.Lamp,
                ItemType.MagicMirror,
                ItemType.MoonPearl,
                ItemType.PegasusBoots,
                ItemType.PowerGlove,
                ItemType.Quake,
                ItemType.Shovel,
                //ItemType.TitansMitt,
                ItemType.BlueMail,
                //ItemType.Boomerang,
                ItemType.BugCatchingNet,
                ItemType.Cape,
                //ItemType.MirrorShield,
                //ItemType.RedBoomerang,
                //ItemType.RedMail,
                ItemType.StaffOfByrna,
            };
        }

        public List<ItemType> GetItemPool(SeedRandom random)
        {
            return new List<ItemType>
            {
                // advancement items
                ItemType.Bow,
                ItemType.CaneOfSomaria,
                ItemType.FireRod,
                ItemType.Flippers,
                ItemType.Hammer,
                ItemType.Hookshot,
                ItemType.IceRod,
                ItemType.Lamp,
                ItemType.Lamp,
                ItemType.Lamp,
                //ItemType.L1SwordAndShield,
                ItemType.MagicMirror,
                ItemType.MoonPearl,
                ItemType.PegasusBoots,
                ItemType.PowerGlove,
                ItemType.Quake,
                ItemType.Shovel,
                ItemType.TitansMitt,
                
                // nice-to-have items
                ItemType.BlueMail,
                ItemType.Boomerang,
                ItemType.Boomerang,
                ItemType.Bottle,
                ItemType.Bottle,
                ItemType.Bottle,
                ItemType.Bottle,
                ItemType.BugCatchingNet,
                ItemType.Cape,
                ItemType.HeartContainer,
                ItemType.MirrorShield,
                ItemType.PieceOfHeart,
                ItemType.PieceOfHeart,
                ItemType.PieceOfHeart,
                ItemType.PieceOfHeart,
                ItemType.PieceOfHeart,
                ItemType.PieceOfHeart,
                ItemType.RedBoomerang,
                ItemType.RedMail,
                ItemType.RedShield,
                ItemType.StaffOfByrna,
                
                // other treasure box contents
                ItemType.Arrow,
                ItemType.TenArrows,
                ItemType.TenArrows,
                ItemType.TenArrows,
                ItemType.TenArrows,
                ItemType.TenArrows,
                ItemType.TenArrows,
                ItemType.TenArrows,
                ItemType.TenArrows,
                ItemType.TenArrows,
                ItemType.TenArrows,

                ItemType.ThreeBombs,
                ItemType.ThreeBombs,
                ItemType.ThreeBombs,
                ItemType.ThreeBombs,
                ItemType.ThreeBombs,
                ItemType.ThreeBombs,
                ItemType.ThreeBombs,
                ItemType.ThreeBombs,
                ItemType.ThreeBombs,
                ItemType.ThreeBombs,
                ItemType.ThreeBombs,
                ItemType.ThreeBombs,
                ItemType.ThreeBombs,
                ItemType.ThreeBombs,
                ItemType.ThreeBombs,
                ItemType.ThreeBombs,
                ItemType.ThreeBombs,

                ItemType.OneRupee,
                ItemType.OneRupee,
                ItemType.FiveRupees,
                ItemType.FiveRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.TwentyRupees,
                ItemType.FiftyRupees,
                ItemType.FiftyRupees,
                ItemType.FiftyRupees,
                ItemType.FiftyRupees,
                ItemType.FiftyRupees,
                ItemType.FiftyRupees,
                ItemType.FiftyRupees,
                ItemType.OneHundredRupees,
                ItemType.ThreeHundredRupees,
                ItemType.ThreeHundredRupees,
            };
        }
    }
}
