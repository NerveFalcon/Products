using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Products.Data.Net;

public class NetService : INetServer
{
	const int Port = 32234;
	Dictionary<string, Func<byte[]>> Handlers { get; set; } = [];
	public void AddHandler(string command, Func<byte[]> handler)
		=> Handlers.Add(command, handler);

	public void RemoveHandler(string command)
		=> Handlers.Remove(command);

	public async Task StartListenAsync()
	{
		using var tcpListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

		try
		{
			tcpListener.Bind(new IPEndPoint(IPAddress.Any, Port));
			tcpListener.Listen();
			Console.WriteLine();
			Console.WriteLine("Сервер запущен");

			while (true)
			{
				using var tcpClient = await tcpListener.AcceptAsync();

				var buffer = new List<byte>();
				var byteRead = new byte[1];

				while (true)
				{
					while (true)
					{
						var count = await tcpClient.ReceiveAsync(byteRead);

						if (count == 0 || byteRead[0] == '\n') break;

						buffer.Add(byteRead[0]);
					}
					var message = Encoding.UTF8.GetString(buffer.ToArray());

					if (Handlers.TryGetValue(message, out var Handler))
					{
						var res = Handler.Invoke();
						await tcpClient.SendAsync(res);
					}
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}
