using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newgame
{
    public partial class Form1 : Form
    {
        System.Media.SoundPlayer playmusic = new System.Media.SoundPlayer();
        System.Media.SoundPlayer playveselie = new System.Media.SoundPlayer();
        System.Media.SoundPlayer asksound = new System.Media.SoundPlayer();
        bool right, left, jump = true, cut;
        int i, j, r = 0;
        int G = 20;
        int Force;
        bool gp1 = true, gp2 = true, gp3 = true, gp4 = true, gp5 = true;
        bool rp = true;
        bool lp = false;
        bool onblock;
        int[] mobmove = new int[10];
        int mm = 5;
        double ghostax1 = 0;
        double ghostax2 = 0;
        bool stopcut = false;
        int solution=0;
        int dies = 0;
        bool toleft=false;
        bool end=false;

        Image playerim, bg, inventory;
        Image copac1, pamant,rock1, block1, block2, mob1, ghost,ghost1 ,blockup1, blockup2;
        Rectangle blockuprect1, blockup2rect1;
        Rectangle blockuprect2;

        Image protect, task, apple;
        Rectangle protectrect, taskrect;

        Rectangle[] applerect = new Rectangle[5];
        int ap = 5;

        Image text1, text2;
        Rectangle text1rect,text2rect;

        Image[] playerr = new Image[5];
        int plrr = 0;
        Image[] playerl = new Image[5];
        Image playerim2;

        Image[] mobim = new Image[3];
        int mbin = 0;
    
        Rectangle playerrect, bgrect, invrect;


        PictureBox[] blockdownpb = new PictureBox[35];

        private void paint_timer_Tick(object sender, EventArgs e)
        {

        }

        int bp = 10;
        Rectangle[] mobrect = new Rectangle[20];

        private void button1_Click(object sender, EventArgs e)
        {
            if (dies == 1 && textBox1.Text == "41")
            {
               
                quest.Enabled = false;
                quest.Visible = false;
                screen.Enabled = true;
                
                playveselie.PlayLooping();
                textBox1.Clear();
                timer1.Start();
            }
            if (dies == 2 && textBox1.Text == "5")
            {
               
                quest.Enabled = false;
                quest.Visible = false;
                screen.Enabled = true;

                playveselie.PlayLooping();
                textBox1.Clear();
                timer1.Start();
            }
            if (dies == 3 && textBox1.Text == "29")
            {
              
                quest.Enabled = false;
                quest.Visible = false;

                screen.Enabled = true;
                playveselie.PlayLooping();
                textBox1.Clear();
                timer1.Start();
            }


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

  

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        int mb = 15;
        PictureBox[] mobpb = new PictureBox[15];
        int mp = 5;
        Rectangle ghostrect1, ghostrect2, ghostrect3, ghostrect4, ghostrect5;

        Image blockdown2image;
        Rectangle blockdown2rect1;

        Rectangle[] copaci = new Rectangle[20];
        int m = 15;
        Rectangle[] pamrect = new Rectangle[20];
        int n = 8;
        Rectangle[] blockdownrect = new Rectangle[35];
        int bl = 10;
       


        private void timer_mobim_Tick(object sender, EventArgs e)
        {
            mbin += 1;
            if (mbin > 2)
                mbin = 0;
            plrr++;
            if (plrr > 4)
                plrr = 0;

        }



    

  
      


        private void timer_ghost_Tick(object sender, EventArgs e)
        {

            ghostax1 += 0.03;
            if(gp1==true)
                ghostpb1.Top += Convert.ToInt32(Math.Cos(ghostax1) * 10);
            if(gp2==true)
                ghostpb2.Top += Convert.ToInt32(Math.Cos(ghostax1) * 10);
            if (gp3 == true)
                ghostpb3.Top += Convert.ToInt32(Math.Cos(ghostax1) * 10);
            if (gp4 == true)
                ghostpb4.Top += Convert.ToInt32(Math.Cos(ghostax1) * 10);
            if (gp5 == true)
                ghostpb5.Top += Convert.ToInt32(Math.Cos(ghostax1) * 10);

            ghostax2 += 0.01;
        }
      
    

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                right = true;
            if (e.KeyCode == Keys.Left)
                left = true;
            if (jump != true)
                if (e.KeyCode == Keys.Up)
                {
                    jump = true;
                    Force = G;
                }
            if (e.KeyCode == Keys.X)
                cut = true;


            
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.X)
            {
                cut = false;
                progressBar1.Visible = false;
                progressBar1.Value = 0;
            }
        }
        public Form1()
        {
            InitializeComponent();
            quest.Visible = false;
            playmusic.SoundLocation = "playerdie.wav";
            playveselie.SoundLocation = "veselie.wav";
            asksound.SoundLocation = "asksound.wav";
            playveselie.PlayLooping();
            timer_suprem.Enabled = true;
            timer3.Enabled = true;
            timer_mobim.Enabled = true;
            progressBar1.Visible = false;
            progressBar1.BringToFront();

            timer1.Enabled = true;

            task = newgame.Properties.Resources.task;
            taskrect = new Rectangle(60, 10, 160, 60);

            protect = newgame.Properties.Resources.protect;
            protectrect = new Rectangle(0, 0, 210, 70);

            apple = newgame.Properties.Resources.apple;
            for(int api=0; api< ap; api++)
                applerect[api] = new Rectangle(0, 0, 45, 45);

            text1 = newgame.Properties.Resources.gofwd;
            text2 = newgame.Properties.Resources.cuttrees;
            text1rect = new Rectangle(0, 250, 340, 110);
            text2rect = new Rectangle(0, 200, 400,132);

            screen.Visible = true;

            blockup2 = newgame.Properties.Resources.blockup3;
            blockup2rect1 = new Rectangle(0, 450, 800, 65);

            for (int mmn = 1; mmn <= mm; mmn++)
                mobmove[mmn] = 5;
            mobim[0] = newgame.Properties.Resources.mobim1;
            mobim[1] = newgame.Properties.Resources.mobim2;
            mobim[2] = newgame.Properties.Resources.mobim3;

            playerr[0] = newgame.Properties.Resources.player1;
            playerr[1] = newgame.Properties.Resources.player2;
            playerr[2] = newgame.Properties.Resources.player3;
            playerr[3] = newgame.Properties.Resources.player31;
            playerr[4] = newgame.Properties.Resources.player4;
            playerl[0] = newgame.Properties.Resources.playerl1;
            playerl[1] = newgame.Properties.Resources.playerl2;
            playerl[2] = newgame.Properties.Resources.playerl3;
            playerl[3] = newgame.Properties.Resources.playerl4;
            playerl[4] = newgame.Properties.Resources.playerl5;

            ghostpb1.Top += 250;
            ghostpb2.Top += 250;
            ghostpb3.Top += 250;
            ghostpb4.Top += 250;
            ghostpb5.Top += 250;

            mobpb[1] = mobpb1;
            mobpb[2] = mobpb2;
            mobpb[3] = mobpb3;
            mobpb[4] = mobpb4;
            mobpb[5] = mobpb5;
            blockdownpb[0] = blockdownpb1;
            blockdownpb[1] = blockdownpb2;
            blockdownpb[2] = blockdownpb3;
            blockdownpb[3] = blockdownpb4;
            blockdownpb[4] = blockdownpb5;
            blockdownpb[5] = blockdownpb6;
            blockdownpb[6] = blockdownpb7;
            blockdownpb[7] = blockdownpb8;
            blockdownpb[8] = blockdownpb9;
            blockdownpb[9] = blockdownpb10;

            applerect[0].Y = 565;
            applerect[1].Y = 300;
            applerect[3].Y = 565;
            applerect[4].Y = 565;
            applerect[2].Y = 290;


            ghostrect1 = new Rectangle(23, 32, 95, 120);
            ghostrect2 = new Rectangle(23, 32, 95, 120);
            ghostrect3 = new Rectangle(23, 32, 95, 120);
            ghostrect4 = new Rectangle(23, 32, 95, 120);
            ghostrect5 = new Rectangle(23, 32, 95, 120);
            ghost = newgame.Properties.Resources.ghost1;
            ghost1 = newgame.Properties.Resources.ghost1;




            blockup1 = newgame.Properties.Resources.groundup;
            blockuprect1 = new Rectangle(23, 32, 224, 51);
            blockuprect2 = new Rectangle(23, 32, 224, 51);

            copac1 = newgame.Properties.Resources.copac1;
            for (int l = 0; l < m; l++)
            {
                copaci[l]= new Rectangle(438, 370, 180, 258);
            }
            for (int l = 2; l < m; l++)
            {
                copaci[l].X = copaci[l - 1].X + 700; ;
            }
            pamant = newgame.Properties.Resources.pamantul;
            for (int p = 0; p < n; p++)
            {
                pamrect[p] = new Rectangle(0, 610, 1280, 80);
            }
            for (int p = 1; p < n; p++)
            {
                pamrect[p].X = pamrect[p - 1].X + 1280;
            }

          
            block1 = newgame.Properties.Resources.grounddown;
            for (int bln = 0; bln < bl; bln++)
            {
                blockdownrect[bln] = new Rectangle(200, 464, 136, 164);
            }
            blockdownpb[1].Left = 700;
            for (int blp = 1; blp < bp; blp++)
                blockdownpb[blp].Left = blockdownpb[blp - 1].Left + 2000;

          

            bg = newgame.Properties.Resources.backg;
            bgrect= new Rectangle(24, 0, 1280, 720);

            playerim = newgame.Properties.Resources.playerim1;
            playerim2 = newgame.Properties.Resources.playerim2;
            playerrect = new Rectangle(48, 66, 27, 70);

            for(int mbn=1; mbn< mb; mbn++)
            {
                mobrect[mbn] = new Rectangle(1130, 555, 60, 64);
            }

            for (int mbn = 2; mbn <= mp; mbn++)
            {
                mobpb[mbn].Left = mobpb[mbn - 1].Left + 1000;
                mobpb[mbn].Top += 420;
            }
            mobpb[1].Top += 420;
            




            inventory = newgame.Properties.Resources.inventory2;
            invrect = new Rectangle(260, 5, 170, 76);

            blockdownpb1.Left += 1000;
            grounduppb1.Left += 1600;
            grounduppb1.Top += 70;
            ghostpb1.Left += 2600;


            blockdown2image = newgame.Properties.Resources.blockdown2;
            blockdown2rect1 = new Rectangle(500, 510, 105, 102);
            blockdownpb[11] = blockdown2pb1;



            lemn.BringToFront();
            applelabel.BringToFront();

            quest.BringToFront();
            
         
        }

        private void screen_Paint(object sender, PaintEventArgs e)
        {
            Graphics t = e.Graphics;
            t.DrawImage(bg, bgrect);

            for(int l=0; l< m; l++)
                if(copaci[l].IntersectsWith(origin.Bounds))
                    t.DrawImage(copac1, copaci[l]);

           
            if (jump == true)
            {
                if( rp==true)
                t.DrawImage(playerim, playerrect);
            if (lp == true)
                t.DrawImage(playerim2, playerrect);
            }
            else
            {
                if (right == true)
                    t.DrawImage(playerr[plrr], playerrect);
                if (left == true)
                    t.DrawImage(playerl[plrr], playerrect);
            }
            if(left==false&&right==false && rp==true)
                t.DrawImage(playerim, playerrect);
            if (left == false && right == false && lp == true)
                t.DrawImage(playerim2, playerrect);



            t.DrawImage(inventory, invrect);

            t.DrawImage(blockdown2image, blockdown2rect1);

            for (int bln = 0; bln < bl; bln++)
                if (blockdownrect[bln].IntersectsWith(origin.Bounds))
                    t.DrawImage(block1, blockdownrect[bln]);
           

            for (int p = 0; p < n; p++)
                if (pamrect[p].IntersectsWith(origin.Bounds))
                    t.DrawImage(pamant, pamrect[p]);

            for (int mbn = 1; mbn <= mp; mbn++)
                if (mobrect[mbn].IntersectsWith(origin.Bounds))
                    t.DrawImage(mobim[mbin], mobrect[mbn]);


            if (blockuprect1.IntersectsWith(origin.Bounds))
                t.DrawImage(blockup1, blockuprect1);

            if (blockup2rect1.IntersectsWith(origin.Bounds))
                t.DrawImage(blockup2, blockup2rect1);
            if (blockuprect2.IntersectsWith(origin.Bounds))
                t.DrawImage(blockup1, blockuprect2);

            if(ghostrect1.IntersectsWith(origin.Bounds))
                 t.DrawImage(ghost, ghostrect1);
            if (ghostrect2.IntersectsWith(origin.Bounds))
                t.DrawImage(ghost, ghostrect2);
            if (ghostrect3.IntersectsWith(origin.Bounds))
                t.DrawImage(ghost, ghostrect3);
            if (ghostrect4.IntersectsWith(origin.Bounds))
                t.DrawImage(ghost, ghostrect4);
            if (ghostrect5.IntersectsWith(origin.Bounds))
                t.DrawImage(ghost, ghostrect5);

            if (text1rect.IntersectsWith(origin.Bounds))
                t.DrawImage(text1, text1rect);
            if (text2rect.IntersectsWith(origin.Bounds))
                t.DrawImage(text2, text2rect);

            for (int api = 0; api < ap; api++)
                if (applerect[api].IntersectsWith(origin.Bounds))
                    t.DrawImage(apple, applerect[api]);

            t.DrawImage(protect, protectrect);

            t.DrawImage(task, taskrect);
        }
    
      

        private void timer1_Tick(object sender, EventArgs e)
        {
            screen.Invalidate();




            //SARITURA

            if (jump == true)
            {
                player.Top -= Force;
                Force -= 1;
               
            }

            if (copaci[10].IntersectsWith(origin.Bounds))
                right = false;
            

            //POZITIONARI
            text1rect.X = copaci[0].X - 400;
            text2rect.X = copaci[1].X-100;
            applerect[0].X = blockdownpb[0].Left - 170;
            applerect[1].X = blockuprect1.Left + 130;
            applerect[3].X = copaci[3].X + 200;
            applerect[4].X = copaci[5].X + 730;
            applerect[2].X = copaci[5].X + 190;


            playerrect.Y = player.Top+2;
            playerrect.X = player.Left+35;
            ghostpb1.Left = blockdownpb[1].Left + 500;
            ghostpb5.Left = ghostpb4.Left + 300;

            ghostrect1.X = ghostpb1.Left +40;

            ghostrect1.Y = ghostpb1.Top;
            ghostrect2.Y = ghostpb2.Top;
            ghostrect3.Y = ghostpb3.Top;
            ghostrect4.Y = ghostpb4.Top;
            ghostrect5.Y = ghostpb5.Top;

            


            ghostpb2.Left = ghostpb1.Left + 500;
            ghostpb3.Left = ghostpb2.Left + 600;
            ghostpb4.Left = ghostpb3.Left + 1200;
            ghostrect2.X = ghostpb2.Left+40;
            ghostrect3.X = ghostpb3.Left+40;
            ghostrect4.X = ghostpb4.Left+40;
            ghostrect5.X = ghostpb5.Left+40;


            blockup2pb1.Left = blockdownpb[2].Left + 800;
            blockup2rect1.X = blockup2pb1.Left + 40;

            blockdown2rect1.X = blockdown2pb1.Left + 40;

            copaci[0].X = pictureBox1.Left;

            blockuppb2.Left = copaci[5].X + 95;
            blockuprect2.X = blockuppb2.Left + 40;
            blockuprect2.Y = blockuppb2.Top;
            copaci[1].X = copaci[0].X + 600;
            copaci[2].X = copaci[1].X + 1000;

            for (int l = 3; l < m; l++)
            {
                copaci[l].X = copaci[l - 1].X + 900; ;
            }
            copaci[6].X = copaci[5].X + 1400;
            copaci[7].X = copaci[6].X + 900;

            pamrect[0].X = ground.Left;
            for (int p = 1; p < n; p++)
            {
                pamrect[p].X = pamrect[p - 1].X + 1280;
            }
            for (int bln = 0; bln < bl; bln++)
                blockdownrect[bln].X = blockdownpb[bln].Left+40;
            for (int mbn = 1; mbn <= mp; mbn++)
            {
                mobrect[mbn].X = mobpb[mbn].Left + 40;
                mobrect[mbn].Y = mobpb[mbn].Top;

            }


            copaci[9].X = copaci[8].X + 2000;

            blockuprect1.X = grounduppb1.Left + 40;
            blockuprect1.Y = grounduppb1.Top;

            //OPREIRE JOS
            if (player.Top + player.Height+20 > screen.Height - 60)
            {
                jump = false;
                player.Top = screen.Height - player.Height - 60;
            }

            //dreapta-stanga
            if (right == true)
            {
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Tag != player.Tag && i == 0)
                    {
                        x.Left -= 5;

                    }


                }
                rp = true;
                lp = false;
            }

            if (left == true)
            {
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Tag != player.Tag && ground.Left < 0 && j == 0)
                    {
                        x.Left += 5;

                    }

                }
                rp = false;
                lp = true;
            }
            
            i = 0;
            j = 0;

            onblock = false;


            //coliziune stanga dreapta & onblock
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag !=player.Tag && x.Bounds.IntersectsWith(origin.Bounds) )
                {
                    //oprire stanga dreapta
                    if (player.Left + player.Width + 4 > x.Left && player.Top < x.Top+x.Height-10 && player.Left < x.Left + player.Width && player.Top > x.Top-player.Height  && onblock==false)
                    {
                        right = false;
                        i = 1;
                    }
                    

                    if (player.Left  < x.Left + x.Width + 4 && player.Top < x.Top+x.Height-15  && player.Left > x.Left && player.Top > x.Top - player.Height && onblock == false)
                    {
                        left = false;
                        j = 1;
                    } 
                    

                    //oprire cadere pe bloc
                    if (player.Top + player.Height +20 > x.Top && player.Left + player.Width > x.Left && player.Left < x.Left + x.Width && player.Top + player.Height < x.Top + 23 && player.Top > x.Top - player.Height - 23)
                    {

                        Force = 0;
                        player.Top = x.Top - player.Height;
                        jump = false;
                        onblock = true;


                    }
                    //cadere de pe bloc
                    else
                    {
                        if (player.Left + player.Width < x.Left && player.Left + player.Width > x.Left - player.Width - 20 && player.Top < x.Top && player.Top + player.Height < x.Top + x.Height)
                            jump = true;
                        else
                            if (player.Left > x.Left + x.Width && player.Left < x.Left + x.Width + 20 && player.Top < x.Top && player.Top + player.Height < x.Top + x.Height)
                            jump = true;
                       
                    }

                    if (player.Bounds.IntersectsWith(x.Bounds) && player.Top < x.Top + x.Height && player.Top > x.Top)
                    {

                        Force = 0;
                        player.Top += 10;

                    }

                   



                }

            }

            //STOP FALLING
            if (player.Top + player.Height > ground.Top)
            {
                jump = false;
                player.Top = ground.Top- player.Height;
            }

            //GHOST COLISION
            #region GHOSTS COLISSIONS
            if (player.Bounds.IntersectsWith(ghostpb1.Bounds))
            {
                playveselie.Stop();
                playmusic.Play();

                quest.BringToFront();
                quest.Enabled = true;
                quest.Visible = true;
                dies += 1;
                gp1 = false;
                ghostpb1.Top -= 400;
                asksound.PlayLooping();
                timer1.Stop();
            }
            if (player.Bounds.IntersectsWith(ghostpb2.Bounds))
            {
                playveselie.Stop();
                playmusic.Play();

                quest.BringToFront();
                quest.Enabled = true;
                quest.Visible = true;
                dies += 1;
                gp2 = false;
                ghostpb2.Top -= 400;
                asksound.PlayLooping();
                timer1.Stop();
            }
            if (player.Bounds.IntersectsWith(ghostpb3.Bounds))
            {
                playveselie.Stop();
                playmusic.Play();

                quest.BringToFront();
                quest.Enabled = true;
                quest.Visible = true;
                dies += 1;
                gp3 = false;
                ghostpb3.Top -= 400;
                asksound.PlayLooping();
                timer1.Stop();
            }
            if (player.Bounds.IntersectsWith(ghostpb4.Bounds))
            {
                playveselie.Stop();
                playmusic.Play();

                quest.BringToFront();
                quest.Enabled = true;
                quest.Visible = true;
                dies += 1;
                gp4 = false;
                ghostpb4.Top -= 400;
                asksound.PlayLooping();

                asksound.PlayLooping();
                timer1.Stop();
            }
            if (player.Bounds.IntersectsWith(ghostpb5.Bounds))
            {
                playveselie.Stop();
                playmusic.Play();

                quest.BringToFront();
                quest.Enabled = true;
                quest.Visible = true;
                dies += 1;
                gp5 = false;
                ghostpb5.Top -= 400;
                asksound.PlayLooping();

                asksound.PlayLooping();
                timer1.Stop();
            }
            #endregion
            //STOP CUT
            if (Convert.ToInt32(lemn.Text) == 9)
                stopcut = true;


            //TREE CUT

            for (int l=0; l< m; l++)
            {
                if ( player.Bounds.IntersectsWith(copaci[l]) && cut==true && stopcut==false)
                {
                    
                    timer2.Start();
                    progressBar1.Visible = true;
                    if (progressBar1.Value == 100)
                    {
                        copaci[l].Y += 1000;
                        progressBar1.Visible = false;
                        progressBar1.Value = 0;
                        lemn.Text = Convert.ToString((Convert.ToInt32(lemn.Text) + 3));
                    }

                    
                }

                if (player.Bounds.IntersectsWith(copaci[l]) && cut == true && stopcut == true)
                {
                    protectrect.X = copaci[l].X;
                    protectrect.Y = 270;
                }
                else
                    if (cut != true)
                        protectrect.X -= 5999;
            }

            //APPLE COLECT
            for(int api=0; api< ap; api++)
            {
                if (applerect[api].IntersectsWith(player.Bounds))
                {
                    applerect[api].Y += 1000;
                    applelabel.Text = Convert.ToString((Convert.ToInt32(applelabel.Text) + 1));
                }
                    
            }


            //MOB
            for (int mpn = 1; mpn <= mp; mpn++)
                if (mobpb[mpn].Bounds.IntersectsWith(origin.Bounds))
            {
                mobpb[mpn].Left -= mobmove[mpn];
                    foreach (PictureBox ct in blockdownpb)
                    {
                        if (ct is PictureBox && ct.Tag != player.Tag && ct.Bounds.IntersectsWith(mobpb[mpn].Bounds))
                        {
                            mobmove[mpn]= mobmove[mpn]*(-1);
                           
                        }
                    } 
                if (player.Top + player.Height + 20 > mobpb[mpn].Top && player.Left + player.Width > mobpb[mpn].Left && player.Left < mobpb[mpn].Left + mobpb[mpn].Width && player.Top + player.Height < mobpb[mpn].Top + 23 && player.Top > mobpb[mpn].Top - player.Height - 23)
                {

                    mobpb[mpn].Top += 1000;
                    
                    Force = 10;
                    jump = true;
                }
                    //VIATA PLAYER
                    if (player.Bounds.IntersectsWith(mobpb[mpn].Bounds))
                    {
                        
                        playveselie.Stop();
                        playmusic.Play();
                        quest.Enabled = true;
                        screen.Enabled = false;
                        
                        quest.Visible = true;
                        dies += 1;
                        mobpb[mpn].Top += 1000;
                        asksound.PlayLooping();
                        timer1.Stop();
                    }
                        
                    
             }





        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int l = 0; l < m; l++)
                if (player.Bounds.IntersectsWith(copaci[l]) && cut == true)
                {
                    progressBar1.Increment(3);

                }
            
        }

        private void timer_suprem_Tick(object sender, EventArgs e)
        {
            if (player.Bounds.IntersectsWith(copaci[8]))
                this.Close();


            if (dies > 3)
                dies = 1;

            if (dies == 1)
            {
                ec1.Visible = true;
                ec2.Visible = false;
                ec3.Visible = false;
            }
            if (dies == 2)
            {
                ec1.Visible = false;
                ec2.Visible = true;
                ec3.Visible = false;
            }
            if (dies == 3)
            {
                ec1.Visible = false;
                ec2.Visible = false;
                ec3.Visible = true;
            }
            //SOLUTIONS
            switch (dies)
            {
                case 1:
                    solution = 41; break;
                case 2:
                    solution = 5; break;
                case 3:
                    solution = 29; break;
            }

           

           
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            r += 1;
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
