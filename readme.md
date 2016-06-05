# Current Version: 3

# About the Legend of Zelda: A Link to the Past Randomizer (or ALttPRandomizer)
This is a simple program that moves around items in the Legend of Zelda: A Link to the Past (ALttP). It is used for racing the game.

When racing the game, it is suggested that each player play the same seed to ensure a level playing field.

# Using the Randomizer
Select a location to save your randomized rom, then select `Create`.

Right now there is only one difficulty, "Casual". There may be other difficulties in the future.

# Differences from the normal game
There are a number of differences from a randomized game to the normal game. Here's a short list:
- The game text is in Japanese _(this obviously isn't different if you are used to playing in Japanese. See below for why.)_
- Chest items and items given to you by the bottle vendor, Sahasrahla, the flute boy, the sick kid, the purple chest, the hobo under the bridge, the catfish, King Zora, and the old mountain man are randomized. Note that this doesn't include chests in the various chest games throughout Hyrule.

Some bugs that wouldn't crop up in normal play have been fixed:
- If you die in a Dark World dungeon and haven't defeated Agahnim, you will end up in what's known as "fake Dark World." This will sometimes cause the Crystal at the end of the dungeon to not spawn, causing a softlock. You cannot spawn in "fake Dark World" in randomizer.
- If you collect Power Gloves after collecting Titan's Mitt, your gloves will downgrade and you will be stuck without a way to lift dark rocks. This will not happen in randomizer.
- If you collect the key in the big chest room in the Swamp Palace _(due to having hookshot earlier than normal)_, then use that key on the top left door of that room, you can cause a soft lock due to being unable to access that key. In randomizer, moving one screen on the overworld away from the entrance to Swamp Palace will reset the water both around Swamp Palace, and the water that would cover those keys.
- If you defeat Agahnim and never found the Magic Mirror, you will be stuck in the Dark World with no way to return to the light world. In randomizer, saving and quitting will cause you to load up in the Light World.
- Occasionally Agahnim will attack you with particles that can't be reflected back at him. In randomizer, this doesn't happen.

# Why is the game in Japanese?
This randomizer uses the 1.0 JP version of the base rom because it is what is primarily used in speedrunning ALttP. Here are some of the features of this version compared to the English version:
- Faster text speed. This is very noticeable during the introduction.
- After getting the Pegasus Boots, pressing `Y` + `A` will allow you to use an item and dash at the same time. For a clear example of this working, try hammer dashing at the bridge leading from Dark Palace to Swamp Palace.
- You can jump down from a wall of which you are partially inside. This is most useful above the section of Turtle Rock that leads to the Mirror Shield.
- In an area where you can't use the Magic Mirror, you can make pushed blocks disappear by trying to use it while pushing the blocks.
- You can enter the Exploration Glitch in Tower of Hera by falling down the rightmost hole on the 3F, then jumping right from the wall.

# What's new in Randomizer?

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
