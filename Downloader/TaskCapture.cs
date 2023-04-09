using Downloader.Common;
using Downloader.Config;
using Downloader.Model;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Downloader
{
    public partial class TaskCapture : BaseForm
    {
        public TaskCapture()
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(Enum.GetNames(typeof(CaptureType)));
            comboBox1.SelectedItem = Enum.GetNames(typeof(CaptureType)).FirstOrDefault();

            CookieContainer CookieContainer = new CookieContainer();
            HttpClientHandler httpClientHandler = new HttpClientHandler() { UseCookies = true, CookieContainer = CookieContainer, Proxy = new WebProxy(GUIConfig.proxyHost), UseProxy = GUIConfig.proxyEnable };
            CookieContainer.Add(new Cookie() { Name = "age_check_done", Value = "1", Domain = ".dmm.co.jp" });
            httpClient = new HttpClient(httpClientHandler);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
        }
        private Uri inputUrl;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                inputUrl = new Uri(textBox1.Text);
            }
            catch (Exception ex)
            {
                EorrMessage("url输入不合法");
                return;
            }
            GetVid(inputUrl.ToString());
        }
        private HttpClient httpClient = new HttpClient();
        BindingList<CaptureData>? data = null;
        private async void GetVid(string url)
        {
            try
            {
                toolStripProgressBar1.Value = 0;
                data = new BindingList<CaptureData>();
                dataGridView1.DataSource = data;
                string html = await httpClient.GetStringAsync(url);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                var vs = doc.DocumentNode.SelectNodes("//ul[@id=\"list\"]/li")
                ?.Select(k =>
                {
                    CaptureData captureData = new CaptureData();
                    string? s = k.SelectNodes(".//a").FirstOrDefault()?.GetAttributeValue("href", "");
                    captureData.url = s;
                    string? cid = Regex.Match(s, "/cid=.*/").Value.Replace("/", "").Replace("cid=", "");
                    var imgTag = k.SelectNodes(".//span[@class=\"img\"]/img").FirstOrDefault();
                    if (imgTag != null)
                    {
                        captureData.imageUrl = imgTag.GetAttributeValue("src", "");
                        captureData.title = imgTag.GetAttributeValue("alt", "");
                    }
                    captureData.Type = CaptureType.DMM;
                    captureData.vid = cid;
                    return captureData;
                })?.ToList();
                if (vs != null)
                {
                    for (int i = 0; i < vs.Count; i++)
                    {
                        if (IsDisposed)
                            return;
                        var item = vs[i];
                        try
                        {
                            item.image = Image.FromStream(await httpClient.GetStreamAsync(item.imageUrl));
                        }
                        catch (Exception)
                        {
                        }
                        data.Add(item);
                        if (!toolStripProgressBar1.IsDisposed)
                            toolStripProgressBar1.Value = (int)Math.Floor(100m / Convert.ToDecimal(vs.Count) * i);
                    }
                }
                InfoMessage("完毕");
            }
            catch (Exception ex)
            {
                EorrMessage(ex.Message);
                return;
            }
            finally
            {
                if (!toolStripProgressBar1.IsDisposed)
                    toolStripProgressBar1.Value = 100;
            }
        }

        private void TaskCapture_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void vid保存到剪切板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectRows = dataGridView1.SelectedRows;
            if (selectRows != null)
            {
                string vids = string.Empty;
                foreach (DataGridViewRow selectRow in selectRows)
                {
                    CaptureData data = selectRow.DataBoundItem as CaptureData;
                    if (data != null)
                        vids += data.vid + ",";
                }
                vids = vids.TrimEnd(',');
                Clipboard.SetText(vids);
                Loger.Debug("剪切板Get:" + vids);
            }
        }
    }
}
