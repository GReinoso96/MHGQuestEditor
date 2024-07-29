using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuestConverter.Constants;

namespace QuestConverter.Quest
{
    internal class LargeMonsterWaves
    {
        public void load(BinaryReader br, uint waveNum, uint unk, uint cachePtr, uint dataPtr)
        {
            this.waveNum = waveNum;
            this.unk = unk;
            this.cachePtr = cachePtr;
            this.dataPtr = dataPtr;

            br.BaseStream.Position = dataPtr;

            while(true)
            {
                var id = br.ReadUInt16();
                var variant = br.ReadUInt16();
                var qty = br.ReadByte();
                var str = br.ReadUInt16();
                var stg = br.ReadByte();
                var unk1 = br.ReadBytes(20);
                var angle = br.ReadUInt32();
                float[] pos = [br.ReadSingle(), br.ReadSingle(), br.ReadSingle()];
                var unk2 = br.ReadBytes(16);
                if (id == 0xFFFF) break;
                LargeMonster monster = new LargeMonster();
                monster.Load(id, variant, qty, str, stg, unk1, angle, pos, unk2);
                this.monsters.Add(monster);
            }

            br.BaseStream.Position = this.cachePtr;
            for (int i = 0; i < 4; i++)
            {
                var cacheID = br.ReadUInt32();
                this.cacheData.Add(cacheID);
            }
        }
        public UInt32 waveNum;
        public UInt32 unk;
        public UInt32 cachePtr;
        public UInt32 dataPtr;
        public List<LargeMonster> monsters = [];
        public List<UInt32> cacheData = [];
    }
    internal class LargeMonster
    {
        public void Load(ushort id, ushort variant, byte quantity, ushort strength, byte stageId, byte[] unk1, uint angle, float[] pos, byte[] unk2)
        {
            this.id = id;
            this.variant = variant;
            this.quantity = quantity;
            this.strength = strength;
            this.stageId = stageId;
            this.unk1 = Convert.ToHexString(unk1);
            this.pos = pos;
            this.unk2 = Convert.ToHexString(unk2);
            this.angle = angle;
            this.name = EntityNames[id];
        }
        public UInt16 id;
        public UInt16 variant;
        public byte quantity;
        public UInt16 strength;
        public byte stageId;
        public string unk1;
        public UInt32 angle;
        public float[] pos;
        public string unk2;
        public string name = "";
    }
}
