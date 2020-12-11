using System;
using System.IO;

namespace Day03TobogganTrajectory
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../trees.txt";

            int trees = TobogganTrajectory(path);

            Console.WriteLine(trees);
        }

        static int TobogganTrajectory(string path)
        {
            int trees = 0;
            int position = 0;

            using var sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                if (sr.ReadLine()[position] == '#')
                    trees++;

                position = (position + 3) % 31;
            }

            return trees;
        }
    }
}
