using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public List<SupplyItem> supplies = new List<SupplyItem>();
    }

    internal class SupplyItem(UInt16 id, UInt16 amount)
    {
        public UInt16 id = id;
        public UInt16 amount = amount;
    }
}
