using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ResponseRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            while (true)
            {
                Console.WriteLine("Please input web site");
                String webSite = Console.ReadLine();
                WebRequest webRequest = WebRequest.Create(webSite);
                webRequest.UseDefaultCredentials = true;


                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                Console.WriteLine(response.StatusDescription);


                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();

                FileStream fs = File.OpenWrite($"WebSiteNumber_{i}.html");
                i++;
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.Write(responseFromServer);

                // Display the content.
                //Console.WriteLine(responseFromServer);
                // Cleanup the streams and the response.
                streamWriter.Close();
                reader.Close();
                dataStream.Close();
                response.Close();

            }

            Console.ReadKey();
        }
    }
}
