using System;
using System.Diagnostics;
using System.Windows.Forms;
using IcyFFmpeg;
using IcyFFmpeg.Types;

namespace IcyFFmpeg.Sample
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine ffmpeg = new Engine();
            ffmpeg.ConvertTo(Input.FromFile(@"C:\Users\Kevin\Downloads\2021-11-20 13-35-14.mp4"));

        }
    }
}
