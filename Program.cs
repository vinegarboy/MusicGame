using System;
using DxLibDLL;

namespace MusicGame
{
    class Program
    {
        static void Main(string[] args)
        {
            const int W = 380,H=680;
            int box_size = (H-W)/3;
            DX.SetOutApplicationLogValidFlag(DX.FALSE);
            DX.SetAlwaysRunFlag(DX.TRUE);
            DX.SetWindowSizeChangeEnableFlag(DX.FALSE);
            DX.SetFullScreenResolutionMode(DX.DX_FSRESOLUTIONMODE_DESKTOP);
            DX.SetWindowText("MusicGame");
            DX.ChangeWindowMode(DX.TRUE);
            DX.SetGraphMode(W, H, 32);
            if (DX.DxLib_Init() == -1) return;
            while(DX.CheckHitKey(DX.KEY_INPUT_ESCAPE) == 0){
                DX.ClearDrawScreen();
                DX.DrawBox(20,(H-W),20+box_size,(H-W)+box_size,DX.GetColor(180,180,180),DX.TRUE);
                DX.DrawBox(40+box_size,(H-W),40+box_size*2,(H-W)+box_size,DX.GetColor(180,180,180),DX.TRUE);
                DX.DrawBox(60+box_size*2,(H-W),60+box_size*3,(H-W)+box_size,DX.GetColor(180,180,180),DX.TRUE);
                DX.DrawBox(20,(H-W)+20+box_size,20+box_size,(H-W)+20+box_size*2,DX.GetColor(180,180,180),DX.TRUE);
                DX.DrawBox(40+box_size,(H-W)+20+box_size,40+box_size*2,(H-W)+20+box_size*2,DX.GetColor(180,180,180),DX.TRUE);
                DX.DrawBox(60+box_size*2,(H-W)+20+box_size,60+box_size*3,(H-W)+20+box_size*2,DX.GetColor(180,180,180),DX.TRUE);
                DX.DrawBox(20,(H-W)+40+box_size*2,20+box_size,(H-W)+40+box_size*3,DX.GetColor(180,180,180),DX.TRUE);
                DX.DrawBox(40+box_size,(H-W)+40+box_size*2,40+box_size*2,(H-W)+40+box_size*3,DX.GetColor(180,180,180),DX.TRUE);
                DX.DrawBox(60+box_size*2,(H-W)+40+box_size*2,60+box_size*3,(H-W)+40+box_size*3,DX.GetColor(180,180,180),DX.TRUE);

                DX.ScreenFlip();
            }
            DX.DxLib_End();
        }
    }
}
