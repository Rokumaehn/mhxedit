using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mhxedit
{
    public class MonHunTalisman : MonHunEquip
    {
        byte _skillFirstID;
        byte _skillFirstVal;
        byte _skillSecondID;
        byte _skillSecondVal;
        byte _unkTal1;
        byte _unkTal2;

        public string SkillFirst
        {
            get
            {
                if(dictSkills.ContainsKey(_skillFirstID))
                {
                    return dictSkills[_skillFirstID];
                }

                return _skillFirstID.ToString();
            }
            set
            {
                if(dictSkills.ContainsValue(value))
                {
                    _skillFirstID = dictSkills.FirstOrDefault(x => x.Value == value).Key;
                }
                else
                {
                    byte uVal = 0;
                    if(byte.TryParse(value, out uVal))
                    {
                        _skillFirstID = uVal;
                    }
                }
            }
        }

        public bool SkillFirstKnown()
        {
            return dictSkills.ContainsKey(_skillFirstID);
        }

        public string SkillSecond
        {
            get
            {
                if (dictSkills.ContainsKey(_skillSecondID))
                {
                    return dictSkills[_skillSecondID];
                }

                return _skillSecondID.ToString();
            }
            set
            {
                if (dictSkills.ContainsValue(value))
                {
                    _skillSecondID = dictSkills.FirstOrDefault(x => x.Value == value).Key;
                }
                else
                {
                    byte uVal = 0;
                    if (byte.TryParse(value, out uVal))
                    {
                        _skillSecondID = uVal;
                    }
                }
            }
        }

        public bool SkillSecondKnown()
        {
            return dictSkills.ContainsKey(_skillSecondID);
        }


        public string SkillFirstValue
        {
            get
            {
                return _skillFirstVal.ToString();
            }
            set
            {
                byte uVal = 0;
                if (byte.TryParse(value, out uVal))
                {
                    _skillFirstVal = uVal;
                }
            }
        }

        public string SkillSecondValue
        {
            get
            {
                return _skillSecondVal.ToString();
            }
            set
            {
                byte uVal = 0;
                if (byte.TryParse(value, out uVal))
                {
                    _skillSecondVal = uVal;
                }
            }
        }

        public MonHunTalisman(byte[] equip) : base(equip)
        {
            if (base._id > allTalisman.Length - 1) base._id = (byte)(allTalisman.Length - 1);

            _skillFirstID = equip[12];
            _skillSecondID = equip[13];
            _skillFirstVal = equip[14];
            _skillSecondVal = equip[15];

            if (!(equip[18] == 0 && equip[19] == 0))
            {
                _unkTal1 = equip[18];
                _unkTal2 = equip[19];
            }
            else
            {
                _unkTal1 = 0x47;
                _unkTal2 = 0x01;
            }
        }

        public override byte[] Serialize()
        {
            byte[] ret = base.Serialize();

            ret[12] = _skillFirstID;
            ret[13] = _skillSecondID;
            ret[14] = _skillFirstVal;
            ret[15] = _skillSecondVal;

            return ret;
        }

        public static Dictionary<byte,string> dictSkills = new Dictionary<byte,string> {
            { 0, "<null>"},
        };

        public static Dictionary<byte, string> testXYZ = new Dictionary<byte, string> {
            { 0, "<null>"},
            { 1, "Poison"},
            { 2, "Paralysis"},
            { 3, "Sleep"},
            { 4, "Stun"},
            { 5, "Hearing"},
            { 6, "Wind Res"},
            { 7, "Tremor Res"},
            { 8, "Tumbling Res"},
            { 9, "Heat Res"},
            { 10, "Cold Res"},
            { 11, "Cold Acc"},
            { 12, "Heat Acc"},
            { 13, "Anti-Theft"},
            { 14, "Def lock"},
            { 15, "Frenzy Res"},
            { 16, "Biology"},
            { 17, "Bleeding"},
            { 18, "Attack"},
            { 19, "Defense"},
            { 20, "Health"},
        };
    }
}
