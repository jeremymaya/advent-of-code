using System;
using System.Collections.Generic;
using System.IO;

namespace Day01ReportRepair
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../expense-report.txt";
            int year = 2020;

            int num = ReportRepair(year, path);

            Console.WriteLine(num);
        }

        static int ReportRepair(int year, string path)
        {
            Dictionary<int, int> nums = new Dictionary<int, int>();

            try
            {
                using var sr = new StreamReader(path);
                while (!sr.EndOfStream)
                    if (Int32.TryParse(sr.ReadLine(), out int current))
                        if (nums.ContainsKey(current))
                            return nums[current] * current;
                        else
                            nums.Add(year - current, current);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 0;
        }
    }
}
