
namespace MassRobloxAssetStealer
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.TopBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.LogBox = new VertexFramework.UIControls.VRichTextBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.KeywordBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ItemCount = new System.Windows.Forms.ComboBox();
            this.PageCountForAudio = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Start = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ItemTypeCombo = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FindLocation = new Guna.UI2.WinForms.Guna2Button();
            this.SaveLocTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.TopBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopBar
            // 
            this.TopBar.Controls.Add(this.label1);
            this.TopBar.Controls.Add(this.guna2ControlBox2);
            this.TopBar.Controls.Add(this.guna2ControlBox1);
            this.TopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopBar.Location = new System.Drawing.Point(0, 0);
            this.TopBar.Name = "TopBar";
            this.TopBar.Size = new System.Drawing.Size(736, 33);
            this.TopBar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Iris\'s Infinity Bulk Downloader";
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Animated = true;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.guna2ControlBox2.HoverState.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(665, 0);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.ShadowDecoration.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.Size = new System.Drawing.Size(38, 33);
            this.guna2ControlBox2.TabIndex = 1;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Animated = true;
            this.guna2ControlBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(703, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(33, 33);
            this.guna2ControlBox1.TabIndex = 0;
            // 
            // LogBox
            // 
            this.LogBox.BackColor = System.Drawing.Color.Black;
            this.LogBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogBox.ForeColor = System.Drawing.Color.White;
            this.LogBox.Location = new System.Drawing.Point(44, 256);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(659, 101);
            this.LogBox.TabIndex = 1;
            this.LogBox.Text = "Logging Started";
            this.LogBox.TextChanged += new System.EventHandler(this.LogBox_TextChanged);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.TopBar;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Settings";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.KeywordBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ItemCount);
            this.panel1.Controls.Add(this.PageCountForAudio);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Start);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.ItemTypeCombo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.FindLocation);
            this.panel1.Controls.Add(this.SaveLocTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(42, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 196);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(236, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(251, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "*";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(483, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(175, 130);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(474, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "*";
            // 
            // KeywordBox
            // 
            this.KeywordBox.Animated = true;
            this.KeywordBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.KeywordBox.DefaultText = "";
            this.KeywordBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.KeywordBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.KeywordBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.KeywordBox.DisabledState.Parent = this.KeywordBox;
            this.KeywordBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.KeywordBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.KeywordBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.KeywordBox.FocusedState.Parent = this.KeywordBox;
            this.KeywordBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.KeywordBox.ForeColor = System.Drawing.Color.White;
            this.KeywordBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.KeywordBox.HoverState.Parent = this.KeywordBox;
            this.KeywordBox.Location = new System.Drawing.Point(108, 115);
            this.KeywordBox.Name = "KeywordBox";
            this.KeywordBox.PasswordChar = '\0';
            this.KeywordBox.PlaceholderText = "";
            this.KeywordBox.SelectedText = "";
            this.KeywordBox.ShadowDecoration.Parent = this.KeywordBox;
            this.KeywordBox.Size = new System.Drawing.Size(322, 22);
            this.KeywordBox.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 14);
            this.label7.TabIndex = 17;
            this.label7.Text = "Search Param:";
            // 
            // ItemCount
            // 
            this.ItemCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ItemCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ItemCount.ForeColor = System.Drawing.Color.White;
            this.ItemCount.FormattingEnabled = true;
            this.ItemCount.Items.AddRange(new object[] {
            "100",
            "200",
            "300",
            "400",
            "500",
            "600",
            "700",
            "800",
            "900",
            "1000",
            "1100",
            "1200",
            "1300",
            "1400",
            "1500",
            "1600",
            "1700",
            "1800",
            "1900",
            "2000"});
            this.ItemCount.Location = new System.Drawing.Point(109, 84);
            this.ItemCount.Name = "ItemCount";
            this.ItemCount.Size = new System.Drawing.Size(121, 21);
            this.ItemCount.TabIndex = 13;
            this.ItemCount.Text = "100";
            // 
            // PageCountForAudio
            // 
            this.PageCountForAudio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PageCountForAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PageCountForAudio.ForeColor = System.Drawing.Color.White;
            this.PageCountForAudio.FormattingEnabled = true;
            this.PageCountForAudio.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.PageCountForAudio.Location = new System.Drawing.Point(109, 84);
            this.PageCountForAudio.Name = "PageCountForAudio";
            this.PageCountForAudio.Size = new System.Drawing.Size(121, 21);
            this.PageCountForAudio.TabIndex = 16;
            this.PageCountForAudio.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(485, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Specific IDs (Seperate by new lines)";
            // 
            // Start
            // 
            this.Start.CheckedState.Parent = this.Start;
            this.Start.CustomImages.Parent = this.Start;
            this.Start.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Start.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Start.ForeColor = System.Drawing.Color.White;
            this.Start.HoverState.Parent = this.Start;
            this.Start.Location = new System.Drawing.Point(250, 152);
            this.Start.Name = "Start";
            this.Start.ShadowDecoration.Parent = this.Start;
            this.Start.Size = new System.Drawing.Size(180, 30);
            this.Start.TabIndex = 12;
            this.Start.Text = "Start";
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "Item Count:";
            // 
            // ItemTypeCombo
            // 
            this.ItemTypeCombo.BackColor = System.Drawing.Color.Transparent;
            this.ItemTypeCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ItemTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ItemTypeCombo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ItemTypeCombo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ItemTypeCombo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ItemTypeCombo.FocusedState.Parent = this.ItemTypeCombo;
            this.ItemTypeCombo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ItemTypeCombo.ForeColor = System.Drawing.Color.White;
            this.ItemTypeCombo.HoverState.Parent = this.ItemTypeCombo;
            this.ItemTypeCombo.ItemHeight = 30;
            this.ItemTypeCombo.Items.AddRange(new object[] {
            "Shirts",
            "Pants",
            "Audio",
            "Face"});
            this.ItemTypeCombo.ItemsAppearance.Parent = this.ItemTypeCombo;
            this.ItemTypeCombo.Location = new System.Drawing.Point(109, 42);
            this.ItemTypeCombo.Name = "ItemTypeCombo";
            this.ItemTypeCombo.ShadowDecoration.Parent = this.ItemTypeCombo;
            this.ItemTypeCombo.Size = new System.Drawing.Size(136, 36);
            this.ItemTypeCombo.StartIndex = 0;
            this.ItemTypeCombo.TabIndex = 9;
            this.ItemTypeCombo.SelectedIndexChanged += new System.EventHandler(this.ItemTypeCombo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Catalog Type: ";
            // 
            // FindLocation
            // 
            this.FindLocation.Animated = true;
            this.FindLocation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.FindLocation.BorderThickness = 1;
            this.FindLocation.CheckedState.Parent = this.FindLocation;
            this.FindLocation.CustomImages.Parent = this.FindLocation;
            this.FindLocation.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.FindLocation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FindLocation.ForeColor = System.Drawing.Color.White;
            this.FindLocation.HoverState.Parent = this.FindLocation;
            this.FindLocation.Location = new System.Drawing.Point(437, 14);
            this.FindLocation.Name = "FindLocation";
            this.FindLocation.ShadowDecoration.Parent = this.FindLocation;
            this.FindLocation.Size = new System.Drawing.Size(31, 22);
            this.FindLocation.TabIndex = 7;
            this.FindLocation.Text = "...";
            this.FindLocation.Click += new System.EventHandler(this.FindLocation_Click);
            // 
            // SaveLocTextBox
            // 
            this.SaveLocTextBox.Animated = true;
            this.SaveLocTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SaveLocTextBox.DefaultText = "";
            this.SaveLocTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.SaveLocTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.SaveLocTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SaveLocTextBox.DisabledState.Parent = this.SaveLocTextBox;
            this.SaveLocTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SaveLocTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.SaveLocTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SaveLocTextBox.FocusedState.Parent = this.SaveLocTextBox;
            this.SaveLocTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SaveLocTextBox.ForeColor = System.Drawing.Color.White;
            this.SaveLocTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SaveLocTextBox.HoverState.Parent = this.SaveLocTextBox;
            this.SaveLocTextBox.Location = new System.Drawing.Point(109, 14);
            this.SaveLocTextBox.Name = "SaveLocTextBox";
            this.SaveLocTextBox.PasswordChar = '\0';
            this.SaveLocTextBox.PlaceholderText = "";
            this.SaveLocTextBox.ReadOnly = true;
            this.SaveLocTextBox.SelectedText = "";
            this.SaveLocTextBox.ShadowDecoration.Parent = this.SaveLocTextBox;
            this.SaveLocTextBox.Size = new System.Drawing.Size(322, 22);
            this.SaveLocTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Save Location:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(6, 165);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(183, 17);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "Show Debug Console (Extra Info)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(736, 369);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.TopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Main_Load);
            this.TopBar.ResumeLayout(false);
            this.TopBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TopBar;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Label label1;
        private VertexFramework.UIControls.VRichTextBox LogBox;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button Start;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox ItemTypeCombo;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button FindLocation;
        private Guna.UI2.WinForms.Guna2TextBox SaveLocTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ItemCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox PageCountForAudio;
        private Guna.UI2.WinForms.Guna2TextBox KeywordBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

