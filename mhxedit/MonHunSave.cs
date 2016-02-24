using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace mhxedit
{
    class MonHunSave
    {
        uint unknown;
        byte slotFirst;
        byte slotSecond;
        byte slotThird;
        byte slotLast;
        uint unknown2;
        uint[] slotOffsets;

        public MonHunCharacter[] slots;

        public MonHunSave(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                BinaryReader reader = new BinaryReader(fs);

                // Read character slot offsets
                slotOffsets = new uint[3];
                fs.Seek(0x10, SeekOrigin.Begin);
                for (int i = 0; i < 3; i++)
                {
                    slotOffsets[i] = reader.ReadUInt32();
                }

                // read character slots
                MemoryStream[] ms = new MemoryStream[3];
                slots = new MonHunCharacter[3];
                for (int i = 0; i < 3; i++)
                {
                    // Read a character
                    fs.Seek(slotOffsets[i], SeekOrigin.Begin);
                    ms[i] = new MemoryStream(reader.ReadBytes(0xEB52C));
                    slots[i] = new MonHunCharacter(ms[i]);
                }
            }
        }

        public void Save(string fileName)
        {
            using (var file = new FileStream(fileName, FileMode.Open))
            {
                BinaryWriter writer = new BinaryWriter(file);
                for (int i = 0; i < 3; i++)
                {
                    // Write basic character stuff
                    file.Seek(slotOffsets[i], SeekOrigin.Begin);
                    writer.Write(slots[i].SerializeBase());
                    // Write Item Box
                    file.Seek(slotOffsets[i] + 0x290, SeekOrigin.Begin);
                    writer.Write(slots[i].SerializeItemBox());
                    // Write Equipment Box
                    file.Seek(slotOffsets[i] + 0x4667, SeekOrigin.Begin);
                    writer.Write(slots[i].SerializeEquipmentBox());
                }

            }
        }
    }
}
