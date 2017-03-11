using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace mhxedit
{
    public class Meal
    {
        protected byte[] unlocked;
        protected byte[] flaggedNew;

        public Meal(MemoryStream ms)
        {
            BinaryReader reader = new BinaryReader(ms);

            reader.BaseStream.Seek(0x1FE6C, SeekOrigin.Begin);

            unlocked = reader.ReadBytes(12);
            flaggedNew = reader.ReadBytes(12);
        }

        protected int _countUnlocked;
        public int CountUnlocked
        {
            get
            {
                _countUnlocked = 0;
                for (int i = 0; i < (12 * 8); i++)
                {
                    if ((unlocked[i / 8] & (1 << (i % 8))) > 0)
                    {
                        _countUnlocked++;
                    }
                }
                
                return _countUnlocked;
            }

            set
            {

            }
        }

        public void UnlockAll()
        {
            for (int i = 0; i < (12 * 8); i++)
            {
                if ((unlocked[i / 8] & (1 << (i % 8))) == 0)
                {
                    unlocked[i / 8] = (byte)(unlocked[i / 8] | (1 << (i % 8)));
                    flaggedNew[i / 8] = (byte)(unlocked[i / 8] | (1 << (i % 8)));
                }
            }
        }

        public virtual byte[] Serialize()
        {
            byte[] ret = new byte[12*2];

            Array.Copy(unlocked, 0, ret, 0, 12);
            Array.Copy(flaggedNew, 0, ret, 12, 12);

            return ret;
        }
    }
}
