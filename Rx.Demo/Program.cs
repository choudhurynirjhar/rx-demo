using System;
using System.Reactive.Linq;

namespace Rx.Demo
{
    static class Program
    {
        static void Main(string[] args)
        {
            Observable.Range(1, 100).Where(x => x % 2 == 0)
                .Merge(Observable.Range(1, 100).Where(x => x % 2 == 0))
                .Subscribe(Console.WriteLine);

            Console.WriteLine("Completed!");
            Console.ReadLine();
        }
    }
}
