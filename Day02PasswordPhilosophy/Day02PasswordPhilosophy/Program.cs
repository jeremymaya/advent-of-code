using System;
using System.IO;

namespace Day02PasswordPhilosophy
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../passwords.txt";

            int valid = PasswordPhilosophy(path);

            Console.WriteLine(valid);
        }

        static int PasswordPhilosophy(string path)
        {
            int valid = 0;

            try
            {
                using var sr = new StreamReader(path);
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(' ');
                    string[] range = line[0].Split('-');

                    int appear = CountLetter(line[1][0], line[2]);

                    if (appear >= Int32.Parse(range[0]) && appear <= Int32.Parse(range[1]))
                        valid++;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return valid;
        }

        static int CountLetter(char letter, string password)
        {
            int appear = 0;

            for (int i = 0; i < password.Length; i++)
                if (letter == password[i])
                    appear++;

            return appear;
        }
    }
}
