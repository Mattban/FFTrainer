using FFTrainer.Util;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FFTrainer.Windows
{
    /// <summary>
    /// Interaction logic for MonsterWindow.xaml
    /// </summary>
    public partial class MonsterWindow : Window
    {
        private ExdCsvReader.Monster[] _monsters;
        public int Choice = 0;
        public bool Dontbother = false;
        public class MobsxD
        {
            public int Index { get; set; }
            public bool Real { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }
        public MonsterWindow(ExdCsvReader.Monster[] monsters)
        {
            InitializeComponent();
            _monsters = monsters;

            foreach (ExdCsvReader.Monster xD in _monsters)
            {
                if (xD.Real == true)
                {
                    monsterlist.Items.Add(new MobsxD
                    {
                        Index = Convert.ToInt32(xD.Index),
                        Name = xD.Name.ToString()
                    });
                }
            }
        }

        private void textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = textbox.Text.ToLower();
            monsterlist.Items.Clear();
            foreach (ExdCsvReader.Monster xD in _monsters.Where(g => g.Name.ToLower().Contains(filter)))
                if (xD.Real == true)
                {
                    monsterlist.Items.Add(new MobsxD
                    {
                        Index = Convert.ToInt32(xD.Index),
                        Name = xD.Name.ToString()
                    });
                }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (monsterlist.SelectedItem == null)
                Close();

            Dontbother = true;
            var Value = (MobsxD)monsterlist.SelectedItem;

            Choice = (int)Value.Index;
            Close();
        }
    }
}
