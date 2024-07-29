using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestConverter.Quest
{
    internal class GatherStage
    {
        public void load(BinaryReader br, uint ptr)
        {
            br.BaseStream.Position = ptr;
            while(true)
            {
                float[] pos = [br.ReadSingle(), br.ReadSingle(), br.ReadSingle()];
                var size = br.ReadSingle();
                var gatherID = br.ReadUInt16();
                var times = br.ReadUInt16();
                var type = br.ReadUInt16();
                var unk = br.ReadUInt16();
                if (pos[0] == -1.0) break;
                var node = new GatherNode();
                node.load(pos,size, gatherID, times, type, unk);
                this.Nodes.Add(node);
            }
        }
        public UInt32 ptr;
        public List<GatherNode> Nodes = [];
    }
    internal class GatherNode
    {
        public void load(float[] pos, float size, ushort gatherId, ushort times, ushort type, ushort unk)
        {
            this.pos = pos;
            this.size = size;
            this.gatherID = gatherId;
            this.times = times;
            this.type = type;
            this.unk = unk;
        }
        public float[] pos;
        public float size;
        public UInt16 gatherID;
        public UInt16 times;
        public UInt16 type;
        public UInt16 unk;
    }
}
