using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHGQuestEditor.Quest
{
    internal class SmMonGroups
    {
        public SmMonGroups(BinaryReader br, uint ptr)
        {
            br.BaseStream.Position = ptr;
            while (true)
            {
                var ptrs = br.ReadUInt32();
                if (ptrs == 0) break;
                var curPos = br.BaseStream.Position;
                this.groups.Add(new SmallMonsters(br, ptrs));
                br.BaseStream.Position = curPos;
            }
        }
        List<SmallMonsters> groups = new List<SmallMonsters>();
    }
    internal class SmallMonsters
    {
        public SmallMonsters(BinaryReader br, uint ptr)
        {
            br.BaseStream.Position = ptr;
            while (true)
            {
                var stage = br.ReadUInt32();
                var unk = br.ReadUInt32();
                var cache = br.ReadUInt32();
                var data = br.ReadUInt32();
                if (stage == 0) break;
                stages.Add(new SmMonStages(br,stage, unk, cache, data));
            }
        }
        public uint groupPtr;

        public List<SmMonStages> stages = new List<SmMonStages>();
    }

    internal class SmMonStages
    {
        public uint stage;
        public uint unk;
        public uint cachePtr;
        public uint dataPtr;

        public List<SmMonData> monsters = new List<SmMonData>();

        public SmMonStages(BinaryReader br, uint stage, uint unk, uint cachePtr, uint dataPtr)
        {
            this.stage = stage;
            this.unk = unk;
            this.cachePtr = cachePtr;
            this.dataPtr = dataPtr;

            br.BaseStream.Position = this.dataPtr;
        }
    }

    internal class SmMonData(BinaryReader br, uint ptr)
    {
        public uint id;
        public uint variant;
        public uint quantity;
        public uint[] unk1;
        public float[] pos;
        public uint[] unk2;
    }
}
