using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestConverter.Quest
{
    internal class StartData
    {
        public void load(uint stage, uint[] unk)
        {
            this.stage = stage;
            this.unk = unk;
        }
        public UInt32 stage;
        public UInt32[] unk = [];
    }
}
