using QuestConverter.Quest;
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
        public void loadData(BinaryReader br)
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

            // Visual Data
            this.questData = new QuestData();
            this.questData.load(br, dataPtr);

            // Supplies
            var supplies = new SupplyData();
            supplies.load(br, this.supplyPtr);
            this.supplyData = supplies;

            // Rewards
            br.BaseStream.Position = this.rewardPtr;
            while(true) {
                var curptr = br.BaseStream.Position;
                var typeRew = br.ReadInt32();
                var ptrRew = br.ReadUInt32();
                if (typeRew == 0xFFFF) break;
                var reward = new RewardData();
                reward.load(br, curptr, typeRew, ptrRew);
                this.rewardData.Add(reward);
                br.BaseStream.Position = curptr+=8;
            };

            // Script
            br.BaseStream.Position = this.scriptPtr;
            while (true)
            {
                var opcode = br.ReadUInt16();
                var arg1 = br.ReadUInt16();
                var arg2 = br.ReadUInt16();
                var arg3 = br.ReadUInt16();
                if (opcode > 0xFF) break;
                this.scriptData.Add(new ScriptData(opcode, arg1, arg2, arg3));
            }

            // Small Monsters
            smallMons.load(br, this.sMonPtr);
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

        public QuestData questData = new();

        public SupplyData supplyData = new();

        public List<RewardData> rewardData = [];

        public List<ScriptData> scriptData = [];

        public SmallMonsterWaves smallMons = new SmallMonsterWaves();
    }
}
