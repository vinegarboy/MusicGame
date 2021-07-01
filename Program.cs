using System.Net.Http.Headers;
using System.Data;
using System.Data.Common;
using System;
using DxLibDLL;
using System.Threading;
using System.IO;

namespace MusicGame
{
    class ViewWindow{
        private int width,height,cb_w,cb_h;
        private uint white = DX.GetColor(255,255,255);
        public ViewWindow(int w,int h,int cw,int ch){
            cb_w=cw;
            cb_h=ch;
            this.InitWindowSize(w,h);
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
            DX.SetFontSize(width/10);
            DX.DrawString(width/12,(height/24),"Type Music",white);
            return 0;
        }
        public int SelectWindow(){
            return 1;
        }
        public int PlayWindow(){
            DX.DrawBox(width/2-cb_w/2,height/2-cb_h/2,width/2+cb_w/2,height/2+cb_h/2,white,0);
            DX.SetFontSize(Convert.ToInt32(cb_w*0.8));
            DX.DrawString((width/2-cb_w/2)+(cb_w-Convert.ToInt32(cb_w*0.8))/2,(height/2-cb_h/2)+(cb_h-Convert.ToInt32(cb_w*0.8))/2,"a",white);
            return 2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[,] wsizes={{640,480},{800,600},{1024,768},{1280,1024},{1280,720},{1920,1080}};
            int width = wsizes[0,0],height = wsizes[0,1],cbp = 40,cb_w = width*cbp/100,cb_h=height*cbp/100,vf=0;
            //設定
            DX.ChangeWindowMode(1);
            DX.SetWindowSizeChangeEnableFlag( 0,0 ) ;
            DX.DxLib_Init();
            ViewWindow vw = new ViewWindow(width,height,cb_w,cb_h);
            vw.InitWindowSize(width,height);
            //debugMessage
            Console.WriteLine($"");
            //メインのループ処理 vf=0はタイトル。vf=1で曲選,vf=2でプレイ画面,以降設定画面は1刻みで設定しコメントに記す。2021/07/01
            while(DX.CheckHitKey(DX.KEY_INPUT_ESCAPE)!=1){
                //画面の更新処理
                DX.ClearDrawScreen();
                DX.SetDrawScreen(DX.DX_SCREEN_BACK);
                //ここからメインループ
                if(vf==0){
                    vf = vw.TitleWindow();
                }
                else if(vf==1){
                    vf = vw.SelectWindow();
                }
                else if(vf==2){
                    vf = vw.PlayWindow();
                }
                DX.ScreenFlip();
            }
            DX.DxLib_End();
        }
    }
}
