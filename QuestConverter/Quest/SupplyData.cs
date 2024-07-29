using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuestConverter.Constants;

namespace MHGQuestEditor.Quest
{
    internal class SupplyData
    {
        public void load(BinaryReader br, uint ptr)
        {
            br.BaseStream.Position = ptr;

            while (true)
            {
                var item = br.ReadUInt16();
                var amount = br.ReadUInt16();
                if(item == 0) { break; }
                var supply = new SupplyItem();
                supply.load(item, amount);
                this.supplies.Add(supply);
            }
        }

        public List<SupplyItem> supplies = new List<SupplyItem>();
    }

    internal class SupplyItem
    {
        public UInt16 id;
        public UInt16 amount;
        public string name = "";

        public void load(UInt16 id, UInt16 amount)
        {
            this.id = id;
            this.amount = amount;
            this.name = ItemNames[id];
        }
    }
}
