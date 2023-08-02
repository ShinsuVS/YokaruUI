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
using YokaruUI.Model;

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
        public APiContainer container = new APiContainer();
      

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



       
    }
}
