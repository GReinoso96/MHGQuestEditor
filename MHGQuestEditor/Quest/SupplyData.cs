﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MHGQuestEditor.Constants;

namespace MHGQuestEditor.Quest
{
    internal class SupplyData
    {
        public SupplyData(BinaryReader br, uint ptr)
        {
            br.BaseStream.Position = ptr;

            while (true)
            {
                var item = br.ReadUInt16();
                var amount = br.ReadUInt16();
                if(item == 0) { break; }
                this.supplies.Add(new SupplyItem(item, amount));
            }
            while(this.supplies.Count < 32)
            {
                this.supplies.Add(new SupplyItem(0, 0));
            }
        }

        public List<SupplyItem> supplies = new List<SupplyItem>();
    }

    internal class SupplyItem
    {
        public UInt16 id;
        public UInt16 amount;
        public string name;

        public SupplyItem(UInt16 id, UInt16 amount)
        {
            this.id = id;
            this.name = ItemNames[id];
            this.amount = amount;
        }

        public override string ToString()
        {
            this.name = ItemNames[this.id];
            return name;
        }
    }
}
