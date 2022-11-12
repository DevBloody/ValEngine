using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ValEngineKernel;
using System.Threading;
using System.IO;
using System.Net;
using System.Web;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Reflection;

namespace ValEngine
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
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }
            base.WndProc(ref m);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender,EventArgs e)
        {

        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            Process.Start("https://dsc.gg/ValorantHackers");
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            string tempPath = Path.GetTempPath();
            string auroradllpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Starlight.dll";
            string exchange = guna2TextBox2.Text;
            WebClient webClient = new WebClient();
            if (!File.Exists(tempPath + "/Inject.exe"))
            {
                webClient.DownloadFile("https://cdn.discordapp.com/attachments/1032986535273967696/1033439324609462362/Injector.exe", tempPath + "/Inject.exe");
            }//what 

            Process process = Process.Start(new ProcessStartInfo { FileName = (string.Concat(guna2TextBox1.Text, "\\ShooterGame\\Binaries\\Win64\\VALORANT-Win64-Shipping")), Arguments = "-epicapp=VALORANT -epicenv=Prod -epiclocale=en-us -epicportal -nobe -fromfl=eac -fltoken=919348d6add4c4c7c7507e61" });
            proc.Suspend(process);
            Process process1 = Process.Start(new ProcessStartInfo { FileName = (string.Concat(guna2TextBox1.Text, "\\ShooterGame\\Binaries\\Win64\\VALORANT-Win64-Shipping")), Arguments = "-epicapp=VALORANT -epicenv=Prod -epiclocale=en-us -epicportal -nobe -fromfl=eac -fltoken=919348d6add4c4c7c7507e61" });
            proc.Suspend(process1);
            Process process2 = Process.Start(new ProcessStartInfo { FileName = (string.Concat(guna2TextBox1.Text, "\\ShooterGame\\Binaries\\Win64\\VALORANT-Win64-Shipping")), Arguments = string.Concat("-AUTH_PASSWORD=unused -AUTH_LOGIN=" + exchange + " -AUTH_PASSWORD=unused -AUTH_TYPE=epic -epicapp=VALORANT -epicportal -noeac -fromfl=be -fltoken=020912211c40g052474d02f1 -skippatchcheck -caldera=eyJhbGciOiJFUzI1NiIsInR5cCI6IkpXVCJ9.eyJhY2NvdW50X2lkIjoiYmU5ZGE1YzJmYmVhNDQwN2IyZjQwZWJhYWQ4NTlhZDQiLCJnZW5lcmF0ZWQiOjE2Mzg3MTcyNzgsImNhbGRlcmFHdWlkIjoiMzgxMGI4NjMtMmE2NS00NDU3LTliNTgtNGRhYjNiNDgyYTg2IiwiYWNQcm92aWRlciI6IkVhc3lBbnRpQ2hlYXQiLCJub3RlcyI6IiIsImZhbGxiYWNrIjpmYWxzZX0.VAWQB67RTxhiWOxx7DBjnzDnXyyEnX7OljJm-j2d88G_WgwQ9wrE6lwMEHZHjBd1ISJdUO1UVUqkfLdU5nofBQ") });
            base.Hide();
            process2.WaitForInputIdle();                                                                                //Testing this curretly
            new Process()
            {
                StartInfo = {

                                Arguments = string.Format("\"{0}\" \"{1}\"", (object) process2.Id, (object) auroradllpath),
                                CreateNoWindow = true,
                                UseShellExecute = false,
                                FileName = ($"{tempPath}/Inject.exe")
                                }

            }.Start();


            Thread.Sleep(30000);


            Thread.Sleep(1000);
            process2.WaitForExit();
            base.Show();
            Process.Start("taskkill", "/f /pid " + process.Id); Process.Start("taskkill", "/f /pid " + process1.Id);
            Process.Start("taskkill", "/f /im " + "node.exe"); Process.Start("taskkill", "/f /im " + "cmd.exe"); Process.Start("taskkill", "/f /im " + "conhost.exe");
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select Valorant Game Path.");
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                this.guna2TextBox1.Text = dialog.FileName;
            }
            if (!Directory.Exists(this.guna2TextBox1.Text + "/Valorant"))
            {
                MessageBox.Show("Invalid path.");
                this.guna2TextBox1.Text = string.Empty;
                //wait what lol
            }
        }
    }
}
