/*
 * Read From File
 * Pawelski
 * 11/14/2023
 * Developing Desktop Applications
 * 
 * Instructions:
 * First, run the program. What does it do? To understand this program,
 * let's break it down into the individual lines. Consider this line of code...
 * 
 * const string FILE_PATH = @"BabyNames.txt";
 * 
 * What does this line of code do? What does the @ before the string mean?
 * Where is the file located? (HINT: You may want to open the project folder 
 * in File Explorer or switch to the Folder View in Solution Explorer.) How
 * is the file organized?
 * Next, let's talk about this line of code...
 * 
 * FileStream file = new FileStream(FILE_PATH, FileMode.Open, FileAccess.Read);
 * 
 * What does this line of code do? What is the purpose of FileMode and FileAccess?
 * What values can each be? What does each mean?
 * Next, let's look at this line of code...
 * 
 * StreamReader reader = new StreamReader(file);
 * 
 * What does this line of code do?
 * Next, let's add a breakpoint on line 59 and step through the program in debugging
 * mode. What does the loop do in this program? What does !reader.EndOFStream mean?
 * Next, what do these lines of code do?
 * 
 * reader.Close();
 * file.Close();
 * 
 * Finally, try deleting the following line of code...
 * 
 * using System.IO;
 * 
 * The program no longer works! Why?
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            const string FILE_PATH = @"BabyNames.txt";
            FileStream file = new FileStream(FILE_PATH, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            while(!reader.EndOfStream)
            {
                Console.WriteLine(reader.ReadLine());
            }

            reader.Close();
            file.Close();
        }
    }
}
