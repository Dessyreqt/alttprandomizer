namespace AlttpRandomizer.Rom
{
    public enum ItemType
    {
        L1SwordAndShield = 0x00, // can't be used until after uncle dies
        L2Sword = 0x01, // crashes game
        L3Sword = 0x02, // can't be used until after uncle dies
        L4Sword = 0x03, // can't be used until after uncle dies
        BlueShield = 0x04, // can't be used until after uncle dies
        RedShield = 0x05, // can't be used until after uncle dies
        MirrorShield = 0x06, // can't be used until after uncle dies
        FireRod = 0x07,
        IceRod = 0x08,
        Hammer = 0x09,
        Hookshot = 0x0a,
        Bow = 0x0b,
        Boomerang = 0x0c, // alt: 10 arrows
        Powder = 0x0d,
        Bee = 0x0e, // does nothing if no bottle
        Bombos = 0x0f,
        Ether = 0x10,
        Quake = 0x11,
        Lamp = 0x12, // alt: 5 rupees
        Shovel = 0x13,
        OcarinaInactive = 0x14,
        CaneOfSomaria = 0x15,
        Bottle = 0x16,
        PieceOfHeart = 0x17,
        StaffOfByrna = 0x18,
        Cape = 0x19,
        MagicMirror = 0x1a,
        PowerGlove = 0x1b,
        TitansMitt = 0x1c,
        BookOfMudora = 0x1d,
        Flippers = 0x1e,
        MoonPearl = 0x1f,
        Crystal = 0x20, // crashes game
        BugCatchingNet = 0x21,
        BlueMail = 0x22,
        RedMail = 0x23,
        Key = 0x24,
        Compass = 0x25,
        HeartContainerNoAnimation = 0x26,
        Bomb = 0x27,
        ThreeBombs = 0x28,
        Mushroom = 0x29,
        RedBoomerang = 0x2a,
        RedPotion = 0x2b, // does nothing if no bottle
        GreenPotion = 0x2c, // does nothing if no bottle
        BluePotion = 0x2d, // does nothing if no bottle
        RedPotion2 = 0x2e, // does nothing if no bottle
        GreenPotion2 = 0x2f, // does nothing if no bottle
        BluePotion2 = 0x30, // does nothing if no bottle
        TenBombs = 0x31,
        BigKey = 0x32,
        Map = 0x33,
        OneRupee = 0x34,
        FiveRupees = 0x35,
        TwentyRupees = 0x36,
        PendantOfCourage = 0x37, // green
        PendantOfWisdom = 0x38, // red
        PendantOfPower = 0x39, // blue
        BowAndArrows = 0x3a,
        BowAndSilverArrows = 0x3b,
        Bee2 = 0x3c, // does nothing if no bottle
        Fairy = 0x3d, // does nothing if no bottle
        HeartContainerNoDialog = 0x3e,
        HeartContainer = 0x3f,
        OneHundredRupees = 0x40,
        FiftyRupees = 0x41,
        Heart = 0x42,
        Arrow = 0x43,
        TenArrows = 0x44,
        SmallMagic = 0x45,
        ThreeHundredRupees = 0x46,
        TwentyRupees2 = 0x47,
        GoodBee = 0x48, // does nothing if no bottle
        L1Sword = 0x49, // can't be used until after uncle dies
        OcarinaActive = 0x4a,
        PegasusBoots = 0x4b,
		HyruleCastleEscapeKey = 0x80,
		EasternPalaceKey = 0x81,
		DesertPalaceKey = 0x82,
		TowerOfHeraKey = 0x83,
		HyruleCastleTowerKey = 0x84,
		DarkPalaceKey = 0x85,
		SwampPalaceKey = 0x86,
		SkullWoodsKey = 0x87,
		ThievesTownKey = 0x88,
		IcePalaceKey = 0x89,
		MiseryMireKey = 0x8A,
		TurtleRockKey = 0x8B,
		GanonsTowerKey = 0x8C,
		EasternPalaceBigKey = 0x91,
		DesertPalaceBigKey = 0x92,
		TowerOfHeraBigKey = 0x93,
		DarkPalaceBigKey = 0x85,
		SwampPalaceBigKey = 0x86,
		SkullWoodsBigKey = 0x87,
		ThievesTownBigKey = 0x88,
		IcePalaceBigKey = 0x89,
		MiseryMireBigKey = 0x8A,
		TurtleRockBigKey = 0x8B,
		GanonsTowerBigKey = 0x8C,

	}

	public class Item
    {
        private ItemType type;
        public string HexValue { get; set; }

        public Item(ItemType insertedItem)
        {
            Type = insertedItem;
        }


        public ItemType Type
        {
            get { return type; }
            set
            {
                type = value;
                HexValue = ((char)type).ToString();
            }
        }
    }
}
