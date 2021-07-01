using System;
using DxLibDLL;

namespace MusicGame
{
    class ViewWindow{
        private int width,height,cb_w,cb_h,re = 0;
        //Title=0~2 Menu=3~7 Play~ other
        private int[] fontshundle = new int[20];
        private uint white = DX.GetColor(255,255,255);
        public ViewWindow(int w,int h,int cw,int ch){
            cb_w=cw;
            cb_h=ch;
            this.InitWindowSize(w,h);
            fontshundle[0] = DX.CreateFontToHandle(null,width/10,10);
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
                re=1;
            }
            return re;
        }
        public int SelectWindow(){
            DX.DrawString(width/2,height/2,"Menu",white);
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
