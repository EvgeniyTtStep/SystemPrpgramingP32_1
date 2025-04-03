using System;
using System.Threading;

class MyClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Main thread started: queue a working element");
        Random rnd = new Random();
        for (int i = 0; i < 10; i++)
        {
            ThreadPool.QueueUserWorkItem(WorkingElementMethod, rnd.Next( 10));
        }
        Console.WriteLine("Main thread finished: execute other tasks");
        Thread.Sleep(1000);
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }


    private static void WorkingElementMethod(object state)
    {
        Console.WriteLine("\tThread: " + Thread.CurrentThread.ManagedThreadId + " state: " + state);
        Thread.Sleep(1000);
    } 
}