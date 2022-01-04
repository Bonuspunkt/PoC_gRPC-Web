using System.Runtime.InteropServices;
using Greet;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;

var version = RuntimeInformation.FrameworkDescription;

var handler = new GrpcWebHandler(new HttpClientHandler());
handler.HttpVersion = new Version(1, 1);

var options = new GrpcChannelOptions {HttpHandler = handler};


var channel = GrpcChannel.ForAddress("http://localhost:5001", options);
var client = new Greeter.GreeterClient(channel);

var result = await client.SayHelloAsync(new HelloRequest { Name = version });
Console.WriteLine(result.Message);
