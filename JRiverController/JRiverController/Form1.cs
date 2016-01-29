using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JRiverController
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void btnTestWebResponse_MouseClick(object sender, MouseEventArgs e)
		{
			JRiverCommands jRiverCommands = new JRiverCommands(txtServerIP.Text, txtServerPort.Text);
			string strResponse = jRiverCommands.TestWebServiceResponse();

			txtWebResponse.Text = strResponse;
		}

		private void btnGetPlaylistsList_MouseClick(object sender, MouseEventArgs e)
		{
			JRiverCommands jRiverCommands = new JRiverCommands(txtServerIP.Text, txtServerPort.Text);
			string strResponse = jRiverCommands.GetPlaylistsList();

			txtWebResponse.Text = strResponse;
		}
	}
}
