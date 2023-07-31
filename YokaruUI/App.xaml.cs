using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using YandexMusicApi;
using YandexMusicApi.Api;
using YandexMusicApi.Auth;
using YandexMusicApi.Network;

namespace YokaruUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 


    public partial class App : Application
    {
        public bool LightTheme = true;
        public Token tokenobj;
        private bool _AuthComplete = false;
        public string tokenAuth;
        public string loginAuth;
        public string PassAuth;
        public bool AuthComplete
        {
            get { if(tokenAuth == null)
                {
                    return false;
                }
                else
                {
                    return _AuthComplete;
                }
                }
            set {

            if(_AuthComplete != value )
                {
                    _AuthComplete = value;
                    
                }
            }
        }



        public async void AuthToYandex(string log, string pass)
        {
            NetworkParams networkParams = new NetworkParams() { }; // Creating an object of class NetworkParams, if necessary you can specify there proxy and UserAgent to use in requests.
            Token tokenObject = new Token(log, pass, networkParams);
            var result = await tokenObject.LoginUsername(); // Send Username to get authorization options
            loginAuth = log; PassAuth = pass;
            if (result.Data["preferred_auth_method"].ToString() == "password") // If the best authorization option is a password
            {
                result = await tokenObject.LoginPassword(); // Starting authorization by password
                var tokens = await tokenObject.GetToken(result.Data["retpath"].ToString()); // Getting a token   
                                                                                           // MessageBox.Show(Convert.ToString(token));

                var definition = new { token = "" };
                var curlToken = JsonConvert.DeserializeAnonymousType(Convert.ToString(tokens), definition);
               

                AuthComplete = true;
                tokenAuth = curlToken.token;


                MessageBox.Show("Авторизация успешно пройдена.");

                //Navigated(new System.Uri("View/Pages/SoundsPage.xaml", UriKind.RelativeOrAbsolute));
                ((MainWindow)Application.Current.MainWindow).PagesNavigation.NavigationService.Navigate(new System.Uri("View/Pages/SoundsPage.xaml", UriKind.RelativeOrAbsolute));
                //((MainWindow)Application.Current.MainWindow).imgs.ImageSource = new BitmapImage();
            }






        }
    }
}
