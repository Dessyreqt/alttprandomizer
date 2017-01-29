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
            this.label3 = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.TextBox();
            this.seed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.filename = new System.Windows.Forms.TextBox();
            this.sramTrace = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.showComplexity = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.heartBeepSpeed = new System.Windows.Forms.ComboBox();
            this.checkForUpdates = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bulkCreateCount = new System.Windows.Forms.NumericUpDown();
            this.bulkCreate = new System.Windows.Forms.Button();
            this.listSpoiler = new System.Windows.Forms.Button();
            this.browse = new System.Windows.Forms.Button();
            this.create = new System.Windows.Forms.Button();
            this.randomSpoiler = new System.Windows.Forms.Button();
            this.report = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bulkCreateCount)).BeginInit();
            this.SuspendLayout();
            // 
            // createSpoilerLog
            // 
            this.createSpoilerLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createSpoilerLog.AutoSize = true;
            this.createSpoilerLog.Location = new System.Drawing.Point(271, 169);
            this.createSpoilerLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.createSpoilerLog.Name = "createSpoilerLog";
            this.createSpoilerLog.Size = new System.Drawing.Size(167, 24);
            this.createSpoilerLog.TabIndex = 32;
            this.createSpoilerLog.Text = "Create Spoiler Log";
            this.createSpoilerLog.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Difficulty:";
            // 
            // randomizerDifficulty
            // 
            this.randomizerDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.randomizerDifficulty.FormattingEnabled = true;
            this.randomizerDifficulty.Items.AddRange(new object[] {
            "Casual",
            "Glitched",
            "No Randomization"});
            this.randomizerDifficulty.Location = new System.Drawing.Point(93, 29);
            this.randomizerDifficulty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.randomizerDifficulty.Name = "randomizerDifficulty";
            this.randomizerDifficulty.Size = new System.Drawing.Size(190, 28);
            this.randomizerDifficulty.TabIndex = 30;
            this.randomizerDifficulty.SelectedIndexChanged += new System.EventHandler(this.randomizerDifficulty_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(358, 20);
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
            this.output.Location = new System.Drawing.Point(18, 282);
            this.output.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.output.Size = new System.Drawing.Size(898, 330);
            this.output.TabIndex = 22;
            this.output.WordWrap = false;
            // 
            // seed
            // 
            this.seed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seed.Location = new System.Drawing.Point(14, 49);
            this.seed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.seed.Name = "seed";
            this.seed.Size = new System.Drawing.Size(572, 26);
            this.seed.TabIndex = 27;
            this.seed.TextChanged += new System.EventHandler(this.seed_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(575, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Output Filename (<seed> is replaced with file seed, <date> is replaced with date)" +
    "";
            // 
            // filename
            // 
            this.filename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filename.Location = new System.Drawing.Point(14, 109);
            this.filename.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(526, 26);
            this.filename.TabIndex = 25;
            this.filename.Text = "ALttP Random <seed>.sfc";
            this.filename.TextChanged += new System.EventHandler(this.filename_TextChanged);
            this.filename.Leave += new System.EventHandler(this.filename_Leave);
            // 
            // sramTrace
            // 
            this.sramTrace.AutoSize = true;
            this.sramTrace.Location = new System.Drawing.Point(9, 112);
            this.sramTrace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sramTrace.Name = "sramTrace";
            this.sramTrace.Size = new System.Drawing.Size(126, 24);
            this.sramTrace.TabIndex = 35;
            this.sramTrace.Text = "SRAM Trace";
            this.sramTrace.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.showComplexity);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.heartBeepSpeed);
            this.groupBox1.Controls.Add(this.checkForUpdates);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.randomizerDifficulty);
            this.groupBox1.Controls.Add(this.sramTrace);
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(294, 254);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Randomizer Options";
            // 
            // showComplexity
            // 
            this.showComplexity.AutoSize = true;
            this.showComplexity.Checked = true;
            this.showComplexity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showComplexity.Location = new System.Drawing.Point(9, 148);
            this.showComplexity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.showComplexity.Name = "showComplexity";
            this.showComplexity.Size = new System.Drawing.Size(155, 24);
            this.showComplexity.TabIndex = 39;
            this.showComplexity.Text = "Show Complexity";
            this.showComplexity.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "Heart Beep Speed:";
            // 
            // heartBeepSpeed
            // 
            this.heartBeepSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.heartBeepSpeed.FormattingEnabled = true;
            this.heartBeepSpeed.Items.AddRange(new object[] {
            "Off",
            "Normal",
            "Half",
            "Quarter"});
            this.heartBeepSpeed.Location = new System.Drawing.Point(165, 71);
            this.heartBeepSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.heartBeepSpeed.Name = "heartBeepSpeed";
            this.heartBeepSpeed.Size = new System.Drawing.Size(118, 28);
            this.heartBeepSpeed.TabIndex = 37;
            // 
            // checkForUpdates
            // 
            this.checkForUpdates.AutoSize = true;
            this.checkForUpdates.Location = new System.Drawing.Point(9, 218);
            this.checkForUpdates.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkForUpdates.Name = "checkForUpdates";
            this.checkForUpdates.Size = new System.Drawing.Size(247, 24);
            this.checkForUpdates.TabIndex = 36;
            this.checkForUpdates.Text = "Check for Updates on Startup";
            this.checkForUpdates.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.bulkCreateCount);
            this.groupBox2.Controls.Add(this.bulkCreate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.filename);
            this.groupBox2.Controls.Add(this.listSpoiler);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.createSpoilerLog);
            this.groupBox2.Controls.Add(this.seed);
            this.groupBox2.Controls.Add(this.browse);
            this.groupBox2.Controls.Add(this.create);
            this.groupBox2.Location = new System.Drawing.Point(321, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(597, 254);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Options";
            // 
            // bulkCreateCount
            // 
            this.bulkCreateCount.Location = new System.Drawing.Point(14, 211);
            this.bulkCreateCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bulkCreateCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bulkCreateCount.Name = "bulkCreateCount";
            this.bulkCreateCount.Size = new System.Drawing.Size(66, 26);
            this.bulkCreateCount.TabIndex = 38;
            this.bulkCreateCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // bulkCreate
            // 
            this.bulkCreate.Image = global::AlttpRandomizer.Properties.Resources.bulk_checkmark;
            this.bulkCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bulkCreate.Location = new System.Drawing.Point(88, 208);
            this.bulkCreate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bulkCreate.Name = "bulkCreate";
            this.bulkCreate.Size = new System.Drawing.Size(140, 37);
            this.bulkCreate.TabIndex = 37;
            this.bulkCreate.Text = "Bulk Create";
            this.bulkCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bulkCreate.UseVisualStyleBackColor = true;
            this.bulkCreate.Click += new System.EventHandler(this.bulkCreate_Click);
            // 
            // listSpoiler
            // 
            this.listSpoiler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listSpoiler.Image = global::AlttpRandomizer.Properties.Resources.bulleted_list_options;
            this.listSpoiler.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.listSpoiler.Location = new System.Drawing.Point(447, 208);
            this.listSpoiler.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listSpoiler.Name = "listSpoiler";
            this.listSpoiler.Size = new System.Drawing.Size(140, 37);
            this.listSpoiler.TabIndex = 36;
            this.listSpoiler.Text = "List Spoiler";
            this.listSpoiler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.listSpoiler.UseVisualStyleBackColor = true;
            this.listSpoiler.Click += new System.EventHandler(this.listSpoiler_Click);
            // 
            // browse
            // 
            this.browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browse.Image = global::AlttpRandomizer.Properties.Resources.MenuFileSaveIcon;
            this.browse.Location = new System.Drawing.Point(550, 105);
            this.browse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(38, 38);
            this.browse.TabIndex = 26;
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // create
            // 
            this.create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.create.Image = global::AlttpRandomizer.Properties.Resources.base_checkmark;
            this.create.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.create.Location = new System.Drawing.Point(447, 162);
            this.create.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(140, 37);
            this.create.TabIndex = 23;
            this.create.Text = "Create";
            this.create.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // randomSpoiler
            // 
            this.randomSpoiler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.randomSpoiler.Image = global::AlttpRandomizer.Properties.Resources._112_RefreshArrow_Blue;
            this.randomSpoiler.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.randomSpoiler.Location = new System.Drawing.Point(18, 623);
            this.randomSpoiler.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.randomSpoiler.Name = "randomSpoiler";
            this.randomSpoiler.Size = new System.Drawing.Size(183, 37);
            this.randomSpoiler.TabIndex = 34;
            this.randomSpoiler.Text = "Random Spoiler";
            this.randomSpoiler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.randomSpoiler.UseVisualStyleBackColor = true;
            this.randomSpoiler.Click += new System.EventHandler(this.randomSpoiler_Click);
            // 
            // report
            // 
            this.report.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.report.Image = global::AlttpRandomizer.Properties.Resources.base_exclamationmark;
            this.report.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.report.Location = new System.Drawing.Point(720, 623);
            this.report.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(198, 37);
            this.report.TabIndex = 33;
            this.report.Text = "Report an issue";
            this.report.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.report.UseVisualStyleBackColor = true;
            this.report.Click += new System.EventHandler(this.report_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 678);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.randomSpoiler);
            this.Controls.Add(this.report);
            this.Controls.Add(this.output);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(949, 708);
            this.Name = "MainForm";
            this.Text = "A Link to the Past Randomizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bulkCreateCount)).EndInit();
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
        private System.Windows.Forms.Button report;
        private System.Windows.Forms.Button randomSpoiler;
        private System.Windows.Forms.CheckBox sramTrace;
        private System.Windows.Forms.Button listSpoiler;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkForUpdates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox heartBeepSpeed;
        private System.Windows.Forms.Button bulkCreate;
        private System.Windows.Forms.NumericUpDown bulkCreateCount;
        private System.Windows.Forms.CheckBox showComplexity;
    }
}

