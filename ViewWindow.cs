using System;
using System.IO;
using System.Drawing;
using DxLibDLL;

namespace MusicGame
{
    class ViewWindow{
        private int width,height,cb_w,cb_h,re = 0,skey = 0,a_x=0,a_y=0,a_w=0,a_h=0,lev_k=0,l_sf=0;
        //Title=0~2 Menu=3~7 Play~ other
        private int[] fontshundle = new int[20];
        private uint white = DX.GetColor(255,255,255);
        public string[] musics_f;
        public MusicDate[] md;
        private Font f;
        private System.Drawing.Text.PrivateFontCollection pfc = new System.Drawing.Text.PrivateFontCollection();
        private int[] images = new int[5];
        
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
            //init
            pfc.AddFontFile("./skins/fonts/fonts.TTF");
        }
        public void InitWindowSize(int nw,int nh){
            DX.SetGraphMode(nw,nh,16);
            DX.SetWindowSize(nw,nh);
            DX.SetWindowMinSize(nw,nh);
            DX.SetWindowMaxSize(nw,nh);
            width = nw;
            height = nh;
            a_h=height/3;
            a_w=a_h;
            a_x=width/2-(width/20)*4;
            a_y=height/7;
            fontshundle[0] = DX.CreateFontToHandle(null,width/10,10);
            fontshundle[1] = DX.CreateFontToHandle(null,width/12,6);
            fontshundle[2] = DX.CreateFontToHandle("游明朝",width/24,1);
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
            int m_x,m_y;
            DX.DrawStringToHandle(0,0,"All Music",white,fontshundle[1]);
            DX.DrawExtendGraph(a_x,a_y,a_x+a_w,a_y+a_h,md[skey].img,0);
            l_sf--;
            if(md.Length ==1){
                DX.DrawStringToHandle(width/2,(height*3)/4,md[skey].title,white,fontshundle[2]);
                DX.DrawStringToHandle(width/2-(width/20)*4,(height*4)/7,$"Level:{md[skey].levs[lev_k]}",white,fontshundle[2]);
            }
            else if(md.Length ==2){
                DX.DrawStringToHandle(width/2,(height*3)/4,md[skey].title,white,fontshundle[2]);
                DX.GetMousePoint(out m_x,out m_y);
                if((DX.CheckHitKey(DX.KEY_INPUT_RIGHT)==1)||((DX.GetMouseInput()==1)&&(m_x>a_x+a_w))||((DX.GetMouseInput()==1)&&(m_x>a_x+(a_w/2)&&m_x<a_x+a_w)&&(m_y<a_y||m_y>a_y+a_h))){
                    //選曲変更
                    if(skey==0){
                        skey=1;
                    }else{
                        skey=0;
                    }
                }else if((DX.CheckHitKey(DX.KEY_INPUT_LEFT)==1)||((DX.GetMouseInput()==1)&&(m_x<a_x))||((DX.GetMouseInput()==1)&&(m_x>a_x&&m_x<a_x+(a_w/2))&&(m_y<a_y||m_y>a_y+a_h))){
                    //選曲変更
                    if(skey==0){
                        skey=1;
                    }else{
                        skey=0;
                    }
                }
            }
            else{
                DX.DrawStringToHandle(width/2,(height*3)/4,md[skey].title,white,fontshundle[2]);
                DX.GetMousePoint(out m_x,out m_y);
                if((DX.CheckHitKey(DX.KEY_INPUT_RIGHT)==1)||((DX.GetMouseInput()==1)&&(m_x>a_x+a_w))||((DX.GetMouseInput()==1)&&(m_x>a_x+(a_w/2)&&m_x<a_x+a_w)&&(m_y<a_y||m_y>a_y+a_h))){
                    //選曲変更(加算)
                    skey++;
                    if(skey>=md.Length){
                        skey=0;
                    }
                }else if((DX.CheckHitKey(DX.KEY_INPUT_LEFT)==1)||((DX.GetMouseInput()==1)&&(m_x<a_x))||((DX.GetMouseInput()==1)&&(m_x>a_x&&m_x<a_x+(a_w/2))&&(m_y<a_y||m_y>a_y+a_h))){
                    //選曲変更(減算)
                    skey--;
                    if(skey<0){
                        skey = md.Length-1;
                    }
                }
            }
            if(DX.CheckHitKey(DX.KEY_INPUT_UP)==1&&l_sf<=0){
                lev_k++;
                if(lev_k>2){
                    lev_k=2;
                }
                l_sf=30;
            }
            else if(DX.CheckHitKey(DX.KEY_INPUT_DOWN)==1&&l_sf<=0){
                lev_k--;
                if(lev_k<0){
                    lev_k=0;
                }
                l_sf=30;
            }
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
