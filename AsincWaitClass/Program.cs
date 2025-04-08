using System.Text;

class MyClass
{
    public static void Main(string[] args)
    {
        FileStream fileStream = new FileStream(
            "C:\\Users\\Home\\RiderProjects\\SystemPrpgramingP32_1\\AsincWaitClass\\text",
            FileMode.Open, FileAccess.Read, FileShare.Read, 1024, FileOptions.Asynchronous);

        Byte[] buffer = new Byte[100];
        IAsyncResult result = fileStream.BeginRead(buffer, 0, buffer.Length, null, null);


        while (result.IsCompleted == false)
        {
            Console.WriteLine("Waiting for file...");
            Thread.Sleep(100);
        }

        Int32 readBytes = fileStream.EndRead(result);

        fileStream.Close();

        Console.WriteLine("Read {0} bytes", readBytes);
        Console.WriteLine(Encoding.UTF8.GetString(buffer));
    }
}