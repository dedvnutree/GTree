// Tkachuk Pavel. Assignment 2 for class CS341
// TASK : https://cs.winona.edu/iyengar/CS%20341/Fall%202021/assignment%202%20F21.htm

using System;
using System.IO;

namespace Assignment2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var grandParentPath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString();
                var path = Path.Combine(grandParentPath, "tree.dat");
                string[] lines = System.IO.File.ReadAllLines(path);
                var tree = Gtree.Parse<int>(lines).ToString().Split('\n');
                
                File.WriteAllLines(Path.Combine(grandParentPath, "tree2.dat"), tree);
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }
    }
}