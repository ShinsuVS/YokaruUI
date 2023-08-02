using System;
using System.Collections.Generic;
using System.ComponentModel;
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


namespace YokaruUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public bool stwsd = true;
        private double _volume;
        private bool mouseCaptured = false;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        //public double Volume
        //{
        //    get { return _volume; }
        //    set
        //    {
        //        _volume = value;
        //        OnPropertyChanged("Volume");
        //    }
        //}



        //private void MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (Mouse.LeftButton == MouseButtonState.Pressed && mouseCaptured)
        //    {
        //        var x = e.GetPosition(volumeBar).X;
        //        var ratio = x / volumeBar.ActualWidth;
        //        Volume = ratio * volumeBar.Maximum;
        //    }
        //}

        //private void MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    mouseCaptured = true;
        //    var x = e.GetPosition(volumeBar).X;
        //    var ratio = x / volumeBar.ActualWidth;
        //    Volume = ratio * volumeBar.Maximum;
        //}

        //private void MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    mouseCaptured = false;
        //}

        //#region Property Changed

        //public event PropertyChangedEventHandler PropertyChanged;

        //private void OnPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //}

        //#endregion

        private void dragMe(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {
                //trow
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            // PagesNavigation.Navigate(new HomePage());

            PagesNavigation.Navigate(new System.Uri("View/Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdSounds_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("View/Pages/SoundsPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdNotes_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("View/Pages/NotesPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdPayment_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("View/Pages/PaymentPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Auth_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("View/Pages/AuthPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnPlayPause_Click(object sender, RoutedEventArgs e)
        {
            if (stwsd == true)
            {

                btnPlayPause.Content = FindResource("Play");

                //btnPlayPause.Style = Style.Resources.FindName("IconButtonsMusicStyle");    //FindResource("IconButtonsMusicStyle");
                stwsd = false;

            }
            else
            {
                btnPlayPause.Content = FindResource("Pause");


                stwsd = true;
            }


        }

        private void rdUsersMusic_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rdSettings_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("View/Pages/SettingsPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdApplicationInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            if(Registration.Content == "Регистрация"){
                var destinationurl = "https://passport.yandex.ru/auth/reg?origin=music_button-header&retpath=https%3A%2F%2Fmusic.yandex.ru%2Fsettings%3Freqid%3D681003997166846339441180892017690396%26from-passport";
                var sInfo = new System.Diagnostics.ProcessStartInfo(destinationurl) { UseShellExecute = true, };
                System.Diagnostics.Process.Start(sInfo);
            }
            if(Registration.Content == "Выйти")
            {
                
            }
           

        }

        private void VolumeControl_Click(object sender, RoutedEventArgs e)
        {
            pVolume.IsOpen= true;
        }

        private void home_ContentRendered(object sender, EventArgs e)
        {

        }

        private void imgs_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("View/Pages/AuthPage.xaml", UriKind.RelativeOrAbsolute));
        }
        public void changeImgs( string Url)
        {
           
            Uri _Url = new Uri("https://avatars.yandex.net/get-yapic/" + Url + "/islands-middle");
            imgs.ImageSource = new BitmapImage(_Url);

        }

        public void ChangeUser(string display_name)
        {
            Auth.Content = display_name;
            Registration.Content = "Выйти";
        }
    }
}
