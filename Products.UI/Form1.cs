using Products.Data.Net;

namespace Products.UI
{
	public partial class Form1 : Form
	{
		bool IsGood => isGoodBox.Checked;
		NetService NetService {  get; set; }
		Task? ListenProcess { get; set; }
		public Form1()
		{
			InitializeComponent();
			NetService = new();

			ListenProcess = NetService.StartListenAsync();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			NetService.LoadProducts();
		}

		private void Camera_Click(object sender, EventArgs e) 
			=> NetService.SendAsync(IsGood ? Commands.AddProductGood
										   : Commands.AddProductBad)
						 .Wait();
	}
}
