using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionPractise
{
    class Program
    {
        public static int CalculateSumRecusrively(int n, int m)
        {
            int sum = n;
            if(n < m)
            {
                n++;
                return sum += CalculateSumRecusrively(n, m);
            }
            return sum;
        }
        static void reverseString(string str)
        {
            if ((str == null) || (str.Length <= 1))
                Console.Write(str);

            else
            {
                Console.Write(str[str.Length - 1]);
                reverseString(str.Substring(0, (str.Length - 1)));
            }
        }

        public static int CountEvenlyDivisions(double num)
        {
            int count = 0;
            if(num > 0 && num % 2 == 0)
            {
                count++;
                num /= 2;
                return count += CountEvenlyDivisions(num);
            }
            return count;
        }
        static void Main(string[] args)
        {
            int sum = CalculateSumRecusrively(1, 10);
            Console.WriteLine($"The calculated sum from 1 to 3 is equal to {sum}");

            int divisions = CountEvenlyDivisions(8);
            Console.WriteLine($"The number of divisions is equal to {divisions}");

            String str = "Geeks for Geeks";
            reverseString(str);
            Console.ReadKey();
        }
    }
}
