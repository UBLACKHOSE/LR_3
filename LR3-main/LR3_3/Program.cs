using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LR3_3
{
    class Program
    {



        static void Main(string[] args)
        {



            Location l = new Location(10,10);

            Moving_Enemy m_e = new Moving_Enemy(5, 5, 10);

            Enemy e = new Enemy(6, 7, 10);
            //Console.WriteLine(m_e.GetAvatar());


            l.AddEnemy(m_e);


            l.AddEnemy(e);
            l.Print();
            Console.WriteLine();
            l.MovingEnemy();

            l.MovingEnemy();
            l.MovingEnemy();
            l.MovingEnemy();
            l.MovingEnemy();
            l.Print();

            //while (true)
            //{
            //    int des;
            //    des = Convert.ToInt32(Console.ReadLine());
            //    l.MovingEnemy();
            //    l.MovingHero(des);
            //    l.Print();
            //}


            using (FileStream fs = new FileStream("enemy.json", FileMode.OpenOrCreate))
            {
                string[,] map = new string[10,10];
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        map[i, j] = "0";
                    }
                }
                JsonSerializer.SerializeAsync<string[,]>(fs, map);
                Console.WriteLine("Data has been saved to file");
            }

            //Console.WriteLine();
            //l.MovingHero(2);
            //l.MovingHero(3);
            //l.MovingHero(3);

            //l.Print();





        }
    }
    class Persons
    {
        public string Name { get; }
        public int Age { get; set; }
        public Persons(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
