using System;
using System.ComponentModel;
using System.IO;
using System.Globalization;
using System.Threading;
using Memory;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Net;
using AutoUpdaterDotNET;
using FFTrainer.Util;

namespace FFTrainer.ViewModels
{
    public class MainViewModel
    {
        private Mediator mediator;

        private BackgroundWorker worker;
        public Mem MemLib = new Mem();
        private CharacterDetailsViewModel characterDetails;
        public CharacterDetailsViewModel CharacterDetails { get => characterDetails; set => characterDetails = value; }

        public MainViewModel()
        {
            // open the process to FFXIV
            try
            {
                mediator = new Mediator();
                int gameProcId = MemLib.getProcIDFromName("ffxiv_dx11");
                MemoryManager.Instance.MemLib.OpenProcess(gameProcId);
                if (gameProcId <= 0) throw new ArgumentException("You must have ffxiv_dx11.exe running first before running this application!");
                ServicePointManager.SecurityProtocol = (ServicePointManager.SecurityProtocol & SecurityProtocolType.Ssl3) | (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
                AutoUpdater.RunUpdateAsAdmin = true;
                AutoUpdater.DownloadPath = Environment.CurrentDirectory;
                AutoUpdater.Start("https://raw.githubusercontent.com/SaberNaut/xd/master/Updates.xml");
                // initialize a background worker
                // load the settings
                var path = Path.Combine(Directory.GetCurrentDirectory(), "FFXIVTrainer.zip");
                var path2 = Path.Combine(Directory.GetCurrentDirectory(), "ZipExtractor.exe");
                if (File.Exists(path)) File.Delete(path);
                if (File.Exists(path2)) File.Delete(path2);
                LoadSettings();
                worker = new BackgroundWorker();
                worker.DoWork += Worker_DoWork;
                // run the worker
                worker.RunWorkerAsync();
                characterDetails = new CharacterDetailsViewModel(mediator);
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Oh no!");
            }
        }
        private void LoadSettings()
        {
            // create an xml serializer
            var serializer = new XmlSerializer(typeof(Settings), "");
            // create namespace to remove it for the serializer
            var ns = new XmlSerializerNamespaces();
            // add blank namespaces
            ns.Add("", "");
            // string xmlData = Properties.Resources.Settings;
            var document = XDocument.Load(@"https://raw.githubusercontent.com/SaberNaut/xd/master/Settingsxd.xml");
            // using a stream reader
            using (StringReader reader = new StringReader(document.ToString()))
            {
                try
                {
                    Settings.Instance = (Settings)serializer.Deserialize(reader);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // no fancy tricks here boi
            MemoryManager.Instance.BaseAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.AoBOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.CameraAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.CameraOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.EmoteAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.GposeEmoteOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.GposeAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.GposeOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.TimeAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.TimeOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.WeatherAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.WeatherOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.TerritoryAddress = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.TerritoryOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.HousingOffset = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.HousingOffset, NumberStyles.HexNumber));
            MemoryManager.Instance.GposeFilters = MemoryManager.Instance.GetBaseAddress(int.Parse(Settings.Instance.GposeFilters, NumberStyles.HexNumber));
            while (true)
            {
                // sleep for 500 ms
                Thread.Sleep(Properties.Settings.Default.Read);
                // check if our memory manager is set /saving
                if (!MainWindow.CurrentlySaving) mediator.SendWork();
            }
        }
    }
}