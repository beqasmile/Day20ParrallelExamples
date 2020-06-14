using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelExamples
{
    class Program
    {
        static readonly object lockObject = new object();
        static void Main(string[] args)
        {
            Thread carThread = new Thread(() => CreateAndPrintCar());
            carThread.Start();

            Thread carDriver = new Thread(() => CreateAndPrintDriver());
            carDriver.Start();

            Parallel.Invoke(() => CreateAndPrintCar(), () => CreateAndPrintDriver());

            Parallel.For(0, 20, i =>
            {
                Console.WriteLine("{0} on Task {1}", i, Task.CurrentId);
            });

           // CreateAndPrintDriver();

           // CreateAndPrintCar();

            Console.ReadKey();
        }

        private static void CreateAndPrintDriver()
        {
            for (int i = 0; i < 1000; i++)
            {
                Driver x = new Driver(i, " driver name " + i, " driver family " + i, EnumDriver.RegularCarDriver, lockObject);
                x.PrintDriver();
            }
        }

        private static void CreateAndPrintCar()
        {
            for (int i = 0; i < 1000; i++)
            {
                Car x = new Car(" car " + i, i.ToString(), EnumCarType.Bus, i * 100,lockObject);
                x.PrintCar();
            }
        }
    }
}
