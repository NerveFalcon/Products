using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Net.Http.Headers;
using TcpSharp;

namespace Products.Data.Net;

public class NetService
{
	public TcpSharpSocketServer Server { get; }
	public IProductService ProductService { get; }

	public NetService(IProductService productService)
	{
		Server = new TcpSharpSocketServer(INetServer.Port);
		Server.OnDataReceived += OnDataReceived;
		ProductService = productService;
	}

	private void OnDataReceived(object? sender, OnServerDataReceivedEventArgs e)
	{
		var data = Encoding.UTF8.GetString(e.Data);
		var commands = data.Split('\n');
		foreach (var command in commands)
			if (!string.IsNullOrWhiteSpace(command))
				HandleCommand(e.ConnectionId, command);
	}

	private void HandleCommand(string connectionId, string command)
	{
		bool res;
		switch ($"{command}\n")
		{
			case Commands.AddProductGood:
				res = ProductService.TryAdd(true);
				Server.SendString(connectionId, res ? Results.AddedGood : Results.NotAdded);
				break;
			case Commands.AddProductBad:
				res = ProductService.TryAdd(false);
				Server.SendString(connectionId, res ? Results.AddedBad : Results.NotAdded);
				break;
			case Commands.RemoveProduct:
				res = ProductService.TryRemove();
				Server.SendString(connectionId, res ? Results.Removed : Results.NotRemoved);
				break;
			case Commands.GetProducts:
				var prods = ProductService.GetSnapshot();
				var message = Results.List 
							+ string.Join(",", 
									prods.Select(p => p.IsGood 
													? Results.AddedGood 
													: Results.AddedBad));
                Console.WriteLine(message);
				Server.SendString(connectionId, message);
				break;
			default:
				break;
		}
	}

	public void StartListening() => Server.StartListening();
}
