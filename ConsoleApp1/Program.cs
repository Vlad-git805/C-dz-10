using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public delegate void CountDelegate(int x);

    class SuperCounter
    {
        private CountDelegate algoritm;

        public SuperCounter()
        {
            algoritm = delegate (int limit)
            {
                for (int i = 0; i < limit; i++)
                {
                    Console.Write(i + "  ");
                }
            };
        }

        public SuperCounter(CountDelegate algo)
        {
            algoritm = algo;
        }

        public void Set_algoritm(CountDelegate algo)
        {
            algoritm += algo;
        }

        public void Calculate(int limit)
        {
            int i = 1;
            foreach (var item in algoritm.GetInvocationList())
            {
                Console.Write( i + " - ");
                Console.WriteLine(((CountDelegate)item).Method.Name);
                i++;
            }
            Console.WriteLine("Enter algorint: ");
            Console.WriteLine();
            int numbe = int.Parse(Console.ReadLine());
            ((CountDelegate)algoritm.GetInvocationList()[numbe - 1]).Invoke(limit);
        }
    }

    class Program
    {

        private static int Fact(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Fact(x - 1);
            }
        }

        public static void Factorial(int limit)
        {
            for (int i = 1; i <= limit; i++)
            {
                Console.Write(Fact(i) + "  ");
            }
        }

        public static void Fibanachi(int limit)
        {
            int count = 0, count_1 = 1, count_2 = 1;
            Console.Write(count_1 + "  " + count_2 + "  ");
            for (; count < limit;)
            {
                    
                count = count_1 + count_2;
                Console.Write(count + "  ");
                count_1 = count_2;
                count_2 = count;
            }
        }

        public static void Step_2(int limit)
        {
            for (int i = 0; i < limit; i++)
            {
                Console.Write(i * i + "  ");
            }
        }

        public static void Simple_numbers(int limit)
        {
            for (int i = 0; i < limit; i++)
            {
                Console.Write(i + "  ");
            }
        }

        static void Main(string[] args)
        {
            CountDelegate countDelegate = Factorial;
            countDelegate += Fibanachi;
            countDelegate += Step_2;

            //SuperCounter superCounter = new SuperCounter();
            //superCounter.Calculate(150);

            SuperCounter superCounter = new SuperCounter(countDelegate);
            superCounter.Calculate(150);
        }
    }
}
