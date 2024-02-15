using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace sadovniks
{
    class Program
    {
        const int n = 3;
        const int delay = 10;
        static int[,] sad =new int [n, n];
        static object locker = new object();
        public static void Gardener1()
        {
            
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {                    
                        if (sad[i, j] != 2)
                    {
                        int delay = sad[i, j];
                        sad[i, j] = 1;
                        Thread.Sleep(delay);
                    }
                           
                        //int delay2 = 1;
                      
                       //Console.Write($"({i},{j}) {sad[i, j]} ");
                    }                    
                }

        }
        public static void Gardener2()
        {
            
                for (int i = n-1; i > -1; i--)
                {
                    for (int j = n-1; j > -1; j--)
                    {

                    if (sad[j, i] != 1)
                    {
                        int delay = sad[i, j];
                        sad[j, i] = 2;
                        Thread.Sleep(delay);
                    }
                        //Console.Write($"({j},{i}) {sad[i, j]} ");
                    }
                }         
            
        }
        public static void Print()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{sad[i, j],3}");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sad[i, j] = random.Next(3,20);
                }                
            }
            Print();
            ThreadStart threadStart = new ThreadStart(Gardener1);
            Thread thread = new Thread(threadStart);
            //thread.Name = $"Stream {i}";
            thread.Start();

            Gardener2();
                        
            Print();
           
            Console.ReadKey();
        }
    }
}
