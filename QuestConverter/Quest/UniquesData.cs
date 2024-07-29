using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestConverter.Quest
{
    internal class UniqueStage
    {
        public void load(BinaryReader br, uint ptr)
        {
            br.BaseStream.Position = ptr;
            while (true)
            {
                var id = br.ReadUInt16();
                var type = br.ReadUInt16();
                float[] pos = [br.ReadSingle(), br.ReadSingle(), br.ReadSingle()];
                var size = br.ReadSingle();
                var angle = br.ReadUInt32();
                if (pos[0] == -1.0) break;
                var node = new UniqueNode();
                node.load(id, type, pos, size, angle);
                this.Nodes.Add(node);
            }
        }
        public List<UniqueNode> Nodes = [];
    }

    internal class UniqueNode
    {
        public void load(ushort id, ushort type, float[] pos, float size, uint angle)
        {
            this.id = id;
            this.type = type;
            this.pos = pos;
            this.size = size;
            this.angle = angle;
        }
        public UInt16 id = 0;
        public UInt16 type;
        public float[] pos = [];
        public float size;
        public UInt32 angle;
    }
}
