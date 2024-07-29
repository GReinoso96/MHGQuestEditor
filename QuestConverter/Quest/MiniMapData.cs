using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestConverter.Quest
{
    internal class MiniMapData
    {
        public void load(BinaryReader br)
        {
            this.pos = [ br.ReadSingle(), br.ReadSingle() ];
            this.unk1 = br.ReadUInt32();
            this.unk2 = br.ReadUInt32();
            this.unk3 = [br.ReadSingle(), br.ReadSingle(), br.ReadSingle() ];
            this.unk4 = br.ReadUInt32();
        }
        public float[] pos = []; // 2
        public UInt32 unk1;
        public UInt32 unk2;
        public float[] unk3 = []; // 3
        public UInt32 unk4;
    }
}
