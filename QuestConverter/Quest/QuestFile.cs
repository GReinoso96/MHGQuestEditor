using QuestConverter.Quest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static QuestConverter.Constants;

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

            // Start Data
            br.BaseStream.Position = this.startPtr;
            for (int i = 0; i < 4; i++)
            {
                var map = br.ReadUInt32();
                uint[] unk = [ br.ReadUInt32(), br.ReadUInt32(), br.ReadUInt32() ];
                var strtData = new StartData();
                strtData.load(map, unk);
                this.startData.Add(strtData);
            }

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
                this.scriptData.Add(new ScriptData(opcode, arg1, arg2, arg3));
                if (br.BaseStream.Position >= this.progStrPtr) break;
            }

            // Small Monsters
            smallMons.load(br, this.sMonPtr);

            // Large Monsters
            br.BaseStream.Position = this.lMonPtr;
            while (true)
            {
                var waveNum = br.ReadUInt32();
                var unkL = br.ReadUInt32();
                var cachePtr = br.ReadUInt32();
                var dataPtr = br.ReadUInt32();
                if (waveNum == 0) break;
                var curpos = br.BaseStream.Position;
                var wave = new LargeMonsterWaves();
                wave.load(br,waveNum,unkL,cachePtr,dataPtr);
                this.largeMons.Add(wave);
                br.BaseStream.Position = curpos;
            }

            // Zones
            br.BaseStream.Position = this.zonePtr;
            while (true)
            {
                var zonePtr = br.ReadUInt32();
                if (zonePtr > br.BaseStream.Length) break;
                var curpos = br.BaseStream.Position;
                ZoneGroup zone = new ZoneGroup();
                zone.load(br, zonePtr);
                this.zoneData.Add(zone);
                br.BaseStream.Position = curpos;
            }

            // Minimap
            br.BaseStream.Position = this.originsPtr;
            // Get the count of zones from zone data, dirty hack
            foreach(var zone in this.zoneData)
            {
                var miniMap = new MiniMapData();
                miniMap.load(br);
                this.miniMapData.Add(miniMap);
            }

            // Gathering Nodes
            br.BaseStream.Position = this.gatherPtr+8; // Skipping that dummy entry
            for(int i = 0; i < 89;i++) // Either skips lobby stages or there's just no data for Battlegrounds
            {
                var gPtr = br.ReadUInt32();
                var curPtr = br.BaseStream.Position;
                var stageGather = new GatherStage();
                if (gPtr != 0)
                {
                    stageGather.load(br, gPtr);
                }
                this.gatherData.Add(stageGather);
                br.BaseStream.Position = curPtr;
            }

            br.BaseStream.Position = this.uniquesPtr;
            for (int i = 0; i < 90; i++)
            {
                var uPtr = br.ReadUInt32();
                var curPtr = br.BaseStream.Position;
                var stageUniques = new UniqueStage();
                if(uPtr != 0)
                {
                    stageUniques.load(br, uPtr);
                }
                this.uniquesData.Add(stageUniques);
                br.BaseStream.Position = curPtr;
            }

            br.BaseStream.Position = progStrPtr;

            uint firststPtr = 0;

            while(true)
            {
                var strptr = br.ReadUInt32();
                if(firststPtr == 0) { firststPtr = strptr; }
                if (strptr < firststPtr) break;
                var curPtr = br.BaseStream.Position;
                var strProg = StringHelper.ReadUntilNull(br,strptr);
                this.progressStr.Add(strProg);
                br.BaseStream.Position = curPtr;
            }

            br.BaseStream.Position = this.campPtr;
            this.campData.localeId = br.ReadUInt32();
            this.campData.areaId = br.ReadUInt32();
            this.campData.unk1 = br.ReadUInt32();
            this.campData.unk2 = br.ReadUInt32();
        }

        private UInt32 dataPtr;
        private UInt32 startPtr;
        private UInt32 supplyPtr;
        private UInt32 rewardPtr;
        private UInt32 scriptPtr;
        private UInt32 sMonPtr;
        private UInt32 lMonPtr;
        private UInt32 zonePtr;
        private UInt32 originsPtr;
        private UInt32 campPtr;
        private UInt32 gatherPtr;
        private UInt32 uniquesPtr;
        private UInt32 progStrPtr;
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

        public List<StartData> startData = new();

        public SupplyData supplyData = new();

        public List<RewardData> rewardData = [];

        public List<ScriptData> scriptData = [];

        public SmallMonsterWaves smallMons = new SmallMonsterWaves();

        public List<LargeMonsterWaves> largeMons = [];

        public List<ZoneGroup> zoneData = [];

        public List<MiniMapData> miniMapData = [];

        public List<GatherStage> gatherData = [];

        public List<UniqueStage> uniquesData = [];

        public List<string> progressStr = [];

        public CampData campData = new();

        public void write(BinaryWriter bw)
        {
            // Start writing quest text
            bw.BaseStream.Position = 0x68;

            // Save ptr and write each
            var titlePtr = bw.BaseStream.Position;
            StringHelper.WriteAddNull(bw, this.questData.title.Replace("\r\n","\n"));
            var winPtr = bw.BaseStream.Position;
            StringHelper.WriteAddNull(bw, this.questData.win.Replace("\r\n", "\n"));
            var failPtr = bw.BaseStream.Position;
            StringHelper.WriteAddNull(bw, this.questData.fail.Replace("\r\n", "\n"));
            var descPtr = bw.BaseStream.Position;
            StringHelper.WriteAddNull(bw, this.questData.description.Replace("\r\n", "\n"));

            // If pos isn't divisible by 4, add zero
            while(bw.BaseStream.Position % 4 != 0) { bw.Write((byte)0); }

            // Save quest text pointers
            this.questData.stringsPtr = (uint)bw.BaseStream.Position;
            bw.Write((UInt32)titlePtr); bw.Write((UInt32)winPtr); bw.Write((UInt32)failPtr); bw.Write((UInt32)descPtr);

            // Save ptr for next section
            this.startPtr = (uint)bw.BaseStream.Position;

            // Go back to quest data and write
            bw.BaseStream.Position = 0x48;
            bw.Write((byte)this.questData.type);
            bw.Write((byte)this.questData.questFlags);
            bw.Write((UInt16)this.questData.stars);
            bw.Write((UInt32)this.questData.fee);
            bw.Write((UInt32)this.questData.reward);
            bw.Write((UInt32)this.questData.cartCost);
            bw.Write((UInt32)this.questData.timeLimit);
            bw.Write((UInt16)this.questData.locale);
            bw.Write((UInt16)this.questData.unk);
            bw.Write((UInt32)this.questData.stringsPtr);
            bw.Write((UInt16)this.questData.conditions);
            bw.Write((UInt16)this.questData.id);

            // Start Data
            bw.BaseStream.Position = this.startPtr;
            foreach(var stData in this.startData)
            {
                bw.Write((UInt32)stData.stage);
                bw.Write((UInt32)stData.unk[0]);
                bw.Write((UInt32)stData.unk[1]);
                bw.Write((UInt32)stData.unk[2]);
            }

            // Small Monster Data
            foreach(var smonWave in this.smallMons.waves)
            {
                foreach(var smonStg in smonWave.monstages)
                {
                    smonStg.dataPtr = (UInt32)bw.BaseStream.Position;
                    foreach(var smon in smonStg.monsters)
                    {
                        bw.Write((UInt16)smon.id);
                        bw.Write((UInt16)smon.variant);
                        bw.Write((UInt32)smon.quantity);
                        bw.Write(Convert.FromHexString(smon.unk1));
                        bw.Write((UInt32)smon.angle);
                        bw.Write((Single)smon.pos[0]);
                        bw.Write((Single)smon.pos[1]);
                        bw.Write((Single)smon.pos[2]);
                        bw.Write(Convert.FromHexString(smon.unk2));
                    }
                    // Write End Marker
                    bw.Write((UInt16)0xFFFF);
                    StringHelper.WriteZero(bw, 0x3A);

                    // Write Cache
                    smonStg.cachePtr = (UInt32)bw.BaseStream.Position;
                    foreach(var data in smonStg.cacheData)
                    {
                        bw.Write((UInt32)data);
                    }
                }
                // Write Stage Data
                smonWave.ptr = (UInt32)bw.BaseStream.Position;
                foreach (var smonStg in smonWave.monstages)
                {
                    bw.Write((UInt32)smonStg.stage);
                    bw.Write((UInt32)smonStg.unk);
                    bw.Write((UInt32)smonStg.cachePtr);
                    bw.Write((UInt32)smonStg.dataPtr);
                }
                bw.Write(smonWave.unkLine[0]);
                bw.Write(smonWave.unkLine[1]);
                bw.Write(smonWave.unkLine[2]);
                bw.Write(smonWave.unkLine[3]);
            }
            this.sMonPtr = (uint)bw.BaseStream.Position;
            foreach (var smonWave in this.smallMons.waves)
            {
                bw.Write((UInt32)smonWave.ptr);
            }
            bw.Write((UInt32)0);

            foreach (var lmonWave in this.largeMons)
            {
                lmonWave.dataPtr = (UInt32)bw.BaseStream.Position;
                foreach (var monster in lmonWave.monsters)
                {
                    bw.Write((UInt16)monster.id);
                    bw.Write((UInt16)monster.variant);
                    bw.Write((byte)monster.quantity);
                    bw.Write((UInt16)monster.strength);
                    bw.Write((byte)monster.stageId);
                    bw.Write(Convert.FromHexString(monster.unk1));
                    bw.Write((UInt32)monster.angle);
                    bw.Write((Single)monster.pos[0]);
                    bw.Write((Single)monster.pos[1]);
                    bw.Write((Single)monster.pos[2]);
                    bw.Write(Convert.FromHexString(monster.unk2));
                }
                // Write End Marker
                bw.Write((UInt16)0xFFFF);
                StringHelper.WriteZero(bw, 0x3A);

                // Write Cache
                lmonWave.cachePtr = (UInt32)bw.BaseStream.Position;
                foreach (var data in lmonWave.cacheData)
                {
                    bw.Write((UInt32)data);
                }
            }
            this.lMonPtr = (UInt32)bw.BaseStream.Position;
            foreach (var lmonWave in this.largeMons)
            {
                bw.Write((UInt32)lmonWave.waveNum);
                bw.Write((UInt32)lmonWave.unk);
                bw.Write((UInt32)lmonWave.cachePtr);
                bw.Write((UInt32)lmonWave.dataPtr);
            }
            StringHelper.WriteZero(bw, 0x10);

            // Write Script
            this.scriptPtr = (UInt32)bw.BaseStream.Position;
            foreach (var code in this.scriptData)
            {
                bw.Write((UInt16)code.opcode);
                bw.Write((UInt16)code.arg1);
                bw.Write((UInt16)code.arg2);
                bw.Write((UInt16)code.arg3);
            }

            // Progress String Dummy Space
            this.progStrPtr = (UInt32)bw.BaseStream.Position;
            foreach(var str in this.progressStr)
            {
                bw.Write((UInt32)0);
            }

            // Camp Data
            this.campPtr = (UInt32)bw.BaseStream.Position;
            bw.Write((UInt32)this.campData.localeId);
            bw.Write((UInt32)this.campData.areaId);
            bw.Write((UInt32)this.campData.unk1);
            bw.Write((UInt32)this.campData.unk2);

            // Write Zone Transitions
            foreach(var zone in this.zoneData)
            {
                zone.ptr = (UInt32)bw.BaseStream.Position;
                foreach (var node in zone.zones)
                {
                    bw.Write((UInt32)node.targetStg);
                    bw.Write((Single)node.pos[0]);
                    bw.Write((Single)node.pos[1]);
                    bw.Write((Single)node.pos[2]);
                    bw.Write((Single)node.size[0]);
                    bw.Write((Single)node.size[1]);
                    bw.Write(Convert.FromHexString(node.unk));
                    bw.Write((Single)node.targetPos[0]);
                    bw.Write((Single)node.targetPos[1]);
                    bw.Write((Single)node.targetPos[2]);
                    bw.Write((UInt32)node.targetAngle);
                }
                bw.Write((UInt32)0xFFFFFFFF);
                bw.Write((Single)(-1.0));
                StringHelper.WriteZero(bw, 0x2C);
            }
            this.zonePtr = (UInt32)bw.BaseStream.Position;
            foreach (var zone in this.zoneData)
            {
                bw.Write((UInt32)zone.ptr);
            }

            // Mini Map Pos
            this.originsPtr = (UInt32)bw.BaseStream.Position;
            foreach(var org in this.miniMapData)
            {
                bw.Write((Single)org.pos[0]);
                bw.Write((Single)org.pos[1]);
                bw.Write((UInt32)org.unk1);
                bw.Write((UInt32)org.unk2);
                bw.Write((Single)org.unk3[0]);
                bw.Write((Single)org.unk3[1]);
                bw.Write((Single)org.unk3[2]);
                bw.Write((UInt32)org.unk4);
            }

            // Supplies
            this.supplyPtr = (UInt32)bw.BaseStream.Position;
            foreach(var supply in this.supplyData.supplies)
            {
                bw.Write((UInt16)supply.id);
                bw.Write((UInt16)supply.amount);
            }

            // Gather Stuff
            bw.Write(Convert.FromHexString("00002D00"));
            var dummyGatherData = (UInt32)bw.BaseStream.Position;
            bw.Write(Convert.FromHexString("1900FFFF4B008D00FFFF0000"));
            var dummyGatherPtr = (UInt32)bw.BaseStream.Position;
            bw.Write((UInt32)dummyGatherData);
            foreach(var group in this.gatherData)
            {
                if(group.Nodes.Count != 0)
                {
                    group.ptr = (UInt32)bw.BaseStream.Position;
                    foreach (var node in group.Nodes)
                    {
                        bw.Write((Single)node.pos[0]);
                        bw.Write((Single)node.pos[1]);
                        bw.Write((Single)node.pos[2]);
                        bw.Write((Single)node.size);
                        bw.Write((UInt16)node.gatherID);
                        bw.Write((UInt16)node.times);
                        bw.Write((UInt16)node.type);
                        bw.Write((UInt16)node.unk);
                    }
                    bw.Write((Single)(-1.0));
                    StringHelper.WriteZero(bw, 0x14);
                } else
                {
                    group.ptr = 0;
                }
            }
            this.gatherPtr = (UInt32)bw.BaseStream.Position;
            bw.Write((UInt32)dummyGatherPtr);
            bw.Write((UInt32)0);
            foreach (var group in this.gatherData)
            {
                bw.Write((UInt32)group.ptr);
            }

            // Uniques Stuff
            foreach (var group in this.uniquesData)
            {
                if (group.Nodes.Count != 0)
                {
                    group.ptr = (UInt32)bw.BaseStream.Position;
                    foreach (var node in group.Nodes)
                    {
                        bw.Write((UInt16)node.id);
                        bw.Write((UInt16)node.type);
                        bw.Write((Single)node.pos[0]);
                        bw.Write((Single)node.pos[1]);
                        bw.Write((Single)node.pos[2]);
                        bw.Write((Single)node.size);
                        bw.Write((UInt32)node.angle);
                    }
                    bw.Write((UInt32)0);
                    bw.Write((Single)(-1.0));
                    StringHelper.WriteZero(bw, 0x10);
                }
                else
                {
                    group.ptr = 0;
                }
            }
            this.uniquesPtr = (UInt32)bw.BaseStream.Position;
            foreach (var group in this.uniquesData)
            {
                bw.Write((UInt32)group.ptr);
            }

            // Reward Data
            foreach(var group in this.rewardData)
            {
                group.ptr = (UInt32)bw.BaseStream.Position;
                foreach (var item in group.rewards)
                {
                    bw.Write((UInt16)item.chance);
                    bw.Write((UInt16)item.id);
                    bw.Write((UInt16)item.amount);
                }
                bw.Write((UInt16)0xFFFF);
            }
            this.rewardPtr = (UInt32)bw.BaseStream.Position;
            foreach (var group in this.rewardData)
            {
                bw.Write((UInt32)group.type);
                bw.Write((UInt32)group.ptr);
            }
            bw.Write((UInt16)0xFFFF);
            StringHelper.WriteZero(bw, 0x6);

            // Actual Progress Strings
            List<uint> strPtrs = new List<uint>();
            foreach(var str in this.progressStr)
            {
                strPtrs.Add((UInt32)bw.BaseStream.Position);
                StringHelper.WriteAddNull(bw, str);
            }
            bw.BaseStream.Position = this.progStrPtr;
            foreach(var ptr in strPtrs)
            {
                bw.Write((UInt32)ptr);
            }

            // Write Header
            bw.BaseStream.Position = 0;
            bw.Write((UInt32)0x48);
            bw.Write((UInt32)this.startPtr);
            bw.Write((UInt32)this.supplyPtr);
            bw.Write((UInt32)this.rewardPtr);
            bw.Write((UInt32)this.scriptPtr);
            bw.Write((UInt32)this.sMonPtr);
            bw.Write((UInt32)this.lMonPtr);
            bw.Write((UInt32)this.zonePtr);
            bw.Write((UInt32)this.originsPtr);
            bw.Write((UInt32)this.campPtr);
            bw.Write((UInt32)this.gatherPtr);
            bw.Write((UInt32)this.uniquesPtr);
            bw.Write((UInt32)this.progStrPtr);
            bw.Write((UInt32)this.monsterHP);
            bw.Write((UInt32)this.hrp);
            bw.Write((UInt32)this.onlineFlag);

            bw.Write((UInt16)this.bossSize);
            bw.Write((byte)this.difficulty);
            bw.Write((byte)this.spawnID);

            bw.Write((byte)this.bossSizeClass);
            bw.Write((byte)this.supplyType);
            bw.Write((byte)this.supplyMon);
            bw.Write((byte)this.supplyNum);
        }
    }
}
