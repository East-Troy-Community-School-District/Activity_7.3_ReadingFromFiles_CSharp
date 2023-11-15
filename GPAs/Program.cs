/*
 * GPAs
 * Pawelski
 * 11/14/2023
 * Developing Desktop Applications
 * 
 * Instructions:
 * Where is the StudentData.txt file located? How is the data structured?
 * What does the following line of code do in the program?
 * 
 * string[] fields = record.Split(',');
 * 
 * Is it necessary to use all fields in the data? If we needed to use both
 * fields in each record, how could we store the information locally?
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPAs
{
    class Program
    {
        static void Main(string[] args)
        {
            const string PATH = @"StudentData.txt";
            FileStream file = new FileStream(PATH, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            List<double> gpas = new List<double>();
            while(!reader.EndOfStream)
            {
                string record = reader.ReadLine();
                string[] fields = record.Split(',');
                gpas.Add(Convert.ToDouble(fields[1]));
            }
            reader.Close();
            file.Close();

            Console.WriteLine("Average GPA: " + Math.Round(Average(gpas), 3));
        }

        /// <summary>
        /// Calculates the average of the numbers.
        /// </summary>
        /// <param name="nums">Non-empty list of numbers.</param>
        /// <returns>Average of the numbers.</returns>
        /// <exception cref="ArgumentException">Thrown when list is empty.</exception>
        private static double Average(List<double> nums)
        {
            if (nums.Count == 0)
            {
                throw new ArgumentException("The list cannot be empty.");
            }

            double total = 0.0;
            foreach(double num in nums)
            {
                total += num;
            }
            return total / nums.Count;
        }
    }
}
