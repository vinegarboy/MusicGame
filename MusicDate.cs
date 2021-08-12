using System;
using DxLibDLL;
using System.IO;

namespace MusicGame
{
    class MusicDate{
        public string title{get; set;}
        public int img{get; set;}
        public string[] fm_d{get; set;}
        public string[] levs{get; set;}
        //0 = easy , 1 = normal , 2 = hard
        public string sound_path{get;set;}
        public MusicDate(string path){
            fm_d = new string[3];
            levs = new string[3];
            StreamReader sr = new StreamReader($"{path}/info.if");
            string d;
            d = sr.ReadToEnd();
            title = d.Split(',')[0];
            levs[0] = d.Split(',')[1];
            levs[1] = d.Split(',')[2];
            levs[2] = d.Split(',')[3];
            fm_d[0] = (new StreamReader($"{path}/easy.fm")).ReadToEnd();
            fm_d[1] = (new StreamReader($"{path}/normal.fm")).ReadToEnd();
            fm_d[2] = (new StreamReader($"{path}/hard.fm")).ReadToEnd();
            img = DX.LoadGraph($"{path}/img.png");
            sound_path = $"{path}/music.mp3";
        }
    }
}