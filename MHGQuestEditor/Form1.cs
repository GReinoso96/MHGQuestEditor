using MHGQuestEditor.Quest;
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
                        foreach (string locale in LocaleNames)
                        {
                            this.locale.Items.Add(locale);
                        }
                        this.locale.SelectedIndex = 0;
                        // Difficulties
                        foreach (string difficulty in DifficultyNames)
                        {
                            this.difficulty.Items.Add(difficulty);
                        }
                        this.difficulty.SelectedIndex = 0;
                        // Quest Types
                        foreach (string types in QuestTypes)
                        {
                            this.questType.Items.Add(types);
                        }
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
                        this.itemNameSup.Items.AddRange(ItemNames);
                        //this.rewardItem.Items.AddRange(ItemNames);
                        this.supplyMon.SelectedIndex = 0;
                        // Reward Types
                        //this.rwTypeAdd.DataSource = new BindingSource(RewardTypeDict, null);
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
                        this.questFlags.Text = quest.questData.questFlags.ToString();
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
                        }

                        // Rewards
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
