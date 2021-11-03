using System;
using System.Collections.Generic;
using System.Linq;

namespace ListCollectionSortReverseMethodDemo
{
    public class Program
    {

        public delegate void Omer();

        public static void Main()
        {
            List<int> integerList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };


            Console.WriteLine(integerList.Where(NewMethod2).FirstOrDefault());
            Console.WriteLine(integerList.Where(NewMethod()).FirstOrDefault());
            Console.ReadKey();
        }

        private static Func<int, bool> NewMethod()
        {
            return x => x == 5;
        }

        private static bool NewMethod2(int X)
        {
            return true;
        }

        public Omer MyMethod()
        {
            return MyMethod2;
        }

        public void MyMethod2()
        {

            throw new NotImplementedException();
        }
    }

}