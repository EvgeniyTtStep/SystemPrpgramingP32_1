class InterlockedCounter
{
    int field1;
    int field2;
 
    public int Field1
    {
        get { return field1; }
    }
 
    public int Field2
    {
        get { return field2; }
    }
 
    public void UpdateFields()
    {
       Console.WriteLine("Start:" + DateTime.Now.ToLongTimeString());

        
        for (int i = 0; i < 100_000_000; ++i)
        {
           Interlocked.Increment(ref field1);
           if (field1 % 2 == 0)
               Interlocked.Increment(ref field2);
        }
        Console.WriteLine("End:" + DateTime.Now.ToLongTimeString());
    }
}

class MyClass
{
    public static void Main(string[] args)
    {
            Console.WriteLine("Синхронізація Interlocked-методами:");
            InterlockedCounter c = new InterlockedCounter();
 
            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i] = new Thread(c.UpdateFields);
                threads[i].Start();
            }
 
            for (int i = 0; i < threads.Length; ++i)
                threads[i].Join();

            Console.WriteLine("Field1: {0}, Field2: {1}\n\n", c.Field1, c.Field2);
    }
}