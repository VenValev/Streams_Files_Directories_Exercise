namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            int count = 0;
            List<string> output = new List<string>();

            foreach(string line in lines)
            {
                count++;
                
                int letters = line.Count(char.IsLetter);
                int symbols = line.Count(char.IsPunctuation);

                string modifiedLine = $"Line {count}: {line} ({letters})({symbols})";
                output.Add(modifiedLine);
            }
            File.WriteAllLines(outputFilePath, output);
        }
    }
}
