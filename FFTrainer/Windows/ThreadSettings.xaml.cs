using System.Windows;

namespace FFTrainer.Windows
{
    /// <summary>
    /// Interaction logic for ThreadSettings.xaml
    /// </summary>
    public partial class ThreadSettings : Window
    {
        public ThreadSettings()
        {
            InitializeComponent();
            WriteText.Value = Properties.Settings.Default.Write;
            ReadText.Value = Properties.Settings.Default.Read;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Write = (int)WriteText.Value;
            Properties.Settings.Default.Read = (int)ReadText.Value;
            Properties.Settings.Default.Save();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Write = 10;
            Properties.Settings.Default.Read = 500;
            Properties.Settings.Default.Save();
            WriteText.Value = 10;
            ReadText.Value = 500;
        }
    }
}
