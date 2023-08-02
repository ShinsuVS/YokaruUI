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
using YokaruUI.Model;

namespace YokaruUI.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void AuthClick_Click(object sender, RoutedEventArgs e)
        {


            

            ((App)Application.Current).container.AuthToYandex(Convert.ToString(LoginTBText.Text), Convert.ToString(PasswordPBText.Password));
            //Player pw = new Player();
            //MessageBox.Show(Convert.ToString(LoginTBText.Text) + Convert.ToString(PasswordPBText.Password));
           // ((App)Application.Current).AuthToYandex(Convert.ToString(LoginTBText.Text), Convert.ToString(PasswordPBText.Password));


        }

        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if(LoginTBText.Text == "Login")
            LoginTBText.Text = "";
        }
    }
}
