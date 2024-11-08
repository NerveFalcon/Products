using Products.Data;
using Products.Data.Net;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.UI
{
	public class NetService : Data.Net.NetService
	{
		public NetService() : base()
        {
			AddHandler(Results.AddedGood, AddedGood);
			AddHandler(Results.List, AddedGood);
		}

		private void AddedGood()
		{
			throw new NotImplementedException();
		}

		internal async Task LoadProducts()
		{
			await SendAsync(Commands.GetProducts);
		}
	}
}
