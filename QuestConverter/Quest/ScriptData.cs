using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuestConverter.Constants;

namespace QuestConverter.Quest
{
    internal class ScriptData
    {
        public UInt16 opcode;
        public UInt16 arg1;
        public UInt16 arg2;
        public UInt16 arg3;
        public string desc = "";

        public ScriptData(ushort opcode, ushort arg1, ushort arg2, ushort arg3)
        {
            this.opcode = opcode;
            this.arg1 = arg1;
            this.arg2 = arg2;
            this.arg3 = arg3;

            if(opcode == 0x2)
            {
                this.desc = $"Slay {arg2} {EntityNames[arg1]}";
            }

            else if (opcode == 0x4)
            {
                this.desc = $"Deliver {arg2} {ItemNames[arg1]}";
            }
        }
    }
}
