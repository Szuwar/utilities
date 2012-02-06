namespace niji
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lmd5 = new System.Windows.Forms.Label();
            this.pmd5 = new System.Windows.Forms.ProgressBar();
            this.lsha1 = new System.Windows.Forms.Label();
            this.psha1 = new System.Windows.Forms.ProgressBar();
            this.lsha256 = new System.Windows.Forms.Label();
            this.psha256 = new System.Windows.Forms.ProgressBar();
            this.lsha512 = new System.Windows.Forms.Label();
            this.psha512 = new System.Windows.Forms.ProgressBar();
            this.llm = new System.Windows.Forms.Label();
            this.plm = new System.Windows.Forms.ProgressBar();
            this.lntlm = new System.Windows.Forms.Label();
            this.pntlm = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Step 1: Select Dictionary File";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 20);
            this.button1.TabIndex = 0;
            this.button1.Text = "...";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(328, 20);
            this.textBox1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox6);
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(13, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(371, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Step 2: Select Hash Types";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(49, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "MD5";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(61, 19);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(54, 17);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "SHA1";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(121, 19);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(66, 17);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "SHA256";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(193, 19);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(66, 17);
            this.checkBox4.TabIndex = 0;
            this.checkBox4.Text = "SHA512";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Enabled = false;
            this.checkBox5.Location = new System.Drawing.Point(312, 19);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(56, 17);
            this.checkBox5.TabIndex = 0;
            this.checkBox5.Text = "NTLM";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Enabled = false;
            this.checkBox6.Location = new System.Drawing.Point(265, 19);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(41, 17);
            this.checkBox6.TabIndex = 0;
            this.checkBox6.Text = "LM";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(13, 122);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(371, 48);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Step 3: Select Output Folder";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(328, 20);
            this.textBox2.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(340, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 20);
            this.button2.TabIndex = 0;
            this.button2.Text = "...";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(13, 176);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(371, 39);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Step 5: Misc Options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seperator:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(68, 13);
            this.textBox3.MaxLength = 1;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(10, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = ",";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Location = new System.Drawing.Point(13, 221);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(371, 57);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Step 6: Go!";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(13, 284);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(371, 217);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(7, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Generate";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(193, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(172, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "Abort";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.pntlm);
            this.groupBox6.Controls.Add(this.psha256);
            this.groupBox6.Controls.Add(this.lntlm);
            this.groupBox6.Controls.Add(this.plm);
            this.groupBox6.Controls.Add(this.lsha256);
            this.groupBox6.Controls.Add(this.llm);
            this.groupBox6.Controls.Add(this.psha1);
            this.groupBox6.Controls.Add(this.psha512);
            this.groupBox6.Controls.Add(this.lsha1);
            this.groupBox6.Controls.Add(this.lsha512);
            this.groupBox6.Controls.Add(this.pmd5);
            this.groupBox6.Controls.Add(this.lmd5);
            this.groupBox6.Location = new System.Drawing.Point(12, 507);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(372, 284);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Progress";
            // 
            // lmd5
            // 
            this.lmd5.AutoSize = true;
            this.lmd5.Location = new System.Drawing.Point(3, 21);
            this.lmd5.Name = "lmd5";
            this.lmd5.Size = new System.Drawing.Size(71, 13);
            this.lmd5.TabIndex = 0;
            this.lmd5.Text = "MD5: 0.000%";
            // 
            // pmd5
            // 
            this.pmd5.Location = new System.Drawing.Point(6, 37);
            this.pmd5.Name = "pmd5";
            this.pmd5.Size = new System.Drawing.Size(360, 23);
            this.pmd5.TabIndex = 1;
            // 
            // lsha1
            // 
            this.lsha1.AutoSize = true;
            this.lsha1.Location = new System.Drawing.Point(3, 66);
            this.lsha1.Name = "lsha1";
            this.lsha1.Size = new System.Drawing.Size(76, 13);
            this.lsha1.TabIndex = 0;
            this.lsha1.Text = "SHA1: 0.000%";
            // 
            // psha1
            // 
            this.psha1.Location = new System.Drawing.Point(6, 82);
            this.psha1.Name = "psha1";
            this.psha1.Size = new System.Drawing.Size(360, 23);
            this.psha1.TabIndex = 1;
            // 
            // lsha256
            // 
            this.lsha256.AutoSize = true;
            this.lsha256.Location = new System.Drawing.Point(3, 110);
            this.lsha256.Name = "lsha256";
            this.lsha256.Size = new System.Drawing.Size(88, 13);
            this.lsha256.TabIndex = 0;
            this.lsha256.Text = "SHA256: 0.000%";
            // 
            // psha256
            // 
            this.psha256.Location = new System.Drawing.Point(6, 126);
            this.psha256.Name = "psha256";
            this.psha256.Size = new System.Drawing.Size(360, 23);
            this.psha256.TabIndex = 1;
            // 
            // lsha512
            // 
            this.lsha512.AutoSize = true;
            this.lsha512.Location = new System.Drawing.Point(3, 150);
            this.lsha512.Name = "lsha512";
            this.lsha512.Size = new System.Drawing.Size(88, 13);
            this.lsha512.TabIndex = 0;
            this.lsha512.Text = "SHA512: 0.000%";
            // 
            // psha512
            // 
            this.psha512.Location = new System.Drawing.Point(6, 166);
            this.psha512.Name = "psha512";
            this.psha512.Size = new System.Drawing.Size(360, 23);
            this.psha512.TabIndex = 1;
            // 
            // llm
            // 
            this.llm.AutoSize = true;
            this.llm.Enabled = false;
            this.llm.Location = new System.Drawing.Point(3, 195);
            this.llm.Name = "llm";
            this.llm.Size = new System.Drawing.Size(63, 13);
            this.llm.TabIndex = 0;
            this.llm.Text = "LM: 0.000%";
            // 
            // plm
            // 
            this.plm.Enabled = false;
            this.plm.Location = new System.Drawing.Point(6, 211);
            this.plm.Name = "plm";
            this.plm.Size = new System.Drawing.Size(360, 23);
            this.plm.TabIndex = 1;
            // 
            // lntlm
            // 
            this.lntlm.AutoSize = true;
            this.lntlm.Enabled = false;
            this.lntlm.Location = new System.Drawing.Point(3, 239);
            this.lntlm.Name = "lntlm";
            this.lntlm.Size = new System.Drawing.Size(78, 13);
            this.lntlm.TabIndex = 0;
            this.lntlm.Text = "NTLM: 0.000%";
            // 
            // pntlm
            // 
            this.pntlm.Enabled = false;
            this.pntlm.Location = new System.Drawing.Point(6, 255);
            this.pntlm.Name = "pntlm";
            this.pntlm.Size = new System.Drawing.Size(360, 23);
            this.pntlm.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 803);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Niji - Rainbow Table Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ProgressBar pntlm;
        private System.Windows.Forms.ProgressBar psha256;
        private System.Windows.Forms.Label lntlm;
        private System.Windows.Forms.ProgressBar plm;
        private System.Windows.Forms.Label lsha256;
        private System.Windows.Forms.Label llm;
        private System.Windows.Forms.ProgressBar psha1;
        private System.Windows.Forms.ProgressBar psha512;
        private System.Windows.Forms.Label lsha1;
        private System.Windows.Forms.Label lsha512;
        private System.Windows.Forms.ProgressBar pmd5;
        private System.Windows.Forms.Label lmd5;
    }
}

