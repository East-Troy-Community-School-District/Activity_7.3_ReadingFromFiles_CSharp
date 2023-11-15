/*
 * Maximum Minimum
 * Pawelski
 * 11/14/2023
 * Developing Desktop Applications
 * 
 * Instructions:
 * What are the names of the text files in this program? How must you enter
 * the name of the file to get the program to work? How does this program allow
 * the user to decide what file to read? What happens when a file name is entered
 * that does not exist? Let's take a moment to discuss these lines of code...
 * 
 * FileStream file = null;
 * StreamReader reader = null;
 * 
 * In addition, let's talk about these lines of code...
 * 
 * reader?.Close();
 * file?.Close();
 * 
 * Finally, why did Mr. Pawelski need to use a list in this program? (HINT: Are
 * there the same amount of numbers in each file being read?)
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumMinimum
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;
            FileStream file = null;
            StreamReader reader = null;
            List<int> integers = new List<int>();

            Console.Write("Enter the full name of the file you would like to open. >> ");
            path = Console.ReadLine();

            try
            {
                file = new FileStream(path, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(file);
                while (!reader.EndOfStream)
                {
                    integers.Add(Convert.ToInt32(reader.ReadLine()));
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                reader?.Close();
                file?.Close();
            }

            try
            {
                Console.WriteLine("Minimum: " + Minimum(integers));
                Console.WriteLine("Maximum: " + Maximum(integers));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        /// <summary>
        /// Finds the minimum or lowest value in the list.
        /// </summary>
        /// <param name="nums">A non-empty list of integers.</param>
        /// <returns>Minimum or lowest value in the list.</returns>
        /// <exception cref="ArgumentException">Thrown when the list in empty.</exception>
        private static int Minimum(List<int> nums)
        {
            if (nums.Count == 0)
            {
                throw new ArgumentException("The list must be non-empty.");
            }
            int minimum = nums[0];
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] < minimum)
                {
                    minimum = nums[i];
                }
            }
            return minimum;
        }

        /// <summary>
        /// Finds the maximum or highest value in the list.
        /// </summary>
        /// <param name="nums">A non-empty list of integers.</param>
        /// <returns>Maximum or highest value in the list.</returns>
        /// /// <exception cref="ArgumentException">Thrown when the list in empty.</exception>
        private static int Maximum(List<int> nums)
        {
            if (nums.Count == 0)
            {
                throw new ArgumentException("The list must be non-empty.");
            }
            int maximum = nums[0];
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] > maximum)
                {
                    maximum = nums[i];
                }
            }
            return maximum;
        }
    }
}
