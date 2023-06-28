using System;

namespace CountVowels
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!UserInput.TryReadString("Pls enter a sentence", out string str1))
                return;

            int count = 0;
            foreach (var item in str1.ToLower())
            {
                if ("aeiouy".Contains(item))
                    count++;

                /*
                foreach (var c in "aeiouy")
                {
                    if (item == c)
                        count++;
                }
                */
            }

            Console.WriteLine($"'{str1}' contains {count} vowels");
        }
    }
}
