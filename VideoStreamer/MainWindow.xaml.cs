using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows;

namespace VideoStreamer
{
    public partial class MainWindow : Window
    {
        private readonly DirectoryInfo vlcLibDirectory;
        public MainWindow()
        {
            InitializeComponent();

            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            vlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            var options = new string[]
            {
                ":network-caching=200",
            };

            this.StreamControl.SourceProvider.CreatePlayer(vlcLibDirectory);
            
            //RTSP link here depend on the IP of Camera used
            //tbURL.Text = "rtsp://IP Camera address:8557/h264";

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.StreamControl?.Dispose();
            base.OnClosing(e);
        }

        private void OnPlayButtonClick(object sender, RoutedEventArgs e)
        {
            this.StreamControl.SourceProvider.CreatePlayer(vlcLibDirectory);


            try
            {
                this.StreamControl.SourceProvider.MediaPlayer.Play(new Uri(tbURL.Text));
            }
            catch
            {
                MessageBox.Show("Url can't be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnStopButtonClick(object sender, RoutedEventArgs e)
        {
            this.StreamControl?.Dispose();
            this.StreamControl = null;
            tbURL.Text = "Enter Url";
        }

        private void OnSpeedButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.StreamControl == null)
            {
                MessageBox.Show("Media player is not initialized!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(speedBtn.IsChecked == true)
            {
                this.StreamControl.SourceProvider.MediaPlayer.Rate = 2;
                speedBtn.Content = "Speed (x2)";
            }
            else
            {
                this.StreamControl.SourceProvider.MediaPlayer.Rate = 1;
                speedBtn.Content = "Speed (Normal)";
            }
           
        }

        private void GetLength_Click(object sender, RoutedEventArgs e)
        {
            if (this.StreamControl == null)
            {
                MessageBox.Show("Media player is not initialized!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            GetLength.Content = this.StreamControl.SourceProvider.MediaPlayer.Length + " ms";
        }

        private void GetCurrentTime_Click(object sender, RoutedEventArgs e)
        {
            if (this.StreamControl == null)
            {
                MessageBox.Show("Media player is not initialized!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            GetCurrentTime.Content = this.StreamControl.SourceProvider.MediaPlayer.Time + " ms";
            
        }

        
    }
}