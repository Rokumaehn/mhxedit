using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace mhxedit
{
    public class MonHunCharacter
    {
        public string name;
        public uint playTime;
        public uint zenny;
        public ushort hr;
        public MonHunItem[] itemBox;
        public MonHunEquip[] equipBox;


        public byte[] SerializeBase()
        {
            byte[] ret = new byte[42];
            BinaryWriter writer = new BinaryWriter(new MemoryStream(ret));

            byte[] bname = new byte[32];
            for (int i = 0; i < 32; i++) bname[i] = 0;
            System.Text.Encoding.UTF8.GetBytes(name, 0, name.Length, bname, 0);
            writer.Write(bname);
            writer.Write(playTime);
            writer.Write(zenny);
            writer.Write(hr);

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

        public MonHunCharacter(MemoryStream ms)
        {
            BinaryReader reader = new BinaryReader(ms);
            itemBox = new MonHunItem[1400];
            equipBox = new MonHunEquip[1400];

            reader.BaseStream.Seek(0x0, SeekOrigin.Begin);
            name = System.Text.Encoding.UTF8.GetString(reader.ReadBytes(32), 0, 32);
            playTime = reader.ReadUInt32();
            zenny = reader.ReadUInt32();
            hr = reader.ReadUInt16();

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

            reader.BaseStream.Seek(0x4667, SeekOrigin.Begin);
            for (int i = 0; i < 1400; i++)
            {
                equipBox[i] = new MonHunEquip(reader.ReadBytes(36));
            }
        }
    }
}
