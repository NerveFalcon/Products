using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Products.Data.Net;

public class NetService : INetServer, INetClient, IDisposable
{
	const int Port = 32234;
	Dictionary<string, Func<byte[]>> Handlers { get; set; } = [];
	public Socket TcpListener { get; }

	public NetService()
    {
		TcpListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		TcpListener.Bind(new IPEndPoint(IPAddress.Loopback, Port));
	}
	public void AddHandler(string command, Func<byte[]> handler)
		=> Handlers.Add(command, handler);

	public void AddHandler(string command, Action handler)
		=> AddHandler(command, () => { handler.Invoke(); return [0]; });

	public void RemoveHandler(string command)
		=> Handlers.Remove(command);

	public Task SendAsync(byte[] message) 
		=> TcpListener.SendAsync(message);

	public Task SendAsync(string message)
		=> TcpListener.SendAsync(Encoding.UTF8.GetBytes(message));

	public async Task StartListenAsync()
	{
		try
		{
			TcpListener.Listen();
			Console.WriteLine();
			Console.WriteLine("Сервер запущен");

			while (true)
			{
				using var tcpClient = await TcpListener.AcceptAsync();

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

					if (Handlers.TryGetValue(message, out var handler))
					{
						var res = handler.Invoke();
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

	public void Dispose() => TcpListener.Dispose();
}
