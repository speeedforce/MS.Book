using System;
using System.IO;
using System.Net.Http;
using System.Text;

namespace MS.Book.ManageProgramFlow.AsyncAwaitChapter
{
    public static class AsyncAwaitListing2
    {
        /// <summary>
        /// Example disabling SynchronizationContext flow
        /// Use when we don't need use async result in main thread (example UI thread in WPF/UWP)
        /// </summary>
        public static async void ButtonSimulate()
        {
            HttpClient httpClient = new HttpClient();

            string content = await httpClient.GetStringAsync("http://www.microsoft.com")
                .ConfigureAwait(false);
            
            
            // If we set the ui element in this case, we will have exception
            // textBox1.Text = content; => throw exception
            
            
            // If we just write to the file, it's ok.
            // We don't need necessary to write it synchronously
            using (FileStream sourceStream = new FileStream("temp.html", FileMode.Create, FileAccess.Write, FileShare.None,4096, useAsync: true))
            {
                byte[] encodedText = Encoding.Unicode.GetBytes(content);
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length)
                    .ConfigureAwait(false);
            };
        }
    }
}