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
        public void InitWindowSize(int width,int height){
            DX.SetGraphMode(width,height,16);
            DX.SetWindowSize(width,height);
            DX.SetWindowMinSize(width,height);
            DX.SetWindowMaxSize(width,height);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[,] wsizes={{640,480},{800,600},{1024,768},{1280,1024},{1280,720},{1920,1080}};
            int width = wsizes[0,0],height = wsizes[0,1],cbp = 40,cb_w = width*cbp/100,cb_h=height*cbp/100;
            uint white = DX.GetColor(255,255,255);
            //設定
            DX.ChangeWindowMode(1);
            DX.SetWindowSizeChangeEnableFlag( 0,0 ) ;
            DX.DxLib_Init();
            ViewWindow vw = new ViewWindow();
            vw.InitWindowSize(width,height);
            DX.SetFontSize(cb_w);
            //debugMessage
            Console.WriteLine($"");
            //メインのループ処理
            while(DX.CheckHitKey(DX.KEY_INPUT_ESCAPE)!=1){
                //画面の更新処理
                DX.ClearDrawScreen();
                DX.SetDrawScreen(DX.DX_SCREEN_BACK);

                //ここからメインループ
                DX.DrawBox(width/2-cb_w/2,height/2-cb_h/2,width/2+cb_w/2,height/2+cb_h/2,white,0);
                DX.DrawString(width/2-cb_w/2,height/2-cb_h/2,"a",white);
                DX.ScreenFlip();
            }
            DX.DxLib_End();
        }
    }
}
