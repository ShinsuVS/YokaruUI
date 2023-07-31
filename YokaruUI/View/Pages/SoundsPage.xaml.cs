using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using YandexMusicApi;
using YandexMusicApi.Api;
using YandexMusicApi.Auth;
using YandexMusicApi.Network;

namespace YokaruUI.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SoundsPage.xaml
    /// </summary>
    public partial class SoundsPage : Page
    {
        public SoundsPage()
        {
            InitializeComponent();
            chc();
            if (((App)Application.Current).AuthComplete == true)
            {
                NetworkParams networkParams = new NetworkParams();
                Token tokenObject = new Token(((App)Application.Current).loginAuth, ((App)Application.Current).PassAuth, networkParams);
                var token = ((App)Application.Current).tokenAuth;
                var ACInfo = new Default(networkParams, token);
                var info = ACInfo.GetAllFeed().Result.ToString();
                
                //var definition = new { uid = "" };
                //var customer1 = JsonConvert.DeserializeAnonymousType(Convert.ToString(info), definition);
                //MessageBox.Show(info);




                //var aacc = new Default(networkParams, customer1.token.ToString());
                //string srds = aacc.GetChart().Result.ToString();
                //string path = AppDomain.CurrentDomain.BaseDirectory;
                //path = path.Substring(0, path.IndexOf("bin")) + "TextFile1.txt";
                //StreamWriter sw = new StreamWriter(path);
                //sw.WriteLine(srds);
                //Console.WriteLine(srds);
            }


        }





        public async void chc()
        {
           
        }
    }
}

