using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace mhxedit
{
    public class MonHunCharacter
    {
        // Basic
        public string name;
        public uint playTime;
        private uint funds;
        public ushort hr;
        // Extended
        public uint hrPoints;
        public uint funds2;
        public uint extUnknown1;
        public uint academyPoints;
        public uint berunaPoints;
        public uint kokotoPoints;
        public uint pokkePoints;
        public uint yukumoPoints;

        public byte[] flags1;

        public MonHunItem[] itemBox;
        public MonHunEquip[] equipBox;

        public MonHunEquip equippedWeapon;

        private Craftable craftables;
        private Meal meals;
        private ComboList comboList;


        public bool ItemBoxP11Unlocked
        {
            get
            {
                return (flags1[2] & 32)==32;
            }

            set
            {
                if (value) flags1[2] |= 32;
                else flags1[2] &= (byte)(flags1[2] & (~32));
            }
        }

        public bool ItemBoxP12Unlocked
        {
            get
            {
                return (flags1[2] & 64) == 64;
            }

            set
            {
                if (value) flags1[2] |= 64;
                else flags1[2] &= (byte)(flags1[2] & (~64));
            }
        }

        public bool PalicoBoxP6Unlocked
        {
            get
            {
                return (flags1[6] & 32) == 32;
            }

            set
            {
                if (value) flags1[6] |= 32;
                else flags1[6] &= (byte)(flags1[6] & (~32));
            }
        }

        public bool PalicoBoxP7Unlocked
        {
            get
            {
                return (flags1[6] & 64) == 64;
            }

            set
            {
                if (value) flags1[6] |= 64;
                else flags1[6] &= (byte)(flags1[6] & (~64));
            }
        }

        public uint Funds
        {
            get
            {
                return funds;
            }

            set
            {
                funds = value;
                funds2 = value;
            }
        }

        public Craftable Craftables
        {
            get
            {
                return craftables;
            }
        }

        public Meal Meals
        {
            get
            {
                return meals;
            }
        }

        public ComboList Combolist
        {
            get
            {
                return comboList;
            }
        }

        public MonHunEquip ReloadEquip(int idx)
        {
            if (idx < 0 || idx > equipBox.Length - 1) return equipBox[idx];
            equipBox[idx] = MonHunEquip.Create(equipBox[idx].Serialize());
            return equipBox[idx];
        }

        public byte[] SerializeBase()
        {
            byte[] ret = new byte[42];
            BinaryWriter writer = new BinaryWriter(new MemoryStream(ret));

            byte[] bname = new byte[32];
            for (int i = 0; i < 32; i++) bname[i] = 0;
            System.Text.Encoding.UTF8.GetBytes(name, 0, name.Length, bname, 0);
            writer.Write(bname);
            writer.Write(playTime);
            writer.Write(funds);
            writer.Write(hr);

            return ret;
        }

        public byte[] SerializeExtended()
        {
            byte[] ret = new byte[4 * 8];
            BinaryWriter writer = new BinaryWriter(new MemoryStream(ret));

            writer.Write(hrPoints);
            writer.Write(funds2);
            writer.Write(extUnknown1);
            writer.Write(academyPoints);
            writer.Write(berunaPoints);
            writer.Write(kokotoPoints);
            writer.Write(pokkePoints);
            writer.Write(yukumoPoints);

            return ret;
        }

        public byte[] SerializeFlags1()
        {
            byte[] ret = new byte[8];
            BinaryWriter writer = new BinaryWriter(new MemoryStream(ret));

            writer.Write(flags1);

            return ret;
        }


        public byte[] SerializeItemBox()
        {
            byte[] ret = new byte[3150];
            BinaryWriter writer = new BinaryWriter(new MemoryStream(ret));

            uint buffer = 0;
            uint bits = 0;
            for (int i = 0; i < 1400; i++)
            {
                buffer = (itemBox[i].GetRaw() << ((int)bits)) | buffer;
                bits += 18;

                while (bits >= 8)
                {
                    writer.Write((byte)buffer);
                    buffer >>= 8;
                    bits -= 8;
                }
            }

            return ret;
        }

        public byte[] SerializeEquipmentBox()
        {
            byte[] ret = new byte[36*1400];
            BinaryWriter writer = new BinaryWriter(new MemoryStream(ret));

            for (int i = 0; i < 1400; i++)
            {
                Array.Copy(equipBox[i].Serialize(), 0, ret, i * 36, 36);
            }

            return ret;
        }

        public byte[] SerializeCraftables()
        {
            return craftables.Serialize();
        }

        public byte[] SerializeMeals()
        {
            return meals.Serialize();
        }

        public byte[] SerializeComboList()
        {
            return comboList.Serialize();
        }

        public MonHunCharacter(MemoryStream ms)
        {
            BinaryReader reader = new BinaryReader(ms);
            itemBox = new MonHunItem[1400];
            equipBox = new MonHunEquip[1400];

            reader.BaseStream.Seek(0x0, SeekOrigin.Begin);
            name = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(32), 0, 32);
            playTime = reader.ReadUInt32();
            funds = reader.ReadUInt32();
            hr = reader.ReadUInt16();

            reader.BaseStream.Seek(0x0110, SeekOrigin.Begin);
            equippedWeapon = MonHunEquip.Create(reader.ReadBytes(36));

            reader.BaseStream.Seek(0x1476, SeekOrigin.Begin);
            hrPoints = reader.ReadUInt32();
            funds2 = reader.ReadUInt32();
            extUnknown1 = reader.ReadUInt32();
            academyPoints = reader.ReadUInt32();
            berunaPoints = reader.ReadUInt32();
            kokotoPoints = reader.ReadUInt32();
            pokkePoints = reader.ReadUInt32();
            yukumoPoints = reader.ReadUInt32();

            reader.BaseStream.Seek(0x1A22, SeekOrigin.Begin);
            flags1 = reader.ReadBytes(8);

            // Item Box
            reader.BaseStream.Seek(0x290, SeekOrigin.Begin);
            uint buffer = 0;
            uint bits = 0;
            for (int i = 0; i < 1400; i++)
            {
                byte b = 0;

                while (bits < 18)
                {
                    b = reader.ReadByte();
                    buffer >>= 8;
                    buffer = (((uint)(b)) << 24) | (buffer & 0x00FFFFFF); // shift right into
                    bits += 8;
                }

                if (bits >= 18)
                {
                    uint item = (buffer >> ((int)(32 - bits))) & 0x0003FFFF;
                    buffer = ((uint)b) << 24;
                    bits -= 18;
                    // Item OK
                    itemBox[i] = new MonHunItem(item & 0x7FF, item >> 11);
                }
            }

            // Equipment Box
            reader.BaseStream.Seek(0x4667, SeekOrigin.Begin);
            for (int i = 0; i < 1400; i++)
            {
                equipBox[i] = MonHunEquip.Create(reader.ReadBytes(36));
            }

            // Craftables
            craftables = new Craftable(ms);

            // Meals
            meals = new Meal(ms);

            // Combo List
            comboList = new ComboList(ms);
        }
    }
}
