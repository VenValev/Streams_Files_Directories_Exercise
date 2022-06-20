namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            //1. прочетем четните редовете
            //2. заменим символите с @
            //3. reverse words
            StringBuilder s = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int counter = -1; //брой редовете
                string line = reader.ReadLine(); //четем по 1 ред от файла

                while (line != null)
                {
                    counter++;
                    if (counter % 2 == 0)
                    {
                        //замяна
                        line = Replace(line);
                        //обърна в обратен ред
                        line = Reverse(line);
                        //Console.WriteLine(line);
                        s.AppendLine(line);
                    }

                    line = reader.ReadLine();
                }
            }
            return s.ToString();
        }

        public static string Reverse(string line)
        {   //"@I was quick to judge him@ but it wasn't his fault@".Split()
            //["@I", "was", "quick", "to", "judge", "him@", "but", "it", "wasn't", "his", "fault@"].Reverse()
            //["fault@", "his", "wasn't", "it", "but", "him@", "judge", "to", "quick", "was", "@I"].Join(" ")
            //"fault@ his wasn't it but him@ judge to quick was @I"
            return string.Join(" ", line.Split().Reverse());
        }

        public static string Replace(string line) //върне реда със заместени символи
        {
            //-I was quick to judge him, but it wasn't his fault.
            //@I was quick to judge him@ but it wasn't his fault@
            return line.Replace("-", "@")
                 .Replace(",", "@")
                 .Replace(".", "@")
                 .Replace("!", "@")
                 .Replace("?", "@");
        }
    }
}