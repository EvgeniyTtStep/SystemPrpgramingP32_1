class MyClass
{
    
    private delegate UInt64 AsyncSumDelegate(UInt64 n);
    
    public static void Main(string[] args)
    {
        AsyncSumDelegate sumDelegate = new AsyncSumDelegate(Sum);
        sumDelegate.BeginInvoke(1000000, EndSum, sumDelegate);
        
        Console.ReadKey();
    }
    
    private static UInt64 Sum(UInt64 n)
    {
        UInt64 sum = 1;
        for (UInt64 i = 2; i < n; i++)
        {
            sum += i;
        }
        return sum;
    }


    private static void EndSum(IAsyncResult ar)
    {
        AsyncSumDelegate del = (AsyncSumDelegate)ar.AsyncState;
        UInt64 res = del.EndInvoke(ar);
        
        Console.WriteLine("Sum = " + res);
    }
}