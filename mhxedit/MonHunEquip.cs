using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mhxedit
{
    public class MonHunIdName
    {
        byte _type;
        string _name;
        public byte ID { get { return _type; } set { _type = value; } }
        public string Name { get { return _name; } set { _name = value; } }
    }

    public class MonHunEquip
    {
        protected byte _type = 0;
        protected ushort _id = 0;
        protected byte _level = 0;
        protected byte[] _unk1 = null;
        protected byte _slots = 0;

        public string Type
        {
            get { return types[_type]; }
            set
            {
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i] == value)
                        _type = (byte)i;
                }
            }
        }
        public string[] TypeAvailable
        {
            get
            {
                return types;
            }
        }


        public string ID
        {
            get
            {
                switch (_type)
                {
                    case 0:
                        if (dictIdsNull.ContainsKey(_id))
                            return dictIdsNull[_id];
                        return _id.ToString();
                    case 1:
                        if (dictIdsHead.ContainsKey(_id))
                            return dictIdsHead[_id];
                        return _id.ToString();
                    case 2:
                        if (dictIdsBody.ContainsKey(_id))
                            return dictIdsBody[_id];
                        return _id.ToString();
                    case 3:
                        if (dictIdsArms.ContainsKey(_id))
                            return dictIdsArms[_id];
                        return _id.ToString();
                    case 4:
                        if (dictIdsWaist.ContainsKey(_id))
                            return dictIdsWaist[_id];
                        return _id.ToString();
                    case 5:
                        if (dictIdsLegs.ContainsKey(_id))
                            return dictIdsLegs[_id];
                        return _id.ToString();
                    case 6:
                        if (dictIdsTalisman.ContainsKey(_id))
                            return dictIdsTalisman[_id];
                        return _id.ToString();
                    case 7:
                        if (dictIdsGreatsword.ContainsKey(_id))
                            return dictIdsGreatsword[_id];
                        return _id.ToString();
                    case 8:
                        if (dictIdsSwordAndShield.ContainsKey(_id))
                            return dictIdsSwordAndShield[_id];
                        return _id.ToString();
                    case 9:
                        if (dictIdsHammer.ContainsKey(_id))
                            return dictIdsHammer[_id];
                        return _id.ToString();
                    case 10:
                        if (dictIdsLance.ContainsKey(_id))
                            return dictIdsLance[_id];
                        return _id.ToString();
                    case 11:
                        if (dictIdsHeavyBowgun.ContainsKey(_id))
                            return dictIdsHeavyBowgun[_id];
                        return _id.ToString();
                    case 12:
                        if (dictIdsNone15.ContainsKey(_id))
                            return dictIdsNone15[_id];
                        return _id.ToString();
                    case 13:
                        if (dictIdsLightBowgun.ContainsKey(_id))
                            return dictIdsLightBowgun[_id];
                        return _id.ToString();
                    case 14:
                        if (dictIdsLongsword.ContainsKey(_id))
                            return dictIdsLongsword[_id];
                        return _id.ToString();
                    case 15:
                        if (dictIdsGunlance.ContainsKey(_id))
                            return dictIdsGunlance[_id];
                        return _id.ToString();
                    case 16:
                        if (dictIdsBow.ContainsKey(_id))
                            return dictIdsBow[_id];
                        return _id.ToString();
                    case 17:
                        if (dictIdsDualBlades.ContainsKey(_id))
                            return dictIdsDualBlades[_id];
                        return _id.ToString();
                    case 18:
                        if (dictIdsHuntingHorn.ContainsKey(_id))
                            return dictIdsHuntingHorn[_id];
                        return _id.ToString();
                    case 19:
                        if (dictIdsInsectGlaive.ContainsKey(_id))
                            return dictIdsInsectGlaive[_id];
                        return _id.ToString();
                    case 20:
                        if (dictIdsChargeBlade.ContainsKey(_id))
                            return dictIdsChargeBlade[_id];
                        return _id.ToString();
                    default:
                        break;
                }
                return "";
            }
            set
            {
                for (int i = 0; i < this.IDAvailable.Length; i++)
                {
                    if (this.IDAvailable[i] == value)
                        _id = (byte)i;
                }
            }
        }
        public string[] IDAvailable
        {
            get
            {
                switch (_type)
                {
                    case 0:
                        return dictIdsNull.Values.ToArray();
                    case 1:
                        return dictIdsHead.Values.ToArray();
                    case 2:
                        return dictIdsBody.Values.ToArray();
                    case 3:
                        return dictIdsArms.Values.ToArray();
                    case 4:
                        return dictIdsWaist.Values.ToArray();
                    case 5:
                        return dictIdsLegs.Values.ToArray();
                    case 6:
                        return dictIdsTalisman.Values.ToArray();
                    case 7:
                        return dictIdsGreatsword.Values.ToArray();
                    case 8:
                        return dictIdsSwordAndShield.Values.ToArray();
                    case 9:
                        return dictIdsHammer.Values.ToArray();
                    case 10:
                        return dictIdsLance.Values.ToArray();
                    case 11:
                        return dictIdsHeavyBowgun.Values.ToArray();
                    case 12:
                        return dictIdsNone15.Values.ToArray();
                    case 13:
                        return dictIdsLightBowgun.Values.ToArray();
                    case 14:
                        return dictIdsLongsword.Values.ToArray();
                    case 15:
                        return dictIdsGunlance.Values.ToArray();
                    case 16:
                        return dictIdsBow.Values.ToArray();
                    case 17:
                        return dictIdsDualBlades.Values.ToArray();
                    case 18:
                        return dictIdsHuntingHorn.Values.ToArray();
                    case 19:
                        return dictIdsInsectGlaive.Values.ToArray();
                    case 20:
                        return dictIdsChargeBlade.Values.ToArray();
                    default:
                        break;
                }

                return dictIdsNull.Values.ToArray();
            }
        }

        public byte Level
        {
            get
            {
                return (byte)(_level + 1);
            }
            set
            {
                if (value == 0)
                    _level = 1;
                else
                    _level = (byte)(value - 1);
            }
        }

        public byte Slots
        {
            get
            {
                return _slots;
            }
            set
            {
                if (value < 4)
                {
                    _slots = value;
                }
            }
        }



        public MonHunEquip(byte[] equip)
        {
            _type = equip[0];
            if (_type == 0)
            {
                _unk1 = new byte[32];
                for (int i = 0; i < _unk1.Length; i++) _unk1[i] = 0;
                return;
            }

            _id = BitConverter.ToUInt16(equip, 1);
            _level = equip[3];

            _unk1 = new byte[32];
            Array.Copy(equip, 4, _unk1, 0, _unk1.Length);

            _slots = equip[16];
        }

        public static MonHunEquip Create(byte[] equip)
        {
            MonHunEquip obj = null;

            byte tp = equip[0];

            switch (tp)
            {
                case 6:
                    obj = new MonHunTalisman(equip);
                    break;
                default:
                    obj = new MonHunEquip(equip);
                    break;
            }

            return obj;
        }

        public virtual byte[] Serialize()
        {
            byte[] ret = new byte[36];

            ret[0] = _type;
            Array.Copy(BitConverter.GetBytes(_id), 0, ret, 1, 2);
            ret[3] = _level;

            Array.Copy(_unk1, 0, ret, 4, _unk1.Length);

            ret[16] = _slots;

            return ret;
        }



        public virtual System.Drawing.Bitmap GetIcon()
        {
            switch (_type)
            {
                case 0:
                    return null;
                case 1:
                    return null; //dictIdsHead.Values.ToArray();
                case 2:
                    return null; //dictIdsBody.Values.ToArray();
                case 3:
                    return null; //dictIdsArms.Values.ToArray();
                case 4:
                    return null; //dictIdsWaist.Values.ToArray();
                case 5:
                    return null; // dictIdsLegs.Values.ToArray();
                case 6:
                    return null; // dictIdsTalisman.Values.ToArray();
                case 7:
                    return (System.Drawing.Bitmap)(Properties.Resources.ResourceManager.GetObject("Equip_Greatsword"));
                case 8:
                    return (System.Drawing.Bitmap)(Properties.Resources.ResourceManager.GetObject("Equip_SwordAndShield"));
                case 9:
                    return (System.Drawing.Bitmap)(Properties.Resources.ResourceManager.GetObject("Equip_Hammer"));
                case 10:
                    return (System.Drawing.Bitmap)(Properties.Resources.ResourceManager.GetObject("Equip_Lance"));
                case 11:
                    return (System.Drawing.Bitmap)(Properties.Resources.ResourceManager.GetObject("Equip_HeavyBowgun"));
                case 12:
                    return null; // none
                case 13:
                    return (System.Drawing.Bitmap)(Properties.Resources.ResourceManager.GetObject("Equip_LightBowgun"));
                case 14:
                    return (System.Drawing.Bitmap)(Properties.Resources.ResourceManager.GetObject("Equip_Longsword"));
                case 15:
                    return (System.Drawing.Bitmap)(Properties.Resources.ResourceManager.GetObject("Equip_Gunlance"));
                case 16:
                    return (System.Drawing.Bitmap)(Properties.Resources.ResourceManager.GetObject("Equip_Bow"));
                case 17:
                    return (System.Drawing.Bitmap)(Properties.Resources.ResourceManager.GetObject("Equip_Dualblades"));
                case 18:
                    return (System.Drawing.Bitmap)(Properties.Resources.ResourceManager.GetObject("Equip_HuntingHorn"));
                case 19:
                    return (System.Drawing.Bitmap)(Properties.Resources.ResourceManager.GetObject("Equip_InsectGlaive"));
                case 20:
                    return (System.Drawing.Bitmap)(Properties.Resources.ResourceManager.GetObject("Equip_ChargeBlade"));
                default:
                    break;
            }

            return null;
        }



        public static string[] types = new string[]{
            "<null>",
            "Head",
            "Body",
            "Arms",
            "Waist",
            "Legs",
            "Talisman",
            "Great Sword",
            "Sword and Shield",
            "Hammer",
            "Lance",
            "Heavy Bowgun",
            "<No Item>",
            "Light Bowgun",
            "Longsword",
            "Switch Axe",
            "Gunlance",
            "Bow",
            "Dual Blades",
            "Hunting Horn",
            "Insect Glaive",
            "Charge Blade"
        };






        public static Dictionary<ushort, string> dictIdsNull = new Dictionary<ushort, string> {
            { 0, "0"}
        };

        public static Dictionary<ushort, string> dictIdsHead = new Dictionary<ushort, string> {
            { 0, "0"}
        };

        public static Dictionary<ushort, string> dictIdsBody = new Dictionary<ushort, string> {
            { 0, "0"}
        };

        public static Dictionary<ushort, string> dictIdsArms = new Dictionary<ushort, string> {
            { 0, "0"}
        };

        public static Dictionary<ushort, string> dictIdsWaist = new Dictionary<ushort, string> {
            { 0, "0"}
        };

        public static Dictionary<ushort, string> dictIdsLegs = new Dictionary<ushort, string> {
            { 0, "0"}
        };

        public static Dictionary<ushort, string> dictIdsTalisman = new Dictionary<ushort, string> {
            { 0, "0"},
            { 1, "Pawn Talisman"},
            { 2, "Bishop Talisman"},
            { 3, "Knight Talisman"},
            { 4, "Rook Talisman"},
            { 5, "Queen Talisman"},
            { 6, "King Talisman"},
            { 7, "Dragon Talisman"}
        };

        public static Dictionary<ushort, string> dictIdsGreatsword = new Dictionary<ushort, string> {
            { 0, "0"},
            { 1, "Beruna Blade"}
        };

        public static Dictionary<ushort, string> dictIdsSwordAndShield = new Dictionary<ushort, string> {
            { 0, "0"},
            { 1, "Beruna Sword"}
        };

        public static Dictionary<ushort, string> dictIdsHammer = new Dictionary<ushort, string> {
            { 0, "0"},
            { 1, "Beruna Hammer"}
        };

        public static Dictionary<ushort, string> dictIdsLance = new Dictionary<ushort, string> {
            { 0, "0"},
            { 1, "Beruna Lance"}
        };

        public static Dictionary<ushort, string> dictIdsHeavyBowgun = new Dictionary<ushort, string> {
            { 0, "0"},
            { 1, "Beruna Cannon"}
        };

        public static Dictionary<ushort, string> dictIdsNone15 = new Dictionary<ushort, string> {
            { 0, "0"},
        };

        public static Dictionary<ushort, string> dictIdsLightBowgun = new Dictionary<ushort, string> {
            { 0, "0"}
        };

        public static Dictionary<ushort, string> allLightBowgun = new Dictionary<ushort, string> {
            { 0, "0"}
        };

        public static Dictionary<ushort, string> dictIdsLongsword = new Dictionary<ushort, string> {
            { 0, "<null>"},
            { 1, "Beruna Saber"},
            { 2, "Bushido Saber"},
            { 3, "Diapason"},
            { 4, "Guardian Sword"},
            { 5, "Aqua Guardian"},
            { 6, "Chainslaughter"},
            { 7, "<7,NeedsTranslation>"},
            { 8, "<8,NeedsTranslation>"},
            { 9, "Iron Katana"},
            { 10, "Hidden Saber"},
            { 11, "Eager Cleaver"},
            { 12, "Wailing Ghost"},
            { 13, "Thunderclap"},
            { 14, "Imperial Saber"},
            { 15, "Rimeblossom"},
            { 16, "Yuki Ichimonji"},
            { 17, "Aikuchi"},
            { 18, "Toad Abetter"},
            { 19, "Rogue Sword"},
            { 20, "<20,NeedsTranslation>"}
        };

         public static Dictionary<ushort, string> dictIdsSwitchAxe = new Dictionary<ushort, string> {
            { 0, "0"}
        };
         public static Dictionary<ushort, string> dictIdsGunlance = new Dictionary<ushort, string> {
            { 0, "0"}
        };
         public static Dictionary<ushort, string> dictIdsBow = new Dictionary<ushort, string> {
            { 0, "0"}
        };
         public static Dictionary<ushort, string> dictIdsDualBlades = new Dictionary<ushort, string> {
            { 0, "0"}
        };
         public static Dictionary<ushort, string> dictIdsHuntingHorn = new Dictionary<ushort, string> {
            { 0, "0"}
        };
         public static Dictionary<ushort, string> dictIdsInsectGlaive = new Dictionary<ushort, string> {
            { 0, "0"}
        };
         public static Dictionary<ushort, string> dictIdsChargeBlade = new Dictionary<ushort, string> {
            { 0, "0"}
        };
    }
}
