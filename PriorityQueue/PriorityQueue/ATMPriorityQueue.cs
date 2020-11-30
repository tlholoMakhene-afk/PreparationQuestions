using System;
using System.Collections.Generic;

namespace PriorityQueue
{
    partial class Program
    {
        public class ATMPriorityQueue<T> where T : IComparable<T>
        {
            private Queue<T> data;

            public ATMPriorityQueue()
            {
                this.data = new Queue<T>();
            }

            public override string ToString()
            {
                string s = "";
                for (int i = 0; i < data.Count; ++i)
                    s += "ATM " + (i+1).ToString()  + " in " + data.ElementAt(i).ToString() + "meters ";
                return s;
            }

            public int Count()
            {
                return data.Count;
            }

            public T Dequeue()
            {
                return data.Dequeue();
            }

            public void Enqueue(T item)
            {
                data.Enqueue(item);
            }

            public T Peek()
            {
                return data.Peek();
            }
           public void Order()
            {
                Queue<T> q2 = new Queue<T>();
                foreach (T i in this.data.OrderBy(x => x))
                    q2.Enqueue(i);

                this.data = q2;
            }

        }

    }
}
