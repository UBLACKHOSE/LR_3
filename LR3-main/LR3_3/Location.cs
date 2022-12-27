using System;
using System.Collections.Generic;
using System.Text;

namespace LR3_3
{
    public class Location
    {
        private int width { get; set; }
        private int height { get; set; }
        private string[,] map { get; set;  }
        Hero hero { get; set; }
        List<Enemy> enemies { get; set; }

        public Location(int w, int h)
        {
            width = w;
            height = h;
            map = new string[w,h];
            hero = new Hero("lOl", "X");
            enemies = new List<Enemy>();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    map[i, j] = "0";
                    if(i == hero.getX() && j == hero.getY())
                    {
                        map[i, j] = hero.getAvatar();
                    } 
                    if (i == width - 1 && j == height - 1)
                    {
                        map[i, j] = "$";
                    }
                }
            }
        }


        public Enemy proverka(int x,int y)
        {
            foreach(var enem in enemies)
            {
                if (enem.getX() == x && enem.getY() == y)
                {
                    return enem;
                }
            }
            return null;
        }


        public void Print()
        {
            
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {

                    if (i == hero.getX() && j == hero.getY())
                    {
                        Console.Write(hero.getAvatar());
                    } 
                    else if ((i == width - 1 && j == height - 1)&& (hero.getRiches() == false))
                    {
                        Console.Write("$");
                    }
                    else if (proverka(i,j) != null)
                    {
                        Console.Write( proverka(i, j).GetAvatar());
                    }
                    else
                    {
                        Console.Write("0");
                    }
                }
                Console.WriteLine();
            }
        }

        public void MovingHero(int directions)
        {
            switch(directions)
            {
                case 1: if(0 != hero.getX())
                    {
                        if (proverka(hero.getX() - 1, hero.getY()) != null)
                        {
                            hero.Hit(proverka(hero.getX() - 1, hero.getY()).getDamage());
                        }
                        else if (map[hero.getX() - 1, hero.getY()] == "$") {
                            hero.setRiches(true);
                            hero.Moving(hero.getX() - 1, hero.getY());
                        }
                        else
                        {
                            hero.Moving(hero.getX() - 1, hero.getY());
                        }
                    }
                    break;
                case 2:
                    if (width != hero.getY())
                    {
                        if (proverka(hero.getX(), hero.getY() + 1) != null)
                        {
                            hero.Hit(proverka(hero.getX(), hero.getY() + 1).getDamage());
                        }
                        else if (map[hero.getX(), hero.getY() + 1] == "$")
                        {
                            hero.setRiches(true);
                            hero.Moving(hero.getX(), hero.getY() + 1);
                        }
                        else
                        {
                            hero.Moving(hero.getX(), hero.getY() + 1);
                        }
                    }
                    break;
                case 3:
                    if (height != hero.getX())
                    {

                        if (proverka(hero.getX() + 1, hero.getY()) != null)
                        {
                            hero.Hit(proverka(hero.getX() + 1, hero.getY()).getDamage());
                        }
                        else if (map[hero.getX() + 1, hero.getY()] == "$")
                        {
                            hero.setRiches(true);
                            hero.Moving(hero.getX() + 1, hero.getY());
                        }
                        else
                        {
                            hero.Moving(hero.getX() + 1, hero.getY());
                        }
                    }
                    break;
                case 4:
                    if (0 != hero.getY())
                    {
                        if (proverka(hero.getX(), hero.getY() - 1) != null)
                        {
                            hero.Hit(proverka(hero.getX(), hero.getY() - 1).getDamage());
                        }
                        else if (map[hero.getX(), hero.getY() - 1] == "$")
                        {
                            hero.setRiches(true);
                            hero.Moving(hero.getX(), hero.getY() - 1);
                        }
                        else
                        {
                            hero.Moving(hero.getX(), hero.getY() - 1);
                        }


                    }
                    break;
            }
        }



        public void MovingEnemy()
        {

           foreach(var en in enemies)
            {
                if(en.avatar == "M")
                {
                    var rand = new Random();
                    int directions = rand.Next(4);
                    switch (directions)
                    {
                        case 0:
                            if (0 != en.getX())
                            {
                                if (hero.getX() == en.getX() - 1 && hero.getY() == en.getY())
                                {
                                    hero.Hit(en.getDamage());
                                }
                                else if (proverka(en.getX() - 1, en.getY()) ==null)
                                {
                                    en.Moving(en.getX() - 1, en.getY());
                                }
                            }
                            break;
                        case 1:
                            if (width != en.getY())
                            {

                                if (hero.getX() == en.getX() && hero.getY() == en.getY() + 1)
                                {
                                    hero.Hit(en.getDamage());
                                }
                                else if (proverka(en.getX(), en.getY() + 1) != null)
                                {
                                    en.Moving(en.getX(), en.getY() + 1);
                                }
                            }
                            break;
                        case 2:
                            if (height != en.getX())
                            {

                                if (hero.getX() == en.getX()+1 && hero.getY() == en.getY())
                                {
                                    hero.Hit(en.getDamage());
                                }
                                else if (proverka(en.getX() + 1, en.getY()) != null)
                                {
                                    en.Moving(en.getX() + 1, en.getY() );
                                }
                            }
                            break;
                        case 3:
                            if (0 != en.getY())
                            {

                                if (hero.getX() == en.getX() && hero.getY() == en.getY() - 1)
                                {
                                    hero.Hit(en.getDamage());
                                }
                                else if (proverka(en.getX(), en.getY() - 1) != null)
                                {
                                    en.Moving(en.getX(), en.getY() - 1);
                                }
                            }
                            break;
                    }
                }
            }


        }

        public void AddEnemy(Enemy enemy)
        {
            enemies.Add(enemy);
        }
    }
}
