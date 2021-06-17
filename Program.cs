using System.Data;
using System.Data.Common;
using System;
using DxLibDLL;
using System.Threading;
using System.IO;

namespace MusicGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 600,height = 400;
            DX.ChangeWindowMode(DX.TRUE);
            if (DX.DxLib_Init() < 0){
                return;
            }
            DX.SetWindowMinSize(width,height);
            DX.SetWindowSize(width,height);
            DX.SetWindowMaxSize(width,height);
            DX.SetWaitVSyncFlag(DX.FALSE);
            DX.GetWindowSize(out width,out height);
            int cb_x = width/2,cb_y=(height)/3;
            Console.WriteLine($"{cb_x} {cb_y}");
            while(DX.CheckHitKey(DX.KEY_INPUT_ESCAPE)!=1){
                DX.ClearDrawScreen();
                DX.SetDrawScreen(DX.DX_SCREEN_BACK);
                //ここからメインループ
                DX.DrawLine(cb_x,cb_y,cb_x,cb_y+100,DX.GetColor(255,255,255),DX.TRUE);
                DX.ScreenFlip();
            }
            DX.DxLib_End();
        }
    }
}
