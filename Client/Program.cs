using System;
using System.Threading;
using NetRemoting.Shared;

namespace NetRemoting.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Client side ....");

            var i = 0;
            while (true)
            {
                try
                {
                    var p = (People) Activator.GetObject(typeof(People), "tcp://localhost:25253/p");
                    p.SetAge(i);
                    Console.WriteLine($"{i} succeed => {p.Age}");
                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{i} failed ==> {ex.Message}");
                }

                i++;
            }
        }
    }
}