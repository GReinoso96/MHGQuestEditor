using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MHGQuestEditor.Constants;

namespace MHGQuestEditor.Quest
{
    internal class RewardData
    {
        public RewardData(BinaryReader br, uint ptr)
        {
            br.BaseStream.Position = ptr;

            while (true)
            {
                var type = br.ReadUInt32();
                var rwdPtr = br.ReadUInt32();
                var curOffset = br.BaseStream.Position;
                if (type == 0xFFFF) { break; }
                this.groups.Add(new RewardGroup(br, rwdPtr, type));
                br.BaseStream.Position = curOffset;
            }
        }
        public List<RewardGroup> groups = new List<RewardGroup>();
    }

    internal class RewardGroup
    {
        public RewardGroup(BinaryReader br, uint ptr, uint type)
        {
            br.BaseStream.Position = ptr;

            this.type = type;
            this.rwdPtr = ptr;

            if(RewardTypeDict.TryGetValue(type, out var rewardType))
            {
                this.strType = rewardType.ToString();
            }

            while (true)
            {
                var chance = br.ReadUInt16();
                var item = br.ReadUInt16();
                var amount = br.ReadUInt16();
                if (chance == 0xFFFF) { break; }
                this.rewards.Add(new RewardItem(chance, item, amount));
            }
        }
        public UInt32 type;
        public UInt32 rwdPtr;
        public string strType = "Unknown";
        public List<RewardItem> rewards = new List<RewardItem>();

        public override string ToString()
        {
            return this.strType;
        }
    }

    internal class RewardItem(UInt16 chance, UInt16 id, UInt16 amount)
    {
        public UInt16 chance = chance; public UInt16 id = id; public UInt16 amount = amount;
    }
}
