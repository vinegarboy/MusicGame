using System;
using System.IO;
using DxLibDLL;

namespace MusicGame
{
    class ViewWindow{
        private int width,height,cb_w,cb_h,re = 0,skey = 0;
        //Title=0~2 Menu=3~7 Play~ other
        private int[] fontshundle = new int[20];
        private uint white = DX.GetColor(255,255,255);
        public string[] musics_f;
        public MusicDate[] md;
        public void SetMenuMusic(){
            musics_f = Directory.GetDirectories("./musics/", "*", SearchOption.AllDirectories);
            md = new MusicDate[musics_f.Length];
            for(int i = 0;i<md.Length;i++){
                md[i] = new MusicDate(musics_f[i]);
            }
        }
        public ViewWindow(int w,int h,int cw,int ch){
            cb_w=cw;
            cb_h=ch;
            this.InitWindowSize(w,h);
            fontshundle[0] = DX.CreateFontToHandle(null,width/10,10);
            fontshundle[1] = DX.CreateFontToHandle(null,width/12,6);
            fontshundle[2] = DX.CreateFontToHandle("游明朝",width/20,1);
        }
        public void InitWindowSize(int nw,int nh){
            DX.SetGraphMode(nw,nh,16);
            DX.SetWindowSize(nw,nh);
            DX.SetWindowMinSize(nw,nh);
            DX.SetWindowMaxSize(nw,nh);
            width = nw;
            height = nh;
        }
        public int TitleWindow(){
            DX.DrawStringToHandle(width/12,(height/24),"Type Music",white,fontshundle[0]);
            DX.DrawStringToHandle(width/2,(height/3)*2,"Click",white,fontshundle[0]);
            if(DX.GetMouseInput()==1){
                SetMenuMusic();
                re=1;
            }
            return re;
        }
        public int SelectWindow(){
            DX.DrawStringToHandle(0,0,"All Music",white,fontshundle[1]);
            fontshundle[2] = DX.CreateFontToHandle("游明朝",width/20,1);
            DX.DrawStringToHandle(width/2,(height*3)/4,md[skey].title,white,fontshundle[2]);
            return re;
        }
        public int PlayWindow(){
            DX.DrawBox(width/2-cb_w/2,height/2-cb_h/2,width/2+cb_w/2,height/2+cb_h/2,white,0);
            DX.SetFontSize(Convert.ToInt32(cb_w*0.8));
            DX.DrawString((width/2-cb_w/2)+(cb_w-Convert.ToInt32(cb_w*0.8))/2,(height/2-cb_h/2)+(cb_h-Convert.ToInt32(cb_w*0.8))/2,"a",white);
            return re;
        }
    }
}
