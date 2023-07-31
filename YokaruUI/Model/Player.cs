using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using YandexMusicApi;
using YandexMusicApi.Auth;
using YandexMusicApi.Network;

namespace YokaruUI.Model
{
    public class Player
    {
        public MediaPlayer mediaPlayer = new MediaPlayer();





        public void Pause() { mediaPlayer.Pause();}
        public void Stop() { mediaPlayer.Stop();}
        public void Play() { mediaPlayer.Play();}
        //public void Resume() {mediaPlayer.}




        public async void AuthYam(string login, string password)
        {
            NetworkParams networkParams = new NetworkParams() { }; // Creating an object of class NetworkParams, if necessary you can specify there proxy and UserAgent to use in requests.
            Token tokenObject = new Token("Login", "Password", networkParams);
            var result = await tokenObject.LoginUsername(); // Send Username to get authorization options

            if (result.Data["preferred_auth_method"].ToString() == "password") // If the best authorization option is a password
            {
                result = await tokenObject.LoginPassword(); // Starting authorization by password
                if (result.Data["errors"][0].ToString().Trim() == "redirect") // If you have two-factor authorization enabled
                {
                    result = await tokenObject.CheckChallenge(); // Checking what Yandex needs for authorization
                    if (result.Data["challenge"]["challengeType"].ToString().Trim() == "phone_confirmation") // If Yandex needs an SMS to confirm authorization
                    {
                        string phoneId = result.Data["challenge"]["phoneId"].ToString(); // Get phoneId to receive sms later
                        result = await tokenObject.ValidatePhoneById(phoneId); // Check the received phoneId
                        if (result.Data["status"].ToString().Trim() == "ok") // If all is well
                        {
                            await tokenObject.PhoneConfirmCodeSubmit(phoneId); // Sending sms to phone

                            Console.WriteLine("Write SMS code");
                            string smsCode = Console.ReadLine();

                            await tokenObject.PhoneConfirmCode(smsCode); // Send the code to Yandex
                            result = await tokenObject.ChallengeCommit("phone_confirmation"); // Talking to Yandex about the end of two-factor authentication
                            var token = await tokenObject.GetToken(result.Data["retpath"].ToString()); // Getting a token

                            Console.WriteLine(token);
                        }
                    }
                }
            }

        }


    }
}
