using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MassRobloxAssetStealer
{
    public partial class Main : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        int FinishedItems = 0;
        public List<string> ItemIDs = new List<string>();
        public Dictionary<string, string> SongData = new Dictionary<string, string>();

        private string SaveDirectory;

        public Main()
        {
            InitializeComponent();
        }

        public enum LogType
        {
            System,
            Error,
            Info,
        }

        public enum ClothingType
        {
            Accessories,
            ClassicPants,
            ClassicShirts
        }

        public void LogData(LogType logType, string Message = "")
        {
            LogBox.Invoke(new Action(() =>
            {
                switch (logType)
                {
                    case LogType.System:
                        LogBox.BindText(Color.DimGray, "[SYSTEM] ");
                        LogBox.BindText(Color.White, $"{Message}\n");
                        break;
                    case LogType.Info:
                        LogBox.BindText(Color.DimGray, "[LOG] ");
                        LogBox.BindText(Color.FromArgb(85, 136, 238), $"{Message}\n");
                        break;
                    case LogType.Error:
                        LogBox.BindText(Color.DimGray, "[ERROR] ");
                        LogBox.BindText(Color.Red, $"{Message}\n");
                        break;
                    default:
                        break;
                }
            }));
        }

        private void Main_Load(object sender, EventArgs e)
        {
            AllocConsole();
            ShowWindow(GetConsoleWindow(), 0);
            LogBox.Clear();
            LogData(LogType.System, "Logging started!");
        }

        private void DoError(string ErrorMessage)
        {
            LogData(LogType.Error, $"There was an error while downloading, please open an issue on github!");
            using (StreamWriter writer = new StreamWriter($"{SaveDirectory}\\temp\\ErrorLog.txt"))
                writer.WriteLine(ErrorMessage);
            Process.Start($"{SaveDirectory}\\temp\\ErrorLog.txt");
        }

        public string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        private void FindLocation_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.ShowNewFolderButton = true;
                dialog.Description = "Choose where the items will be saved to!";

                DialogResult Result = dialog.ShowDialog();

                if (Result == DialogResult.OK)
                {
                    if (Directory.Exists(dialog.SelectedPath))
                    {
                        SaveDirectory = dialog.SelectedPath;
                        SaveLocTextBox.Text = SaveDirectory;
                    }
                }
            }
        }

        public string GetNextPageCursor(string CatalogURL)
        {
            string Cursor = string.Empty;

            using (WebClient client = new WebClient())
            {
                string JsonData = client.DownloadString(CatalogURL);

                JToken Data = JToken.Parse(JsonData);

                Cursor = Data["nextPageCursor"].ToString();
            }

            return Cursor;
        }

        public void GatherIDs(string CatalogURL)
        {
            using (WebClient client = new WebClient())
            {
                string JsonData = client.DownloadString(CatalogURL);

                JToken Data = JToken.Parse(JsonData);
                JArray IdData = JArray.Parse(Data["data"].ToString());

                for (int i = 0; i < IdData.Count; i++)
                {
                    Data = JToken.Parse(IdData[i].ToString());
                    ItemIDs.Add(Data["id"].ToString());
                }
            }
        }

        public string GetAssetName(string ID)
        {
            return ID;
        }

        public void ScrapeAudioIds(string LibraryUrl)
        {
            bool DoneOne = false;
            string[] Audios = LibraryUrl.Split(new string[] { "item-image-wrapper" }, StringSplitOptions.None);

            foreach (string Audio in Audios)
            {
                if (!DoneOne)
                {
                    DoneOne = true;
                }
                else if (!Audio.Contains("MediaPlayerControls"))
                {}
                else
                {
                    string NewBlock = Audio.Substring(Audio.IndexOf("img title"), Audio.IndexOf("textDisplay"));
                    string SongTitleP1 = NewBlock.Substring(NewBlock.IndexOf("\"") + 1);
                    string SongTitle = SongTitleP1.Substring(0, SongTitleP1.IndexOf("\""));

                    string SongUrlP1 = NewBlock.Substring(NewBlock.IndexOf("-url=") + 6);
                    string SongUrl = SongUrlP1.Substring(0, SongUrlP1.IndexOf("\""));

                    SongData.Add(SongTitle, SongUrl);

                    LogData(LogType.Info, $"Parsed Song: {SongUrl}");
                }
            }            
        }

        public string ParseFile(string File)
        {
            int pfrom = 0;

            if (File.Contains("ShirtTemplate"))
                pfrom = File.IndexOf("<Content name=\"ShirtTemplate\">") + "<Content name=\"ShirtTemplate\">".Length + 15;
            else if (File.Contains("PantsTemplate"))
                pfrom = File.IndexOf("<Content name=\"PantsTemplate\">") + "<Content name=\"ShirtTemplate\">".Length + 15;

            int pto = File.IndexOf("</Content>") - 14;

            string Parsed = File.Substring(pfrom, pto - pfrom).Replace("http://www.roblox.com/asset/?id=", "https://assetdelivery.roblox.com/v1/asset?id=");
            LogData(LogType.Info, $"Parsed Url: {Parsed}");
            return Parsed;
        }

        public string GetValidName(string filename)
        {
            string Final = string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));

            if (Final.Contains(";"))
                Final = Final.Substring(Final.LastIndexOf(";") + 1);

            return Final;
        }

        private void ManualIDs()
        {
            foreach (string Id in richTextBox1.Lines)
            {
                long Out;
                if (long.TryParse(Id, out Out))
                {
                    ItemIDs.Add(Id);
                }
            }
        }

        private void GetClothingIds(ClothingType type)
        {
            string PageCur;
            string BaseUrl = $"https://catalog.roblox.com/v1/search/items?Keyword={KeywordBox.Text}&category=3&limit=100&subcategory={type}";
            string CatalogUrl = $"https://catalog.roblox.com/v1/search/items?Keyword={KeywordBox.Text}&category=3&limit=100&subcategory={type}";

            if (type == ClothingType.Accessories)
            {
                BaseUrl = $"https://catalog.roblox.com/v1/search/items?Keyword={KeywordBox.Text}&category=11&limit=100&subcategory={type}";
                CatalogUrl = $"https://catalog.roblox.com/v1/search/items?Keyword={KeywordBox.Text}&category=11&limit=100&subcategory={type}";
            }

            LogData(LogType.Info, $"Detected type as: {type}");
            LogData(LogType.Info, "Cathering Item IDs...");

            for (int i = 1; i <= (int.Parse(ItemCount.Text) / 100); i++)
            {
                if (i == 1)
                {
                    GatherIDs(CatalogUrl);
                }
                else
                {
                    PageCur = GetNextPageCursor(CatalogUrl);
                    LogData(LogType.Info, $"Going to next page: {PageCur}");
                    CatalogUrl = BaseUrl + $"&cursor={PageCur}";
                    LogData(LogType.Info, $"New catalog URL: {CatalogUrl}");
                    GatherIDs(CatalogUrl);
                }
            }
        }

        private void StartSave(ClothingType type)
        {
            string DirType = type.ToString().Replace("Classic", "");
            LogData(LogType.Info, $"Initiating first download step...");
            new Thread(() =>
            {
                foreach (string ID in ItemIDs)
                {
                    using (WebClient client = new WebClient())
                    {
                        if (type == ClothingType.Accessories)
                        {
                            client.DownloadFileCompleted += (s, e) =>
                            {
                                LogData(LogType.Info, $"Downloaded: https://www.roblox.com/catalog/{ID}");
                            };
                            client.DownloadFileAsync(new Uri($"https://assetdelivery.roblox.com/v1/asset?id={ID}"), $"{SaveDirectory}\\Accessories\\{ID}.rbxm");
                        }
                        else
                        {
                            try
                            {
                                client.DownloadFileAsync(new Uri($"https://assetdelivery.roblox.com/v1/asset?id={ID}"), $"{SaveDirectory}\\temp\\{ID}");
                                client.DownloadFileCompleted += (erere, ererer) =>
                                {
                                    string FileData;
                                    try
                                    {
                                        FileData = File.ReadAllText($"{SaveDirectory}\\temp\\{ID}");
                                    }
                                    catch (Exception er) { FileData = ""; Console.WriteLine(er.ToString()); }

                                    if (FileData.Contains("roblox"))
                                    {
                                        try
                                        {
                                            File.Delete($"{SaveDirectory}\\temp\\{ID}");
                                        }
                                        catch (Exception er) { Console.WriteLine(er.ToString()); }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            File.Move($"{SaveDirectory}\\temp\\{ID}", $"{SaveDirectory}\\Shirts\\{GetValidName(GetAssetName(ID))}.png");
                                        }
                                        catch (Exception er) { Console.WriteLine(er.ToString()); }
                                        return;
                                    }

                                    Console.WriteLine(ParseFile(FileData));
                                    try
                                    {
                                        client.DownloadFile(ParseFile(FileData), $"{SaveDirectory}\\Shirts\\{GetValidName(GetAssetName(ID))}.png");
                                    }
                                    catch (Exception er) { Console.WriteLine(er.ToString()); }
                                    FinishedItems++;
                                    Console.WriteLine("Finished a download!");
                                };
                            }
                            catch { }
                        }
                    }
                }
            }).Start();
        }

        private void FetchIDs()
        {
            switch (ItemTypeCombo.Text)
            {
                case "Shirts":
                    GetClothingIds(ClothingType.ClassicShirts);
                    LogData(LogType.Info, $"Gathered a total of: {ItemIDs.Count} IDs");
                    break;
                case "Pants":
                    GetClothingIds(ClothingType.ClassicPants);
                    LogData(LogType.Info, $"Gathered a total of: {ItemIDs.Count} IDs");
                    break;
                case "Audio":
                    LogData(LogType.Info, "Cathering Item IDs...");
                    for (int i = 1; i <= (int.Parse(PageCountForAudio.Text)); i++)
                    {
                        using (WebClient client = new WebClient())
                        {
                            ScrapeAudioIds(client.DownloadString($"https://api.irisapp.ca/RobloxAPI/AudioGrabber.php?AIO={KeywordBox.Text}&PGN={i}"));
                        }
                    }
                    LogData(LogType.Info, $"Gathered a total of: {SongData.Count} IDs");
                    break;
                case "Accessories":
                    GetClothingIds(ClothingType.Accessories);
                    LogData(LogType.Info, $"Gathered a total of: {ItemIDs.Count} IDs");
                    break;
            }
        }

        private void StartSave()
        {
            switch (ItemTypeCombo.Text)
            {
                case "Shirts":
                    StartSave(ClothingType.ClassicShirts);
                    break;
                case "Pants":
                    StartSave(ClothingType.ClassicPants);
                    break;
                case "Audio":
                    foreach (string FName in SongData.Keys)
                    {
                        new Thread(() =>
                        {
                            using (WebClient client = new WebClient())
                            {
                                try
                                {
                                    string FileName = GetValidName(GetAssetName(FName));

                                    client.DownloadFileCompleted += (s, e) =>
                                    {
                                        LogData(LogType.Info, $"Finished downloading: {FileName}.mp3");
                                        FinishedItems++;
                                    };

                                    client.DownloadFile(SongData[FName], $"{SaveDirectory}\\Audio\\{FileName}.mp3");
                                }
                                catch (Exception er) {
                                    DoError(er.Message);
                                }
                            }
                        }).Start();
                    }
                    break;
                case "Accessories":
                    StartSave(ClothingType.Accessories);
                    break;
            }
        }

        private async void Start_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The downloader is more stable if it has focus (dont click away)!", "Asset Downloader", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Start.Enabled = false;
            ItemIDs.Clear();

            if (Directory.Exists($"{SaveDirectory}\\temp"))
            {
                try
                {
                    Directory.Delete($"{SaveDirectory}\\temp");
                }
                catch {
                    MessageBox.Show("Unable to delete temp folder, please make sure you haven't touched it!", "Asset Downloader", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Directory.CreateDirectory(SaveDirectory + "\\temp");
            Directory.CreateDirectory(SaveDirectory + "\\Shirts");
            Directory.CreateDirectory(SaveDirectory + "\\Pants");
            Directory.CreateDirectory(SaveDirectory + "\\Audio");
            Directory.CreateDirectory(SaveDirectory + "\\Accessories");

            LogBox.Clear();
            LogData(LogType.System, "Logging started!");
            await Task.Delay(15);
            if (!ManualInputCheck.Checked)
            {
                LogData(LogType.System, $"Fetching {ItemCount.Text} IDs for assets: {ItemTypeCombo.Text}");
                FetchIDs();
            }
            await Task.Delay(15);
            LogData(LogType.System, "Gather specific IDs...");
            ManualIDs();
            await Task.Delay(15);
            LogData(LogType.System, $"Done fetching asset IDs!");
            LogData(LogType.System, $"Continuing to download in ~3 seconds!");
            ItemIDs = ItemIDs.Distinct().ToList();
            await Task.Delay(2500);
            StartSave();

            await Task.Delay(Convert.ToInt32((int.Parse(ItemCount.Text) * 10) / 1.2));

            new Thread(async () =>
            {
                for (; ; )
                {
                    await Task.Delay(50);

                    if (FinishedItems >= ItemIDs.Count - Math.Floor((ItemIDs.Count / 3) + .0))
                    {
                        LogData(LogType.System, "Finished count is closing on ItemCount!");

                        ItemTypeCombo.Invoke(new Action(() =>
                        {
                            LogData(LogType.System, $"Files saved: {Directory.GetFiles($"{SaveDirectory}\\{ItemTypeCombo.Text}").Count()} / {ItemIDs.Count}");

                            if (Directory.GetFiles($"{SaveDirectory}\\{ItemTypeCombo.Text}").Count() != ItemIDs.Count)
                            {
                                LogData(LogType.System, "Due to issues with some assets, some failed to download!");
                            }
                        }));

                        LogData(LogType.System, "Opening directory!");

                        ItemTypeCombo.Invoke(new Action(() =>
                        {
                            Process.Start($"{SaveDirectory}\\{ItemTypeCombo.Text}");
                        }));

                        Start.Invoke(new Action(() =>
                        {
                            Start.Enabled = true;
                        }));

                        break;
                    }
                }
            }).Start();

        }

        private void LogBox_TextChanged(object sender, EventArgs e)
        {
            LogBox.SelectionStart = LogBox.Text.Length;
            LogBox.ScrollToCaret();
        }

        private void ItemTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemTypeCombo.Text == "Audio")
            {
                PageCountForAudio.Visible = true;
                ItemCount.Visible = false;
                label5.Text = "Page Count";
            }
            else if (ItemTypeCombo.Text == "Accessories")
            {
                MessageBox.Show("These will all download as RBXM!", "Asset Downloader", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                PageCountForAudio.Visible = false;
                ItemCount.Visible = true;
                label5.Text = "Item Count";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ShowWindow(GetConsoleWindow(), 5);
            }
            else {
                ShowWindow(GetConsoleWindow(), 0);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Array.ForEach(Directory.GetFiles($"{SaveDirectory}\\temp"), x => File.Delete(x));
                Directory.Delete($"{SaveDirectory}\\temp");
            }
            catch (Exception er) { Console.WriteLine(er.ToString()); }
        }
    }
}
