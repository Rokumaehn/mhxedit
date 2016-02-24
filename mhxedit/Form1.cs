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


            monHunItemBindingSource.Clear();
            foreach (var item in selSlot.itemBox)
            {
                monHunItemBindingSource.Add(item);
            }

            monHunEquipBindingSource.Clear();
            foreach (var item in selSlot.equipBox)
            {
                monHunEquipBindingSource.Add(item);

                /*
                DataGridViewRow row = new DataGridViewRow();

                var type = new DataGridViewTextBoxCell();
                var id = new DataGridViewComboBoxCell();
                var level = new DataGridViewTextBoxCell();

                type.Value = item.Type;
                level.Value = item.Level;
                id.DataSource = MonHunEquip.allGreatsword;

                row.Cells.Add(type);
                row.Cells.Add(id);
                row.Cells.Add(level);

                monHunEquipDataGridView.Rows.Add(row);

                break;
                */
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
                var obj = (dgv.DataSource as BindingSource).List[e.RowIndex] as MonHunEquip;

                _equipSelectionUpdating = true;

                _selEquip = obj;

                comboBoxEquipType.DataSource = obj.TypeAvailable;
                comboBoxEquipType.SelectedItem = obj.Type;

                comboBoxEquipID.DataSource = obj.IDAvailable;
                comboBoxEquipID.SelectedItem = obj.ID;

                _equipSelectionUpdating = false;
            }
        }

        bool _equipSelectionUpdating = false;
        MonHunEquip _selEquip = null;

        private void comboBoxEquipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_equipSelectionUpdating) return;

            _selEquip.Type = comboBoxEquipType.SelectedItem.ToString();
            comboBoxEquipID.DataSource = _selEquip.IDAvailable;
            comboBoxEquipID.SelectedItem = _selEquip.ID;

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

        
    }


}
