using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuestConverter.Constants;

namespace MHGQuestEditor.Quest
{
    internal class RewardData
    {
        public void load(BinaryReader br, long ptr, int type, long rewPtr)
        {
            br.BaseStream.Position = ptr;
            this.type = type;

            br.BaseStream.Position = rewPtr;

            while (true)
            {
                var chance = br.ReadUInt16();
                var id = br.ReadUInt16();
                var amount = br.ReadUInt16();

                if (chance == 0xFFFF) { break; }
                this.rewards.Add(new RewardItem(chance,id,amount));
            }
            while (this.rewards.Count < 15)
            {
                this.rewards.Add(new RewardItem(0, 0, 0));
            }
        }

        public void load(int type)
        {
            this.type=type;
            while (this.rewards.Count < 15)
            {
                this.rewards.Add(new RewardItem(0, 0, 0));
            }
        }
        public int type;
        public UInt32 ptr;
        public List<RewardItem> rewards = new();
    }

    internal class RewardItem(UInt16 chance, UInt16 id, UInt16 amount)
    {
        public UInt16 chance = chance; public UInt16 id = id; public UInt16 amount = amount;
        public string name = ItemNames[id];
    }
}
