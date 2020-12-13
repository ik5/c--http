using System;
using System.Net;

namespace http_server
{
    class Program
    {

        static void Main(string[] args)
        {
            Server server = new Server(8001, "localhost");
            server.InitServer();
            server.Run(Handle);
        }

        static protected void Handle(IAsyncResult result)
        {
          Console.WriteLine("in Handle");
          HttpListener listener = (HttpListener)result.AsyncState;
          HttpListenerContext context = listener.EndGetContext(result);

          HttpListenerRequest request = context.Request;
          // Obtain a response object.
          HttpListenerResponse response = context.Response;
          System.IO.Stream output = response.OutputStream;

          string responseString = "{}"
        }
    }
}
