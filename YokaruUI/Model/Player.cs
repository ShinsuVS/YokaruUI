using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace YokaruUI.Model
{
    public class Player
    {
        public MediaPlayer mediaPlayer = new MediaPlayer();





        public void Pause() { mediaPlayer.Pause();}
        public void Stop() { mediaPlayer.Stop();}
        public void Play() { mediaPlayer.Play();}
        //public void Resume() {mediaPlayer.}




    }
}
