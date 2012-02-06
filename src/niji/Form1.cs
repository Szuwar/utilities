using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Security.Cryptography;
namespace niji
{
    public enum Hs
    {
        md5,
        sha1,
        sha256,
        sha512,
        lm,
        ntlm,
    }
    public partial class Form1 : Form
    {
        int ToDo;
        bool md5, sha1, sha128, sha256, lm, ntlm;
        private Thread t;
        private Thread Tmd5;
        private Thread Tsha1;
        private Thread Tsha256;
        private Thread Tsha512;
        string pt;
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Tmd5 != null)
                Tmd5.Abort();
            if (Tsha1 != null)
                Tsha1.Abort();
            if (Tsha256 != null)
                Tsha256.Abort();
            if (Tsha512 != null)
                Tsha512.Abort();
            t.Abort();
            Thread.Sleep(20);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "All Files (*.*)|*.*";
            if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = of.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = fd.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool good = false;
            foreach (CheckBox b in groupBox2.Controls)
            {
                if (b.Checked == true)
                    good = true;
            }
            md5 = checkBox1.Checked;
            sha1 = checkBox2.Checked;
            sha128 = checkBox3.Checked;
            sha256 = checkBox4.Checked;
            lm = checkBox6.Checked;
            ntlm = checkBox5.Checked;
            if (!good)
                MessageBox.Show("You Must Select at least 1 hash type", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
                MessageBox.Show("You Must Select a Dictionary and Output Location", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                button4.Enabled = true;
                button3.Enabled = false;
                pt = textBox2.Text;
                ToDo = File.ReadAllLines(textBox1.Text).Length;
                log("==== " + DateTime.Now.ToLongTimeString() + " ====");
                log("MD5 table: " + md5.ToString());
                log("sha1 table: " + sha1.ToString());
                log("sha128 table: " + sha128.ToString());
                log("sha256 table: " + sha256.ToString());
                log("LM table: " + lm.ToString());
                log("NTLM table: " + ntlm.ToString());
                log("Dictionary: " + textBox1.Text);
                log("Out Folder: " + textBox2.Text);
                log("Separator: " + textBox3.Text);
                t = new Thread(() =>
                {
                    try
                    {
                        log("Initializing files in " + textBox2.Text + @"\niji");
                        if (Directory.Exists(textBox2.Text + @"\niji"))
                        {
                            foreach (string f in Directory.EnumerateFiles(textBox2.Text + @"\niji"))
                            {
                                File.Delete(f);
                            }
                            Directory.Delete(textBox2.Text + @"\niji");
                        }
                        Directory.CreateDirectory(textBox2.Text + @"\niji");
                        log("Creating Table...");
                        if (md5)
                        {
                            Tmd5 = new Thread(() =>
                            {
                                log("Creating MD5 Table...");
                                int c = 0;
                                MD5 md = new MD5CryptoServiceProvider();
                                StreamWriter sw = File.AppendText(textBox2.Text + @"\niji\" + Path.GetFileName(textBox1.Text) + ".md5.csv");
                                foreach (string line in File.ReadAllLines(textBox1.Text))
                                {
                                    byte[] result = md.ComputeHash(Encoding.Unicode.GetBytes(line.ToCharArray()));
                                    StringBuilder sb = new StringBuilder();
                                    for (int i = 0; i < result.Length; i++)
                                    {

                                        sb.Append(result[i].ToString("X2"));

                                    }
                                    sw.WriteLine(string.Format("{0}{1}{2}", line, textBox3.Text, sb.ToString()));
                                    sw.Flush();
                                    c++;
                                    up(Hs.md5, c);
                                    GC.Collect();
                                }
                                log("MD5: DONE!");
                            });
                            Tmd5.IsBackground = true;
                            Tmd5.Start();
                        }
                        if (sha1)
                        {
                            Tsha1 = new Thread(() =>
                            {
                                log("Creating SHA1 Table...");
                                int c = 0;
                                SHA1 sh1 = new SHA1CryptoServiceProvider();
                                StreamWriter sw = File.AppendText(textBox2.Text + @"\niji\" + Path.GetFileName(textBox1.Text) + ".sha1.csv");
                                foreach (string line in File.ReadAllLines(textBox1.Text))
                                {
                                    byte[] result = sh1.ComputeHash(Encoding.Unicode.GetBytes(line.ToCharArray()));
                                    StringBuilder sb = new StringBuilder();
                                    for (int i = 0; i < result.Length; i++)
                                    {

                                        sb.Append(result[i].ToString("X2"));

                                    }
                                    sw.WriteLine(string.Format("{0}{1}{2}", line, textBox3.Text, sb.ToString()));
                                    sw.Flush();
                                    c++;
                                    up(Hs.sha1, c);
                                    GC.Collect();
                                }
                                log("SHA1: DONE!");
                            });
                            Tsha1.IsBackground = true;
                            Tsha1.Start();
                        }
                        if (sha128)
                        {
                            Tsha256 = new Thread(() =>
                            {
                                log("Creating SHA256 Table...");
                                int c = 0;
                                SHA256 sh128 = new SHA256CryptoServiceProvider();
                                StreamWriter sw = File.AppendText(textBox2.Text + @"\niji\" + Path.GetFileName(textBox1.Text) + ".sha256.csv");
                                foreach (string line in File.ReadAllLines(textBox1.Text))
                                {
                                    byte[] result = sh128.ComputeHash(Encoding.Unicode.GetBytes(line.ToCharArray()));
                                    StringBuilder sb = new StringBuilder();
                                    for (int i = 0; i < result.Length; i++)
                                    {

                                        sb.Append(result[i].ToString("X2"));

                                    }
                                    sw.WriteLine(string.Format("{0}{1}{2}", line, textBox3.Text, sb.ToString()));
                                    sw.Flush();
                                    c++;
                                    up(Hs.sha256, c);
                                    GC.Collect();
                                }
                                log("SHA256: DONE!");
                            });
                            Tsha256.IsBackground = true;
                            Tsha256.Start();
                        }
                        if (sha256)
                        {
                            Tsha512 = new Thread(() =>
                            {
                                int c = 0;
                                log("Creating SHA512 Table...");
                                SHA512 sh512 = new SHA512CryptoServiceProvider();
                                StreamWriter sw = File.AppendText(textBox2.Text + @"\niji\" + Path.GetFileName(textBox1.Text) + ".sha512.csv");
                                foreach (string line in File.ReadAllLines(textBox1.Text))
                                {
                                    byte[] result = sh512.ComputeHash(Encoding.Unicode.GetBytes(line.ToCharArray()));
                                    StringBuilder sb = new StringBuilder();
                                    for (int i = 0; i < result.Length; i++)
                                    {

                                        sb.Append(result[i].ToString("X2"));

                                    }
                                    sw.WriteLine(string.Format("{0}{1}{2}", line, textBox3.Text, sb.ToString()));
                                    sw.Flush();
                                    c++;
                                    up(Hs.sha512, c);
                                    GC.Collect();
                                }
                                log("SHA512: DONE!");
                            });
                            Tsha512.IsBackground = true;
                            Tsha512.Start();
                        }
                    }
                    catch (Exception ex)
                    {
                        log(ex.Message);
                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        try
                        {
                            log("Attempting to Clean Up...");
                            en();
                        }
                        catch (Exception ex2)
                        {
                            log(ex2.Message);
                            MessageBox.Show(ex2.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                });
                t.IsBackground = true;
                t.Start();
            }
        }
        private void en()
        {
             MethodInvoker i = delegate
             {
                 groupBox1.Enabled = true;
                 groupBox2.Enabled = true;
                 groupBox3.Enabled = true;
                 groupBox4.Enabled = true;
                 button4.Enabled = false;
                 button3.Enabled = true;
             };
             if (this.InvokeRequired)
                 this.BeginInvoke(i);
             else
                 i.Invoke();
        }
        private void up(Hs m,int c)
        {
            MethodInvoker i = delegate
            {
                Thread.Sleep(2);
                switch (m)
                {
                    case Hs.md5:
                        pmd5.Value = ((c * 100) / ToDo);
                        lmd5.Text = string.Format("MD5:\t {0:N3}%", ((double)c * 100.0D) / (double)ToDo);
                        break;
                    case Hs.sha1:
                        psha1.Value = ((c * 100) / ToDo);
                        lsha1.Text = string.Format("SHA1:\t {0:N3}%", ((double)c * 100.0D) / (double)ToDo);
                        break;
                    case Hs.sha256:
                        psha256.Value = ((c * 100) / ToDo);
                        lsha256.Text = string.Format("SHA256:\t {0:N3}%", ((double)c * 100.0D) / (double)ToDo);
                        break;
                    case Hs.sha512:
                        psha512.Value = ((c * 100) / ToDo);
                        lsha512.Text = string.Format("SHA512:\t {0:N3}%", ((double)c * 100.0D) / (double)ToDo);
                        break;
                    case Hs.lm:
                        break;
                    case Hs.ntlm:
                        break;
                    default:
                        break;
                }
            };
            Thread.Sleep(10);
            if (this.InvokeRequired)
                this.BeginInvoke(i);
            else
                i.Invoke();
        }
        private void log(string m)
        {
            MethodInvoker i = delegate {
                richTextBox1.Text += m + "\n";
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
            };
            if (this.InvokeRequired)
                this.BeginInvoke(i);
            else
                i.Invoke();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            log("===== ABORT =====");
            if (Tmd5 != null)
                Tmd5.Abort();
            if (Tsha1 != null)
                Tsha1.Abort();
            if (Tsha256 != null)
                Tsha256.Abort();
            if (Tsha512 != null)
                Tsha512.Abort();
            t.Abort();
            en();
        }
    }
}
