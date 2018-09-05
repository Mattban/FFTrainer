using FFTrainer.Util;
using System.Collections.Generic;
using System.Windows;

namespace FFTrainer.Windows
{
    /// <summary>
    /// Interaction logic for WeatherSelector.xaml
    /// </summary>
    public partial class WeatherSelector : Window
    {
        public ExdCsvReader.Weather Choice = null;

        private readonly List<ExdCsvReader.Weather> AllowedWeathers;
        // var c = new WeatherSelector(_exdProvider.TerritoryTypes[territory].WeatherRate.AllowedWeathers, 
        //MemoryManager.Instance.MemLib.readByte(MemoryManager.GetAddressString(MemoryManager.Instance.WeatherAddress, Settings.Instance.Character.Weather)));
        public WeatherSelector(List<ExdCsvReader.Weather> allowedWeathers, int currentWeather)
        {
            InitializeComponent();

            AllowedWeathers = allowedWeathers;

            for (int i = 0; i < allowedWeathers.Count; i++)
            {
                comboBox.Items.Add(allowedWeathers[i].Name);

                if (allowedWeathers[i].Index == currentWeather)
                    comboBox.SelectedIndex = i;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Choice = AllowedWeathers[comboBox.SelectedIndex];
            Close();
        }
    }
}
