using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using ICSharpCode.SharpZipLib.Zip.Compression;
using SwfDotNet.IO;
using SwfDotNet.IO.ByteCode;
using SwfDotNet.IO.Tags;
using SwfDotNet.IO.Tags.Types;

namespace SwfExtractor
{
    public partial class Form1 : Form
    {
        private BackgroundWorker _worker = null;
        private string[] _files;
        private Swf _swf = null;
        private string _dir = "";

        public Form1()
        {
            InitializeComponent();

            _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
            _worker.ProgressChanged += new ProgressChangedEventHandler(Worker_ProgressChanged);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SWF|*.swf";
            dlg.Multiselect = true;
            DialogResult res = dlg.ShowDialog();
            if (res == DialogResult.Cancel)
                return;

            _files = dlg.FileNames;
            _worker.RunWorkerAsync();
            BtnStop.Text = "Stop";
            BtnStop.Enabled = true;
            btnOpen.Enabled = false;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (string fileName in _files)
            {
                SwfReader swfReader = new SwfReader(fileName);
                _swf = swfReader.ReadSwf();
                string swfDir = Path.GetDirectoryName(fileName);
                string swfName = Path.GetFileNameWithoutExtension(fileName);
                _dir = Path.Combine(swfDir, swfName);
                if (!Directory.Exists(_dir))
                    Directory.CreateDirectory(_dir);

                int totalFiles = _swf.Tags.Count;
                int counter = 0;
                int pct = 0;
                foreach (BaseTag tag in _swf.Tags)
                {
                    if (_worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    Export(tag, _dir);

                    pct = ((++counter * 100) / totalFiles);
                    _worker.ReportProgress(pct, fileName);
                }
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelFileName.Text = e.UserState as string;
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                BtnStop.Enabled = false;
                BtnStop.Text = "Error";
                MessageBox.Show(e.Error.Message, "Error");
            }
            else if (e.Cancelled == true)
            {
                BtnStop.Enabled = false;
                BtnStop.Text = "Cancelled";
                progressBar1.Value = 0;
            }
            else
            {
                BtnStop.Enabled = true;
                BtnStop.Text = "Done";
            }

            btnOpen.Enabled = true;
        }

        private void Export(BaseTag tag, string dir)
        {
            if (tag is DefineBitsJpeg2Tag)
            {
                DefineBitsJpeg2Tag imgTag = tag as DefineBitsJpeg2Tag;
                imgTag.DecompileToFile(string.Format("{0}\\{1}.jpg", dir, imgTag.CharacterId));
            }
            else if (tag is DefineBitsJpeg3Tag)
            {
                DefineBitsJpeg3Tag imgTag = tag as DefineBitsJpeg3Tag;
                imgTag.DecompileToFile(string.Format("{0}\\{1}.jpg", dir, imgTag.CharacterId));
            }
            else if (tag is DefineBitsLossLessTag)
            {
                DefineBitsLossLessTag imgTag = tag as DefineBitsLossLessTag;
                imgTag.DecompileToFile(string.Format("{0}\\{1}.png", dir, imgTag.CharacterId));
            }
            else if (tag is DefineBitsLossLess2Tag)
            {
                DefineBitsLossLess2Tag imgTag = tag as DefineBitsLossLess2Tag;
                imgTag.DecompileToFile(string.Format("{0}\\{1}.png", dir, imgTag.CharacterId));
            }
            else if (tag is DefineSoundTag)
            {
                DefineSoundTag soundTag = tag as DefineSoundTag;
                if (soundTag.SoundFormat == SoundCodec.MP3)
                    soundTag.DecompileToFile(string.Format("{0}\\{1}.mp3", dir, soundTag.CharacterId));
                else
                    soundTag.DecompileToFile(string.Format("{0}\\{1}.wav", dir, soundTag.CharacterId));
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (BtnStop.Text == "Stop")
            {
                BtnStop.Text = "Cancelled";
                _worker.CancelAsync();
            }
            else if (BtnStop.Text == "Done")
            {
                System.Diagnostics.Process.Start("explorer.exe", _dir);
            }
        }
    }
}
