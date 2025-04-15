class MyClass
{
    public static void Main(string[] args)
    {
        Semaphore semaphore = new Semaphore(3, 3, "My_semaphore");

        for (int i = 0; i < 6; i++)
        {
            ThreadPool.QueueUserWorkItem(MyMethod, semaphore);
        }
        
        Console.ReadLine();
    }

    static void MyMethod(object obj)
    {
        Semaphore? semaphore = obj as Semaphore;

        bool stop = false;

        while (!stop)
        {
            if (semaphore.WaitOne(500))
            {
                try
                {
                    Console.WriteLine("Thread received " + Thread.CurrentThread.ManagedThreadId + " blocking");
                    Thread.Sleep(2000);
                }
                finally
                {
                    stop = true;
                    semaphore.Release();
                    Console.WriteLine("Thread released " + Thread.CurrentThread.ManagedThreadId + " blocking");
                }
            }
            else
            {
                Console.WriteLine("Timeout " + Thread.CurrentThread.ManagedThreadId + " is over blocking");
            }
        }
    }
}