using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YandexMusicApi;
using YandexMusicApi.Api;
using YandexMusicApi.Auth;
using YandexMusicApi.Network;

namespace YokaruUI.Model
{
    public class APiContainer
    {
        public NetworkParams networkParams = new NetworkParams();
        private string LoginForAuth;
        private string PasswordForAuth;
        private string TokenFromAuth;
        private Token tokenObject;
        private List<string> likedTracksID = new List<string>();


        public async Task AuthToYandex(string login, string password)
        {
            LoginForAuth = login;
            PasswordForAuth = password;
            tokenObject = new Token(login, password, networkParams);
            var result = await tokenObject.LoginUsername(); // Send Username to get authorization options

            if (result.Data["preferred_auth_method"].ToString() == "password") // If the best authorization option is a password
            {
                result = await tokenObject.LoginPassword(); // Starting authorization by password

                var token = await tokenObject.GetToken(result.Data["retpath"].ToString()); // Getting a token
                var def = new { token = "" };

                var tokenau = JsonConvert.DeserializeAnonymousType(Convert.ToString(token), def);
                TokenFromAuth = tokenau.token.ToString();

                var ACInfo = new Account(networkParams, TokenFromAuth);
                JObject sd = await ACInfo.ShowInformAccountFromYandexPassport();
                
                var main = App.Current.MainWindow as MainWindow;

                var def1 = new { default_avatar_id = "", display_name = "" };

                var url = JsonConvert.DeserializeAnonymousType(sd.ToString(), def1);

                //MessageBox.Show(url.display_name);
                main.changeImgs(url.default_avatar_id);
                main.ChangeUser(url.display_name);
                MessageBox.Show("Авторизация выполнена успешно.");
            }

        }

        public async Task getLikedTracksFromApi()
        {
           // MessageBox.Show(LoginForAuth + " " + PasswordForAuth);
           
            tokenObject = new Token(LoginForAuth, PasswordForAuth, networkParams);
            var result = await tokenObject.LoginUsername(); // Send Username to get authorization options

            if (result.Data["preferred_auth_method"].ToString() == "password") // If the best authorization option is a password
            {
                result = await tokenObject.LoginPassword(); // Starting authorization by password

                var token = await tokenObject.GetToken(result.Data["retpath"].ToString()); // Getting a token
                var def = new { token = "" };

                var tokenau = JsonConvert.DeserializeAnonymousType(Convert.ToString(token), def);
                TokenFromAuth = tokenau.token.ToString();

                var ACInfo = new Account(networkParams, TokenFromAuth);
                JObject sd = await ACInfo.ShowInformAccount();
                var main = App.Current.MainWindow as MainWindow;

                var def1 = new { result = new { account = new { uid = "" } } };

                var url = JsonConvert.DeserializeAnonymousType(sd.ToString(), def1);


                var TRInfo = new Track(networkParams, TokenFromAuth);
                JObject sd1 = await TRInfo.GetLikesTrack(url.result.account.uid);
                //string path = AppDomain.CurrentDomain.BaseDirectory;
                //path = path.Substring(0, path.IndexOf("bin")) + "Model\\TextFile1.txt";

                //StreamWriter sw = new StreamWriter(path);
                //sw.WriteLine(sd1.ToString());
             
                //List<string> def2 = new { result = new { library = new { List<string>tracks } } };
                MainRootingClass rt = JsonConvert.DeserializeObject<MainRootingClass>(sd1.ToString());


                string sv = "";
                for(int i = 0; i < rt.result.library.tracks.Count; i++)
                {
                    //sw.WriteLine(rt.result.library.tracks[i].id);
                    likedTracksID.Add(rt.result.library.tracks[i].id);
                    sv = sv + likedTracksID[i] + "\n";
                }
                //sw.Close();
                MessageBox.Show(sv);

               
            }



        }

    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class InvocationInfo
    {
        [JsonProperty("req-id")]
        public string reqid { get; set; }
        public string hostname { get; set; }

        [JsonProperty("exec-duration-millis")]
        public int execdurationmillis { get; set; }
    }

    public class Library
    {
        public int uid { get; set; }
        public int revision { get; set; }
        public string playlistUuid { get; set; }
        public List<TrackInfo> tracks { get; set; }
    }

    public class Result
    {
        public Library library { get; set; }
    }

    public class MainRootingClass
    {
        public InvocationInfo invocationInfo { get; set; }
        public Result result { get; set; }
    }

    public class TrackInfo
    {
        public string id { get; set; }
        public string albumId { get; set; }
        public DateTime timestamp { get; set; }
    }



}
