using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class SealedSingletonRun
    {
        public static void Run()
        {

            SealedSingleton fromTeachaer = SealedSingleton.GetInstance;
            fromTeachaer.PrintDetails("From Teacher");
            SealedSingleton fromStudent = SealedSingleton.GetInstance;
            fromStudent.PrintDetails("From Student");

            /*
             * Instantiating singleton from a derived class. 
             * This violates singleton pattern principles.
             */
            SealedSingleton.DerivedSingleton derivedObj = new SealedSingleton.DerivedSingleton();
            derivedObj.PrintDetails("From Derived");

            Console.ReadLine();

        }
    }

    public class SealedSingleton
    {
        private static int counter = 0;
        private static SealedSingleton? instance = null;

        public static SealedSingleton GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new SealedSingleton();
                return instance;
            }
        }

        private SealedSingleton()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }

        public class DerivedSingleton : SealedSingleton
        {
        }
    }
}
