using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Threading;

namespace file_storage_server
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
        static HttpListener listener;

        static void Main(string[] args)
        {
           // listener = new HttpListener();
            //listener.Prefixes.Add("http://localhost:8888/file_storage/");
            //listener.Start();
           // Console.WriteLine("Server is up");
            //HttpListenerContext context = listener.GetContext();
            //HttpListenerRequest request = context.Request;
            //Console.WriteLine("method:" + request.HttpMethod);
            //Console.WriteLine("raw uri:" + request.RawUrl);
           // HttpListenerResponse response = context.Response;

            //string responseStr = "<html><head><meta charset='utf8'></head><body>Привет мир!</body></html>";
            //byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseStr);
            //получаем поток ответа и пишем в него ответ
           // response.ContentLength64 = buffer.Length;
           // Stream output = response.OutputStream;
           // output.Write(buffer, 0, buffer.Length);
            //закрываем поток
           // output.Close();


            //listener.Stop();


            Server server = new Server("http://localhost:8888/file_storage/", "USERS_DIRS");
            server.StartListening();
            int handlerscount = 0;
            while (handlerscount<5)
            {

                // ThreadStart threadStart = new ThreadStart(server.HandleRequest);
                //Thread thread = new Thread(threadStart);
                server.HandleRequest(ref handlerscount);
                handlerscount++;
            }

            // Console.ReadKey();
            //server.StopListening();
        }
    }
    class Server
    {
        class File_Base
        {
            public String dirpass;
            public File_Base(String dirpass)
            {
                this.dirpass = dirpass;
                StreamReader sr = new StreamReader(dirpass + "/filenames.txt");
                while (!sr.EndOfStream)
                {
                    String filename = sr.ReadLine();
                    AddFile(filename, dirpass + filename+".txt");
                }
                sr.Dispose();

             
            }
            class File
            {
                public String name;
                public String pass;
                public File(String filename, String filepass)
                {
                    this.name = filename;
                    this.pass = filepass;
                }
            }
            private List<File> files = new List<File>();

            public void AddFile(String filename, String filepass)
            {
                files.Add(new File(filename, filepass));
            }
            public String DeleteFile(String filename)
            {
                Boolean wasfound = false;
                File file=new File("none","none");
                
                for (int i=0; i<files.Count; i++)
                {
                    file = files.ElementAt(i);
                    if (file.name == filename)
                    {
                        wasfound = true;
                        files.Remove(files.ElementAt(i));
                        break;
                    }
                }
                if (wasfound)
                    return file.name;
                else
                    return "notfound";
            }
            public String GetAllFilesNames()
            {
                String result = String.Empty;
                for (int i = 0; i < files.Count; i++)
                {
                    result = result + "/"+files.ElementAt(i).name;
                }
                return result;
            }
            public void Refresh()
            {
                StreamWriter sw = new StreamWriter(dirpass + "/filenames.txt",false);
                for (int i = 0; i < files.Count; i++)
                {
                    sw.WriteLine(files.ElementAt(i).name);
                }
                sw.Dispose();
            }
        }
        private HttpListenerContext context;
        private HttpListenerRequest request;
        private HttpListenerResponse response;
        private File_Base filebase;
        private String uri;
        private byte[] requestcontent;
        private HttpListener listener;
        public Server(String uri, String dirpass)
        {
            
            listener = new HttpListener();
            listener.Prefixes.Add(uri);
            this.uri = uri;
            this.filebase = new File_Base("USERS_DIRS");
        }
        public void StartListening()
        {
            listener.Start();
            Console.WriteLine("Server is up");
           
        }
        public void ThreadProc()
        {
            HttpListenerContext context = listener.GetContextAsync().Result;
            ParseRequest(GetRequest(context),context);

        }
        public void HandleRequest(ref int counter)
        {

            //;
            counter--;
            //thread.Start();
            ThreadProc();
            //return context;

        }
        public void StopListening()
        {
            listener.Stop();
            Console.WriteLine("Server is down");
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
        public Boolean AddFile(String filename, String filepass)
        {
            try
            {
                
                filebase.AddFile(filename, filepass);
                FileStream fileStream = new FileStream(filepass, FileMode.Create);
                fileStream.Write(requestcontent, 0, requestcontent.Length);
                fileStream.Close();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        
        public Boolean DeleteFile(String filename)
        {
            String pass=filebase.DeleteFile(filename);
            if (pass != "notfound")
            {
                File.Delete(filebase.dirpass+"/"+pass);
                return true;
            }
            else
            {
                Console.WriteLine("file not found");
                return false;
            }
                
        }
        public byte[] GetFileBytes(String filename)
        {
            byte[] result;
            try
            {
                FileStream fileStream = new FileStream(filebase.dirpass+"/"+filename, FileMode.Open);
                result = new byte[fileStream.Length];
                fileStream.Read(result, 0, (int)fileStream.Length);
                
                fileStream.Dispose();
            }
            catch
            {
                Console.WriteLine("File not exists");
                result = null;
            }
            return result;
        }
        // return String arr, where[0] - httpmethod, [1] - uri without main uri
        public String[] GetRequest()
        {
            
            String[] result = new String[2];
            context = listener.GetContext();
            request = context.Request;
            Stream contentstream = request.InputStream;
            requestcontent = new byte[request.ContentLength64];
            contentstream.Read(requestcontent,0,(int)request.ContentLength64);
            result[0] = request.HttpMethod;
            result[1] = request.RawUrl;
            result[1] = result[1].Substring(14);
            result[1] = result[1].TrimEnd('/');
            

            Console.WriteLine("Method:" + result[0] + " Uri:" + result[1]);
            return result;

        }
        public String[] GetRequest(HttpListenerContext context)
        {

            String[] result = new String[2];
            //context = listener.GetContext();
            request = context.Request;
            Stream contentstream = request.InputStream;
            requestcontent = new byte[request.ContentLength64];
            contentstream.Read(requestcontent, 0, (int)request.ContentLength64);
            result[0] = request.HttpMethod;
            result[1] = request.RawUrl;
            result[1] = result[1].Substring(14);
            result[1] = result[1].TrimEnd('/');


            Console.WriteLine("Method:" + result[0] + " Uri:" + result[1]);
            return result;

        }
        public void ParseRequest(String[] requestresult, HttpListenerContext context)
        {
            Boolean result;
            switch (requestresult[0])
            {
                case "GET":
                    if (requestresult[1] == "ALL")
                    {
                        SendResponse( Encoding.UTF8.GetBytes(filebase.GetAllFilesNames()),context );
                    }
                    else
                    {
                        if (GetFileBytes(requestresult[1]) != null)
                            SendResponse(GetFileBytes(requestresult[1]), context);
                        else
                            SendResponse("file not found",context);
                    }
                    break;


                case "PUT":
                    result=AddFile(requestresult[1], filebase.dirpass+"/"+requestresult[1]);
                    
                    if (!result)
                    {
                        SendResponse("Can't add file", context);
                    }
                    else
                    {
                        SendResponse("File add sucsessfully", context);
                    }
                    
                    break;


                case "DELETE":
                    result=DeleteFile(requestresult[1]);
                    if (!result)
                    {
                        SendResponse("File not found", context);
                    }
                    else
                    {
                        SendResponse("Done", context);
                    }
                    break;
                case "POST":
                    if (requestresult[1] == "SETDIR")
                    { 
                        filebase = new File_Base("USERS_DIRS/"+Encoding.UTF8.GetString(requestcontent));

                    }
                    else
                    {
                        DeleteFile(requestresult[1]);
                        AddFile(requestresult[1], filebase.dirpass + "/" + requestresult[1]);
                        SendResponse("Done",context);
                    }
                    break;
                case "COPY":
                    if (requestresult[1] == "ALL")
                    {
                        SendResponse(Encoding.UTF8.GetBytes(filebase.GetAllFilesNames()), context);
                    }
                    else
                    {
                        if (GetFileBytes(requestresult[1]) != null)
                            SendResponse(GetFileBytes(requestresult[1]), context);
                        else
                            SendResponse("file not found", context);
                    }

                    break;
            }
            filebase.Refresh();

        }
        public void SendResponse(String contentstr, HttpListenerContext context)
        {
            if (context.Request == null)
            {
                Console.WriteLine("Request to response not found");
            }
            else
            {
                response = context.Response;
                byte[] content = System.Text.Encoding.UTF8.GetBytes(contentstr);
                response.ContentEncoding = Encoding.UTF8;
                response.ContentLength64 = content.Length;
                Stream responsestream = response.OutputStream;
                responsestream.Write(content, 0, content.Length);
                responsestream.Close();
            }

        }
        public void SendResponse(byte[] content, HttpListenerContext context)
        {
            if (context.Request == null)
            {
                Console.WriteLine("Request to response not found");
            }
            response = context.Response;
            response.ContentLength64 = content.Length;
            Stream responsestream = response.OutputStream;
            responsestream.Write(content, 0, content.Length);
            responsestream.Close();
        }
    }
}
