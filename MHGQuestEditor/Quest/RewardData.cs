﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MHGQuestEditor.Constants;

namespace MHGQuestEditor.Quest
{
    internal class RewardData
    {
        public RewardData(BinaryReader br, long ptr, int type, long rewPtr)
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

        public RewardData(int type)
        {
            this.type=type;
            while (this.rewards.Count < 15)
            {
                this.rewards.Add(new RewardItem(0, 0, 0));
            }
        }
        public int type;
        public List<RewardItem> rewards = new List<RewardItem>();

        public override string ToString()
        {
            return RewardTypeDict[this.type];
        }
    }

    internal class RewardItem(UInt16 chance, UInt16 id, UInt16 amount)
    {
        public UInt16 chance = chance; public UInt16 id = id; public UInt16 amount = amount;

        public override string ToString()
        {
            return ItemNames[this.id];
        }
    }
}
