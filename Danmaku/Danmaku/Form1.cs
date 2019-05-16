using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Danmaku
{
    public partial class frm : Form
    {
        public frm()
        {
            InitializeComponent();
        }

        bool[] keypressed = new bool[8];
        Keys[] keyobject = { Keys.W, Keys.A, Keys.S, Keys.D, Keys.Space, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3 };
        
        int playerx = 150;
        int playery = 400;
        int playersp = 3;
        static int playerprojmax = 160;
        int playerprojdensity = 2;
        int line = 0;
        bool[] playerproj = new bool[playerprojmax];
        double[] playerprojx = new double[playerprojmax];
        double[] playerprojy = new double[playerprojmax];
        double[] playerprojxsp = new double[playerprojmax];
        double[] playerprojysp = new double[playerprojmax];
        int playerprojcount = 0;

        int bossx = 150;
        int bossy = 100;
        int bosshp = 2000;
        int difficulty = 1;

        bool[] moveset = new bool[4];
        int[] movesettick = { 1, 1, 1, 1 };
        int[] movesetdensity = { 20, 20, 20, 5 };
        int[] movesetspeed = { 4, 4, 4, 8 };
        double[] movesetvariant = new double[4];
        static int bossprojmax = 500;
        bool[] bossproj = new bool[bossprojmax];
        double[] bossprojx = new double[bossprojmax];
        double[] bossprojy = new double[bossprojmax];
        double[] bossprojxsp = new double[bossprojmax];
        double[] bossprojysp = new double[bossprojmax];
        Brush[] bossprojcolor = new Brush[bossprojmax];
        int bossprojcount = 0;
        int timertick = 0;

        Random rnd = new Random();

        public void createSq(double x, double y, int size, Brush brush, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(Convert.ToInt32(x) - 63 * size / 100, Convert.ToInt32(y) - 82 * size / 100 - 1);
            e.Graphics.DrawString("■", new Font("Arial", size), brush, new Point(0, 0));
            e.Graphics.TranslateTransform(0 - Convert.ToInt32(x) + 63 * size / 100, 0 - Convert.ToInt32(y) + 82 * size / 100 + 1);
        }

        public void move0() //swipe right
        {
            bossprojy[bossprojcount] = bossy;
            bossprojx[bossprojcount] = bossx;
            bossprojysp[bossprojcount] = movesetspeed[0] * Math.Sin(Math.PI - ((Math.PI * movesettick[0] - Math.PI) / (movesetdensity[0] - 1)) + movesetvariant[0]);
            bossprojxsp[bossprojcount] = movesetspeed[0] * Math.Cos(Math.PI - ((Math.PI * movesettick[0] - Math.PI) / (movesetdensity[0] - 1)) + movesetvariant[0]);
            bossprojcolor[bossprojcount] = Brushes.Pink;
            bossproj[bossprojcount] = true;
            bossprojcount++;
            movesettick[0]++;
            if (movesettick[0] == movesetdensity[0] +1) { moveset[0] = false; movesettick[0] = 1; }
            if (bossprojcount == bossprojmax -1) { bossprojcount = 0; }
        }

        public void move1() //swipe left
        {
            bossprojy[bossprojcount] = bossy;
            bossprojx[bossprojcount] = bossx;
            bossprojysp[bossprojcount] = movesetspeed[1] * Math.Sin(((Math.PI * movesettick[1] - Math.PI) / (movesetdensity[1] - 1)) + movesetvariant[1]);
            bossprojxsp[bossprojcount] = movesetspeed[1] * Math.Cos(((Math.PI * movesettick[1] - Math.PI) / (movesetdensity[1] - 1)) + movesetvariant[1]);
            bossprojcolor[bossprojcount] = Brushes.Aqua;
            bossproj[bossprojcount] = true;
            bossprojcount++;
            movesettick[1]++;
            if (movesettick[1] == movesetdensity[1] + 1) { moveset[1] = false; movesettick[1] = 1; }
            if (bossprojcount == bossprojmax -1) { bossprojcount = 0; }
        }

        public void move2() //circle
        {
            for (int i = 0; i < movesetdensity[2]; i++)
            {
                bossprojy[bossprojcount] = bossy;
                bossprojx[bossprojcount] = bossx;
                bossprojysp[bossprojcount] = movesetspeed[2] * Math.Sin(2 * Math.PI * i / movesetdensity[2] + movesetvariant[2]);
                bossprojxsp[bossprojcount] = movesetspeed[2] * Math.Cos(2 * Math.PI * i / movesetdensity[2] + movesetvariant[2]);
                bossprojcolor[bossprojcount] = Brushes.LightGreen;
                bossproj[bossprojcount] = true;
                bossprojcount++;
                if (bossprojcount == bossprojmax -1) { bossprojcount = 0; }
            }
            movesettick[2]++;
            if (movesettick[2] == 2) { moveset[2] = false; movesettick[2] = 1; }
        }

        public void move3() //aim
        {
            if (movesettick[3] % 5 == 0)
            { 
                bossprojy[bossprojcount] = bossy;
                bossprojx[bossprojcount] = bossx;
                bossprojysp[bossprojcount] = movesetspeed[3] * Math.Sin(Math.Atan2((playery - bossy), (playerx - bossx)));
                bossprojxsp[bossprojcount] = movesetspeed[3] * Math.Cos(Math.Atan2((playery - bossy), (playerx - bossx)));
                bossprojcolor[bossprojcount] = Brushes.Yellow;
                bossproj[bossprojcount] = true;
                bossprojcount++;
            }
            movesettick[3]++;
            if (movesettick[3] == 5 * movesetdensity[3] + 1) { moveset[3] = false; movesettick[3] = 1; }
            if (bossprojcount == bossprojmax -1) { bossprojcount = 0; }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                if (e.KeyCode == keyobject[i])
                {
                    keypressed[i] = true;
                }
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                if (e.KeyCode == keyobject[i])
                {
                    keypressed[i] = false;
                }
            }
        }

        private void ptb_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < playerprojmax; i++)
            {
                if (playerproj[i] == true)
                {
                    createSq(playerprojx[i], playerprojy[i], 8, Brushes.White, e);
                }
            }
            for (int i = 0; i < bossprojmax; i++)
            {
                if (bossproj[i] == true)
                {
                    createSq(bossprojx[i], bossprojy[i], 20, bossprojcolor[i], e);
                }
            }
            createSq(bossx, bossy, 100, Brushes.Green, e);
            createSq(playerx, playery, 10, Brushes.Red, e);
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            timertick++;

            if (keypressed[0] == true) { playery = playery - playersp; }
            else if (keypressed[2] == true) { playery = playery + playersp; }
            if (keypressed[1] == true) { playerx = playerx - playersp; }
            else if (keypressed[3] == true) { playerx = playerx + playersp; }
            if (keypressed[5] == true) { playerprojdensity = 1; line = 0; }
            else if (keypressed[6] == true) { playerprojdensity = 2; line = 0; }
            else if (keypressed[7] == true) { playerprojdensity = 3; line = 0; }

            for (int i = 0; i < playerprojmax; i++)
            {
                if (playerprojdensity == 1)
                {
                    if (playerproj[i] == true) { playerprojxsp[i] = 0; playerprojysp[i] = -13; }
                }
                else if (playerprojdensity == 2)
                {
                    if (line == 0)
                    { if (playerproj[i] == true) { playerprojxsp[i] = -1.08; playerprojysp[i] = -12.96; } line = 1; }
                    else if (line == 1)
                    { if (playerproj[i] == true) { playerprojxsp[i] = 0; playerprojysp[i] = -13; } line = 2; }
                    else if (line == 2)
                    { if (playerproj[i] == true) { playerprojxsp[i] = 0; playerprojysp[i] = -13; } line = 3; }
                    else if (line == 3)
                    { if (playerproj[i] == true) { playerprojxsp[i] = 1.08; playerprojysp[i] = -12.96; } line = 0; }
                }
                else if (playerprojdensity == 3)
                {
                    if (line == 0)
                    { if (playerproj[i] == true) { playerprojxsp[i] = -3.21; playerprojysp[i] = -12.59; } line = 1; }
                    else if (line == 1)
                    { if (playerproj[i] == true) { playerprojxsp[i] = -1; playerprojysp[i] = -12.96; } line = 2; }
                    else if (line == 2)
                    { if (playerproj[i] == true) { playerprojxsp[i] = 1; playerprojysp[i] = -12.96; } line = 3; }
                    else if (line == 3)
                    { if (playerproj[i] == true) { playerprojxsp[i] = 3.21; playerprojysp[i] = -12.59; } line = 0; }
                }
                    playerprojx[i] = playerprojx[i] + playerprojxsp[i];
                    playerprojy[i] = playerprojy[i] + playerprojysp[i];

                    if (playerproj[i] == true)
                    {
                        if (playerprojx[i] < 0 || playerprojx[i] > 300 || playerprojy[i] < 0 || playerprojy[i] > 480)
                        {
                            playerproj[i] = false;
                        }
                        if (playerprojx[i] < bossx + 33 && playerprojx[i] > bossx - 33 && playerprojy[i] < bossy + 33 && playerprojy[i] > bossy - 33)
                        {
                            playerproj[i] = false;
                            bosshp--;
                            lblHP.Text = "Boss HP: " + bosshp;
                        }
                    }
            }

            for (int i = 0; i < bossprojmax; i++)
            {
                if (bossproj[i] == true)
                {
                    bossprojx[i] = bossprojx[i] + bossprojxsp[i];
                    bossprojy[i] = bossprojy[i] + bossprojysp[i];
                    if (bossprojx[i] < 0 || bossprojx[i] > 300 || bossprojy[i] < 0 || bossprojy[i] > 480)
                    {
                        bossproj[i] = false;
                    }
                    if (playerx < bossprojx[i] + 6 && playerx > bossprojx[i] - 6 && playery < bossprojy[i] + 8 && playery > bossprojy[i] - 4)
                    {
                        bossproj[i] = false;
                        tmr.Enabled = false;
                        MessageBox.Show("YOU DIED.");
                    }
                }
            }

            if (bosshp <= 1500 && bosshp > 1000) { difficulty = 2; }
            if (bosshp <= 1000 && bosshp > 500) { difficulty = 3; }
            if (bosshp <= 500 && bosshp > 0) { difficulty = 4; }
            if (bosshp <= 0) { difficulty = 0; }

            if (difficulty == 1)
            {
                if (timertick % 40 == 1) { moveset[0] = true; movesetvariant[0] = 0.5 - rnd.NextDouble(); }
                if (timertick % 40 == 21) { moveset[1] = true; movesetvariant[1] = 0.5 - rnd.NextDouble(); }
                if (timertick % 80 == 1) { moveset[2] = true; movesetvariant[2] = 0.5 - rnd.NextDouble(); }
            }
            else if (difficulty == 2)
            {
                if (timertick % 30 == 1) { moveset[0] = true; movesetvariant[0] = 0.5 - rnd.NextDouble(); }
                if (timertick % 30 == 16) { moveset[1] = true; movesetvariant[1] = 0.5 - rnd.NextDouble(); }
                if (timertick % 60 == 1) { moveset[2] = true; movesetvariant[2] = 0.5 - rnd.NextDouble(); }
            }
            else if (difficulty == 3)
            {
                if (timertick % 20 == 1) { moveset[0] = true; movesetvariant[0] = 0.5 - rnd.NextDouble(); }
                if (timertick % 20 == 11) { moveset[1] = true; movesetvariant[1] = 0.5 - rnd.NextDouble(); }
                if (timertick % 40 == 1) { moveset[2] = true; movesetvariant[2] = 0.5 - rnd.NextDouble(); }
                if (timertick % 40 == 21) { moveset[3] = true; }
            }
            else if (difficulty == 4)
            {
                movesetdensity[0] = 20;
                movesetdensity[1] = 20;    
                movesetdensity[2] = 40;    
                movesetdensity[3] = 4;  
                movesetspeed[0] = 5;
                movesetspeed[1] = 5;    
                movesetspeed[2] = 5;    
                movesetspeed[3] = 10; 

                if (timertick % 20 == 1) { moveset[0] = true; movesetvariant[0] = 0.5 - rnd.NextDouble(); }
                if (timertick % 20 == 11) { moveset[1] = true; movesetvariant[1] = 0.5 - rnd.NextDouble(); }
                if (timertick % 10 == 1) { moveset[2] = true; movesetvariant[2] = 0.5 - rnd.NextDouble(); }
                if (timertick % 20 == 6) { moveset[3] = true; }
            }
            /*
            if (timertick % 20 == 1) { moveset[0] = true; movesetvariant[0] = 0.5 - rnd.NextDouble(); }
            if (timertick % 20 == 11) { moveset[1] = true; movesetvariant[1] = 0.5 - rnd.NextDouble(); }
            if (timertick % 40 == 1) { moveset[2] = true; movesetvariant[2] = 0.5 - rnd.NextDouble(); }
            
             */

            if (moveset[0] == true) { move0(); }
            if (moveset[1] == true) { move1(); }
            if (moveset[2] == true) { move2(); }
            if (moveset[3] == true) { move3(); } 

            if (keypressed[4] == true)
            {
                for (int i = 0; i < 4; i++)
                {
                    playerproj[playerprojcount] = true;
                    playerprojx[playerprojcount] = playerx + 8*i - 12;
                    playerprojy[playerprojcount] = playery;
                    if (playerprojcount == playerprojmax -1) { playerprojcount = 0; }
                    else { playerprojcount++; }
                }
            }

            

            ptb.Refresh();
        }

    }
}
