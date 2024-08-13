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
        }

        public void load(int type)
        {
            this.type=type;
        }
        public int type;
        public UInt32 ptr;
        public List<RewardItem> rewards = new();
    }

    internal class RewardItem
    {
        public RewardItem(UInt16 chance, UInt16 id, UInt16 amount)
        {
            this.chance = chance;
            this.id = id;
            this.amount = amount;
            if(id < ItemNames.Length)
            {
                this.name = ItemNames[id];
            }
        }
        public UInt16 chance;
        public UInt16 id;
        public UInt16 amount;
        public string name = "";
    }
}
