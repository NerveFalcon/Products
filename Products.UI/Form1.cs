namespace Products.UI;

public partial class Form1 : Form
{
	bool IsGood => isGoodBox.Checked;
	PictureBox[] pictures = new PictureBox[5];

	NetService NetService { get; set; }
	public Form1()
	{
		InitializeComponent();
		NetService = new();
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		pictures[0] = pictureBox1;
		pictures[1] = pictureBox2;
		pictures[2] = pictureBox3;
		pictures[3] = pictureBox4;
		pictures[4] = pictureBox5;
		ReDrawImage();
	}

	void ReDrawImage()
	{
		foreach (var pic in pictures)
			pic.BackColor = Color.Gray;
		var products = NetService.GetSnapshot();
		for (int i = 0; i < products.Length; i++)
			pictures[i].BackColor = products[i].IsGood ? Color.Green : Color.Yellow;
	}

	private void Camera_Click(object sender, EventArgs e)
	{
		Camera.Enabled = false;
		if (NetService.TryAdd(IsGood))
			ReDrawImage();
		Camera.Enabled = true;
	}

	private void Pusher_Click(object sender, EventArgs e)
	{
		Pusher.Enabled = false;
		if (NetService.TryRemove())
			ReDrawImage();
		Pusher.Enabled = true;
	}
}
