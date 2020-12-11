using System;
using System.IO;

namespace Day03TobogganTrajectory
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../trees.txt";

            int rightOne = TobogganTrajectory(path, 1, 1);
            int rightThree = TobogganTrajectory(path, 3, 1);
            int rightFive = TobogganTrajectory(path, 5, 1);
            int rightSeven = TobogganTrajectory(path, 7, 1);
            int downTwo = TobogganTrajectory(path, 1, 2);

            Console.WriteLine(rightOne);
            Console.WriteLine(rightThree);
            Console.WriteLine(rightFive);
            Console.WriteLine(rightSeven);
            Console.WriteLine(downTwo);

            long product = (long)rightOne * (long)rightThree * (long)rightFive * (long)rightSeven * (long)downTwo;

            Console.WriteLine(product);
        }

        static int TobogganTrajectory(string path, int right, int down)
        {
            int trees = 0;
            int x = 0;
            int y = 0;

            using var sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                string current = sr.ReadLine();

                if (down != 1 && y++ % down != 0)
                    continue;

                if (current[x] == '#')
                    trees++;

                x = (x + right) % current.Length;
            }

            return trees;
        }
    }
}
