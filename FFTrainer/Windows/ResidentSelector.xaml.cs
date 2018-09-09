using FFTrainer.Util;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FFTrainer.Windows
{
    /// <summary>
    /// Interaction logic for ResidentSelector.xaml
    /// </summary>
    public partial class ResidentSelector : Window
    {
        private ExdCsvReader.Resident[] _residents;
        public ExdCsvReader.Resident Choice = null;

        public ResidentSelector(ExdCsvReader.Resident[] residents)
        {
            InitializeComponent();
            _residents = residents;
            foreach (ExdCsvReader.Resident resident in _residents) residentlist.Items.Add(resident);


            _residents = residents;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (residentlist.SelectedItem == null)
                Close();
            Choice = residentlist.SelectedItem as ExdCsvReader.Resident;
            Close();
        }

        private void textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = textbox.Text.ToLower();
            residentlist.Items.Clear();
            foreach (ExdCsvReader.Resident resident in _residents.Where(g => g.Name.ToLower().Contains(filter))) residentlist.Items.Add(resident);
        }
    }
}
