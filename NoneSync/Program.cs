class MonitorLockCounter
{
    int field1;
    int field2;

    public int Field1 { get { return field1; }}
    public int Field2 { get { return field2; }}
    public void UpdateFields()
    {
        Console.WriteLine("Start:" + DateTime.Now.ToLongTimeString());

        for (int i = 0; i < 100_000_000; ++i)
        {
            
            try
            {
                ++field1;
                if (field1 % 2 == 0)
                    ++field2;
            }
            finally
            {
                
            }
        }
        Console.WriteLine("End:" + DateTime.Now.ToLongTimeString());



    }
}

class MyClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("БЕЗ Синхронізації блокування:");
        MonitorLockCounter c = new MonitorLockCounter();

        for (int i = 0; i < 5; ++i)
        {
            c.UpdateFields();
        }
        
        Console.WriteLine("Field1: {0}, Field2: {1}\n\n", c.Field1, c.Field2);
    }
}