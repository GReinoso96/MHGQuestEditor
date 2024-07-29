using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHGQuestEditor
{
    internal class StringHelper
    {
        public static string ReadUntilNull(BinaryReader br, uint ptr) {
            if(ptr <= br.BaseStream.Length)
            {
                br.BaseStream.Seek(ptr, SeekOrigin.Begin);
                var enc = Encoding.GetEncoding("shift-jis");
                string txt = "";
                while (true)
                {
                    byte str = br.ReadByte();
                    if (str == 0) { break; }
                    else if (str >= 0x81)
                    {
                        byte[] str2 = { str, br.ReadByte() };
                        txt += enc.GetString(str2);
                    }
                    /*else if (str == 0xA)
                    {
                        txt += "<NL>";
                    }*/
                    else
                    {
                        byte[] str2 = { str };
                        txt += enc.GetString(str2);
                    }

                }

                return txt;
            } else
            {
                return "Pointer out of bounds!";
            }
        }

        public static void WriteAddNull(BinaryWriter bw, string text)
        {
            byte[] str = Encoding.GetEncoding("shift-jis").GetBytes(text);

            foreach (byte chr in str)
            {
                bw.Write(chr);
            }
            bw.Write((byte)0x0);
            /*
            while (bw.BaseStream.Position % 4 != 0)
            {
                bw.Write((byte)0x0);
            }*/
        }

        public static void WriteZero(BinaryWriter bw, int size)
        {
            for (int i = 0; i < size; i++)
            {
                bw.Write((byte)0);
            }
        }
    }
}
