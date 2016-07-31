# Current Version: 5

# About the Legend of Zelda: A Link to the Past Randomizer (or ALttPRandomizer)
This is a simple program that moves around items in the Legend of Zelda: A Link to the Past (ALttP). It is used for racing the game.

When racing the game, it is suggested that each player play the same seed to ensure a level playing field.

This was created by Dessyreqt & Karkat, with input from the SRL ALttP community.

# Using the Randomizer
Select a location to save your randomized rom, then select `Create`.

Right now there is only one difficulty, "Casual". There may be other difficulties in the future.

# Differences from the normal game
There are a number of differences from a randomized game to the normal game. Here's a short list:
- The game text is in Japanese _(this obviously isn't different if you are used to playing in Japanese. See below for why.)_
- Chest items, heart pieces, medallions, the Book of Mudora, and items given to you by NPCs are randomized. Note that this doesn't include chests in the various chest games throughout Hyrule.
- The rupee maximum is now 9999.
- You can't turn the tree kid to wood. This is to prevent being unable to get his item.
- Escaping the castle at the beginning of the game no longer requires the lamp.
- In the light world, you don't need the Lamp to see in the dark.
- In the dark world, the crystals will display on your inventory screen even if you haven't defeated Agahnim.

Some bugs that wouldn't crop up in normal play have been fixed:
- If you die in a Dark World dungeon and haven't defeated Agahnim, you will end up in what's known as "fake Dark World." This will sometimes cause the Crystal at the end of the dungeon to not spawn, causing a softlock. You cannot spawn in "fake Dark World" in randomizer.
- If you collect Power Gloves after collecting Titan's Mitt, your gloves will downgrade and you will be stuck without a way to lift dark rocks. This will not happen in randomizer.
- If you collect the key in the big chest room in the Swamp Palace _(due to having hookshot earlier than normal)_, then use that key on the top left door of that room, you can cause a soft lock due to being unable to access that key. In randomizer, moving one screen on the overworld away from the entrance to Swamp Palace will reset the water both around Swamp Palace, and the water that would cover those keys.
- If you defeat Agahnim and never found the Magic Mirror, you will be stuck in the Dark World with no way to return to the light world. In randomizer, saving and quitting will cause you to load up in the Light World.
- Occasionally Agahnim will attack you with particles that can't be reflected back at him. In randomizer, this doesn't happen.
- If you take damage while using the "fake flippers" glitch, the game may enter a locked state where all input is ignored. In randomizer, you will instead die and have all faeries removed from your inventory, allowing you to continue with the game.
- If you flute from the Master Sword grove or save & quit, it may be possible to have an invisible follower following you. This would prevent you from entering the Dark Palace as Kiki won't follow you if you already have a follower. In randomizer, this has been fixed.

# Why is the game in Japanese?
This randomizer uses the 1.0 JP version of the base rom because it is what is primarily used in speedrunning ALttP. Here are some of the features of this version compared to the English version:
- Faster text speed. This is very noticeable during the introduction.
- After getting the Pegasus Boots, pressing `Y` + `A` will allow you to use an item and dash at the same time. For a clear example of this working, try hammer dashing at the bridge leading from Dark Palace to Swamp Palace.
- You can jump down from a wall of which you are partially inside. This is most useful above the section of Turtle Rock that leads to the Mirror Shield.
- In an area where you can't use the Magic Mirror, you can make pushed blocks disappear by trying to use it while pushing the blocks.
- You can enter the Exploration Glitch in Tower of Hera by falling down the rightmost hole on the 3F, then jumping right from the wall.

# What's new in Randomizer?

v5
- Added capability for Mushroom/Powder and Shovel/Ocarina to be carried simultaneously.
- Mushroom, Powder, and Ocarina added to randomization pool.
- Massive overhaul of a lot of the item locations, generally making things more permissive and removing softlocks.
- Randomized Misery Mire and Turtle Rock medallion requirements.
- Digging in random places will now give you pickups.
- The Treasure Chest game will guaranteed give you its item on the second chest.
- The Digging Game will guaranteed give you its item on the 15th dig.
- Treasure Chest game and Digging Game added to randomization locations.
- Bottles may now be found prefilled with items.
- Bottle submenu now opens with X; use Y to change between bottles without opening submenu.
- Credits updated to reflect what King Zora sold you.
- Update checking logic updated.
- Will no longer spawn in Dark World if you die in Dark World pre-Aga.
- Fixed bottles not showing in inventory if gotten early.
- Fixed HUD not updating for Silver Arrows.
- Fixed Ganon warping more than once in teleport phase.

v4
- Heart Pieces are now randomized into the mix!
- Ether, Bombos, and the Book of Mudora are now randomized into the mix!
- 300 rupee NPCs are now randomized into the mix!
- Randomization will now try to distribute items more evenly. As a result, necessary items should show up toward the end of the game more often than before.
- NPCs are no longer forced to give you unique items.
- The max rupee count is now 9999.
- Reworked key generating algorithm. This should remove softlocks while keeping key locations interesting (for most dungeons.)
- Keys will no longer spawn in big chests.
- Removed 2 copies of the Lamp from the item pool.
- Removed 3 red rupees from the item pool.
- Added 5 instances of 100 rupees to the item pool.
- Can no longer softlock by turning shovel kid into a tree.
- Mantle door at beginning of the game no longer requires a lamp.
- Removed invisible follower from getting Master Sword.
- Will show crystals in Dark World even if Agahnim not defeated.
- Taking damage during fake flippers will no longer softlock the game. Instead, you'll die, but at least you get to continue.
- Added the ability to save the current item state to the SRAM every 4.267 seconds. This is not enabled in the UI at this point, as doing so will cause some unintended graphical glitches. This is in support of Zarby89's automatic inventory display (for streamers.)

v3
- Added "Random Spoiler" button. This allows you to see a random seed's spoiler without creating the rom.
- Added Red Shield to the list of available items, replacing an instance of 20 rupees.
- Fixed the requirements to enter the graves near the Sanctuary.
- Fixed Swamp Palace locations that require the Hammer.
- Fixed where saving and quitting will take you in the Dark World if you haven't defeated Agahnim 1 yet.
- Fixed the "fake Light World" condition if you save and quit in a Dark World dungeon.
- Fixed boomerang and shield downgrades.
- Fixed Fire Rod requirement for certain Turtle Rock chests.
- Fixed some rare crashes in rom generation.
- Fixed item generation involving Book of Mudora.
- Made keys in Thieves' Town and Turtle Rock more lenient in where they spawn.
- Changed output font to a fixed-width font.

v2
- Fixed a bug that didn't allow you to create the seed entered.
- Accounted for the fact that hookshot can be used to access lower Dark World.

v1
- Chest items and items given to you by the bottle vendor, Sahasrahla, the flute boy, the sick kid, the purple chest, the hobo under the bridge, the catfish, King Zora, and the old mountain man are randomized. Note that this doesn't include chests in the various chest games throughout Hyrule.
- Fake Dark World is fixed.
- Titan's Mitt won't downgrade to Power Gloves.
- Swamp Palace softlock is fixed.
- "No mirror" softlock is fixed.
- 0bb patch for Agahnim applied.
