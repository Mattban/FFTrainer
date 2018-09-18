﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FFXIVTool.Views
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    public partial class AboutView : UserControl
    {
        public AboutView()
        {
            InitializeComponent();
        }
        private void GitHubButton_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/SaberNaut/FFTrainer");
        }
        private void DonateButton_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("https://ko-fi.com/seibanaut");
        }

        private void ChatButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://discord.gg/nxu2Ydp");
        }
    }
}
