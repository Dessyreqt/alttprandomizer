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
            this.browse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.TextBox();
            this.seed = new System.Windows.Forms.TextBox();
            this.create = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.filename = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.randomSpoiler = new System.Windows.Forms.Button();
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
            // browse
            // 
            this.browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browse.Image = global::AlttpRandomizer.Properties.Resources.MenuFileSaveIcon;
            this.browse.Location = new System.Drawing.Point(454, 82);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(25, 25);
            this.browse.TabIndex = 26;
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
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
            // output
            // 
            this.output.AcceptsReturn = true;
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output.Location = new System.Drawing.Point(10, 111);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.output.Size = new System.Drawing.Size(469, 184);
            this.output.TabIndex = 22;
            this.output.WordWrap = false;
            // 
            // seed
            // 
            this.seed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seed.Location = new System.Drawing.Point(10, 46);
            this.seed.Name = "seed";
            this.seed.Size = new System.Drawing.Size(469, 20);
            this.seed.TabIndex = 27;
            // 
            // create
            // 
            this.create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.create.Location = new System.Drawing.Point(404, 17);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(75, 23);
            this.create.TabIndex = 23;
            this.create.Text = "Create";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
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
            // filename
            // 
            this.filename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filename.Location = new System.Drawing.Point(10, 85);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(438, 20);
            this.filename.TabIndex = 25;
            this.filename.Text = "ALttP Random <seed>.sfc";
            this.filename.TextChanged += new System.EventHandler(this.filename_TextChanged);
            this.filename.Leave += new System.EventHandler(this.filename_Leave);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Location = new System.Drawing.Point(387, 301);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(92, 23);
            this.btnReport.TabIndex = 33;
            this.btnReport.Text = "Report an issue";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // randomSpoiler
            // 
            this.randomSpoiler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.randomSpoiler.Location = new System.Drawing.Point(10, 301);
            this.randomSpoiler.Name = "randomSpoiler";
            this.randomSpoiler.Size = new System.Drawing.Size(100, 23);
            this.randomSpoiler.TabIndex = 34;
            this.randomSpoiler.Text = "Random Spoiler";
            this.randomSpoiler.UseVisualStyleBackColor = true;
            this.randomSpoiler.Click += new System.EventHandler(this.randomSpoiler_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 336);
            this.Controls.Add(this.randomSpoiler);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.createSpoilerLog);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.randomizerDifficulty);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.output);
            this.Controls.Add(this.seed);
            this.Controls.Add(this.create);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.filename);
            this.Name = "MainForm";
            this.Text = "A Link to the Past Randomizer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox createSpoilerLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox randomizerDifficulty;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.TextBox seed;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox filename;
		private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button randomSpoiler;
    }
}

