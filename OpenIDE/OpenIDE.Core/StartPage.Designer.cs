﻿namespace OpenIDE.Core
{
    partial class StartPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartPage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.openProjectLink = new System.Windows.Forms.LinkLabel();
            this.newProjectLink = new System.Windows.Forms.LinkLabel();
            this.startLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.newsLabel = new System.Windows.Forms.Label();
            this.newsList = new Telerik.WinControls.UI.RadListControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newsList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.openProjectLink);
            this.panel1.Controls.Add(this.newProjectLink);
            this.panel1.Controls.Add(this.startLabel);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 531);
            this.panel1.TabIndex = 0;
            // 
            // openProjectLink
            // 
            this.openProjectLink.AutoSize = true;
            this.openProjectLink.Location = new System.Drawing.Point(18, 205);
            this.openProjectLink.Name = "openProjectLink";
            this.openProjectLink.Size = new System.Drawing.Size(69, 13);
            this.openProjectLink.TabIndex = 2;
            this.openProjectLink.TabStop = true;
            this.openProjectLink.Text = "Open Project";
            this.openProjectLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.openProjectLink_LinkClicked);
            // 
            // newProjectLink
            // 
            this.newProjectLink.AutoSize = true;
            this.newProjectLink.Location = new System.Drawing.Point(18, 176);
            this.newProjectLink.Name = "newProjectLink";
            this.newProjectLink.Size = new System.Drawing.Size(65, 13);
            this.newProjectLink.TabIndex = 1;
            this.newProjectLink.TabStop = true;
            this.newProjectLink.Text = "New Project";
            this.newProjectLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.newProjectLink_LinkClicked);
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.BackColor = System.Drawing.SystemColors.Control;
            this.startLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.ForeColor = System.Drawing.Color.Black;
            this.startLabel.Location = new System.Drawing.Point(17, 139);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(46, 24);
            this.startLabel.TabIndex = 0;
            this.startLabel.Text = "Start";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // newsLabel
            // 
            this.newsLabel.AutoSize = true;
            this.newsLabel.BackColor = System.Drawing.Color.Transparent;
            this.newsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newsLabel.ForeColor = System.Drawing.Color.Black;
            this.newsLabel.Location = new System.Drawing.Point(278, 20);
            this.newsLabel.Name = "newsLabel";
            this.newsLabel.Size = new System.Drawing.Size(58, 24);
            this.newsLabel.TabIndex = 3;
            this.newsLabel.Text = "News";
            // 
            // newsList
            // 
            this.newsList.EnableTheming = false;
            this.newsList.Location = new System.Drawing.Point(282, 48);
            this.newsList.Name = "newsList";
            this.newsList.Size = new System.Drawing.Size(606, 467);
            this.newsList.TabIndex = 4;
            this.newsList.Text = "radListControl1";
            // 
            // StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.newsList);
            this.Controls.Add(this.newsLabel);
            this.Controls.Add(this.panel1);
            this.Name = "StartPage";
            this.Size = new System.Drawing.Size(891, 531);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel openProjectLink;
        private System.Windows.Forms.LinkLabel newProjectLink;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label newsLabel;
        private Telerik.WinControls.UI.RadListControl newsList;
    }
}
