class MyClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Mutex Synchronization:");
        Counter counter = new Counter();
        Thread[] threads = new Thread[5];
        
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(counter.UpdateCount);
            threads[i].Start();
        }
        

    }
}

class Counter
{
    int count;
    Mutex mutex = new Mutex(false, "SYNC_MUTEX");

    public int Count
    {
        get { return count; }
    }

    public void UpdateCount()
    {
        Console.WriteLine("Start:" + DateTime.Now.ToLongTimeString());

        for (int i = 0; i < 1_000_000; i++)
        {
            mutex.WaitOne();
            ++count;
            mutex.ReleaseMutex();
        }
        
        Console.WriteLine("End:" + DateTime.Now.ToLongTimeString());

    }
}