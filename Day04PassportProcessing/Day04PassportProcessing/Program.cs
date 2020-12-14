using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

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

                if (ValidatePassport(requiredFields))
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

        static bool ValidatePassport(Dictionary<string, string> requiredFields)
        {
            if (requiredFields.Count < 7)
                return false;

            if (requiredFields.Count == 7 && requiredFields.ContainsKey("cid"))
                return false;

            Int32.TryParse(requiredFields["byr"], out int byr);
            if (byr < 1920 || byr > 2002)
                return false;

            Int32.TryParse(requiredFields["iyr"], out int iyr);
            if (iyr < 2010 || iyr > 2020)
                return false;

            Int32.TryParse(requiredFields["eyr"], out int eyr);
            if (eyr < 2020 || eyr > 2030)
                return false;

            Regex hgt = new Regex(@"[0-9]*");
            if (requiredFields["hgt"].Substring(requiredFields["hgt"].Length - 2) == "cm")
            {
                Int32.TryParse(hgt.Match(requiredFields["hgt"]).ToString(), out int cm);
                if (cm < 150 || cm > 193)
                    return false;
            }
            else if (requiredFields["hgt"].Substring(requiredFields["hgt"].Length - 2) == "in")
            {
                Int32.TryParse(hgt.Match(requiredFields["hgt"]).ToString(), out int inch);
                if (inch < 59 || inch > 76)
                    return false;
            }
            else
                return false;

            Regex hcl = new Regex(@"^#([0-9]|[a-f]){6}");
            if (!hcl.IsMatch(requiredFields["hcl"]))
                return false;

            Regex ecl = new Regex(@"amb|blu|brn|gry|grn|hzl|oth");
            if (!ecl.IsMatch(requiredFields["ecl"]))
                return false;

            if (requiredFields["pid"].Length != 9)
                return false;

            return true;
        }
    }
}
