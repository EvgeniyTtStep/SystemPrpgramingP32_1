using System.Text;

class AsyncWaitClass
{
    static void Main(string[] args)
    {
        string[] files =
        {
            "C:\\Users\\Home\\RiderProjects\\SystemPrpgramingP32_1\\AsyncMultiFiles\\text1.txt",
            "C:\\Users\\Home\\RiderProjects\\SystemPrpgramingP32_1\\AsyncMultiFiles\\text2.txt",
            "C:\\Users\\Home\\RiderProjects\\SystemPrpgramingP32_1\\AsyncMultiFiles\\text3.txt"
        };

        AsyncReader[] asrArr = new AsyncReader[3];

        for (int i = 0; i < asrArr.Length; ++i)
        {
            asrArr[i] = new AsyncReader(
                new FileStream(files[i], FileMode.Open, FileAccess.Read, FileShare.Read, 1024,
                    FileOptions.Asynchronous), 100);
        }

        foreach (AsyncReader asr in asrArr)
        {
            Console.WriteLine(asr.EndRead());
        }
    }
}

class AsyncReader
{
    FileStream stream;
    byte[] data;
    IAsyncResult asyncResult;

    public AsyncReader(FileStream stream, int size)
    {
        this.stream = stream;
        data = new byte[size];
        asyncResult = stream.BeginRead(data, 0, size, null, null);
    }

    public string EndRead()
    {
        int count = stream.EndRead(asyncResult);
        stream.Close();
        Array.Resize(ref data, count);
        return string.Format("File {0}\n{1}\n", stream.Name, Encoding.UTF8.GetString(data));
    }
}