using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TimeTester
{
    static class StopwatchTest
    {
        static void CheckTime()
        {
            Console.WriteLine("Hello World!");

            var list = new List<string>();
            for (int i = 0; i < Math.Pow(10, 6); i++)
            {
                if (i == 1 || i % 2 != 0)
                {
                    list.Add(i.ToString());
                }
                else
                {
                    list.Add(null);
                }
            }

            var watch = new Stopwatch();
            watch.Start();

            foreach (var s in list)
            {
                try
                {
                    int i = s.Length;
                }
                catch (Exception ex)
                {
                    string e = ex.Message;
                    var a = ex.StackTrace;
                }
            }

            watch.Stop();
            Console.WriteLine(watch.Elapsed);

            watch.Restart();

            foreach (var s in list)
            {
                try
                {
                    int i = s.Length;
                }
                catch (Exception ex)
                {
                    string e = ex.Message;
                    string a = ex.StackTrace;
                }
            }

            watch.Stop();
            Console.WriteLine(watch.Elapsed);
        }
    }
}
