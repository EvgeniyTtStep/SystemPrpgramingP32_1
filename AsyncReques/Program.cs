using System;
using System.IO;
using System.Threading;
using System.Text;



class AsyncRequestClass
    {
        public static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, FileOptions.Asynchronous);
            Byte[] data = new Byte[100];
            IAsyncResult ar = fs.BeginRead(data, 0, data.Length, null, null);
            while (!ar.AsyncWaitHandle.WaitOne(10, false))
            {
                Console.WriteLine("Операцію не завершено, зачекайте....");
            }
            Int32 bytesRead = fs.EndRead(ar);
            fs.Close();
            Console.WriteLine("Кількість зчитаних байтів = {0}", bytesRead);
            Console.WriteLine(Encoding.UTF8.GetString(data).Remove(0, 1));
        }
        
    }
