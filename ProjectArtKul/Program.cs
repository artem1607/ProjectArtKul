using System;

namespace ProjectArtKul
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            int n = 5;
            Console.WriteLine($"n={n}");
            int[] arr = {1, 2, 3, 4, 5};
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"n={i}");
                if(arr[i] == 2)
                {
                    Console.WriteLine("Hi");
                } 
                else
                {
                    Console.WriteLine("Good bye!!!");
                }
            }
        }
    }
}
