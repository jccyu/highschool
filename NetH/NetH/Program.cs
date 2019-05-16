using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetH
{
    class Program
    {
        static public int x = 0;
        static public int y = 0;

        static void Main(string[] args)
        {
            Dungeon Map1 = new Dungeon();
            ConsoleKeyInfo pressed = new ConsoleKeyInfo();
            x = Map1.xstart;
            y = Map1.ystart;
            DrawMap(Map1);

            while (true)
            {
                pressed = Console.ReadKey();
                if (pressed.Key == ConsoleKey.W && Map1.Index[x, y - 1] != 0 && Map1.Index[x, y - 1] != 2 && Map1.Index[x, y - 1] != 3)
                    y = y - 1;
                else if (pressed.Key == ConsoleKey.A && Map1.Index[x - 1, y] != 0 && Map1.Index[x - 1, y] != 2 && Map1.Index[x - 1, y] != 3)
                    x = x - 1;
                else if (pressed.Key == ConsoleKey.S && Map1.Index[x, y + 1] != 0 && Map1.Index[x, y + 1] != 2 && Map1.Index[x, y + 1] != 3)
                    y = y + 1;
                else if (pressed.Key == ConsoleKey.D && Map1.Index[x + 1, y] != 0 && Map1.Index[x + 1, y] != 2 && Map1.Index[x + 1, y] != 3)
                    x = x + 1;
                DrawMap(Map1);
            }
        }

        static void DrawMap(Dungeon map)
        {
            Console.Clear();
            for (int i = -8; i < 9; i++)
            {
                Console.Write("\n");
                for (int j = -20; j < 21; j++)
                {
                    if (i == 0 && j == 0)
                        Console.Write("@");
                    else if (x + j < 0 || x + j >= map.xmax || y + i < 0 || y + i >= map.ymax)
                        Console.Write(" ");
                    else if (map.Index[x + j, y + i] == 0)
                        Console.Write(" ");
                    else if (map.Index[x + j, y + i] == 1)
                        Console.Write(".");
                    else if (map.Index[x + j, y + i] == 2)
                        Console.Write("#");
                    else if (map.Index[x + j, y + i] == 3)
                        Console.Write("#");
                    else if (map.Index[x + j, y + i] == 4)
                        Console.Write("<");
                    else if (map.Index[x + j, y + i] == 5)
                        Console.Write(">");
                    else if (map.Index[x + j, y + i] == 6)
                        Console.Write("C");

                }
            }
        }
    }

    class Dungeon
    {
        public int[,] Index { get; set; }

        public int xmax = 100;
        public int ymax = 20;
        int xroommax = 12;
        int yroommax = 6;
        int xroommin = 6;
        int yroommin = 3;

        int x = 0;
        int y = 0;
        int xroom = 0;
        int yroom = 0;

        int xwall = 0;
        int ywall = 0;
        int wallcount = 0;
        int direction = -1; //^>v<

        int roommax = 20;
        int roommin = 15;

        int[] freq = {4,5,6,6,6,6,6,6,6,6,6};
        int xsprinkler = 0;
        int ysprinkler = 0;

        public int xstart = 0;
        public int ystart = 0;
        public int xend = 0;
        public int yend = 0;

        Random rnd = new Random();

        public Dungeon()
        {
            this.Index = new int[xmax, ymax];
            int room = rnd.Next(roommin, roommax);

            for (int i = 0; i < room; i++)
                TestRoom();

            Sprinkle();

        }

        public void Sprinkle()
        {
            bool overlap = true;
            for (int i = 0; i < freq.Length; i++)
            {
                overlap = true;
                while (overlap == true)
                {
                    overlap = false;
                    xsprinkler = rnd.Next(1, xmax);
                    ysprinkler = rnd.Next(1, ymax);
                    if (Index[xsprinkler, ysprinkler] != 1)
                        overlap = true;
                }
                Index[xsprinkler, ysprinkler] = freq[i];
                if(freq[i] == 4)
                {
                    xstart = xsprinkler;
                    ystart = ysprinkler;
                }
                if (freq[i] == 5)
                {
                    xend = xsprinkler;
                    yend = ysprinkler;
                }
            }
            
            
            
            


        }

        public void TestRoom()
        {
            if (wallcount != 0) //randomly pick a wall and do calc
                RandomWall();

            bool overlap1 = true;
            bool overlap2 = true;
            int overlaploop = 0;
            while (overlap1 == true) //error checks if the room fits
            {
                overlaploop++;
                overlap2 = true;
                while (overlap2 == true) //error checks randomizer if its out of xmax ymax bound.
                {
                    overlaploop++;
                    overlap2 = false;
                    overlap1 = false;
                    xroom = rnd.Next(xroommin, xroommax);
                    yroom = rnd.Next(yroommin, yroommax);

                    if (direction == -1) //first room
                    {
                        x = rnd.Next(1, xmax - xroom - 1);
                        y = rnd.Next(1, ymax - xroom - 1);
                    }
                    else //not first rooms
                    {
                        if (direction == 0)
                        {
                            x = rnd.Next(xwall - xroom + 1, xwall);
                            y = ywall - yroom;
                        }
                        else if (direction == 1)
                        {
                            x = xwall + 1;
                            y = rnd.Next(ywall - yroom + 1, ywall);
                        }
                        else if (direction == 2)
                        {
                            x = rnd.Next(xwall - xroom + 1, xwall);
                            y = ywall + 1;
                        }
                        else if (direction == 3)
                        {
                            x = xwall - xroom; ;
                            y = rnd.Next(ywall - yroom + 1, ywall);
                        }
                        if (x < 1 || x > xmax - xroom - 1 || y < 1 || y > ymax - yroom - 1) //error checks randomizer if its out of xmax ymax bound.
                        {
                            overlap2 = true;
                        }
                        if (overlaploop > 20) //re-randomize wall
                        {
                            overlaploop = 0;
                            RandomWall();
                        }
                    }
                }

                for (int i = 0; i < yroom; i++) //check if overlap with other tiles
                {
                    for (int j = 0; j < xroom; j++)
                    {
                        if (Index[x + j, y + i] != 0)
                        {
                            overlap1 = true;
                            break;
                        }
                    }
                    if (overlap1 == true)
                    {
                        break;
                    }
                }
                if (overlaploop >20)
                {
                    overlaploop = 0;
                    RandomWall();
                }
            }

            Create(); //create room
        }

        public void RandomWall()
        {
            int randomwall = 0;
            int randomwallcount = 0;
            bool overlap = true;
            while (overlap == true)
            {
                //Console.WriteLine("randomwall wallcount");
                overlap = false;
                randomwall = rnd.Next(1, wallcount);
                randomwallcount = 0;

                for (int i = 0; i < ymax; i++)
                {
                    for (int j = 0; j < xmax; j++)
                    {
                        if (Index[j, i] == 2)
                        {
                            randomwallcount++;
                            if (randomwallcount == randomwall)
                            {
                                xwall = j;
                                ywall = i;
                                break;
                            }
                        }
                    }
                }
                if (xwall - 1 < 0 || xwall + 1 >= xmax || ywall - 1 < 0 || ywall + 1 >= ymax)
                {
                    overlap = true;
                }
                else
                {
                    if (Index[xwall - 1, ywall] == 0)
                        direction = 3;
                    else if (Index[xwall + 1, ywall] == 0)
                        direction = 1;
                    else if (Index[xwall, ywall - 1] == 0)
                        direction = 0;
                    else if (Index[xwall, ywall + 1] == 0)
                        direction = 2;
                    else
                        overlap = true;
                }
            }


        }


        public void Create()
        {
            for (int i = -1; i <= yroom; i++)
            {
                for (int j = -1; j <= xroom; j++)
                {
                    if (i == -1 || i == yroom || j == -1 || j == xroom)
                    {
                        if ((i == -1 && j == -1) || (i == -1 && j == xroom) || (i == yroom && j == -1) || (i == yroom && j == xroom))
                        {
                            if (Index[x + j, y + i] == 2)
                                wallcount--;
                            Index[x + j, y + i] = 3;
                        }
                        else
                        {
                            if (Index[x + j, y + i] != 2)
                            {
                                Index[x + j, y + i] = 2;
                                wallcount++;
                            }
                        }


                    }
                    else
                        Index[x + j, y + i] = 1;
                }
            }

            if (direction != -1)
            {
                Index[xwall, ywall] = 1;
                wallcount--;
            }
        }
    }
}
