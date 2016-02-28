using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mhxedit
{
    public class MonHunTalisman : MonHunEquip
    {
        ushort _skillFirstID;
        byte _skillFirstVal;
        ushort _skillSecondID;
        byte _skillSecondVal;

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
                    ushort uVal = 0;
                    if(ushort.TryParse(value, out uVal))
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
                    ushort uVal = 0;
                    if (ushort.TryParse(value, out uVal))
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
            _skillFirstID = BitConverter.ToUInt16(equip, 12);
            _skillFirstVal = equip[14];
            _skillSecondVal = equip[15];
            _skillSecondID = BitConverter.ToUInt16(equip, 18);
            
        }

        public override byte[] Serialize()
        {
            byte[] ret = base.Serialize();

            Array.Copy(BitConverter.GetBytes(_skillFirstID), 0, ret, 12, 2);
            ret[14] = _skillFirstVal;
            ret[15] = _skillSecondVal;
            Array.Copy(BitConverter.GetBytes(_skillSecondID), 0, ret, 18, 2);

            return ret;
        }

        public static Dictionary<ushort,string> dictSkills = new Dictionary<ushort,string> {
            { 0, "<null>"},
        };
    }
}
