namespace JRiverController
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtServerIP = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtServerPort = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnGetPlaylistsList = new System.Windows.Forms.Button();
			this.btnTestWebResponse = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtWebResponse = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtServerIP
			// 
			this.txtServerIP.Location = new System.Drawing.Point(103, 17);
			this.txtServerIP.Name = "txtServerIP";
			this.txtServerIP.Size = new System.Drawing.Size(100, 20);
			this.txtServerIP.TabIndex = 0;
			this.txtServerIP.Text = "192.168.0.32";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Server Address";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Port";
			// 
			// txtServerPort
			// 
			this.txtServerPort.Location = new System.Drawing.Point(103, 44);
			this.txtServerPort.Name = "txtServerPort";
			this.txtServerPort.Size = new System.Drawing.Size(100, 20);
			this.txtServerPort.TabIndex = 3;
			this.txtServerPort.Text = "52199";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtServerPort);
			this.groupBox1.Controls.Add(this.txtServerIP);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(513, 78);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Server settings";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Controls.Add(this.btnTestWebResponse);
			this.groupBox2.Controls.Add(this.btnGetPlaylistsList);
			this.groupBox2.Location = new System.Drawing.Point(12, 96);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(513, 281);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "JRiver Controls";
			// 
			// btnGetPlaylistsList
			// 
			this.btnGetPlaylistsList.Location = new System.Drawing.Point(11, 34);
			this.btnGetPlaylistsList.Name = "btnGetPlaylistsList";
			this.btnGetPlaylistsList.Size = new System.Drawing.Size(118, 39);
			this.btnGetPlaylistsList.TabIndex = 0;
			this.btnGetPlaylistsList.Text = "Get Playlists List";
			this.btnGetPlaylistsList.UseVisualStyleBackColor = true;
			this.btnGetPlaylistsList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnGetPlaylistsList_MouseClick);
			// 
			// btnTestWebResponse
			// 
			this.btnTestWebResponse.Location = new System.Drawing.Point(11, 91);
			this.btnTestWebResponse.Name = "btnTestWebResponse";
			this.btnTestWebResponse.Size = new System.Drawing.Size(118, 39);
			this.btnTestWebResponse.TabIndex = 1;
			this.btnTestWebResponse.Text = "Test Web Response";
			this.btnTestWebResponse.UseVisualStyleBackColor = true;
			this.btnTestWebResponse.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnTestWebResponse_MouseClick);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtWebResponse);
			this.groupBox3.Location = new System.Drawing.Point(6, 136);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(501, 139);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Web Server Response";
			// 
			// txtWebResponse
			// 
			this.txtWebResponse.Location = new System.Drawing.Point(7, 20);
			this.txtWebResponse.Multiline = true;
			this.txtWebResponse.Name = "txtWebResponse";
			this.txtWebResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtWebResponse.Size = new System.Drawing.Size(488, 113);
			this.txtWebResponse.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(537, 389);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "JRiver Controller";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox txtServerIP;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtServerPort;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnTestWebResponse;
		private System.Windows.Forms.Button btnGetPlaylistsList;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtWebResponse;
	}
}

