using System;
using System.Drawing;

namespace OpenIDE.Core.Controls
{
	/// <summary>
	/// Summary description for ShellControl.
	/// </summary>
	public class ShellControl : System.Windows.Forms.UserControl
	{
		private ShellTextBox shellTextBox;
		public event EventCommandEntered CommandEntered;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ShellControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			

			// TODO: Add any initialization after the InitializeComponent call
		}

		internal void FireCommandEntered(string command)
		{
			OnCommandEntered(command);
		}

		protected virtual void OnCommandEntered(string command)
		{
			if (CommandEntered != null)
				CommandEntered(command, new CommandEnteredEventArgs(command));
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public Color ShellTextForeColor
		{
			get { return shellTextBox != null ? shellTextBox.ForeColor : Color.Green; }
			set 
			{
				if (shellTextBox != null)
					shellTextBox.ForeColor = value;
			}
		}

		public Color ShellTextBackColor
		{
			get { return shellTextBox != null ? shellTextBox.BackColor:Color.Black; }
			set 
			{ 
				if (shellTextBox != null)
					shellTextBox.BackColor = value; 
			}
		}

		public Font ShellTextFont
		{
			get { return shellTextBox != null ? shellTextBox.Font: new Font("Tahoma", 8); }
			set 
			{
				if (shellTextBox != null)
					shellTextBox.Font = value; 
			}
		}

		public void Clear()
		{
			shellTextBox.Clear();
		}

		public void WriteText(string text)
		{
			shellTextBox.WriteText(text);
		}

		public string[] GetCommandHistory()
		{
			return shellTextBox.GetCommandHistory();
		}


		public string Prompt
		{
			get { return shellTextBox.Prompt; }
			set { shellTextBox.Prompt = value; }
		}


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			shellTextBox = new ShellTextBox();
			SuspendLayout();
			// 
			// shellTextBox
			// 
			shellTextBox.AcceptsReturn = true;
			shellTextBox.AcceptsTab = true;
			shellTextBox.BackColor = Color.Black;
			shellTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			shellTextBox.ForeColor = Color.LawnGreen;
			shellTextBox.Location = new System.Drawing.Point(0, 0);
			shellTextBox.Multiline = true;
			shellTextBox.Name = "shellTextBox";
			shellTextBox.Prompt = ">>>";
			shellTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			shellTextBox.BackColor = Color.Black;
			shellTextBox.Font = new Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			shellTextBox.ForeColor = Color.LawnGreen;
			shellTextBox.Size = new System.Drawing.Size(232, 216);
			shellTextBox.TabIndex = 0;
			shellTextBox.Text = "";
			// 
			// ShellControl
			// 
			Controls.Add(shellTextBox);
			Name = "ShellControl";
			Size = new System.Drawing.Size(232, 216);
			ResumeLayout(false);

		}
		#endregion
	}

	public class CommandEnteredEventArgs : EventArgs
	{
		string command;
		public CommandEnteredEventArgs(string command)
		{
			this.command = command;
		}

		public string Command
		{
			get { return command; }
		}
	}

	public delegate void EventCommandEntered(object sender, CommandEnteredEventArgs e);

}