using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MHGQuestEditor.Constants;

namespace MHGQuestEditor.Quest
{
    internal class QuestFile
    {

        public QuestFile(BinaryReader br)
        {
            br.BaseStream.Position = 0;
            this.dataPtr = br.ReadUInt32();
            this.startPtr = br.ReadUInt32();
            this.supplyPtr = br.ReadUInt32();
            this.rewardPtr = br.ReadUInt32();
            this.scriptPtr = br.ReadUInt32();
            this.sMonPtr = br.ReadUInt32();
            this.lMonPtr = br.ReadUInt32();
            this.zonePtr = br.ReadUInt32();
            this.originsPtr = br.ReadUInt32();
            this.campPtr = br.ReadUInt32();
            this.gatherPtr = br.ReadUInt32();
            this.uniquesPtr = br.ReadUInt32();
            this.progStrPtr = br.ReadUInt32();
            this.monsterHP = br.ReadUInt32();
            this.hrp = br.ReadUInt32();
            this.onlineFlag = br.ReadUInt32();
            this.bossSize = br.ReadUInt16();
            this.difficulty = br.ReadByte();
            this.spawnID = br.ReadByte();
            this.bossSizeClass = br.ReadByte();
            this.supplyType = br.ReadByte();
            this.supplyMon = br.ReadByte();
            this.supplyNum = br.ReadByte();

            this.questData = new QuestData(br, this.dataPtr);

            this.supplyData = new SupplyData(br, this.supplyPtr);

            this.rewardData = new RewardData(br, this.rewardPtr);
        }

        public UInt32 dataPtr;
        public UInt32 startPtr;
        public UInt32 supplyPtr;
        public UInt32 rewardPtr;
        public UInt32 scriptPtr;
        public UInt32 sMonPtr;
        public UInt32 lMonPtr;
        public UInt32 zonePtr;
        public UInt32 originsPtr;
        public UInt32 campPtr;
        public UInt32 gatherPtr;
        public UInt32 uniquesPtr;
        public UInt32 progStrPtr;
        public UInt32 monsterHP;
        public UInt32 hrp;
        public UInt32 onlineFlag;
        public UInt16 bossSize;
        public byte difficulty;
        public byte spawnID;
        public byte bossSizeClass;
        public byte supplyType;
        public byte supplyMon;
        public byte supplyNum;

        public QuestData questData;

        public SupplyData supplyData;

        public RewardData rewardData;
    }
}
