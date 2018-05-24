using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace кур
{
    class Test_Read
    {
        static Mutex mutex = new Mutex();
        public async void Execute()
        {
            mutex.WaitOne();
            Console.WriteLine("Общий блок между потоками!");
            mutex.ReleaseMutex();
            Console.WriteLine("нгезаивисимая часть кода потока");
        }
    }
}
