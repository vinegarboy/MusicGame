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
            DX.ChangeWindowMode(DX.TRUE);
            DX.SetWindowMinSize(400,800);
            DX.SetWindowMaxSize(400,800);
            while(DX.CheckHitKey(DX.KEY_INPUT_ESCAPE)!=1){
                
            }
        }
    }
}
