namespace Products.UI
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Camera = new Button();
			Pusher = new Button();
			isGoodBox = new CheckBox();
			pictureBox1 = new PictureBox();
			pictureBox2 = new PictureBox();
			pictureBox3 = new PictureBox();
			pictureBox4 = new PictureBox();
			pictureBox5 = new PictureBox();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
			SuspendLayout();
			// 
			// Camera
			// 
			Camera.Location = new Point(177, 104);
			Camera.Name = "Camera";
			Camera.Size = new Size(75, 23);
			Camera.TabIndex = 0;
			Camera.Text = "Камера";
			Camera.UseVisualStyleBackColor = true;
			Camera.Click += Camera_Click;
			// 
			// Pusher
			// 
			Pusher.Location = new Point(543, 104);
			Pusher.Name = "Pusher";
			Pusher.Size = new Size(75, 23);
			Pusher.TabIndex = 1;
			Pusher.Text = "Толкатель";
			Pusher.UseVisualStyleBackColor = true;
			// 
			// isGoodBox
			// 
			isGoodBox.AutoSize = true;
			isGoodBox.Location = new Point(177, 148);
			isGoodBox.Name = "isGoodBox";
			isGoodBox.Size = new Size(79, 19);
			isGoodBox.TabIndex = 2;
			isGoodBox.Text = "Без брака";
			isGoodBox.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			pictureBox1.Location = new Point(258, 92);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(51, 50);
			pictureBox1.TabIndex = 3;
			pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			pictureBox2.Location = new Point(315, 92);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new Size(51, 50);
			pictureBox2.TabIndex = 3;
			pictureBox2.TabStop = false;
			// 
			// pictureBox3
			// 
			pictureBox3.Location = new Point(372, 92);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new Size(51, 50);
			pictureBox3.TabIndex = 3;
			pictureBox3.TabStop = false;
			// 
			// pictureBox4
			// 
			pictureBox4.Location = new Point(429, 92);
			pictureBox4.Name = "pictureBox4";
			pictureBox4.Size = new Size(51, 50);
			pictureBox4.TabIndex = 3;
			pictureBox4.TabStop = false;
			// 
			// pictureBox5
			// 
			pictureBox5.Location = new Point(486, 92);
			pictureBox5.Name = "pictureBox5";
			pictureBox5.Size = new Size(51, 50);
			pictureBox5.TabIndex = 3;
			pictureBox5.TabStop = false;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(pictureBox5);
			Controls.Add(pictureBox4);
			Controls.Add(pictureBox3);
			Controls.Add(pictureBox2);
			Controls.Add(pictureBox1);
			Controls.Add(isGoodBox);
			Controls.Add(Pusher);
			Controls.Add(Camera);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button Camera;
		private Button Pusher;
		private CheckBox isGoodBox;
		private PictureBox pictureBox1;
		private PictureBox pictureBox2;
		private PictureBox pictureBox3;
		private PictureBox pictureBox4;
		private PictureBox pictureBox5;
	}
}
