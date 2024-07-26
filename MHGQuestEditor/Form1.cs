using MHGQuestEditor.Quest;
using System.ComponentModel;
using System.Text;
using static MHGQuestEditor.Constants;

namespace MHGQuestEditor
{
    public partial class Form1 : Form
    {
        QuestFile quest;
        public Form1()
        {
            InitializeComponent();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "mib files (*.mib)|*.mib";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (BinaryReader br = new(openFileDialog.OpenFile(), Encoding.GetEncoding("shift-jis")))
                    {
                        // UI
                        // Locales
                        this.locale.Items.AddRange(LocaleNames);
                        this.locale.SelectedIndex = 0;
                        // Difficulties
                        this.difficulty.Items.AddRange(DifficultyNames);
                        this.difficulty.SelectedIndex = 0;
                        // Quest Types
                        this.questType.Items.AddRange(QuestTypes);
                        this.questType.SelectedIndex = 0;
                        // Supply Types
                        foreach (string types in SupplyTypes)
                        {
                            this.supplyType.Items.Add(types);
                        }
                        this.supplyType.SelectedIndex = 0;
                        // Monster Names
                        foreach (string monster in EntityNames)
                        {
                            this.supplyMon.Items.Add(monster);
                        }
                        this.supplyMon.SelectedIndex = 0;
                        // Item Names
                        this.supplyItemId.Items.AddRange(ItemNames);
                        this.rwdListCB.Items.AddRange(ItemNames);
                        this.supplyMon.SelectedIndex = 0;
                        // Reward Types
                        //this.rwdGroupCB.DataSource = new BindingSource(RewardTypeDict, null);
                        //this.rwTypeAdd.DisplayMember = "Value";
                        //this.rwTypeAdd.ValueMember = "Key";

                        // Load Quest
                        quest = new QuestFile(br);

                        this.questTitle.Text = quest.questData.title;
                        this.winCond.Text = quest.questData.win;
                        this.failCond.Text = quest.questData.fail;
                        this.description.Text = quest.questData.description;
                        this.difficulty.SelectedIndex = quest.difficulty;
                        this.bossSize.Value = quest.bossSize;
                        this.hrp.Value = quest.hrp;
                        this.locale.SelectedIndex = quest.questData.locale;
                        this.questType.SelectedIndex = quest.questData.type;
                        this.starLvl.Value = quest.questData.stars;
                        this.fee.Value = quest.questData.fee;
                        this.reward.Value = quest.questData.reward;
                        this.cart.Value = quest.questData.cartCost;
                        this.timeLmt.Value = quest.questData.timeLimit;
                        this.dataUnk.Text = quest.questData.unk.ToString();
                        this.id.Value = quest.questData.id;
                        this.qstCond.Text = quest.questData.conditions.ToString();
                        this.supplyType.SelectedIndex = quest.supplyType;
                        this.supplyMon.SelectedIndex = quest.supplyMon;
                        this.supplyQty.Value = quest.supplyNum;

                        // Supplies
                        this.supplyLB.DataSource = quest.supplyData.supplies;
                        this.rwdGroupLB.DataSource = quest.rewardData;

                        this.flag0.Checked = quest.questData.questFlags[0];
                        this.flag1.Checked = quest.questData.questFlags[1];
                        this.flag2.Checked = quest.questData.questFlags[2];
                        this.flag3.Checked = quest.questData.questFlags[3];
                        this.flag4.Checked = quest.questData.questFlags[4];
                        this.flag5.Checked = quest.questData.questFlags[5];
                        this.flag6.Checked = quest.questData.questFlags[6];
                        this.flag7.Checked = quest.questData.questFlags[7];

                        /*supplyGrid.AutoGenerateColumns = false;

                        var supplyList = new BindingList<SupplyItem>(quest.supplyData.supplies);
                        this.supplyGrid.DataSource = new BindingSource(supplyList,null);
                        // Define and add the columns
                        this.supplyItem.DataPropertyName = "id";

                        this.itemQtySup.DataPropertyName = "amount";*/
                        //this.supplyGrid.Refresh();
                        //this.supplyGrid.Columns[0].DataPropertyName = "chance";
                        /*
                        foreach (var item in quest.supplyData.supplies)
                        {
                            var index = this.supplyGrid.Rows.Add();
                            var itemcell = (DataGridViewComboBoxCell)this.supplyGrid.Rows[index].Cells[0];
                            if (item.id < itemcell.Items.Count)
                            {
                                itemcell.Value = itemcell.Items[item.id];
                            }
                            //this.supplyGrid.Rows[index].Cells[0].Value = item.id;
                            this.supplyGrid.Rows[index].Cells[1].Value = item.amount;
                        }*/
                        /*
                        // Rewards
                        this.rewardCB.DataSource = new BindingSource(RewardTypeDict, null);
                        this.rewardCB.ValueMember = "Key";
                        this.rewardCB.DisplayMember = "Value";
                        this.rewardCB.Enabled = true;

                        this.rewardNud.Value = 1;
                        this.rewardNud.Value = 0;

                        this.rewardGrid.AutoGenerateColumns = false;

                        this.rewardGrid.DataSource = quest.rewardData[0].rewards;

                        this.rewardItem.ValueType = typeof(UInt16);
                        this.rewardItem.DataPropertyName = "id";

                        this.rewardChance.ValueType = typeof(UInt16);
                        this.rewardChance.DataPropertyName = "chance";

                        this.rewardGrid.Refresh();*/

                        //this.rewardCB.SelectedItem = 0x8000;
                        //rewardTypes.DataSource = quest.rewardData.groups;
                        //rewardTypes.DisplayMember = "type";
                        /*foreach (var block in quest.rewardData.groups)
                        {
                            rewardTypes.Items.Add(block.type);
                        }*/
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void timeLmt_ValueChanged(object sender, EventArgs e)
        {
            this.timeMins.Text = $"{(UInt32)(this.timeLmt.Value / 1800)} mins.";
        }
        /*
        private void rewardNud_ValueChanged(object sender, EventArgs e)
        {
            int newVal = ((int)this.rewardNud.Value);
            // If the value is higher than current reward groups, add a new one
            if (newVal >= quest.rewardData.Count())
            {
                while (true)
                {
                    quest.rewardData.Add(new RewardData(0x0));
                    if (newVal < quest.rewardData.Count()) { break; }
                }
            }
            // Proceed with selecting the group's data
            var selVal = quest.rewardData[newVal].type;
            if (RewardTypeDict.ContainsKey(selVal))
            {
                this.rewardCB.SelectedValue = selVal;

                this.rewardGrid.DataSource = quest.rewardData[newVal].rewards;
            }
        }

        private void rewardCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nudVal = ((int)this.rewardNud.Value);

            // Item list control
            if (this.rewardCB.SelectedIndex == 0)
            {
                this.rewardGrid.Enabled = false;
            }
            else
            {
                this.rewardGrid.Enabled = true;
            }

            // If it's not the first entry (Self-imposed limit)
            if (nudVal != 0)
            {
                if (this.rewardCB.SelectedItem != null)
                {
                    // Set reward to selected type
                    var pair = (KeyValuePair<int, string>)this.rewardCB.SelectedItem;
                    quest.rewardData[nudVal].type = pair.Key;
                }
            }
        }*/

        private void supplyLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.supplyLB.SelectedItem != null)
            {
                var val = (SupplyItem)this.supplyLB.SelectedItem;
                this.supplyItemId.SelectedIndex = val.id;
                this.supplyItemAmount.Value = val.amount;
            }
        }

        private void supplyItemId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.supplyLB.SelectedItem != null)
            {
                var val = (SupplyItem)this.supplyLB.SelectedItem;
                val.id = (ushort)this.supplyItemId.SelectedIndex;
                this.supplyLB.Refresh();
            }
        }

        private void supplyItemAmount_ValueChanged(object sender, EventArgs e)
        {
            if (this.supplyLB.SelectedItem != null)
            {
                var val = (SupplyItem)this.supplyLB.SelectedItem;
                val.amount = (ushort)this.supplyItemAmount.Value;
            }
        }

        private void rwdGroupLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rwdGroupLB.SelectedItem != null)
            {
                var val = (RewardData)this.rwdGroupLB.SelectedItem;
                this.rwdGroupType.Value = val.type;
                this.rwdGroupName.Text = RewardTypeDict[val.type];
                this.rwdListLB.DataSource = quest.rewardData[this.rwdGroupLB.SelectedIndex].rewards;
            }
        }

        private void rwdListLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rwdListLB.SelectedItem != null)
            {
                var val = (RewardItem)this.rwdListLB.SelectedItem;
                this.rwdListCB.SelectedIndex = val.id;
                this.rwdListChance.Value = val.chance;
                this.rwdListQty.Value = val.amount;
            }
        }

        private void rwdGroupType_ValueChanged(object sender, EventArgs e)
        {
            if (this.rwdGroupLB.SelectedItem != null)
            {
                var val = (RewardData)this.rwdGroupLB.SelectedItem;
                val.type = (ushort)this.rwdGroupType.Value;
                this.rwdGroupName.Text = val.ToString();
            }
        }

        private void rwdListCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rwdListLB.SelectedItem != null)
            {
                var val = (RewardItem)this.rwdListLB.SelectedItem;
                val.id = (ushort)this.rwdListCB.SelectedIndex;
            }
        }

        private void rwdListQty_ValueChanged(object sender, EventArgs e)
        {
            if (this.rwdListLB.SelectedItem != null)
            {
                var val = (RewardItem)this.rwdListLB.SelectedItem;
                val.amount = (ushort)this.rwdListQty.Value;
            }
        }

        private void rwdListChance_ValueChanged(object sender, EventArgs e)
        {
            if (this.rwdListLB.SelectedItem != null)
            {
                var val = (RewardItem)this.rwdListLB.SelectedItem;
                val.chance = (ushort)this.rwdListChance.Value;
            }
        }

        /*private void rewardTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.rewardGrid.Rows.Clear();
            foreach (var item in quest.rewardData.groups[this.rewardTypes.SelectedIndex].rewards)
            {
                var index = this.rewardGrid.Rows.Add();
                var itemcell = (DataGridViewComboBoxCell)this.rewardGrid.Rows[index].Cells[1];
                if (item.id < itemcell.Items.Count)
                {
                    itemcell.Value = itemcell.Items[item.id];
                }
                this.rewardGrid.Rows[index].Cells[0].Value = item.chance;
                this.rewardGrid.Rows[index].Cells[2].Value = item.amount;
            }
        }

        private void rewTypeRemove_Click(object sender, EventArgs e)
        {
            var selectedGroup = this.rewardTypes.SelectedItem as RewardGroup;
            if (selectedGroup.type != 0x8000 || this.rewardTypes.Items.Count > 1)
            {
                quest.rewardData.groups.Remove(selectedGroup);
                this.rewardTypes.Refresh();
            }
        }*/
    }
}
