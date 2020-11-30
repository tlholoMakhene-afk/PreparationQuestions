using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    partial class Program
    {

        static void Main(string[] args)
        {
            ATMPriorityQueue<double> pq = new ATMPriorityQueue<double>();
            int num_ATMS = 3;
            double current_locqtion = 0.0;

            HashSet<KeyValuePair<string, double>> AllATMLocations = new HashSet<KeyValuePair<string, double>>(  )
            {
                new KeyValuePair<string, double>( "amt1", 45.2 ),
                new KeyValuePair<string, double>( "amt2", 80 ),
                new KeyValuePair<string, double>("amt3", 45.2) ,
                new KeyValuePair<string, double>("amt4", 64 ),
                new KeyValuePair<string, double>("amt5", 57 ),
                new KeyValuePair<string, double>("amt6", 1.00),
                new KeyValuePair<string, double>("amt7", 35),
                new KeyValuePair<string, double>("amt8", 78 )
            };


            foreach (var item in AllATMLocations)
            {
                if (pq.Count() < num_ATMS)
                {
                    pq.Enqueue(getLocation(current_locqtion, item.Value));
                }
                else
                {
                    if (pq.Peek() > getLocation(current_locqtion, item.Value))
                    {
                        pq.Dequeue();
                        pq.Enqueue(getLocation(current_locqtion, item.Value));
                    }
                }
            }

            Console.WriteLine("Priory queue is: ");
            pq.Order();
            Console.WriteLine(pq.ToString());
            Console.ReadKey();
        }

        private static double getLocation(double curr, double atm)
        {
            return atm - curr;
        }

    }
}
