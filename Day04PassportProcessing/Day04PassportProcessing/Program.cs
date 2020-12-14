using System;
using System.Collections.Generic;
using System.IO;

namespace Day04PassportProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../passports.txt";

            int passports = PassportProcessing(path);

            Console.WriteLine(passports);
        }

        static int PassportProcessing(string path)
        {
            int passports = 0;

            using var sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                string current = sr.ReadLine();

                Dictionary<string, string> requiredFields = new Dictionary<string, string>();

                while (current != "" && current != null)
                {
                    ProcessCurrentLine(current, requiredFields);
                    current = sr.ReadLine();
                }

                if (requiredFields.Count == 8 || (requiredFields.Count == 7 && !requiredFields.ContainsKey("cid")))
                    passports++;
            }

            return passports;
        }

        static void ProcessCurrentLine(string current, Dictionary<string, string> requiredFields)
        {
            string[] fields = current.Split(' ');

            for (int i = 0; i < fields.Length; i++)
            {
                string[] field = fields[i].Split(':');

                if (!requiredFields.ContainsKey(field[0]))
                    requiredFields.Add(field[0], field[1]);
            }
        }
    }
}
