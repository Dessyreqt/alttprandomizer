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
        public string DifficultyName => "Casual";
	    public string SeedFileString => "C{0:0000000}";
	    public string SeedRomString => "Z3Rv{0} C{1}";

	    public void ResetLocations()
        {
            Locations = new List<Location>
            {
	            new Location
	            {
		            Region = Region.HyruleCastleEscape,
					Name = "Escape - first B2 room [50] (key)",
					Address = 0xE96E,
					CanAccess =
						have =>
						true,
				},
				new Location
				{
					Region = Region.HyruleCastleEscape,
					Name = "Escape - first B2 room [50] (key)",
					Address = 0xE96E,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Hyrule Castle Secret Entrance [85] (lamp / 5 rupees)",
					Address = 0xE971,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.HyruleCastleEscape,
					Name = "Hyrule Castle Boomerang room [113] (boomerang / 10 arrows)",
					Address = 0xE974,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.EasternPalace,
					Name = "Eastern Palace - compass room [168] (compass)",
					Address = 0xE977,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DarkWorld,
					Name = "Graveyard Cave [275] (Magic cape)",
					Address = 0xE97A,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.EasternPalace,
					Name = "Eastern Palace - bow [169] (bow)",
					Address = 0xE97D,
					CanAccess =
						have
						=> true,
				},


				new Location
				{
					Region = Region.SwampPalace,
					Name = "Swamp Palace - map room [55] (map)",
					Address = 0xE986,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.SwampPalace,
					Name = "Swamp Palace - hookshot room [54] (hookshot)",
					Address = 0xE989,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Dam [267] (3 bombs)",
					Address = 0xE98C,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DesertPalace,
					Name = "Desert Palace - Power Glove [115] (power glove)",
					Address = 0xE98F,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.SkullWoods,
					Name = "Skull Woods -  Compass room [103] (compass)",
					Address = 0xE992,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.IcePalace,
					Name = "Ice Palace - above Blue Mail room [126] (3 bombs)",
					Address = 0xE995,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.SkullWoods,
					Name = "Skull Woods - Fire Rod room [88] (fire rod)",
					Address = 0xE998,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.SkullWoods,
					Name = "Skull Woods - east of Fire Rod room [88] (map)",
					Address = 0xE99B,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.SkullWoods,
					Name = "Skull Woods - Big Key room [87] (big key)",
					Address = 0xE99E,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.SkullWoods,
					Name = "Skull Woods - Gibdo/Stalfos room [87] (key)",
					Address = 0xE9A1,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.IcePalace,
					Name = "Ice Palace - Big Key room [31] (big key)",
					Address = 0xE9A4,
					CanAccess =
						have
						=> true,
				},

				new Location
				{
					Region = Region.IcePalace,
					Name = "Ice Palace - Blue Mail [158] (blue mail)",
					Address = 0xE9AA,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.TowerOfHera,
					Name = "Tower of Hera - Entrance [119] (map)",
					Address = 0xE9AD,
					CanAccess =
						have
						=> true,
				},

				new Location
				{
					Region = Region.EasternPalace,
					Name = "Eastern Palace - big ball room [185] (100 rupees)",
					Address = 0xE9B3,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DesertPalace,
					Name = "Desert Palace - Map room [116] (map)",
					Address = 0xE9B6,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.EasternPalace,
					Name = "Eastern Palace - Big key [184] (big key)",
					Address = 0xE9B9,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Link's House [260] (Lamp / 5 Rupees)",
					Address = 0xE9BC,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "cave??? [254] (50 rupees)",
					Address = 0xE9BF,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DesertPalace,
					Name = "Desert Palace - Big key room [117] (big key)",
					Address = 0xE9C2,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Light World Mimic Cave [268] (Piece of Heart)",
					Address = 0xE9C5,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.SkullWoods,
					Name = "Skull Woods - south of Fire Rod room [104] (key)",
					Address = 0xE9C8,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DesertPalace,
					Name = "Desert Palace - compass room [133] (compass)",
					Address = 0xE9CB,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Tavern [259] (Bottle)",
					Address = 0xE9CE,
					CanAccess =
						have
						=> true,
				},

				new Location
				{
					Region = Region.IcePalace,
					Name = "Ice Palace - compass room [46] (compass)",
					Address = 0xE9D4,
					CanAccess =
						have
						=> true,
				},

				new Location
				{
					Region = Region.MiseryMire,
					Name = "Misery Mire - spike room [179] (key)",
					Address = 0xE9DA,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.IcePalace,
					Name = "Ice Palace - map room [63] (map)",
					Address = 0xE9DD,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.IcePalace,
					Name = "Ice Palace - spike room [95] (key)",
					Address = 0xE9E0,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.IcePalace,
					Name = "Ice Palace - b5 up staircase [174] (key)",
					Address = 0xE9E3,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.TowerOfHera,
					Name = "Tower of Hera - first floor [135] (big key)",
					Address = 0xE9E6,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "chicken house [264] (Boomerang / 10 arrows)",
					Address = 0xE9E9,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DarkWorld,
					Name = "doorless hut [262] (Red Boomerang / 300 Rupees)",
					Address = 0xE9EC,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "C-shaped house [284] (300 rupees)",
					Address = 0xE9EF,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Aginah's cave [266] (Piece of Heart)",
					Address = 0xE9F2,
					CanAccess =
						have
						=> true,
				},

				new Location
				{
					Region = Region.TowerOfHera,
					Name = "Tower of Hera - Moon pearl room [big chest] [39] (moon pearl)",
					Address = 0xE9F8,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.TowerOfHera,
					Name = "Tower of Hera - Moon pearl room [small chest] [39] (compass)",
					Address = 0xE9FB,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.SkullWoods,
					Name = "Skull Woods - Entrance to part 2 [89] (key)",
					Address = 0xE9FE,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.ThievesTown,
					Name = "Thieves' Town - Bottom left of huge room [top left chest] [219] (map)",
					Address = 0xEA01,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.ThievesTown,
					Name = "Thieves' Town - Bottom left of huge room [bottom right chest] [219] (big key)",
					Address = 0xEA04,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.ThievesTown,
					Name = "Thieves' Town - Bottom right of huge room [220] (compass)",
					Address = 0xEA07,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.ThievesTown,
					Name = "Thieves' Town - Top left of huge room [203] (20 rupees)",
					Address = 0xEA0A,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.ThievesTown,
					Name = "Thieves' Town - Room above boss [101] (3 bombs) ",
					Address = 0xEA0D,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.ThievesTown,
					Name = "Thieves' Town - Titan's Mitt [68] (Titan's Mitt)",
					Address = 0xEA10,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.ThievesTown,
					Name = "Thieves' Town - next to Blind [69] (key)",
					Address = 0xEA13,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.TurtleRock,
					Name = "Turtle Rock - Chain chomp room [182] (key)",
					Address = 0xEA16,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.TurtleRock,
					Name = "Turtle Rock - Mirror shield room [36] (mirror shield)",
					Address = 0xEA19,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.TurtleRock,
					Name = "Turtle Rock - Map room [left chest] [183] (map)",
					Address = 0xEA1C,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.TurtleRock,
					Name = "Turtle Rock - Map room [right chest] [183] (key)",
					Address = 0xEA1F,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.TurtleRock,
					Name = "Turtle Rock - compass room [214] (compass)",
					Address = 0xEA22,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.TurtleRock,
					Name = "Turtle Rock - big key room [20] (big key)",
					Address = 0xEA25,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.TurtleRock,
					Name = "Turtle Rock - Eye bridge room [top right chest] [213] (1 rupee)",
					Address = 0xEA28,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.TurtleRock,
					Name = "Turtle Rock - Eye bridge room [top left chest] [213] (5 rupees)",
					Address = 0xEA2B,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.TurtleRock,
					Name = "Turtle Rock - Eye bridge room [bottom rigth chest] [213] (20 rupees)",
					Address = 0xEA2E,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.TurtleRock,
					Name = "Turtle Rock - Eye bridge room [bottom left chest] [213] (key)",
					Address = 0xEA31,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.TurtleRock,
					Name = "Turtle Rock - Roller switch room [4] (key)",
					Address = 0xEA34,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DarkPalace,
					Name = "Dark Palace - big key room [58] (big key)",
					Address = 0xEA37,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DarkPalace,
					Name = "Dark Palace - jump room [right chest] [42] (key)",
					Address = 0xEA3A,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DarkPalace,
					Name = "Dark Palace - jump room [left chest] [42] (key)",
					Address = 0xEA3D,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DarkPalace,
					Name = "Dark Palace - hammer room [26] (hammer)",
					Address = 0xEA40,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DarkPalace,
					Name = "Dark Palace - compass room [26] (compass)",
					Address = 0xEA43,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DarkPalace,
					Name = "Dark Palace - spike statue room [26] (5 rupees)",
					Address = 0xEA46,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DarkPalace,
					Name = "Dark Palace - turtle stalfos room [10] (key)",
					Address = 0xEA49,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DarkPalace,
					Name = "Dark Palace - room leading to Helmasaur [left chest] [106] (arrow)",
					Address = 0xEA4C,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DarkPalace,
					Name = "Dark Palace - room leading to Helmasaur [right chest] [106] (key)",
					Address = 0xEA4F,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DarkPalace,
					Name = "Dark Palace - statue push room [43] (map)",
					Address = 0xEA52,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DarkPalace,
					Name = "Dark Palace - maze room [top chest] [25] (3 bombs)",
					Address = 0xEA55,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DarkPalace,
					Name = "Dark Palace - maze room [bottom chest] [25] (key)",
					Address = 0xEA58,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DarkPalace,
					Name = "Dark Palace - shooter room [9] (key)",
					Address = 0xEA5B,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.MiseryMire,
					Name = "Misery Mire - big hub room [194] (key)",
					Address = 0xEA5E,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.MiseryMire,
					Name = "Misery Mire - end of bridge [162] (key)",
					Address = 0xEA61,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.MiseryMire,
					Name = "Misery Mire - compass [193] (compass)",
					Address = 0xEA64,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.MiseryMire,
					Name = "Misery Mire - Cane of Somaria [195] (cane of somaria)",
					Address = 0xEA67,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.MiseryMire,
					Name = "Misery Mire - map room [195] (map)",
					Address = 0xEA6A,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.MiseryMire,
					Name = "Misery Mire - big key [209] (big key)",
					Address = 0xEA6D,
					CanAccess =
						have
						=> true,
				},

				new Location
				{
					Region = Region.MiseryMire,
					Name = "Misery Mire west area [left chest] [269] (Piece of Heart)",
					Address = 0xEA73,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.MiseryMire,
					Name = "Misery Mire west area [right chest] [269] (20 rupees)",
					Address = 0xEA76,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Sanctuary [18] (Heart Container)",
					Address = 0xEA79,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "cave??? [top chest] [248] (3 bombs)",
					Address = 0xEA7C,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "cave??? [bottom chest] [248] (20 rupees)",
					Address = 0xEA7F,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Sahasrahla's Hut [left chest] [261] (50 rupees)",
					Address = 0xEA82,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Sahasrahla's Hut [center chest] [261] (3 bombs)",
					Address = 0xEA85,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Sahasrahla's Hut [right chest] [261] (50 rupees)",
					Address = 0xEA88,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DarkWorld,
					Name = "Spike cave [279] (Staff of Byrna)",
					Address = 0xEA8B,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Kakariko well [top chest] [47] (Piece of Heart)",
					Address = 0xEA8E,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Kakariko well [left chest row of 3] [47] (20 rupees)",
					Address = 0xEA91,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Kakariko well [center chest row of 3] [47] (20 rupees)",
					Address = 0xEA94,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Kakariko well [right chest row of 3] [47] (20 rupees)",
					Address = 0xEA97,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Kakariko well [bottom chest] [47] (3 bombs)",
					Address = 0xEA9A,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.SwampPalace,
					Name = "Swamp Palace - First room [40] (key)",
					Address = 0xEA9D,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.SwampPalace,
					Name = "Swamp Palace - south of hookshot room [70] (compass)",
					Address = 0xEAA0,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.SwampPalace,
					Name = "Swamp Palace - push 4 blocks room [52] (20 rupees)",
					Address = 0xEAA3,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.SwampPalace,
					Name = "Swamp Palace - big key room [53] (big key)",
					Address = 0xEAA6,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.SwampPalace,
					Name = "Swamp Palace - flooded room [left chest] [118] (20 rupees)",
					Address = 0xEAA9,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.SwampPalace,
					Name = "Swamp Palace - flooded room [right chest] [118] (20 rupees)",
					Address = 0xEAAC,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.SwampPalace,
					Name = "Swamp Palace - hidden waterfall door room [102] (20 rupees)",
					Address = 0xEAAF,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.HyruleCastleTower,
					Name = "Hyrule Castle Tower - maze room [208] (key)",
					Address = 0xEAB2,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.HyruleCastleTower,
					Name = "Hyrule Castle Tower - 2 knife guys room [224] (key)",
					Address = 0xEAB5,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - north of gap room [top left chest] [123] (3 bombs)",
					Address = 0xEAB8,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - north of gap room [top right chest] [123] (10 arrows)",
					Address = 0xEABB,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - north of gap room [bottom left chest] [123] (20 rupees)",
					Address = 0xEABE,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - north of gap room [bottom right chest] [123] (20 rupees)",
					Address = 0xEAC1,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - west of teleport room [top left chest] [124] (10 arrows)",
					Address = 0xEAC4,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - west of teleport room [top right chest] [124] (10 arrows)",
					Address = 0xEAC7,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - west of teleport room [bottom left chest] [124] (3 bombs)",
					Address = 0xEACA,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - west of teleport room [bottom right chest] [124] (3 bombs)",
					Address = 0xEACD,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - north of teleport room [125] (key)",
					Address = 0xEAD0,
					CanAccess =
						have
						=> true,
				},

				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - Red Mail [140] (red mail)",
					Address = 0xEAD6,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - down right staircase from entrance [left chest] [140] (10 arrows)",
					Address = 0xEAD9,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - down right staircase from entrance [right chest] [140] (3 bombs)",
					Address = 0xEADC,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - above Armos [140] (10 arrows)",
					Address = 0xEADF,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - east of down right staircase from entrace [141] (key)",
					Address = 0xEAE2,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - compass room [top left chest] [157] (compass)",
					Address = 0xEAE5,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - compass room [top right chest] [157] (1 rupee)",
					Address = 0xEAE8,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - compass room [bottom left chest] [157] (20 rupees)",
					Address = 0xEAEB,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - compass room [bottom right chest] [157] (10 arrows)",
					Address = 0xEAEE,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - north of Armos room [bottom chest] [28] (big key)",
					Address = 0xEAF1,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - north of Armos room [left chest] [28] (10 arrows)",
					Address = 0xEAF4,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - north of Armos room [right chest] [28] (3 bombs)",
					Address = 0xEAF7,
					CanAccess =
						have
						=> true,
				},

				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - north of falling floor four torches [top left chest] [61] (3 bombs)",
					Address = 0xEAFD,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - north of falling floor four torches [top right chest] [61] (3 bombs)",
					Address = 0xEB00,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - before Moldorm [61] (key)",
					Address = 0xEB03,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.GanonsTower,
					Name = "Ganon's Tower - Moldorm room [77] (20 rupees)",
					Address = 0xEB06,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.HyruleCastleEscape,
					Name = "Hyrule Castle - next to Zelda [128] (lamp / 5 rupees)",
					Address = 0xEB09,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.HyruleCastleEscape,
					Name = "Hyrule Castle - map room [114] (map) ",
					Address = 0xEB0C,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Thief's hut [top chest] [285] (Piece of Heart)",
					Address = 0xEB0F,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Thief's hut [top left chest] [285] (20 rupees)",
					Address = 0xEB12,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Thief's hut [top right chest] [285] (20 rupees)",
					Address = 0xEB15,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Thief's hut [bottom left chest] [285] (20 rupees)",
					Address = 0xEB18,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Thief's hut [bottom right chest] [285] (20 rupees)",
					Address = 0xEB1B,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "cave??? [top chest] [286] (20 rupees)",
					Address = 0xEB1E,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "cave??? [top middle chest] [286] (20 rupees)",
					Address = 0xEB21,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "cave??? [bottom middle chest] [286] (20 rupees)",
					Address = 0xEB24,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "cave??? [bottom chest] [286] (20 rupees)",
					Address = 0xEB27,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "cave??? five chests [top left chest] [239] (20 rupees)",
					Address = 0xEB2A,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "cave??? five chests [top left middle chest] [239] (20 rupees)",
					Address = 0xEB2D,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "cave??? five chests [top right middle chest] [239] (20 rupees)",
					Address = 0xEB30,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "cave??? five chests [top right chest] [239] (20 rupees)",
					Address = 0xEB33,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "cave??? five chests [bottom chest] [239] (20 rupees)",
					Address = 0xEB36,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "cave with shop??? [left chest] [255] (3 bombs)",
					Address = 0xEB39,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "cave with shop??? [right chest] [255] (10 arrows)",
					Address = 0xEB3C,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "cave near sanctuary??? [292] (Piece of Heart)",
					Address = 0xEB3F,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "Moldorm Cave [bottom left chest] [291] (3 bombs)",
					Address = 0xEB42,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "Moldorm Cave [top left chest] [291] (20 rupees)",
					Address = 0xEB45,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "Moldorm Cave [top right chest] [291] (20 rupees)",
					Address = 0xEB48,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "Moldorm Cave [bottom right chest] [291] (10 arrows)",
					Address = 0xEB4B,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Ice Cave [288] (Ice Rod)",
					Address = 0xEB4E,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "Hidden floor cave [top right chest] [60] (50 rupees)",
					Address = 0xEB51,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "Hidden floor cave [top left chest] [60] (50 rupees)",
					Address = 0xEB54,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "Hidden floor cave [bottom left chest] [60] (50 rupees)",
					Address = 0xEB57,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.Unknown,
					Name = "Hidden floor cave [bottom right chest] [60] (50 rupees)",
					Address = 0xEB5A,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.HyruleCastleEscape,
					Name = "Escape - final basement room [left chest] [17] (3 Bombs)",
					Address = 0xEB5D,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Uncle (L.1 Sword & Shield)",
					Address = 0x2DF45,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Sahasrahla (Pegasus Boots)",
					Address = 0x2F1FC,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DarkWorld,
					Name = "Flute Boy (Shovel)",
					Address = 0x330BF,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Sick Kid (Bug-Catching Net)",
					Address = 0x339C7,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Purple Chest (Bottle)",
					Address = 0x33D60,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Hobo (Bottle)",
					Address = 0x33E75,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.DarkWorld,
					Name = "Catfish (Quake)",
					Address = 0xEE185,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "King Zora (Flippers)",
					Address = 0xEE1C3,
					CanAccess =
						have
						=> true,
				},
				new Location
				{
					Region = Region.LightWorld,
					Name = "Old mountain man (Magic Mirror)",
					Address = 0xF6A00,
					CanAccess =
						have
						=> true,
				},
			};
        }

        public List<Location> GetAvailableLocations(List<ItemType> haveItems)
        {
			return (from Location location in Locations where location.Item == null && location.CanAccess(haveItems) select location).ToList();
		}

		public List<Location> GetUnavailableLocations(List<ItemType> haveItems)
        {
			return (from Location location in Locations where location.Item == null && !location.CanAccess(haveItems) select location).ToList();
		}

		public void TryInsertCandidateItem(List<Location> currentLocations, List<ItemType> candidateItemList, ItemType candidateItem)
        {
			candidateItemList.Add(candidateItem);
		}

		public int GetInsertedLocation(List<Location> currentLocations, ItemType insertedItem, SeedRandom random)
		{
			int retVal = random.Next(currentLocations.Count);

			return retVal;
		}

	    public ItemType GetInsertedItem(List<Location> currentLocations, List<ItemType> itemPool, SeedRandom random)
	    {
		    ItemType retVal = itemPool[random.Next(itemPool.Count)];

		    return retVal;
	    }

	    public List<ItemType> GetItemPool(SeedRandom random)
        {
			return new List<ItemType>
			{
				// advancement items
				ItemType.CaneOfSomaria,
				ItemType.Bow,
				ItemType.FireRod,
				ItemType.Flippers,
				ItemType.Hammer,
				ItemType.Hookshot,
				ItemType.IceRod,
				ItemType.L1SwordAndShield,
				ItemType.Lamp,
				ItemType.Lamp,
				ItemType.Lamp,
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
				ItemType.Cape,
				ItemType.HeartContainer,
				ItemType.MirrorShield,
				ItemType.Net,
				ItemType.PieceOfHeart,
				ItemType.PieceOfHeart,
				ItemType.PieceOfHeart,
				ItemType.PieceOfHeart,
				ItemType.PieceOfHeart,
				ItemType.PieceOfHeart,
				ItemType.RedBoomerang,
				ItemType.RedMail,
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
