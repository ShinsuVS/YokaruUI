using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
        }
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
            if(stwsd == true)
            {
                btnPlayPause.Content = FindResource("Play");
                stwsd= false;
            
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

        }
    }
}
