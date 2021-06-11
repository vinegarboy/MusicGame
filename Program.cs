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
            int width = 400,height = 800;
            DX.ChangeWindowMode(DX.TRUE);
            if (DX.DxLib_Init() < 0){
                return;
            }
            DX.SetWindowMinSize(width,height);
            DX.SetWindowMaxSize(width,height);
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
            DX.SetWaitVSyncFlag(DX.FALSE);
            while(DX.CheckHitKey(DX.KEY_INPUT_ESCAPE)!=1){
                DX.ClearDrawScreen();
                //ここからメインループ
                DX.ScreenFlip();
            }
            DX.DxLib_End();
        }
    }
}
