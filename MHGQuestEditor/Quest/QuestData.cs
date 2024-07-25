using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHGQuestEditor.Quest
{
    internal class QuestData
    {
        public QuestData(BinaryReader br, uint dataPtr)
        {
            br.BaseStream.Position = dataPtr;
            this.type = br.ReadByte();
            this.questFlags = br.ReadByte();
            this.stars = br.ReadUInt16();
            this.fee = br.ReadUInt32();
            this.reward = br.ReadUInt32();
            this.cartCost = br.ReadUInt32();
            this.timeLimit = br.ReadUInt32();
            this.locale = br.ReadUInt16();
            this.unk = br.ReadUInt16();
            this.stringsPtr = br.ReadUInt32();
            this.conditions = br.ReadUInt16();
            this.id = br.ReadUInt16();

            br.BaseStream.Position = this.stringsPtr;

            uint[] strPtrs = { br.ReadUInt32(), br.ReadUInt32(), br.ReadUInt32(), br.ReadUInt32() };

            this.title = StringHelper.ReadUntilNull(br, strPtrs[0]).Replace("\n","\r\n");
            this.win = StringHelper.ReadUntilNull(br, strPtrs[1]).Replace("\n", "\r\n");
            this.fail = StringHelper.ReadUntilNull(br, strPtrs[2]).Replace("\n", "\r\n");
            this.description = StringHelper.ReadUntilNull(br, strPtrs[3]).Replace("\n", "\r\n");
        }
        public byte type;
        public byte questFlags;
        public UInt16 stars;
        public UInt32 fee;
        public UInt32 reward;
        public UInt32 cartCost;
        public UInt32 timeLimit;
        public UInt16 locale;
        public UInt16 unk;
        public UInt32 stringsPtr;
        public UInt16 conditions;
        public UInt16 id;

        public string title = "";
        public string win = "";
        public string fail = "";
        public string description = "";
    }
}
