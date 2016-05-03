namespace AlttpRandomizer
{
    partial class MainForm
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
            this.createSpoilerLog = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.randomizerDifficulty = new System.Windows.Forms.ComboBox();
            this.browseV11 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.outputV11 = new System.Windows.Forms.TextBox();
            this.seedV11 = new System.Windows.Forms.TextBox();
            this.createV11 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.filenameV11 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // createSpoilerLog
            // 
            this.createSpoilerLog.AutoSize = true;
            this.createSpoilerLog.Location = new System.Drawing.Point(196, 7);
            this.createSpoilerLog.Name = "createSpoilerLog";
            this.createSpoilerLog.Size = new System.Drawing.Size(113, 17);
            this.createSpoilerLog.TabIndex = 32;
            this.createSpoilerLog.Text = "Create Spoiler Log";
            this.createSpoilerLog.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Difficulty:";
            // 
            // randomizerDifficulty
            // 
            this.randomizerDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.randomizerDifficulty.FormattingEnabled = true;
            this.randomizerDifficulty.Items.AddRange(new object[] {
            "Casual"});
            this.randomizerDifficulty.Location = new System.Drawing.Point(68, 6);
            this.randomizerDifficulty.Name = "randomizerDifficulty";
            this.randomizerDifficulty.Size = new System.Drawing.Size(121, 21);
            this.randomizerDifficulty.TabIndex = 30;
            // 
            // browseV11
            // 
            this.browseV11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseV11.Location = new System.Drawing.Point(454, 82);
            this.browseV11.Name = "browseV11";
            this.browseV11.Size = new System.Drawing.Size(25, 25);
            this.browseV11.TabIndex = 26;
            this.browseV11.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Seed (leave blank to generate new random ROM)";
            // 
            // outputV11
            // 
            this.outputV11.AcceptsReturn = true;
            this.outputV11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputV11.Location = new System.Drawing.Point(10, 111);
            this.outputV11.Multiline = true;
            this.outputV11.Name = "outputV11";
            this.outputV11.ReadOnly = true;
            this.outputV11.Size = new System.Drawing.Size(469, 213);
            this.outputV11.TabIndex = 22;
            // 
            // seedV11
            // 
            this.seedV11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seedV11.Location = new System.Drawing.Point(10, 46);
            this.seedV11.Name = "seedV11";
            this.seedV11.Size = new System.Drawing.Size(469, 20);
            this.seedV11.TabIndex = 27;
            // 
            // createV11
            // 
            this.createV11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createV11.Location = new System.Drawing.Point(404, 17);
            this.createV11.Name = "createV11";
            this.createV11.Size = new System.Drawing.Size(75, 23);
            this.createV11.TabIndex = 23;
            this.createV11.Text = "Create";
            this.createV11.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(385, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Output Filename (<seed> is replaced with file seed, <date> is replaced with date)" +
    "";
            // 
            // filenameV11
            // 
            this.filenameV11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameV11.Location = new System.Drawing.Point(10, 85);
            this.filenameV11.Name = "filenameV11";
            this.filenameV11.Size = new System.Drawing.Size(438, 20);
            this.filenameV11.TabIndex = 25;
            this.filenameV11.Text = "ALttP Random <seed>.sfc";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 336);
            this.Controls.Add(this.createSpoilerLog);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.randomizerDifficulty);
            this.Controls.Add(this.browseV11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.outputV11);
            this.Controls.Add(this.seedV11);
            this.Controls.Add(this.createV11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.filenameV11);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox createSpoilerLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox randomizerDifficulty;
        private System.Windows.Forms.Button browseV11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox outputV11;
        private System.Windows.Forms.TextBox seedV11;
        private System.Windows.Forms.Button createV11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox filenameV11;
    }
}

