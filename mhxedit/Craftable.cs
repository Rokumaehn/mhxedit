using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace mhxedit
{
    public class Craftable
    {
        protected byte[] weaponsGreatsword;
        protected byte[] weaponsSwordAndShield;
        protected byte[] weaponsHammer;
        protected byte[] weaponsLance;
        protected byte[] weaponsHeavyBowgun;
        protected byte[] reserved1;
        protected byte[] weaponsLightBowgun;
        protected byte[] weaponsLongsword;
        protected byte[] weaponsSwitchAxe;
        protected byte[] weaponsGunLance;
        protected byte[] weaponsBow;
        protected byte[] weaponsDualBlade;
        protected byte[] weaponsHuntingHorn;
        protected byte[] weaponsInsectGlaive;
        protected byte[] weaponsChargeBlade;

        protected byte[] armorsHead;
        protected byte[] armorsChest;
        protected byte[] armorsArms;
        protected byte[] armorsWaist;
        protected byte[] armorsLegs;

        public Craftable(MemoryStream ms)
        {
            BinaryReader reader = new BinaryReader(ms);

            reader.BaseStream.Seek(0x20BE, SeekOrigin.Begin);

            weaponsGreatsword = reader.ReadBytes(40);
            weaponsSwordAndShield = reader.ReadBytes(40);
            weaponsHammer = reader.ReadBytes(40);
            weaponsLance = reader.ReadBytes(40);
            weaponsHeavyBowgun = reader.ReadBytes(40);
            reserved1 = reader.ReadBytes(40);
            weaponsLightBowgun = reader.ReadBytes(40);
            weaponsLongsword = reader.ReadBytes(40);
            weaponsSwitchAxe = reader.ReadBytes(40);
            weaponsGunLance = reader.ReadBytes(40);
            weaponsBow = reader.ReadBytes(40);
            weaponsDualBlade = reader.ReadBytes(40);
            weaponsHuntingHorn = reader.ReadBytes(40);
            weaponsInsectGlaive = reader.ReadBytes(40);
            weaponsChargeBlade = reader.ReadBytes(40);

            armorsHead = reader.ReadBytes(392);
            armorsChest = reader.ReadBytes(392);
            armorsArms = reader.ReadBytes(392);
            armorsWaist = reader.ReadBytes(392);
            armorsLegs = reader.ReadBytes(392);
        }

        protected int _unlockedArmorCount;
        public int UnlockedArmorCount
        {
            get
            {
                _unlockedArmorCount = 0;
                for (int i = 4; i < 196; i++)
                {
                    _unlockedArmorCount += ((armorsHead[i] & 0x01) == 0x01 ? 1 : 0) +
                        ((armorsHead[i] & 0x02) == 0x02 ? 1 : 0) +
                        ((armorsHead[i] & 0x10) == 0x10 ? 1 : 0) +
                        ((armorsHead[i] & 0x20) == 0x20 ? 1 : 0);

                    _unlockedArmorCount += ((armorsChest[i] & 0x01) == 0x01 ? 1 : 0) +
                        ((armorsChest[i] & 0x02) == 0x02 ? 1 : 0) +
                        ((armorsChest[i] & 0x10) == 0x10 ? 1 : 0) +
                        ((armorsChest[i] & 0x20) == 0x20 ? 1 : 0);

                    _unlockedArmorCount += ((armorsArms[i] & 0x01) == 0x01 ? 1 : 0) +
                        ((armorsArms[i] & 0x02) == 0x02 ? 1 : 0) +
                        ((armorsArms[i] & 0x10) == 0x10 ? 1 : 0) +
                        ((armorsArms[i] & 0x20) == 0x20 ? 1 : 0);

                    _unlockedArmorCount += ((armorsWaist[i] & 0x01) == 0x01 ? 1 : 0) +
                        ((armorsWaist[i] & 0x02) == 0x02 ? 1 : 0) +
                        ((armorsWaist[i] & 0x10) == 0x10 ? 1 : 0) +
                        ((armorsWaist[i] & 0x20) == 0x20 ? 1 : 0);

                    _unlockedArmorCount += ((armorsLegs[i] & 0x01) == 0x01 ? 1 : 0) +
                        ((armorsLegs[i] & 0x02) == 0x02 ? 1 : 0) +
                        ((armorsLegs[i] & 0x10) == 0x10 ? 1 : 0) +
                        ((armorsLegs[i] & 0x20) == 0x20 ? 1 : 0);
                }
                return _unlockedArmorCount;
            }

            set
            {
                
            }
        }

        public void UnlockAll()
        {
            for (int i = 4; i < 196; i++)
            {
                // Head Armors

                if ((armorsHead[i] & 0x01) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsHead[i] = armorsHead[i] |= 0x01; // unlock this item
                    armorsHead[i+196] = armorsHead[i+196] |= 0x01; // mark this item as "new"
                }
                if ((armorsHead[i] & 0x02) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsHead[i] = armorsHead[i] |= 0x02; // unlock this item
                    armorsHead[i + 196] = armorsHead[i + 196] |= 0x02; // mark this item as "new"
                }
                if ((armorsHead[i] & 0x10) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsHead[i] = armorsHead[i] |= 0x10; // unlock this item
                    armorsHead[i + 196] = armorsHead[i + 196] |= 0x10; // mark this item as "new"
                }
                if ((armorsHead[i] & 0x20) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsHead[i] = armorsHead[i] |= 0x20; // unlock this item
                    armorsHead[i + 196] = armorsHead[i + 196] |= 0x20; // mark this item as "new"
                }

                // Chest Armors

                if ((armorsChest[i] & 0x01) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsChest[i] = armorsChest[i] |= 0x01; // unlock this item
                    armorsChest[i + 196] = armorsChest[i + 196] |= 0x01; // mark this item as "new"
                }
                if ((armorsChest[i] & 0x02) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsChest[i] = armorsChest[i] |= 0x02; // unlock this item
                    armorsChest[i + 196] = armorsChest[i + 196] |= 0x02; // mark this item as "new"
                }
                if ((armorsChest[i] & 0x10) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsChest[i] = armorsChest[i] |= 0x10; // unlock this item
                    armorsChest[i + 196] = armorsChest[i + 196] |= 0x10; // mark this item as "new"
                }
                if ((armorsChest[i] & 0x20) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsChest[i] = armorsChest[i] |= 0x20; // unlock this item
                    armorsChest[i + 196] = armorsChest[i + 196] |= 0x20; // mark this item as "new"
                }

                // Arms Armors

                if ((armorsArms[i] & 0x01) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsArms[i] = armorsArms[i] |= 0x01; // unlock this item
                    armorsArms[i + 196] = armorsArms[i + 196] |= 0x01; // mark this item as "new"
                }
                if ((armorsArms[i] & 0x02) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsArms[i] = armorsArms[i] |= 0x02; // unlock this item
                    armorsArms[i + 196] = armorsArms[i + 196] |= 0x02; // mark this item as "new"
                }
                if ((armorsArms[i] & 0x10) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsArms[i] = armorsArms[i] |= 0x10; // unlock this item
                    armorsArms[i + 196] = armorsArms[i + 196] |= 0x10; // mark this item as "new"
                }
                if ((armorsArms[i] & 0x20) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsArms[i] = armorsArms[i] |= 0x20; // unlock this item
                    armorsArms[i + 196] = armorsArms[i + 196] |= 0x20; // mark this item as "new"
                }

                // Waist Armors

                if ((armorsWaist[i] & 0x01) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsWaist[i] = armorsWaist[i] |= 0x01; // unlock this item
                    armorsWaist[i + 196] = armorsWaist[i + 196] |= 0x01; // mark this item as "new"
                }
                if ((armorsWaist[i] & 0x02) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsWaist[i] = armorsWaist[i] |= 0x02; // unlock this item
                    armorsWaist[i + 196] = armorsWaist[i + 196] |= 0x02; // mark this item as "new"
                }
                if ((armorsWaist[i] & 0x10) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsWaist[i] = armorsWaist[i] |= 0x10; // unlock this item
                    armorsWaist[i + 196] = armorsWaist[i + 196] |= 0x10; // mark this item as "new"
                }
                if ((armorsWaist[i] & 0x20) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsWaist[i] = armorsWaist[i] |= 0x20; // unlock this item
                    armorsWaist[i + 196] = armorsWaist[i + 196] |= 0x20; // mark this item as "new"
                }

                // Legs Armors

                if ((armorsLegs[i] & 0x01) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsLegs[i] = armorsLegs[i] |= 0x01; // unlock this item
                    armorsLegs[i + 196] = armorsLegs[i + 196] |= 0x01; // mark this item as "new"
                }
                if ((armorsLegs[i] & 0x02) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsLegs[i] = armorsLegs[i] |= 0x02; // unlock this item
                    armorsLegs[i + 196] = armorsLegs[i + 196] |= 0x02; // mark this item as "new"
                }
                if ((armorsLegs[i] & 0x10) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsLegs[i] = armorsLegs[i] |= 0x10; // unlock this item
                    armorsLegs[i + 196] = armorsLegs[i + 196] |= 0x10; // mark this item as "new"
                }
                if ((armorsLegs[i] & 0x20) == 0) // if bit cleared (i.e. armor not already unlocked)
                {
                    armorsLegs[i] = armorsLegs[i] |= 0x20; // unlock this item
                    armorsLegs[i + 196] = armorsLegs[i + 196] |= 0x20; // mark this item as "new"
                }
            }
        }

        public virtual byte[] Serialize()
        {
            byte[] ret = new byte[2560];

            Array.Copy(weaponsGreatsword, 0, ret,         0, 40);
            Array.Copy(weaponsSwordAndShield, 0, ret,    40, 40);
            Array.Copy(weaponsHammer, 0, ret,            80, 40);
            Array.Copy(weaponsLance, 0, ret,            120, 40);
            Array.Copy(weaponsHeavyBowgun, 0, ret,      160, 40);
            Array.Copy(reserved1, 0, ret,               200, 40);
            Array.Copy(weaponsLightBowgun, 0, ret,      240, 40);
            Array.Copy(weaponsLongsword, 0, ret,        280, 40);
            Array.Copy(weaponsSwitchAxe, 0, ret,        320, 40);
            Array.Copy(weaponsGunLance, 0, ret,         360, 40);
            Array.Copy(weaponsBow, 0, ret,              400, 40);
            Array.Copy(weaponsDualBlade, 0, ret,        440, 40);
            Array.Copy(weaponsHuntingHorn, 0, ret,      480, 40);
            Array.Copy(weaponsInsectGlaive, 0, ret,     520, 40);
            Array.Copy(weaponsChargeBlade, 0, ret,      560, 40);

            Array.Copy(armorsHead, 0, ret,   600, 392);
            Array.Copy(armorsChest, 0, ret,  992, 392);
            Array.Copy(armorsArms, 0, ret,  1384, 392);
            Array.Copy(armorsWaist, 0, ret, 1776, 392);
            Array.Copy(armorsLegs, 0, ret,  2168, 392);

            return ret;
        }
    }
}
