namespace samp_upsav
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.data_x = new System.Windows.Forms.CheckBox();
            this.data_y = new System.Windows.Forms.CheckBox();
            this.data_z = new System.Windows.Forms.CheckBox();
            this.data_ang = new System.Windows.Forms.CheckBox();
            this.data_rad = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.bt_about = new System.Windows.Forms.Button();
            this.text_start = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.text_end = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.text_sep = new System.Windows.Forms.TextBox();
            this.data_snd = new System.Windows.Forms.CheckBox();
            this.bt_attach = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Koordináták mentési módja / Coords saving method:";
            // 
            // data_x
            // 
            this.data_x.AutoSize = true;
            this.data_x.Checked = true;
            this.data_x.CheckState = System.Windows.Forms.CheckState.Checked;
            this.data_x.Location = new System.Drawing.Point(12, 34);
            this.data_x.Name = "data_x";
            this.data_x.Size = new System.Drawing.Size(33, 17);
            this.data_x.TabIndex = 1;
            this.data_x.Text = "X";
            this.data_x.UseVisualStyleBackColor = true;
            // 
            // data_y
            // 
            this.data_y.AutoSize = true;
            this.data_y.Checked = true;
            this.data_y.CheckState = System.Windows.Forms.CheckState.Checked;
            this.data_y.Location = new System.Drawing.Point(51, 34);
            this.data_y.Name = "data_y";
            this.data_y.Size = new System.Drawing.Size(33, 17);
            this.data_y.TabIndex = 1;
            this.data_y.Text = "Y";
            this.data_y.UseVisualStyleBackColor = true;
            // 
            // data_z
            // 
            this.data_z.AutoSize = true;
            this.data_z.Checked = true;
            this.data_z.CheckState = System.Windows.Forms.CheckState.Checked;
            this.data_z.Location = new System.Drawing.Point(90, 34);
            this.data_z.Name = "data_z";
            this.data_z.Size = new System.Drawing.Size(33, 17);
            this.data_z.TabIndex = 1;
            this.data_z.Text = "Z";
            this.data_z.UseVisualStyleBackColor = true;
            // 
            // data_ang
            // 
            this.data_ang.AutoSize = true;
            this.data_ang.Location = new System.Drawing.Point(129, 34);
            this.data_ang.Name = "data_ang";
            this.data_ang.Size = new System.Drawing.Size(53, 17);
            this.data_ang.TabIndex = 1;
            this.data_ang.Text = "Angle";
            this.data_ang.UseVisualStyleBackColor = true;
            // 
            // data_rad
            // 
            this.data_rad.AutoSize = true;
            this.data_rad.Location = new System.Drawing.Point(188, 34);
            this.data_rad.Name = "data_rad";
            this.data_rad.Size = new System.Drawing.Size(59, 17);
            this.data_rad.TabIndex = 1;
            this.data_rad.Text = "Radius";
            this.data_rad.UseVisualStyleBackColor = true;
            this.data_rad.CheckedChanged += new System.EventHandler(this.data_rad_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(253, 33);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(68, 20);
            this.numericUpDown1.TabIndex = 2;
            // 
            // bt_about
            // 
            this.bt_about.Location = new System.Drawing.Point(12, 171);
            this.bt_about.Name = "bt_about";
            this.bt_about.Size = new System.Drawing.Size(92, 24);
            this.bt_about.TabIndex = 3;
            this.bt_about.Text = "About";
            this.bt_about.UseVisualStyleBackColor = true;
            this.bt_about.Click += new System.EventHandler(this.bt_about_Click);
            // 
            // text_start
            // 
            this.text_start.Location = new System.Drawing.Point(12, 79);
            this.text_start.Name = "text_start";
            this.text_start.Size = new System.Drawing.Size(309, 20);
            this.text_start.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Start/Kezdet:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "End/Vég:";
            // 
            // text_end
            // 
            this.text_end.Location = new System.Drawing.Point(12, 118);
            this.text_end.Name = "text_end";
            this.text_end.Size = new System.Drawing.Size(309, 20);
            this.text_end.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Separator/Elválasztó:";
            // 
            // text_sep
            // 
            this.text_sep.Location = new System.Drawing.Point(124, 147);
            this.text_sep.MaxLength = 1;
            this.text_sep.Name = "text_sep";
            this.text_sep.Size = new System.Drawing.Size(24, 20);
            this.text_sep.TabIndex = 7;
            this.text_sep.Text = ",";
            // 
            // data_snd
            // 
            this.data_snd.AutoSize = true;
            this.data_snd.Checked = true;
            this.data_snd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.data_snd.Location = new System.Drawing.Point(154, 149);
            this.data_snd.Name = "data_snd";
            this.data_snd.Size = new System.Drawing.Size(88, 17);
            this.data_snd.TabIndex = 8;
            this.data_snd.Text = "Hang/Sound";
            this.data_snd.UseVisualStyleBackColor = true;
            // 
            // bt_attach
            // 
            this.bt_attach.Location = new System.Drawing.Point(110, 172);
            this.bt_attach.Name = "bt_attach";
            this.bt_attach.Size = new System.Drawing.Size(212, 24);
            this.bt_attach.TabIndex = 11;
            this.bt_attach.Text = "Attach to San Andreas";
            this.bt_attach.UseVisualStyleBackColor = true;
            this.bt_attach.Click += new System.EventHandler(this.bt_attach_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 205);
            this.Controls.Add(this.bt_attach);
            this.Controls.Add(this.data_snd);
            this.Controls.Add(this.text_sep);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_end);
            this.Controls.Add(this.text_start);
            this.Controls.Add(this.bt_about);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.data_rad);
            this.Controls.Add(this.data_ang);
            this.Controls.Add(this.data_z);
            this.Controls.Add(this.data_y);
            this.Controls.Add(this.data_x);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SA-MP Ultimate Position Saver";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox data_x;
        private System.Windows.Forms.CheckBox data_y;
        private System.Windows.Forms.CheckBox data_z;
        private System.Windows.Forms.CheckBox data_ang;
        private System.Windows.Forms.CheckBox data_rad;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button bt_about;
        private System.Windows.Forms.TextBox text_start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_end;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_sep;
        private System.Windows.Forms.CheckBox data_snd;
        private System.Windows.Forms.Button bt_attach;
    }
}

