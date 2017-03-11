using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace mhxedit
{
    public class ComboList
    {
        protected byte[] unlocked;

        public ComboList(MemoryStream ms)
        {
            BinaryReader reader = new BinaryReader(ms);

            reader.BaseStream.Seek(0x190B2, SeekOrigin.Begin);

            unlocked = reader.ReadBytes(21);
        }

        protected int _countUnlocked;
        public int CountUnlocked
        {
            get
            {
                _countUnlocked = 0;
                for (int i = 0; i < (20 * 8); i++)
                {
                    if ((unlocked[i / 8] & (1 << (i % 8))) > 0)
                    {
                        _countUnlocked++;
                    }
                }
                if((unlocked[20] & 0x01) > 0) _countUnlocked++;

                return _countUnlocked;
            }

            set
            {

            }
        }

        public void UnlockAll()
        {
            for (int i = 0; i < (20 * 8); i++)
            {
                if ((unlocked[i / 8] & (1 << (i % 8))) == 0)
                {
                    unlocked[i / 8] = (byte)(unlocked[i / 8] | (1 << (i % 8)));
                }
            }
            unlocked[20] = (byte)(unlocked[20] | 0x01);
        }

        public virtual byte[] Serialize()
        {
            byte[] ret = new byte[21];

            Array.Copy(unlocked, 0, ret, 0, 21);

            return ret;
        }
    }
}
