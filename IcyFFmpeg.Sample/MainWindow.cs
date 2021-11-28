using System;
using System.Windows.Forms;
using IcyFFmpeg.Types;
using IcyFFmpeg.FFmpegDownloader;
using FFmpeg.NET;
using System.IO;

namespace IcyFFmpeg.Sample
{
    public partial class MainWindow : Form
    {
        #region Window
        public MainWindow()
        {
            InitializeComponent();

            engine_download_cb.SelectedIndex = 7;
            engine_download_tb.Text = @$"{DesktopPath}\FFmpeg.exe";

            comboBox1.SelectedIndex = 18;
            comboBox3.SelectedIndex = 0;
        }
        private void Window_ResizeBegin(object sender, EventArgs e) => SuspendLayout();
        private void Window_ResizeEnd(object sender, EventArgs e) => ResumeLayout(true);
        #endregion

        #region Helper Functions
        static string DesktopPath { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private bool IsValidFilename(string path)
        {
            if (string.IsNullOrEmpty(path)) return false;
            string root = null;
            string directory = null;
            try
            {
                root = Path.GetPathRoot(path);
                directory = Path.GetDirectoryName(path);
            }
            catch { return false; }
            if (string.IsNullOrEmpty(root) | string.IsNullOrEmpty(directory) | path.EndsWith(@"\")) return false;
            return true;
        }
        #endregion

        #region Create Engine

        #region Download
        string engine_download_tb_before { get; set; } = @$"{DesktopPath}\FFmpeg.exe";
        private void engine_download_tb_Leave(object sender, EventArgs e)
        {
            if (!IsValidFilename(engine_download_tb.Text))
                engine_download_tb.Text = engine_download_tb_before;
            else
                engine_download_tb_before = engine_download_tb.Text;
        }
        private void engine_download_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (engine_download_cb.SelectedIndex == 0 | engine_download_cb.SelectedIndex == 1 | engine_download_cb.SelectedIndex == 7)
            {
                if (engine_download_tb.Text.EndsWith(".exe")) return;
                engine_download_tb.Text += ".exe"; engine_download_tb_before += ".exe";
            }
            else { engine_download_tb.Text = engine_download_tb.Text.Replace(".exe", ""); engine_download_tb_before = engine_download_tb_before.Replace(".exe", ""); }
        }
        private async void engine_download_btn_Click(object sender, EventArgs e)
        {
            Enums.OperatingSystem os;
            if (engine_download_cb.SelectedIndex == 7)
                os = FFmpegDownloader.OperatingSystem.Get();
            else
                os = (Enums.OperatingSystem)engine_download_cb.SelectedIndex;

            Downloader dl = new();
            dl.Progress += (s, e) => engine_download_pb.Value = e.Percentage;
            dl.Complete += (s, e) =>
            {
                engine_download_pb.Value = engine_download_pb.Maximum;
                MessageBox.Show($"FFmpeg Executable successfully downloaded!\n\nPath: \"{e.Path}\"\nVersion: {e.Version}", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            dl.Error += (s, e) =>
            {
                engine_download_pb.Value = engine_download_pb.Minimum;
                MessageBox.Show($"FFmpeg Executable failed to download!\n\nPath: \"{e.Path}\"\nVersion: {e.Version}\nError: {e.Exception.Message}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            await dl.Latest(os, engine_download_tb.Text);
        }
        #endregion

        #endregion

        private void test()
        {
            EngineOptions options = new("ffmpeg.exe", true, 0, Enums.HardwareAccelerate.cuda, false);
            Engine ffmpeg = new Engine(options);
            ffmpeg.ConvertVideo(Input.FromFile(@"C:\Users\Kevin\Downloads\2021-11-20 13-35-14.mp"), "converted.avi", Enums.VideoFormat.Avi);
            

            FFmpeg.NET.Engine engine = new(@"C:\Users\Kevin\Desktop\ffmpeg.exe");
            engine.Progress += Engine_Progress;
            //engine.ConvertAsync();
            ConversionOptions op = new();


        }
        private void Engine_Progress(object sender, FFmpeg.NET.Events.ConversionProgressEventArgs e)
        {

        }
    }
}
