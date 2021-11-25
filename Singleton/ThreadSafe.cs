using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class ThreadSafeSingletonRun
    {
        public static void Run()
        {
            Parallel.Invoke(
                () => PrintTeacherDetails(),
                () => PrintStudentdetails(),
                   () => Omerdetails(),
                   () => Emredetails()

                );
            //Parallel.Invoke(
            //   () => Omerdetails(),
            //   () => Emredetails()
            //   );
            Console.ReadLine();
        }
        private static void PrintTeacherDetails()
        {
            ThreadSafeSingleton fromTeacher = ThreadSafeSingleton.GetInstance;
            fromTeacher.PrintDetails("From Teacher");
        }
        private static void PrintStudentdetails()
        {
            ThreadSafeSingleton fromStudent = ThreadSafeSingleton.GetInstance;
            fromStudent.PrintDetails("From Student");
        }
        private static void Omerdetails()
        {
            ThreadSafeSingleton fromStudent = ThreadSafeSingleton.GetInstance;
            fromStudent.PrintDetails("Omer");
        }
        private static void Emredetails()
        {
            ThreadSafeSingleton fromStudent = ThreadSafeSingleton.GetInstance;
            fromStudent.PrintDetails("Emre");
        }
    }

    public sealed class ThreadSafeSingleton
    {
        private static int counter = 0;
        private static ThreadSafeSingleton? instance = null;
        private static readonly object Instancelock = new object();

        public static ThreadSafeSingleton GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (Instancelock)
                    {
                        if (instance == null)
                            instance = new ThreadSafeSingleton();
                    }
                }
                return instance;
            }
        }
        private ThreadSafeSingleton()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}
