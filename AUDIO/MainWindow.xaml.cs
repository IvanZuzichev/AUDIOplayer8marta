using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AUDIO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog { IsFolderPicker = true};
            var result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                string[] mus = Directory.GetFiles(dialog.FileName);
                List<String> music = new List<String>();
                foreach (string x in mus)
                {
                    string mp = x[x.Length - 3].ToString() + x[x.Length - 2].ToString() + x[x.Length - 1].ToString();
                    if (mp == "mp3" || mp == "mp4" || mp == "wav")
                    {
                        music.Add(x);
                    }
                }
                listbox.Items.Clear();
                listbox.ItemsSource = music;
                media.Source = new Uri(music[0]);
                media.Play();
            }
        }
        private void list(object sender, SelectionChangedEventArgs e)
        {
            media.Source = new Uri(listbox.SelectedItem.ToString());
            media.Play();
            media.Volume = 0.9;

        }
        private void audioSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Position = new TimeSpan(Convert.ToInt64(audioSlider.Value));
        }
        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            audioSlider.Maximum = media.NaturalDuration.TimeSpan.Ticks;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pause.Content == "play")
            {
                media.Pause();
                pause.Content = "pause";
            }
            else
            {
                media.Play();
                pause.Content = "play";
            }
        }

        private void Daleko_Click(object sender, RoutedEventArgs e)
        {
            if (listbox.SelectedIndex == listbox.Items.Count - 1)
            {
                listbox.SelectedIndex = 0;
            }
            else if (listbox.SelectedIndex == -1)
            {
                listbox.SelectedIndex = 1;
            }
            else
            {
                listbox.SelectedIndex += 1;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (listbox.SelectedIndex == 0)
            {
                listbox.SelectedIndex = listbox.Items.Count - 1;
            }
            else if (listbox.SelectedIndex == -1)
            {
                listbox.SelectedIndex = listbox.Items.Count - 1;
            }
            else
            {
               listbox.SelectedIndex -= 1;
            }
        }
    }
}
