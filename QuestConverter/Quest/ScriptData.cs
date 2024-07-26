using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestConverter.Quest
{
    internal class ScriptData(ushort opcode, ushort arg1, ushort arg2, ushort arg3)
    {
        public UInt16 opcode = opcode;
        public UInt16 arg1 = arg1;
        public UInt16 arg2 = arg2;
        public UInt16 arg3 = arg3;
    }
}
