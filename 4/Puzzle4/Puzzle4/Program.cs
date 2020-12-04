using System;
using System.IO;

namespace Puzzle4
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int validPasswords = 0;

            string[] requiredFields = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };     // cid not required

            var lines = File.ReadAllLines(Environment.CurrentDirectory + @"\..\..\..\input.txt");
            for (var i = 0; i < lines.Length + 1; i++)
            {
                string line = null;
                if (i < lines.Length)
                {
                    line = lines[i];
                }
                if (!String.IsNullOrEmpty(line))
                {
                    foreach (string key in requiredFields)
                    {
                        if (line.Contains(key + ':'))
                            counter++;
                    }
                }
                else
                {
                    if (counter == 7)
                        validPasswords++;
                    counter = 0;
                }
            }

            Console.WriteLine("There were {0} valid passwords.", validPasswords);
        }
    }
}
