using System;
using System.Net;
using System.Threading.Tasks;


namespace http_server
{
  public class Server {
    protected int port;
    protected string address = "0.0.0.0";
    protected HttpListener server = new HttpListener();

    public Server(int port)
    {
      this.port = port;

    }

    public Server(int port, string address)
    {
      this.port = port;
      this.address = address;
    }

    public void InitServer()
    {
      this.server.Prefixes.Add(
          String.Format("http://{0}:{1}/", this.address, this.port)
      );
      this.server.Start();
    }

    public async Task Run(AsyncCallback cb) {
      while (this.server.IsListening) {
        Console.WriteLine("Serving new request:");
        IAsyncResult result = this.server.BeginGetContext(cb, this.server);
         result.AsyncWaitHandle.WaitOne();
        Console.WriteLine("Served a request");
      }
    }

  }

}
