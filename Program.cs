using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        public static void Item4_Interpolation()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            List<string> strs = new List<string>();
            for (var i = 0; i < 10000000; i++)
            {
                //strs.Add($"{i} + {(i + 1)} = {(2 * i + 1)}");
                //strs.Add(String.Format("{0} + {1} = {2}", i, i+1, 2*i+1));
                strs.Add($"{i.ToString()} + {(i + 1).ToString()} = {(2 * i + 1).ToString()}");
            }
            Console.WriteLine(strs[1]);

            stopwatch.Stop();
            System.Console.WriteLine("time : " + stopwatch.ElapsedMilliseconds + "ms");
        }

        public static void Item5_FormattableString()
        {
            string str = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}";
            FormattableString fStr = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}";
            var vStr = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}";
            FormattableString.CurrentCulture($"{DateTime.Now.Hour}:{DateTime.Now.Minute}");
            //Console.WriteLine(str.GetType());
            //Console.WriteLine(fStr.GetType());
            //Console.WriteLine(vStr);
        }

        public static void Item6_Nameof()
        {
            var a = nameof(Item5_FormattableString);
            //var id = nameof(System.IO);
            //var c = nameof(List<List<int>>);
            Console.WriteLine(nameof(a));
            Console.WriteLine(nameof(Item6_Nameof));
        }

        public delegate int Del1(int num);
        public static void Deltest(int a, Del1 del)
        {
            Console.WriteLine(del(a * 2));
            return;
        }
        public static void DeltestMulti(int a, Del1 dels)
        {
            foreach (Del1 del in dels.GetInvocationList())
            {
                Console.WriteLine(del(a * 2));
            }
        }
        public static void Item7_Delegate()
        {
            static int myMethod(int a)
            {
                Console.WriteLine('~');
                return a + 1;
            }
            Del1 del2 = new Del1(myMethod);
            Del1 del3 = delegate (int a) { return a + 1; };
            Del1 myDel = myMethod;
            myDel += (n) => n + 3;
            myDel += myMethod;
            myDel += (n) => n + 4;

            //Console.WriteLine(myDel.GetInvocationList().Length);

            Deltest(1, myDel);
            //Deltest(1, (n) => n+2);
            //DeltestMulti(1, myDel);
            static int myPrintReturn(int a)
            {
                Console.WriteLine("Do myPrintReturn");
                return a + 1;
            }

            Del1 myDel2 = myPrintReturn;
            myDel2 += myPrintReturn;
            myDel2 += myPrintReturn;

            Deltest(1, myDel2);
        }
        public static async Task Item8_Event() {
            var tasks = new Task[100];
            EventSourceScheduler es = new();
            //EventSource es = new();
            EventHandler<int> eh = (_, num) => {Console.Write(num);};
            
            int a, b;
            ThreadPool.GetMinThreads(out a, out b);

            Console.WriteLine(a);
            Console.WriteLine(b);
            es.AddEvent(eh);
            for(int i = 0; i < 100; i++) {
                Thread.Sleep(10);
                tasks[i] = Task.Run(() => {es.RaiseUpdates();});
                //tasks[i] = Task.Run(() => Console.Write("1"));
            }
            Console.Write("@@");
            es.RemoveEvent(eh);
            //es.RaiseUpdates();
            await Task.WhenAll(tasks);
            return;
        }
        // public static async Task Main(String[] args)
        // {
        //     await Item8_Event();
        // }

        public static void ClosureTest()
        {
            int a = 1;
            Action<int> b = delegate(int num) {
                Console.WriteLine(a);
            };
            a += 1;
            b(a);
            a += 2;
        }

        public static void Main(String[] args)
        {
            ClosureTest();
        }
    }
}
