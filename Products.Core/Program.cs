using Products.Core;
using Products.Data.Net;

using System.Text;

using TcpSharp;

Console.WriteLine("Hello, World!");
var prodService = new ProductService(5);
var server = new NetService(prodService);
var client = new TcpSharpSocketClient("localhost", INetServer.Port);

await Task.Delay(500);
server.StartListening();
Console.WriteLine(1);
Console.WriteLine(2);
Console.WriteLine(3);
await Task.Delay(500);
Console.WriteLine(4);
client.Connect();
client.SendString(Commands.AddProductBad);
client.SendString(Commands.AddProductGood);
client.SendString(Commands.AddProductBad);
client.SendString(Commands.AddProductBad);
client.SendString(Commands.AddProductGood);
client.SendString(Commands.AddProductGood);
client.SendString(Commands.AddProductBad);
await Task.Delay(1500);
Console.WriteLine(5);
client.SendString(Commands.GetProducts);

Console.ReadKey();