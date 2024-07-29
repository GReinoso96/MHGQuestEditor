using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using static QuestConverter.Constants;

namespace MHGQuestEditor.Quest
{
    internal class SmallMonsterWaves
    {
        public void load(BinaryReader br, uint ptr)
        {
            br.BaseStream.Position = ptr;
            List<uint> wavePtrs = new List<uint>();
            while (true)
            {
                var wave = br.ReadUInt32();
                if (wave == 0x0) break;
                wavePtrs.Add(wave);
            }
            foreach(var wptr in wavePtrs)
            {
                var wave = new SmallMonsterGroups();
                wave.load(br, wptr);
                this.waves.Add(wave);
            }
        }

        public List<SmallMonsterGroups> waves = [];
    }
    internal class SmallMonsterGroups
    {
        public void load(BinaryReader br, uint ptr)
        {
            br.BaseStream.Position = ptr;
            
            while (true)
            {
                var stage = br.ReadUInt32();
                var unk = br.ReadUInt32();
                var cache = br.ReadUInt32();
                var data = br.ReadUInt32();
                if (stage > 90 || stage == 0x0)
                {
                    this.unkLine = [ stage, unk, cache, data ];
                    break;
                };
                var curpos = br.BaseStream.Position;
                var stagedata = new SmallMonsterStages();
                stagedata.load(br, stage, unk, cache, data);
                monstages.Add(stagedata);
                br.BaseStream.Position = curpos;
            }


        }

        public UInt32[] unkLine = [];
        public UInt32 ptr;

        public List<SmallMonsterStages> monstages = [];
    }

    internal class SmallMonsterStages
    {
        public void load(BinaryReader br, uint stage, uint unk, uint cachePtr, uint dataPtr)
        {
            this.stage = stage;
            this.unk = unk;
            this.cachePtr = cachePtr;
            this.dataPtr = dataPtr;

            br.BaseStream.Position = this.dataPtr;

            while (true)
            {
                var id = br.ReadUInt16();
                var variant = br.ReadUInt16();
                var quantity = br.ReadUInt32();
                var unk1 = br.ReadBytes(20);
                var angle = br.ReadUInt32();
                float[] pos = { br.ReadSingle(), br.ReadSingle(), br.ReadSingle () };
                var unk2 = br.ReadBytes(16);
                if (id == 0xFFFF) break;
                var mon = new SmallMonsterData();
                mon.load(id, variant, quantity, unk1, pos, unk2, angle);
                monsters.Add(mon);
            }

            br.BaseStream.Position = this.cachePtr;
            for(int i = 0; i < 4;i++)
            {
                var cacheID = br.ReadUInt32();
                this.cacheData.Add(cacheID);
            }
        }
        public UInt32 stage;
        public UInt32 unk;
        public UInt32 cachePtr;
        public UInt32 dataPtr;

        public List<UInt32> cacheData = [];

        public List<SmallMonsterData> monsters = [];
    }

    internal class SmallMonsterData
    {
        public void load(ushort id, ushort var, uint qty, byte[] unk1, float[] pos, byte[] unk2, uint angle)
        {
            this.id = id;
            this.variant = var;
            this.quantity = qty;
            this.unk1 = Convert.ToHexString(unk1);
            this.pos = pos;
            this.unk2 = Convert.ToHexString(unk2);
            this.angle = angle;//Convert.ToSingle(angle/255.0);
            this.name = EntityNames[this.id];
        }
        public UInt16 id;
        public UInt16 variant;
        public UInt32 quantity;
        public string unk1 = "";
        public UInt32 angle;
        public float[] pos = [];
        public string unk2 = "";
        public string name = "";
    }
}
