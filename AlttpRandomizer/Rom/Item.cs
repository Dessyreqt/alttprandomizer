using System.Text;

namespace AlttpRandomizer.Rom
{
    public enum InventoryItemType
    {
        Nothing = 0xFF,
        L1SwordAndShield = 0x00, // can't be used until after uncle dies
        L2SwordPedestal = 0x01, // only use this at pedestal
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
        BottleWithRedPotion = 0x2b,
        BottleWithGreenPotion = 0x2c,
        BottleWithBluePotion = 0x2d,
        RedPotion = 0x2e, // does nothing if no bottle
        GreenPotion = 0x2f, // does nothing if no bottle
        BluePotion = 0x30, // does nothing if no bottle
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
        BottleWithBee = 0x3c, 
        BottleWithFairy = 0x3d, 
        HeartContainerNoRefill = 0x3e,
        HeartContainer = 0x3f,
        OneHundredRupees = 0x40,
        FiftyRupees = 0x41,
        Heart = 0x42,
        Arrow = 0x43,
        TenArrows = 0x44,
        SmallMagic = 0x45,
        ThreeHundredRupees = 0x46,
        TwentyRupees2 = 0x47,
        BottleWithGoldBee = 0x48,
        L1Sword = 0x49, // can't be used until after uncle dies
        OcarinaActive = 0x4a,
        PegasusBoots = 0x4b,
        FiftyBombCap = 0x4c,
        SeventyArrowCap = 0x4d,
        HalfMagic = 0x4e,
        QuarterMagic = 0x4f,
        L2Sword = 0x50,
    }

    public enum PendantItemType
    {
        None = 0x00,
        RedPendant = 0x01,
        BluePendant = 0x02,
        GreenPendant = 0x04,
    }

    public enum CrystalItemType
    {
        None = 0x00,
        Crystal6 = 0x01,
        Crystal1 = 0x02,
        Crystal5 = 0x04,
        Crystal7 = 0x08,
        Crystal2 = 0x10,
        Crystal4 = 0x20,
        Crystal3 = 0x40,
    }

    public class InventoryItem : Item
    {
        private InventoryItemType type;
        public new InventoryItemType Type
        {
            get { return type; }
            set
            {
                type = value;
                HexValue = (char)type;
            }
        }

        public InventoryItem(InventoryItemType insertedItem)
        {
            Type = insertedItem;
        }
    }

    public class PendantItem : Item
    {
        private PendantItemType type;
        public new PendantItemType Type
        {
            get { return type; }
            set
            {
                type = value;
                HexValue = (char)type;
            }
        }

        public PendantItem(PendantItemType insertedItem)
        {
            Type = insertedItem;
        }
    }

    public class CrystalItem : Item
    {
        private CrystalItemType type;
        public new CrystalItemType Type
        {
            get { return type; }
            set
            {
                type = value;
                HexValue = (char)type;
            }
        }

        public CrystalItem(CrystalItemType insertedItem)
        {
            Type = insertedItem;
        }
    }

    public class Item
    {
        public char HexValue { get; set; }

        internal Item()
        {
        }

        public virtual object Type { get; set; }

        public static byte[] GetItemLevel(InventoryItemType item)
        {
            byte retVal;

            switch (item)
            {
                case InventoryItemType.RedBoomerang:
                case InventoryItemType.Powder:
                case InventoryItemType.MagicMirror:
                case InventoryItemType.TitansMitt:
                case InventoryItemType.RedShield:
                case InventoryItemType.OcarinaInactive:
                case InventoryItemType.L2Sword:
                case InventoryItemType.BowAndArrows:
                case InventoryItemType.RedMail:
                    retVal = 0x02;
                    break;
                case InventoryItemType.BowAndSilverArrows:
                case InventoryItemType.OcarinaActive:
                case InventoryItemType.MirrorShield:
                case InventoryItemType.L3Sword:
                    retVal = 0x03;
                    break;
                case InventoryItemType.L4Sword:
                    retVal = 0x04;
                    break;
                default:
                    // Anything not listed here is a 1
                    retVal = 0x01;
                    break;
            }

            return new[] { retVal };
        }

        public static bool OmitAccessibleCheck(InventoryItemType item)
        {
            bool retval;

            switch (item)
            {
                case InventoryItemType.Nothing:
                case InventoryItemType.BlueShield:
                case InventoryItemType.RedShield:
                case InventoryItemType.MirrorShield:
                case InventoryItemType.Boomerang:
                case InventoryItemType.PieceOfHeart:
                case InventoryItemType.StaffOfByrna:
                case InventoryItemType.BugCatchingNet:
                case InventoryItemType.BlueMail:
                case InventoryItemType.RedMail:
                case InventoryItemType.Compass:
                case InventoryItemType.HeartContainerNoAnimation:
                case InventoryItemType.Bomb:
                case InventoryItemType.ThreeBombs:
                case InventoryItemType.RedBoomerang:
                case InventoryItemType.TenBombs:
                case InventoryItemType.Map:
                case InventoryItemType.OneRupee:
                case InventoryItemType.FiveRupees:
                case InventoryItemType.TwentyRupees:
                case InventoryItemType.HeartContainerNoRefill:
                case InventoryItemType.HeartContainer:
                case InventoryItemType.OneHundredRupees:
                case InventoryItemType.FiftyRupees:
                case InventoryItemType.Heart:
                case InventoryItemType.Arrow:
                case InventoryItemType.TenArrows:
                case InventoryItemType.SmallMagic:
                case InventoryItemType.ThreeHundredRupees:
                case InventoryItemType.TwentyRupees2:
                case InventoryItemType.FiftyBombCap:
                case InventoryItemType.SeventyArrowCap:
                case InventoryItemType.HalfMagic:
                case InventoryItemType.QuarterMagic:
                    retval = true;
                    break;
                default:
                    // Anything not listed here is a 1
                    retval = false;
                    break;
            }

            return retval;
        }

        public static byte[] GetCheckLocation(InventoryItemType item)
        {
            byte retVal;

            switch (item)
            {
                case InventoryItemType.Bow:
                case InventoryItemType.BowAndArrows:
                case InventoryItemType.BowAndSilverArrows:
                    retVal = 0x40;
                    break;
                case InventoryItemType.Boomerang:
                case InventoryItemType.RedBoomerang:
                    retVal = 0x41;
                    break;
                case InventoryItemType.Hookshot:
                    retVal = 0x42;
                    break;
                case InventoryItemType.Mushroom:
                case InventoryItemType.Powder:
                    retVal = 0x44;
                    break;
                case InventoryItemType.FireRod:
                    retVal = 0x45;
                    break;
                case InventoryItemType.IceRod:
                    retVal = 0x46;
                    break;
                case InventoryItemType.Bombos:
                    retVal = 0x47;
                    break;
                case InventoryItemType.Ether:
                    retVal = 0x48;
                    break;
                case InventoryItemType.Quake:
                    retVal = 0x49;
                    break;
                case InventoryItemType.Lamp:
                    retVal = 0x4a;
                    break;
                case InventoryItemType.Hammer:
                    retVal = 0x4b;
                    break;
                case InventoryItemType.Shovel:
                case InventoryItemType.OcarinaActive:
                case InventoryItemType.OcarinaInactive:
                    retVal = 0x4c;
                    break;
                case InventoryItemType.BugCatchingNet:
                    retVal = 0x4d;
                    break;
                case InventoryItemType.BookOfMudora:
                    retVal = 0x4e;
                    break;
                case InventoryItemType.CaneOfSomaria:
                    retVal = 0x50;
                    break;
                case InventoryItemType.StaffOfByrna:
                    retVal = 0x51;
                    break;
                case InventoryItemType.Cape:
                    retVal = 0x52;
                    break;
                case InventoryItemType.MagicMirror:
                    retVal = 0x53;
                    break;
                case InventoryItemType.PowerGlove:
                case InventoryItemType.TitansMitt:
                    retVal = 0x54;
                    break;
                case InventoryItemType.PegasusBoots:
                    retVal = 0x55;
                    break;
                case InventoryItemType.Flippers:
                    retVal = 0x56;
                    break;
                case InventoryItemType.MoonPearl:
                    retVal = 0x57;
                    break;
                case InventoryItemType.L1Sword:
                case InventoryItemType.L1SwordAndShield:
                case InventoryItemType.L2Sword:
                case InventoryItemType.L2SwordPedestal:
                case InventoryItemType.L3Sword:
                case InventoryItemType.L4Sword:
                    retVal = 0x59;
                    break;
                case InventoryItemType.BlueShield:
                case InventoryItemType.RedShield:
                case InventoryItemType.MirrorShield:
                    retVal = 0x5a;
                    break;
                case InventoryItemType.BlueMail:
                case InventoryItemType.RedMail:
                    retVal = 0x5b;
                    break;
                default:
                    retVal = 0x00;
                    break;
            }

            return new[] { retVal };
        }

        public static byte[] GetCreditsName(InventoryItemType item)
        {
            const int maxLength = 20;
            StringBuilder retVal = new StringBuilder(maxLength, maxLength);

            switch (item)
            {
                case InventoryItemType.Bow:
                    retVal.Append("arrow sling");
                    break;
                case InventoryItemType.BowAndArrows:
                    retVal.Append("point stick");
                    break;
                case InventoryItemType.BowAndSilverArrows:
                    retVal.Append("sharp stick");
                    break;
                case InventoryItemType.Boomerang:
                case InventoryItemType.RedBoomerang:
                    retVal.Append("bent stick");
                    break;
                case InventoryItemType.Hookshot:
                    retVal.Append("boinger");
                    break;
                case InventoryItemType.Mushroom:
                case InventoryItemType.Powder:
                    retVal.Append("legal drugs");
                    break;
                case InventoryItemType.FireRod:
                    retVal.Append("flame staff");
                    break;
                case InventoryItemType.IceRod:
                    retVal.Append("ice cream");
                    break;
                case InventoryItemType.Bombos:
                    retVal.Append("swirly coin");
                    break;
                case InventoryItemType.Ether:
                    retVal.Append("bolt coin");
                    break;
                case InventoryItemType.Quake:
                    retVal.Append("wavy coin");
                    break;
                case InventoryItemType.Lamp:
                    retVal.Append("candle");
                    break;
                case InventoryItemType.Hammer:
                    retVal.Append("m c hammer");
                    break;
                case InventoryItemType.Shovel:
                    retVal.Append("dirt spade");
                    break;
                case InventoryItemType.OcarinaActive:
                case InventoryItemType.OcarinaInactive:
                    retVal.Append("bird call");
                    break;
                case InventoryItemType.BugCatchingNet:
                    retVal.Append("stick web");
                    break;
                case InventoryItemType.BookOfMudora:
                    retVal.Append("moon runes");
                    break;
                case InventoryItemType.CaneOfSomaria:
                    retVal.Append("block stick");
                    break;
                case InventoryItemType.StaffOfByrna:
                    retVal.Append("shiny stick");
                    break;
                case InventoryItemType.Cape:
                    retVal.Append("red hood");
                    break;
                case InventoryItemType.MagicMirror:
                    retVal.Append("your face");
                    break;
                case InventoryItemType.PowerGlove:
                    retVal.Append("lift glove");
                    break;
                case InventoryItemType.TitansMitt:
                    retVal.Append("carry glove");
                    break;
                case InventoryItemType.PegasusBoots:
                    retVal.Append("sprint shoe");
                    break;
                case InventoryItemType.Flippers:
                    retVal.Append("finger webs");
                    break;
                case InventoryItemType.MoonPearl:
                    retVal.Append("lunar orb");
                    break;
                case InventoryItemType.L1Sword:
                case InventoryItemType.L1SwordAndShield:
                case InventoryItemType.L2Sword:
                case InventoryItemType.L2SwordPedestal:
                case InventoryItemType.L3Sword:
                case InventoryItemType.L4Sword:
                    retVal.Append("sword");
                    break;
                case InventoryItemType.BlueShield:
                    retVal.Append("shield");
                    break;
                case InventoryItemType.RedShield:
                    retVal.Append("red shield");
                    break;
                case InventoryItemType.MirrorShield:
                    retVal.Append("face shield");
                    break;
                case InventoryItemType.BlueMail:
                    retVal.Append("blue suit");
                    break;
                case InventoryItemType.RedMail:
                    retVal.Append("purple hat");
                    break;
                case InventoryItemType.ThreeBombs:
                case InventoryItemType.TenBombs:
                case InventoryItemType.Bomb:
                case InventoryItemType.FiftyBombCap:
                    retVal.Append("fireworks");
                    break;
                case InventoryItemType.Arrow:
                case InventoryItemType.TenArrows:
                case InventoryItemType.SeventyArrowCap:
                    retVal.Append("sewing kit");
                    break;
               case InventoryItemType.PieceOfHeart:
               case InventoryItemType.HeartContainerNoAnimation:
               case InventoryItemType.HeartContainerNoRefill:
               case InventoryItemType.HeartContainer:
               case InventoryItemType.Heart:
                    retVal.Append("love");
                    break;
                default:
                    retVal.Append("life lesson");
                    break;
            }

            retVal.Append(" for sale");

            //space it some on the left to center it sliIIiightly better
            if (retVal.Length < maxLength)
            {
                retVal.Insert(0, " ", maxLength - retVal.Length);
            }

            return ConvertToCreditEncoding(retVal.ToString());
        }

        private static byte[] ConvertToCreditEncoding(string input)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input.ToLower());

            // 'a' in ASCII = 0x61
            // 'a' in z3credits = 0x1A (among others, but this for the small font)
            for (var i = 0; i < inputBytes.Length; ++i)
            {
                switch (inputBytes[i])
                {
                    case (byte)' ':
                        inputBytes[i] = 0x9F;
                        break;
                    case (byte)'\'':
                        inputBytes[i] = 0x35;
                        break;
                    case (byte)'-':
                        inputBytes[i] = 0x36;
                        break;
                    case (byte)',':
                        inputBytes[i] = 0x37;
                        break;
                    default:
                        inputBytes[i] = (byte)(inputBytes[i] - 0x47);
                        break;
                }
            }
            return inputBytes;
        }

        public static bool IsBottle(InventoryItemType item)
        {
            switch (item)
            {
                case InventoryItemType.Bottle:
                case InventoryItemType.BottleWithRedPotion:
                case InventoryItemType.BottleWithGreenPotion:
                case InventoryItemType.BottleWithBluePotion:
                case InventoryItemType.BottleWithBee:
                case InventoryItemType.BottleWithFairy:
                case InventoryItemType.BottleWithGoldBee:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsKeyItem(InventoryItemType item)
        {
            return GetCheckLocation(item)[0] != GetCheckLocation(InventoryItemType.Nothing)[0] || IsBottle(item);
        }
    }
}
