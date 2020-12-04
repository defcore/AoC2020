using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Puzzle4
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int validPasswords = 0;
            string passwordString = "";


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
                    passwordString += line + ' ';
                    foreach (string key in requiredFields)
                    {
                        if (line.Contains(key + ':'))
                            counter++;
                    }
                }
                else
                {
                    if (counter == 7)
                    {
                        var isValid = true;
                        var password = passwordString.Trim().Split(' ');
                        foreach (string values in password)
                        {

                            var tmp = values.Split(':');
                            if (tmp[0] == "byr")
                            {
                                if (Int32.Parse(tmp[1]) < 1920 || Int32.Parse(tmp[1]) > 2002)
                                {
                                    isValid = false;
                                    break;
                                }
                            }
                            else if (tmp[0] == "iyr")
                            {
                                if (Int32.Parse(tmp[1]) < 2010 || Int32.Parse(tmp[1]) > 2020)
                                {
                                    isValid = false;
                                    break;
                                }
                            }
                            else if (tmp[0] == "eyr")
                            {
                                if (Int32.Parse(tmp[1]) < 2020 || Int32.Parse(tmp[1]) > 2030)
                                {
                                    isValid = false;
                                    break;
                                }
                            }
                            else if (tmp[0] == "hgt")
                            {
                                if (tmp[1].Contains("cm"))
                                {
                                    if (Int32.Parse(tmp[1].Replace("cm", "")) < 150 || Int32.Parse(tmp[1].Replace("cm", "")) > 193)
                                    {
                                        isValid = false;
                                        break;
                                    }
                                }
                                else if (tmp[1].Contains("in"))
                                {
                                    if (Int32.Parse(tmp[1].Replace("in", "")) < 59 || Int32.Parse(tmp[1].Replace("in", "")) > 76)
                                    {
                                        isValid = false;
                                        break;
                                    }
                                }
                                else
                                    isValid = false;
                            }
                            else if (tmp[0] == "hcl")
                            {
                                if (!tmp[1].StartsWith("#"))
                                {
                                    isValid = false;
                                    break;
                                }
                                if (tmp[1].Length != 7)
                                {
                                    isValid = false;
                                    break;
                                }
                                if (!Regex.Match(tmp[1].Substring(1, tmp[1].Length - 1), "[a-z0-9]+", RegexOptions.IgnoreCase).Success)
                                {
                                    isValid = false;
                                    break;
                                }
                            }
                            else if (tmp[0] == "ecl")
                            {
                                if (!((tmp[1] == "amb") || (tmp[1] == "blu") || (tmp[1] == "brn") || (tmp[1] == "gry") || (tmp[1] == "grn") || (tmp[1] == "hzl") || (tmp[1] == "oth")))
                                {
                                    isValid = false;
                                    break;
                                }
                            }
                            else if (tmp[0] == "pid")
                            {
                                if (tmp[1].Length != 9)
                                {
                                    isValid = false;
                                    break;
                                }
                                else if (!Regex.Match(tmp[1], "[0-9]+", RegexOptions.IgnoreCase).Success)
                                {
                                    isValid = false;
                                    break;
                                }
                            }
                            else if (tmp[0] == "cid")
                            {
                                //ignore
                            }

                        }
                        if (isValid)
                        {
                            validPasswords++;
                        }


                    }
                    passwordString = "";
                    counter = 0;
                }
            }

            Console.WriteLine("There were {0} valid passwords.", validPasswords);
        }
    }
}
