using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;
using System.Diagnostics;
using Ookii.Dialogs;
using SHOpenFolderAndSelectItems;
using System.Text.RegularExpressions;

namespace BatchDownloader {
    public partial class batchDownloader : Form {
        string saveTo;
        VistaFolderBrowserDialog folderBrowserDialog1 = new VistaFolderBrowserDialog();

        public batchDownloader() {
            InitializeComponent();

            saveDir.Text = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Downloads");

            progressGrid.Columns.Add("URL", "URL");

            progressGrid.Columns.Add("SaveLoc", "Save Location");
            progressGrid.Columns.Add("Bytes", "Downloaded");
            progressGrid.Columns.Add("Size", "Size");
            progressGrid.Columns.Add("Speed", "Speed");
            progressGrid.Columns.Add("Percent", "%");
        }

        private void button1_Click(object sender, EventArgs e) {
            if (saveDir.Text.Equals("") || !Directory.Exists(saveDir.Text)) {
                MessageBox.Show("Can't save there! It doesn't exist!");
                return;
            }
            saveTo = saveDir.Text;

            int threads = IsNumeric(concurrentCount.Text) ? toInt(concurrentCount.Text) : 1;
            ThreadPool.SetMaxThreads(threads, threads + 10);

            // split input into urls
            IEnumerable<string> rawUrls = urlBox.Text.Trim().Split('\n');

            IEnumerable<string> replacedUrls = new List<string>();
            foreach (string u in rawUrls) {
                replacedUrls = replacedUrls.Concat(replaceTokens(u.Trim()));
            }
            urlBox.Text = String.Join("\r\n", replacedUrls);

            try {
                IEnumerable<Uri> urls = from str in replacedUrls select new Uri(str);

                foreach(Uri u in urls) {
                    string save = Path.Combine(new string[] {
                        saveTo,
                        Path.GetFileName(u.LocalPath)
                    });

                    progressGrid.Rows.Add(new object[] {
                        u.AbsoluteUri,
                        save,
                        humanBytes(0),
                        "0%"
                    });
                }

                int size = urls.Count();
                for(int i = 0; i < size; i++)
                    (new Thread(DownloadUrl)).Start(i);
            }
            catch (UriFormatException err) {
                MessageBox.Show(err.Message);
            }
        }

        public void DownloadUrl(object state) {
            int rowIndex = (int)state;
            DataGridViewRow row = progressGrid.Rows[rowIndex];

            string save = row.Cells["SaveLoc"].Value.ToString();

            WebClient client = new WebClient();
            client.Proxy = null;

            Stopwatch watch = null;

            client.DownloadProgressChanged += (sender, e) => {
                progressGrid.InvokeEx(grid => {
                    long speed = 0;
                    if (watch == null) {
                        watch = Stopwatch.StartNew();
                    }
                    else {
                        speed = Convert.ToInt64(e.BytesReceived / ((watch.ElapsedMilliseconds + 1) / 1000.0f));
                    }
                    
                    row.Cells["Bytes"].Value = humanBytes(e.BytesReceived);
                    row.Cells["Size"].Value = humanBytes(e.TotalBytesToReceive);
                    row.Cells["Speed"].Value = humanBytes(speed)+"/s";
                    row.Cells["Percent"].Value = e.ProgressPercentage + "%";
                });
            };

            client.DownloadFileCompleted += (sender, e) => {
                row.Cells["Percent"].Value = "100%";
                watch.Stop();
            };

            client.DownloadFileAsync(new Uri(row.Cells["URL"].Value.ToString()), save);
        }

        private void browse_Click(object sender, EventArgs e) {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                saveDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void urlBox_TextChanged(object sender, EventArgs e) {
            urlBox.Text = urlBox.Text.Replace("\r\n", "\n").Replace("\n", "\r\n");
        }

        private void openFolder_Click(object sender, EventArgs e) {
			if (saveDir.Text.Equals("") || !Directory.Exists(saveDir.Text)) {
				MessageBox.Show("Can't save there! It doesn't exist!");
				return;
			}
			ShowSelectedInExplorer.FileOrFolder(saveDir.Text);
        }

        private void about_Click(object sender, EventArgs e) {
            MessageBox.Show("Copyright 2011 Alec Gorge.\r\n\r\nhttp://github.com/alecgorge/batchdownloader");
        }

        private IList<string> createRange(string[] parts) {
            IList<string> replacements = new List<string>();
            int limit = toInt(parts[1]);
            int inc = parts.Count() > 2 ? toInt(parts[2]) : 1; // if no incrementer is given, assume 1

            for (int i = toInt(parts[0]); i <= limit; i += inc)
                replacements.Add(i.ToString().PadLeft(parts[0].Length, '0'));
            return replacements;
        }

        private IEnumerable<string> replaceTokens(string raw, MatchCollection ms) {
			IList<string> replacements = new List<string>();
			IList<string> replaced = new List<string>();

			if (ms.Count == 0) {
				replaced.Add(raw);
				return replaced;
			}

            string range = ms[0].Groups[0].Captures[0].Value;
            range = range.Substring(2, range.Length - 4);

            if (range.Contains(',') || range.Contains('-')) {
                string[] parts = Regex.Split(range, ",|-");

                if (parts.Count() == 3 && IsNumeric(parts)) { // start,stop,inc
                    replacements = createRange(parts);
                }
                else if (parts.Count() == 2 && IsNumeric(parts)) { // start,stop,1
                    replacements = createRange(parts);
                }
                else { // bob,joe
                    foreach (string p in parts) replacements.Add(p);
                }
            }

            int startRange = ms[0].Groups[0].Captures[0].Index;
            int rangeLength = ms[0].Groups[0].Captures[0].Length;
            foreach (string rep in replacements) {
                replaced.Add(raw.Remove(startRange, rangeLength).Insert(startRange, rep));
            }

            if (ms.Count > 1) {
                IEnumerable<string> extras = new List<string>();
                foreach (string n in replaced) {
                    extras = extras.Concat(replaceTokens(n));
                }

                return extras;
            }
            else {
                return replaced;
            }
        }

        private IEnumerable<string> replaceTokens(string raw) {
            MatchCollection ms = Regex.Matches(raw, "{{(.*?)}}");
            return replaceTokens(raw, ms);
        }

        #region Number Stuff
        private bool IsNumeric(object Expression) {
            if (Expression == null || Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;

            try {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            }
            catch { } // just dismiss errors but return false
            return false;
        }
        private bool IsNumeric(object[] expr) {
            foreach (object e in expr) {
                if (!IsNumeric(e)) return false;
            }
            return true;
        }
        private int toInt(string inp) {
            return Convert.ToInt32(inp);
        }
        private string humanBytes(long bytes) {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB" };

            if (bytes < 1) {
                return "0 B";
            }

            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return num.ToString() + " " + suf[place];
        }

        #endregion

		private void progressGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
			ShowSelectedInExplorer.FileOrFolder(progressGrid.Rows[e.RowIndex].Cells["SaveLoc"].Value.ToString());
		}
    }
    public static class ISynchronizeInvokeExtensions {
        public static void InvokeEx<T>(this T @this, Action<T> action) where T : ISynchronizeInvoke {
            if (@this.InvokeRequired) {
                @this.Invoke(action, new object[] { @this });
            }
            else {
                action(@this);
            }
        }
    }
}
