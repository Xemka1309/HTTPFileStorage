using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Windows;
using System.IO;
using System.Windows.Forms;

namespace file_storage_client
{
    enum HttpMethods
    {
        GET,
        POST,
        PUT,
        DELETE,
        COPY,
        MOVE
    }
    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            Application.Run(new ClienForm());

            ////HttpClient httpclient = new HttpClient();
            //httpclient.BaseAddress = new Uri("http://localhost:8888/file_storage/");


            //HttpRequestMessage requestMessage = new HttpRequestMessage();
            //requestMessage.Method = HttpMethod.Post;
            //requestMessage.RequestUri= new Uri("http://localhost:8888/file_storage/");
            //HttpResponseMessage responseMessage;
            //responseMessage = httpclient.SendAsync(requestMessage).Result;

            //byte[] responsebytes = responseMessage.Content.ReadAsByteArrayAsync().Result;
            //Console.WriteLine("RESPONSE:"+Encoding.UTF8.GetString(responsebytes) );

            //Client client = new Client("http://localhost:8888/file_storage/");
            //client.CreateRequest();
            //client.GetFilesNames();
            //Console.WriteLine(client.GetFilesNames());

            //client.CreateRequest();
            //client.SetRequestMethod(HttpMethods.POST);
            //client.SetRequestUri("myfile.txt");
            //client.SendRequest(client.GetFileBytes("filestoadd/myfile.txt"));
            //Console.WriteLine("Press any key to exit");
            //Console.ReadLine();


        }
    }
    class Client
    {
        private String dirpass;
        private String[] identifer;
        private HttpClient httpClient;
        private String server_uri;
        private HttpRequestMessage requestMessage;
        private HttpResponseMessage responseMessage;

        public Client(String string_uri, String log,String pass,String dirpass)
        {
            this.identifer = new String[2];
            this.server_uri = string_uri;
            this.identifer[0] = log;
            this.identifer[1] = pass;
            this.dirpass = dirpass;
        }
        public byte[] GetFileBytes(String filepass)
        {
            byte[] result;
            try
            {
                FileStream fileStream = new FileStream(filepass, FileMode.Open);
                result = new byte[fileStream.Length];
                fileStream.Read(result, 0, (int)fileStream.Length);
            }
            catch
            {
                Console.WriteLine("File not exists");
                result = null;
            }
            return result;
        }

        public void CreateRequest()
        {
            requestMessage = new HttpRequestMessage();
           
        }
        public void SetRequestMethod(HttpMethods httpmethod)
        {
            if (requestMessage == null)
            {
                this.CreateRequest();
            }
            switch (httpmethod)
            {
                case HttpMethods.POST:
                    requestMessage.Method = HttpMethod.Post;
                    break;
                case HttpMethods.DELETE:
                    requestMessage.Method = HttpMethod.Delete;
                    break;
                case HttpMethods.COPY:
                    requestMessage.Method = new HttpMethod("COPY");
                    break;
                case HttpMethods.MOVE:
                    requestMessage.Method = new HttpMethod("MOVE");
                    break;
                case HttpMethods.GET:
                    requestMessage.Method = HttpMethod.Get;
                    break;
                case HttpMethods.PUT:
                    requestMessage.Method = HttpMethod.Put;
                    break;
            }
            
        }
        public void SetRequestUri(String file_name)
        {
            requestMessage.RequestUri = new Uri(server_uri + file_name + "/");
            //requestMessage.
           
        }
        public HttpResponseMessage SendRequest()
        {
            httpClient = new HttpClient();
            responseMessage = httpClient.SendAsync(requestMessage).Result;
            return responseMessage;
        }
        // overload version to use when response message include content
        public HttpResponseMessage SendRequest(byte[] content)
        {
            httpClient = new HttpClient();
            MemoryStream memoryStream = new MemoryStream(content);
            requestMessage.Content = new StreamContent(memoryStream);
            try
            {
                responseMessage = httpClient.SendAsync(requestMessage).Result;
                
            }
            catch (AggregateException ae)
            {
               
                Console.WriteLine(ae.Message);
                Console.WriteLine(ae.InnerException.Message);
            }
            return responseMessage;
        }
        public String GetFilesNames()
        {
            //this.CreateRequest();
            //this.SetRequestMethod(HttpMethods.POST);
            //this.SetRequestUri("SETDIR");
            //this.SendRequest(Encoding.UTF8.GetBytes(this.dirpass));
            String result;

            this.CreateRequest();
            this.SetRequestMethod(HttpMethods.GET);
            this.SetRequestUri("ALL");
            byte[] responsebytes = this.SendRequest().Content.ReadAsByteArrayAsync().Result;
         
            result = Encoding.UTF8.GetString(responsebytes);
            return result;
        }
        
    }
}
