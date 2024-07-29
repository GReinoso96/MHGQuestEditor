using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestConverter.Quest
{
    internal class ZoneGroup
    {
        public void load(BinaryReader br, uint ptr)
        {
            br.BaseStream.Position = ptr;

            while(true)
            {
                var target = br.ReadUInt32();
                float[] pos = [br.ReadSingle(), br.ReadSingle(), br.ReadSingle()];
                float[] size = [br.ReadSingle(), br.ReadSingle()];
                byte[] unk = br.ReadBytes(12);
                float[] targetPos = [br.ReadSingle(), br.ReadSingle(), br.ReadSingle()];
                var angle = br.ReadUInt32();
                if (target == 0xFFFFFFFF) break;
                var zone = new ZoneData();
                zone.load(target, pos, size, unk, targetPos, angle);
                zones.Add(zone);
            }
        }
        public UInt32 ptr;
        public List<ZoneData> zones = [];
    }
    internal class ZoneData
    {
        public void load(uint target, float[] pos, float[] size, byte[] unk, float[] targetPos, uint angle)
        {
            this.targetStg = target;
            this.pos = pos;
            this.size = size;
            this.unk = Convert.ToHexString(unk);
            this.targetPos = targetPos;
            this.targetAngle = angle;
        }
        public UInt32 targetStg;
        public float[] pos;
        public float[] size;
        public string unk;
        public float[] targetPos;
        public UInt32 targetAngle;
    }
}
