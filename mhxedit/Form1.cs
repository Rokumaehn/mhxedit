using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mhxedit
{
    public partial class Form1 : Form
    {
        MonHunSave _save = null;
        MonHunCharacter selSlot = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                _save = new MonHunSave(openFileDialog1.FileName);

                // GUI
                toolStripComboBox1.Enabled = true;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selSlot = _save.slots[toolStripComboBox1.SelectedIndex];

            textBoxName.Text = selSlot.name;
            textBoxPlayTime.Text = selSlot.playTime.ToString();
            textBoxZenny.Text = selSlot.zenny.ToString();
            textBoxRank.Text = selSlot.hr.ToString();

            textBoxRankPoints.Text = selSlot.hrPoints.ToString();
            textBoxAcademyPoints.Text = selSlot.academyPoints.ToString();
            textBoxBerunaPoints.Text = selSlot.berunaPoints.ToString();
            textBoxKokotoPoints.Text = selSlot.kokotoPoints.ToString();
            textBoxPokkePoints.Text = selSlot.pokkePoints.ToString();
            textBoxYukumoPoints.Text = selSlot.yukumoPoints.ToString();

            monHunItemBindingSource.Clear();
            foreach (var item in selSlot.itemBox)
            {
                monHunItemBindingSource.Add(item);
            }

            monHunEquipBindingSource.Clear();
            foreach (var item in selSlot.equipBox)
            {
                monHunEquipBindingSource.Add(item);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _save.Save(openFileDialog1.FileName);
            
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            selSlot = _save.slots[toolStripComboBox1.SelectedIndex];
            selSlot.name = textBoxName.Text;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && ((e.Context & DataGridViewDataErrorContexts.Commit) == DataGridViewDataErrorContexts.Commit))
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        MessageBox.Show("ID has to be an integer value between 0 and 32767");
                        break;
                    case 1:
                        MessageBox.Show("Count has to be an integer value between 0 and 99");
                        break;
                    default:
                        break;
                }
                
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            listBoxSearchResults.Items.Clear();
            string search = textBoxSearch.Text.ToLower();
            for (uint i=0; i < MonHunItem.names.Length; i++)
            {
                var item = MonHunItem.names[i];

                if (item.ToLower().Contains(search))
                {
                    listBoxSearchResults.Items.Add(new KeyValuePair<string, uint>(item, i));
                }
            }
        }

        private void buttonSearchOverwrite_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedCells.Count == 0 || listBoxSearchResults.SelectedItem == null)
            {
                return;
            }

            var item = (MonHunItem)(dataGridView1.SelectedCells[0].OwningRow.DataBoundItem);
            item.Count = (uint)(numericUpDown1.Value);
            item.ID = ((KeyValuePair<string, uint>)(listBoxSearchResults.SelectedItem)).Value;
            dataGridView1.InvalidateRow(dataGridView1.SelectedCells[0].OwningRow.Index);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        private void buttonSetSelMax_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0 || listBoxSearchResults.SelectedItem == null)
            {
                return;
            }

            var item = (MonHunItem)(dataGridView1.SelectedCells[0].OwningRow.DataBoundItem);
            item.Count = (uint)(99);
            dataGridView1.InvalidateRow(dataGridView1.SelectedCells[0].OwningRow.Index);
        }

        private void buttonSetAllMax_Click(object sender, EventArgs e)
        {
            foreach (var item in selSlot.itemBox)
            {
                if(item.ID!=0) item.Count = (uint)(99);
            }
            dataGridView1.EndEdit();
            dataGridView1.Refresh();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int start = dataGridView1.SelectedCells[0].OwningRow.Index;
            int end = start + (int)(numLoopCount.Value);
            uint amount = (uint)(numItemAmount.Value);
            uint id = (uint)(numStartID.Value);
            bool bSkipDummy = checkBoxFillSkipDummy.Checked;

            int index = start;
            for (; start < end;start++, id++)
            {
                if (MonHunItem.names[id] == "<No Item>")
                    continue;
                selSlot.itemBox[index].ID = id;
                selSlot.itemBox[index].Count = amount;

                index++;
            }

            dataGridView1.EndEdit();
            dataGridView1.Refresh();
        }

        private void checkBoxFillSkipDummy_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void monHunEquipDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                var dgv = monHunEquipDataGridView;
                if ((dgv.DataSource as BindingSource).List.Count < e.RowIndex + 1) return;
                var obj = (dgv.DataSource as BindingSource).List[e.RowIndex] as MonHunEquip;

                UpdateSelectedEquip(obj);
            }
        }

        bool _equipSelectionUpdating = false;
        MonHunEquip _selEquip = null;


        public void UpdateSelectedEquip(MonHunEquip obj)
        {
            _equipSelectionUpdating = true;

            comboBoxEquipType.DataSource = null;
            comboBoxEquipID.DataSource = null;

            _selEquip = obj;

            comboBoxEquipType.DataSource = obj.TypeAvailable;
            comboBoxEquipType.SelectedItem = obj.Type;

            comboBoxEquipID.DataSource = obj.IDAvailable;
            comboBoxEquipID.SelectedItem = obj.ID;

            numEquipLevel.Value = obj.Level;

            numSlots.Value = obj.Slots;

            if (_selEquip is MonHunTalisman)
            {
                MonHunTalisman tal = _selEquip as MonHunTalisman;

                comboBoxSkillFirst.DataSource = MonHunTalisman.dictSkills.Values.ToArray();
                if (tal.SkillFirstKnown()) comboBoxSkillFirst.SelectedItem = tal.SkillFirst;
                else comboBoxSkillFirst.Text = tal.SkillFirst;

                comboBoxSkillSecond.BindingContext = new BindingContext();
                comboBoxSkillSecond.DataSource = MonHunTalisman.dictSkills.Values.ToArray();
                if (tal.SkillSecondKnown()) comboBoxSkillSecond.SelectedItem = tal.SkillSecond;
                else comboBoxSkillSecond.Text = tal.SkillSecond;

                textBoxSkillFirstValue.Text = tal.SkillFirstValue;
                textBoxSkillSecondValue.Text = tal.SkillSecondValue;

                textBoxTalRes1.Text = tal.UnkTal1;
                textBoxTalRes2.Text = tal.UnkTal2;
            }
            else
            {
                comboBoxSkillFirst.SelectedItem = null;
                comboBoxSkillFirst.DataSource = null;
                comboBoxSkillSecond.SelectedItem = null;
                comboBoxSkillSecond.DataSource = null;
                textBoxSkillFirstValue.Text = string.Empty;
                textBoxSkillSecondValue.Text = string.Empty;
                textBoxTalRes1.Text = string.Empty;
                textBoxTalRes2.Text = string.Empty;
            }

            _equipSelectionUpdating = false;
        }

        private void comboBoxEquipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_equipSelectionUpdating) return;

            _selEquip.Type = comboBoxEquipType.SelectedItem.ToString();
            _selEquip = selSlot.ReloadEquip(monHunEquipDataGridView.SelectedRows[0].Index);
            monHunEquipBindingSource[monHunEquipDataGridView.SelectedRows[0].Index] = _selEquip;
            UpdateSelectedEquip(_selEquip);

            monHunEquipDataGridView.InvalidateRow( monHunEquipDataGridView.CurrentRow.Index );
        }

        private void comboBoxEquipID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_equipSelectionUpdating) return;

            _selEquip.ID = comboBoxEquipID.SelectedItem.ToString();

            monHunEquipDataGridView.InvalidateRow(monHunEquipDataGridView.CurrentRow.Index);
        }

        private void numEquipLevel_ValueChanged(object sender, EventArgs e)
        {
            if (_equipSelectionUpdating) return;

            _selEquip.Level = (byte)(numEquipLevel.Value);

            monHunEquipDataGridView.InvalidateRow(monHunEquipDataGridView.CurrentRow.Index);
        }

        private void monHunEquipDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in monHunEquipDataGridView.Rows)
            {
                row.HeaderCell.Value = row.Index.ToString("D4");
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = row.Index.ToString("D4");
            }
        }

        private void comboBoxSkillFirst_TextUpdate(object sender, EventArgs e)
        {

        }

        private void comboBoxSkillFirst_TextChanged(object sender, EventArgs e)
        {
            if (_equipSelectionUpdating) return;

            if (_selEquip is MonHunTalisman)
            {
                var obj = _selEquip as MonHunTalisman;

                obj.SkillFirst = comboBoxSkillFirst.Text;

                monHunEquipDataGridView.InvalidateRow(monHunEquipDataGridView.CurrentRow.Index);
            }
        }

        private void comboBoxSkillSecond_TextChanged(object sender, EventArgs e)
        {
            if (_equipSelectionUpdating) return;

            if (_selEquip is MonHunTalisman)
            {
                var obj = _selEquip as MonHunTalisman;

                obj.SkillSecond = comboBoxSkillSecond.Text;

                monHunEquipDataGridView.InvalidateRow(monHunEquipDataGridView.CurrentRow.Index);
            }
        }

        private void textBoxSkillFirstValue_TextChanged(object sender, EventArgs e)
        {
            if (_equipSelectionUpdating) return;

            if (_selEquip is MonHunTalisman)
            {
                var obj = _selEquip as MonHunTalisman;
                obj.SkillFirstValue = textBoxSkillFirstValue.Text;
            }
        }

        private void textBoxSkillSecondValue_TextChanged(object sender, EventArgs e)
        {
            if (_equipSelectionUpdating) return;

            if (_selEquip is MonHunTalisman)
            {
                var obj = _selEquip as MonHunTalisman;
                obj.SkillSecondValue = textBoxSkillSecondValue.Text;
            }
        }

        private void numSlots_ValueChanged(object sender, EventArgs e)
        {
            if (_equipSelectionUpdating) return;

            _selEquip.Slots = (byte)(numSlots.Value);

            monHunEquipDataGridView.InvalidateRow(monHunEquipDataGridView.CurrentRow.Index);
        }

        private void textBoxTalRes1_TextChanged(object sender, EventArgs e)
        {
            if (_equipSelectionUpdating) return;

            if (_selEquip is MonHunTalisman)
            {
                var obj = _selEquip as MonHunTalisman;
                obj.UnkTal1 = textBoxTalRes1.Text;
            }
        }

        private void textBoxTalRes2_TextChanged(object sender, EventArgs e)
        {
            if (_equipSelectionUpdating) return;

            if (_selEquip is MonHunTalisman)
            {
                var obj = _selEquip as MonHunTalisman;
                obj.UnkTal1 = textBoxTalRes2.Text;
            }
        }

        private void textBoxZenny_TextChanged(object sender, EventArgs e)
        {
            uint val = 0;
            if(uint.TryParse(textBoxZenny.Text, out val))
            {
                selSlot.zenny = val;
            }
        }

        private void textBoxRank_TextChanged(object sender, EventArgs e)
        {
            ushort val = 0;
            if (ushort.TryParse(textBoxRank.Text, out val))
            {
                selSlot.hr = val;
            }
        }

        private void textBoxRankPoints_TextChanged(object sender, EventArgs e)
        {
            uint val = 0;
            if (uint.TryParse(textBoxRankPoints.Text, out val))
            {
                selSlot.hrPoints = val;
            }
        }

        private void textBoxAcademyPoints_TextChanged(object sender, EventArgs e)
        {
            uint val = 0;
            if (uint.TryParse(textBoxAcademyPoints.Text, out val))
            {
                selSlot.academyPoints = val;
            }
        }

        private void textBoxBerunaPoints_TextChanged(object sender, EventArgs e)
        {
            uint val = 0;
            if (uint.TryParse(textBoxBerunaPoints.Text, out val))
            {
                selSlot.berunaPoints = val;
            }
        }

        private void textBoxKokotoPoints_TextChanged(object sender, EventArgs e)
        {
            uint val = 0;
            if (uint.TryParse(textBoxKokotoPoints.Text, out val))
            {
                selSlot.kokotoPoints = val;
            }
        }

        private void textBoxPokkePoints_TextChanged(object sender, EventArgs e)
        {
            uint val = 0;
            if (uint.TryParse(textBoxPokkePoints.Text, out val))
            {
                selSlot.pokkePoints = val;
            }
        }

        private void textBoxYukumoPoints_TextChanged(object sender, EventArgs e)
        {
            uint val = 0;
            if (uint.TryParse(textBoxYukumoPoints.Text, out val))
            {
                selSlot.yukumoPoints = val;
            }
        }
    }


}
