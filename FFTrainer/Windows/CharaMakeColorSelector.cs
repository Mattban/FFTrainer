using FFTrainer.Util;
using System;
using System.Windows.Forms;

namespace FFTrainer.Windows
{
    public partial class CharaMakeColorSelector : Form
    {
        private int _startIndex;

        public int Choice = -1;

        public CharaMakeColorSelector(CmpReader colorMap, int start, int length, int selection)
        {
            InitializeComponent();

            for (int i = start; i < start + length; i++)
            {
                var item = new ListViewItem((i - start).ToString());
                item.BackColor = colorMap.Colors[i];

                colorListView.Items.Add(item);
            }

            _startIndex = start;

            colorListView.SelectedIndices.Add(selection);
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            if (colorListView.SelectedIndices.Count == 0)
            {
                MessageBox.Show("No selected color!");
                return;
            }

            Choice = colorListView.SelectedIndices[0];
            Close();
        }
    }
}
