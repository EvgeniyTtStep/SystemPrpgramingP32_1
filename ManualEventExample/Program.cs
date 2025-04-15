class EventSyncClass
{
    static void Main(string[] args)
    {
        Console.WriteLine("Подія з ручним скиданням:");
        //ManualResetEvent mre = new ManualResetEvent(true);
        AutoResetEvent waitHandle = new AutoResetEvent(true);
        for (int i = 0; i < 10; ++i)
            ThreadPool.QueueUserWorkItem(SomeMethod, waitHandle);
        Console.ReadKey();
    }

    static void SomeMethod(object obj)
    {
        EventWaitHandle ev = obj as EventWaitHandle;

        if (ev.WaitOne(10))
        {
            Console.WriteLine("Потік {0} встиг проскочити", Thread.CurrentThread.ManagedThreadId);
            ev.Reset();
        }
        else
            Console.WriteLine("Потік {0} спізнився", Thread.CurrentThread.ManagedThreadId);
    }
}