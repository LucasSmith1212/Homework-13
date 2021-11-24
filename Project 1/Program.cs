// Week 13 Project 1
// File Name: week13project1.cs
// Author: Lucas Smith
// Date:  November 24, 2021
//
// Problem Statement: Write a program that reads both the girl’s and boy’s files into memory using a dictionary. The key should be the name and value should be a user defined object which is the count and rank of the name.
// Allow the user to input a name, the program should find the name in the dictionary and print out the rank and the number of namings. If the name isn’t a key in the dictionary then the program should note this and say that no match exists.
// 
// 
// Overall Plan:
// 1) Add all the System programs required
// 2) Create strings that have the paths for the two files (change it out for a different computer)
// 3) If the files already exist inside the program, delete them (this actually deleted them from my computer permanently)
// 4) Add the string names and their popularity to the dictionaries using for loops and Split()
// 5) Use an infinite while loop to run the program as many times as the user wants, then have them press Q to quit the program.
//
//
// There seems to be an issue with the connection to the files on my computer, even after I re-download them. I don't know if it works on your computer, professor.
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Project_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string boyPath = @"C:\Users\rss44\OneDrive\Desktop\boynames.txt";
            string girlPath = @"C:\Users\rss44\OneDrive\Desktop\girlnames.txt";

            if (File.Exists(boyPath))
            {
                File.Delete(boyPath);
            }

            if (File.Exists(girlPath))
            {
                File.Delete(girlPath);
            }

            Dictionary<string, int> boyDic = new Dictionary<string, int>();
            Dictionary<string, int> girlDic = new Dictionary<string, int>();

            
            using (FileStream fs = File.Create(boyPath))
            {
                
                foreach (string line in System.IO.File.ReadAllLines(boyPath))
                {
                    string[] list = { };
                    
                    list = line.Split(' ');

                    boyDic.Add(list[0], Convert.ToInt32(list[1]));
                }
            }

            using (FileStream fsTwo = File.Create(girlPath))
            {
                
                foreach (string line in System.IO.File.ReadAllLines(girlPath))
                {
                    string[] list;

                    list = line.Split(' ');
                    girlDic.Add(list[0], Convert.ToInt32(list[1])); 
                }
            }

            while (true)
            {
                Console.WriteLine("Type in the name you would like to search for in popularity (Format: Emily): ");
                string nameToSearch = Console.ReadLine();

                bool containsName = girlDic.ContainsKey(nameToSearch);
                bool secondTest;
                if (containsName == true)
                {
                    Console.WriteLine(nameToSearch + girlDic[nameToSearch]);
                } else if (containsName == false)
                {
                    secondTest = boyDic.ContainsKey(nameToSearch);

                    if (secondTest == true)
                    {
                        Console.WriteLine(nameToSearch + boyDic[nameToSearch]);
                    }
                    else if (containsName == false && secondTest == false)
                    {
                        Console.WriteLine("Your name is not on the popularity list. Please try again with a different name.");
                    }
                }

                Console.WriteLine("If you would like to continue, press Y. If you don't, hit Q.");
                char quitOrNo = Convert.ToChar(Console.ReadLine());

                if (quitOrNo == 'Q')
                {
                    System.Environment.Exit(0);
                }
            }
        }
    }
}
