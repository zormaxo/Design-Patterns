using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class EagerSingletonRun
    {
        public static void Run()
        {

            //Parallel.Invoke(
            //       () => PrintTeacherDetails(),
            //       () => PrintStudentdetails()
            //       );

            PrintTeacherDetails();
            PrintStudentdetails();
            StaticTest.Write();
            StaticTest.Write();
        }

        private static void PrintTeacherDetails()
        {
            EagerSingleton fromTeacher = EagerSingleton.GetInstance;
            fromTeacher.PrintDetails("From Teacher");
        }
        private static void PrintStudentdetails()
        {
            EagerSingleton fromStudent = EagerSingleton.GetInstance;
            fromStudent.PrintDetails("From Student");
        }
    }

    public sealed class EagerSingleton
    {
        private static int counter = 0;
        //private static readonly EagerSingleton singleInstance = new EagerSingleton();
        private static readonly Lazy<EagerSingleton> singleInstance =  new Lazy<EagerSingleton>(() => new EagerSingleton());
        public List<int> omer = new List<int> { 1, 2 };

        public static EagerSingleton GetInstance
        {
            get
            {
                return singleInstance.Value;
            }

        }
        private EagerSingleton()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }

        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine(omer.Count);
            omer.Add(3);
        }
    }

    public static class StaticTest
    {
        public static List<int> omer = new List<int> { 1, 2 };

        public static void Write()
        {
            Console.WriteLine(omer.Count);
        }
    }
}
