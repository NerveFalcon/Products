using Products.Data;
using Products.Data.Net;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TcpSharp;

namespace Products.UI
{
	public class NetService : IProductService
	{
		public TcpSharpSocketClient Client { get; }
		private Product[] Products { get; set; } = new Product[5];

		bool inAddProgress = false;
		bool inRemoveProgress = false;
		bool inGetProgress = false;
		string addedResult = string.Empty;
		string removeResult = string.Empty;

		public NetService()
		{
			Client = new TcpSharpSocketClient("localhost", INetServer.Port);
			Client.OnDataReceived += OnDataReceived;
		}

		private void OnDataReceived(object? sender, OnClientDataReceivedEventArgs e)
		{
			var data = Encoding.UTF8.GetString(e.Data);
			switch (data)
			{
				case Results.AddedGood or Results.AddedBad or Results.NotAdded:
					addedResult = data;
					inAddProgress = false;
					break;
				case Results.Removed or Results.NotRemoved:
					removeResult = data;
					inRemoveProgress = false;
					break;
				default:
					HandleDataReceived(data);
					break;
			}
		}

		private void HandleDataReceived(string data)
		{
			if (data.StartsWith(Results.List))
			{
				inGetProgress = false;
				var raw = data.Substring(Results.List.Length);
				Products = raw.Split(',')
								.Select((s) => new Product(s is Results.AddedGood))
								.ToArray();
			}
		}

		public Product[] GetSnapshot()
		{
			if (inGetProgress) return [];
			inGetProgress = true;

			Client.SendString(Commands.GetProducts);
			WaitGetResult().Wait();

			return Products;
		}

		public bool TryAdd(bool isGood)
		{
			if (inAddProgress) return false;
			inAddProgress = true;
			
			Client.SendString(isGood ? Commands.AddProductGood : Commands.AddProductBad);
			WaitAddedResult().Wait();
			
			return addedResult is Results.AddedBad or Results.AddedGood;
		}

		public bool TryRemove()
		{
			if (inRemoveProgress) return false;
			inRemoveProgress = true;

			Client.SendString(Commands.RemoveProduct);
			WaitRemoveResult().Wait();
			
			return removeResult is Results.Removed;
		}

		async Task WaitGetResult()
		{
			while (inGetProgress)
				await Task.Delay(100);
		}

		async Task WaitAddedResult()
		{
			while (inAddProgress)
				await Task.Delay(100);
		}

		async Task WaitRemoveResult()
		{
			while (inRemoveProgress)
				await Task.Delay(100);
		}
	}
}
