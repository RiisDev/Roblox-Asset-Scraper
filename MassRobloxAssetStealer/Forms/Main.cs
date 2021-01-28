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

        public void LogData(LogType logType, string Message = "")
        {
            LogBox.Invoke(new Action(() => {
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

                Console.WriteLine($"Got cursor data: {Cursor}");
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
            string Name = string.Empty;

            using (WebClient client = new WebClient())
            {
                try
                {
                    string HtmlParse = client.DownloadString($"https://www.roblox.com/catalog/{ID}");

                    int pfrom = HtmlParse.IndexOf("border-bottom item-name-container") + "border-bottom item-name-container".Length + 16;
                    int pto = HtmlParse.IndexOf("use-dynamic-thumbnail-lighting") - 260;

                    string FullParse = HtmlParse.Substring(pfrom, pto - pfrom);

                    Name = FullParse;
                    Console.WriteLine($"Got asset name: {Name}");
                }
                catch
                {
                    Name = ID;
                    Console.WriteLine($"Failed to find asset name: {Name}");
                }
            }

            return Name;
        }

        public void ScrapeAudioIds(string LibraryUrl)
        {
            int pfrom = LibraryUrl.IndexOf("item-image-wrapper") + "item-image-wrapper".Length + 1;
            int pto = LibraryUrl.IndexOf("PagingContainerDivTop");

            string FirstParse = LibraryUrl.Substring(pfrom, pto -pfrom);
            string[] AudioObj = FirstParse.Split(new string[] { "class=NotAPrice>Free" }, StringSplitOptions.None);

            foreach (string SData in AudioObj)
            {
                string AudioData = SData;
                if (AudioData.Contains("CatalogItemInfoLabel"))
                {
                    AudioData = ReplaceFirst(AudioData, "></span></div>", "");
                }
                if (!AudioData.Contains("data-mediathumb-url="))
                    return;

                pfrom = AudioData.IndexOf("data-mediathumb-url=") + "data-mediathumb-url=".Length;
                pto = AudioData.IndexOf("></span></div>");
                Console.WriteLine(AudioData);
                string AudioUrl = AudioData.Substring(pfrom, pto - pfrom);

                pfrom = AudioData.IndexOf("\" title=\"") + "\" title=\"".Length;
                pto = AudioData.LastIndexOf("\">");
                string Name = AudioData.Substring(pfrom, pto - pfrom);

                SongData.Add(Name, AudioUrl);

                LogData(LogType.Info, $"Parsed Song: {AudioUrl}");
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
            


            Console.WriteLine(File);

            string Parsed = File.Substring(pfrom, pto - pfrom).Replace("http://www.roblox.com/asset/?id=", "https://assetdelivery.roblox.com/v1/asset?id=");
            LogData(LogType.Info, $"Parsed Url: {Parsed}");
            return Parsed;
        }

        public string ReplaceInvalidChars(string filename)
        {
            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
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

        private async void FetchIDs()
        {
            string BaseUrl = $"https://catalog.roblox.com/v1/search/items?Keyword={KeywordBox.Text}&category=Clothing&limit=100&subcategory=Shirts";
            string CatalogUrl = $"https://catalog.roblox.com/v1/search/items?Keyword={KeywordBox.Text}&category=Clothing&limit=100&subcategory=Shirts";
            string NextPage;
            
            switch (ItemTypeCombo.Text)
            {
                case "Shirts":
                    BaseUrl = $"https://catalog.roblox.com/v1/search/items?Keyword={KeywordBox.Text}&category=Clothing&limit=100&subcategory=Shirts";
                    CatalogUrl = $"https://catalog.roblox.com/v1/search/items?Keyword={KeywordBox.Text}&category=Clothing&limit=100&subcategory=Shirts";
                    LogData(LogType.Info, "Fetching next page cursor...");
                    NextPage = GetNextPageCursor(CatalogURL: CatalogUrl);
                    LogData(LogType.Info, $"Found cursor: {NextPage}");
                    LogData(LogType.Info, "Cathering Item IDs...");
                    for (int i = 1; i <= (int.Parse(ItemCount.Text) / 100); i++)
                    {
                        Console.WriteLine(i);
                        Console.WriteLine((int.Parse(ItemCount.Text) / 100));

                        if (i == 1)
                        {
                            GatherIDs(CatalogUrl);
                        }
                        else
                        {
                            CatalogUrl = BaseUrl + $"&cursor={GetNextPageCursor(CatalogUrl)}";
                            Console.WriteLine(CatalogUrl);
                            GatherIDs(CatalogUrl);
                        }
                    }
                    while (ItemIDs.Count != (int.Parse(ItemCount.Text)))
                    {
                        await Task.Delay(25);
                    }
                    LogData(LogType.Info, $"Gathered a total of: {ItemIDs.Count} IDs");
                    break;
                case "Pants":
                    BaseUrl = $"https://catalog.roblox.com/v1/search/items?Keyword={KeywordBox.Text}&category=Clothing&limit=100&subcategory=Pants&Keyword={KeywordBox.Text}";
                    CatalogUrl = $"https://catalog.roblox.com/v1/search/items?Keyword={KeywordBox.Text}&category=Clothing&limit=100&subcategory=Pants&Keyword={KeywordBox.Text}";
                    LogData(LogType.Info, "Fetching next page cursor...");
                    NextPage = GetNextPageCursor(CatalogURL: CatalogUrl);
                    LogData(LogType.Info, $"Found cursor: {NextPage}");
                    LogData(LogType.Info, "Cathering Item IDs...");
                    for (int i = 1; i <= (int.Parse(ItemCount.Text) / 100); i++)
                    {
                        Console.WriteLine(i);
                        Console.WriteLine((int.Parse(ItemCount.Text) / 100));

                        if (i == 1)
                        {
                            GatherIDs(CatalogUrl);
                        }
                        else
                        {
                            CatalogUrl = BaseUrl + $"&cursor={GetNextPageCursor(CatalogUrl)}";
                            Console.WriteLine(CatalogUrl);
                            GatherIDs(CatalogUrl);
                        }
                    }
                    while (ItemIDs.Count != (int.Parse(ItemCount.Text)))
                    {
                        await Task.Delay(25);
                    }
                    LogData(LogType.Info, $"Gathered a total of: {ItemIDs.Count} IDs");
                    break;
                case "Audio":
                    LogData(LogType.Info, "Cathering Item IDs...");
                    for (int i = 1; i <= (int.Parse(PageCountForAudio.Text)); i++)
                    {
                        using (WebClient client = new WebClient())
                        {
                            Console.WriteLine($"https://search.roblox.com/catalog/contents?CatalogContext=2&SortAggregation=5&LegendExpanded=true&Category=9&PageNumber={i}&Keyword={KeywordBox.Text}");
                            ScrapeAudioIds(client.DownloadString($"https://search.roblox.com/catalog/contents?CatalogContext=2&SortAggregation=5&LegendExpanded=true&Category=9&PageNumber={i}&Keyword={KeywordBox.Text}"));
                        }
                    }
                    LogData(LogType.Info, $"Gathered a total of: {SongData.Count} IDs");
                    break;
            }
        }

        private void StartSave()
        {
            switch (ItemTypeCombo.Text)
            {
                case "Shirts":
                    LogData(LogType.Info, $"Initiating first download step...");
                    new Thread(() =>
                    {
                        foreach (string IDs in ItemIDs)
                        {
                            using (WebClient client = new WebClient())
                            {
                                try
                                {
                                    client.DownloadFileAsync(new Uri($"https://assetdelivery.roblox.com/v1/asset?id={IDs}"), $"{SaveDirectory}\\temp\\{IDs}");
                                    client.DownloadFileCompleted += (erere, ererer) =>
                                    {
                                        string FileData;
                                        try
                                        {
                                            FileData = File.ReadAllText($"{SaveDirectory}\\temp\\{IDs}");
                                        }
                                        catch (Exception er) { FileData = ""; Console.WriteLine(er.ToString()); }

                                        if (FileData.Contains("roblox"))
                                        {
                                            try
                                            {
                                                File.Delete($"{SaveDirectory}\\temp\\{IDs}");
                                            }
                                            catch (Exception er) { Console.WriteLine(er.ToString()); }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                File.Move($"{SaveDirectory}\\temp\\{IDs}", $"{SaveDirectory}\\Shirts\\{ReplaceInvalidChars(GetAssetName(IDs))}.png");
                                            }
                                            catch (Exception er) { Console.WriteLine(er.ToString()); }
                                            return;
                                        }

                                        Console.WriteLine(ParseFile(FileData));
                                        try
                                        {
                                            client.DownloadFile(ParseFile(FileData), $"{SaveDirectory}\\Shirts\\{ReplaceInvalidChars(GetAssetName(IDs))}.png");
                                        }
                                        catch (Exception er) { Console.WriteLine(er.ToString()); }
                                        Console.WriteLine("Finished a download!");
                                    };
                                }
                                catch {}
                            }
                        }
                        Console.WriteLine("Done!");
                    }).Start();
                    break;
                case "Pants":
                    LogData(LogType.Info, $"Initiating first download step...");
                    new Thread(() =>
                    {
                        foreach (string IDs in ItemIDs)
                        {
                            using (WebClient client = new WebClient())
                            {
                                try
                                {
                                    client.DownloadFileAsync(new Uri($"https://assetdelivery.roblox.com/v1/asset?id={IDs}"), $"{SaveDirectory}\\temp\\{IDs}");
                                    client.DownloadFileCompleted += (erere, ererer) =>
                                    {
                                        string FileData;
                                        try
                                        {
                                            FileData = File.ReadAllText($"{SaveDirectory}\\temp\\{IDs}");
                                        }
                                        catch (Exception er) { FileData = ""; Console.WriteLine(er.ToString()); }

                                        if (FileData.Contains("roblox"))
                                        {
                                            try
                                            {
                                                File.Delete($"{SaveDirectory}\\temp\\{IDs}");
                                            }
                                            catch (Exception er) { Console.WriteLine(er.ToString()); }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                File.Move($"{SaveDirectory}\\temp\\{IDs}", $"{SaveDirectory}\\Pants\\{ReplaceInvalidChars(GetAssetName(IDs))}.png");
                                            }
                                            catch (Exception er) { Console.WriteLine(er.ToString()); }
                                            return;
                                        }

                                        Console.WriteLine(ParseFile(FileData));
                                        try
                                        {
                                            client.DownloadFile(ParseFile(FileData), $"{SaveDirectory}\\Pants\\{ReplaceInvalidChars(GetAssetName(IDs))}.png");
                                        }
                                        catch (Exception er) { Console.WriteLine(er.ToString()); }
                                        Console.WriteLine("Finished a download!");
                                    };
                                }
                                catch (Exception er) { Console.WriteLine(er.ToString()); }
                            }
                        }
                        Console.WriteLine("Done!");
                    }).Start();
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
                                    client.DownloadFile(SongData[FName], $"{SaveDirectory}\\Audio\\{ReplaceInvalidChars(GetAssetName(FName))}.mp3");
                                }
                                catch (Exception er) { Console.WriteLine(er.ToString()); }
                            }
                        }).Start();
                    }
                    break;
            }
        }

        private async void Start_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The downloader is more stable if it has focus (dont click away)!", "Asset Downloader", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Start.Enabled = false;
            ItemIDs.Clear();
            if (Directory.Exists(SaveDirectory + "\\temp"))
            {
                foreach (string Files in Directory.GetFiles(SaveDirectory + "\\temp"))
                {
                    try
                    {
                        File.Delete(Files);
                    }
                    catch (Exception er) { Console.WriteLine(er.ToString()); }
                }
            }

            Directory.CreateDirectory(SaveDirectory + "\\temp");
            Directory.CreateDirectory(SaveDirectory + "\\Shirts");
            Directory.CreateDirectory(SaveDirectory + "\\Pants");
            Directory.CreateDirectory(SaveDirectory + "\\Audio");

            LogBox.Clear();
            LogData(LogType.System, "Logging started!");
            await Task.Delay(100);
            LogData(LogType.System, $"Fetching {ItemCount.Text} IDs for assets: {ItemTypeCombo.Text}");
            FetchIDs();
            await Task.Delay(100);
            LogData(LogType.System, "Gather specific IDs...");
            ManualIDs();
            await Task.Delay(100);
            LogData(LogType.System, $"Done fetching asset IDs!");
            LogData(LogType.System, $"Continuing to download in ~3 seconds!");
            await Task.Delay(2500);
            StartSave();

            await Task.Delay(Convert.ToInt32((int.Parse(ItemCount.Text) * 10) / 1.2));

            new Thread(async () =>
            {
                for (; ; )
                {
                    await Task.Delay(50);
                    if (Process.GetCurrentProcess().Threads.Count < 50)
                    {
                        LogData(LogType.System, "System threads seem to be going lower, finished?");

                        ItemTypeCombo.Invoke(new Action(() =>
                        {
                            LogData(LogType.System, $"Files saved: {Directory.GetFiles($"{SaveDirectory}\\{ItemTypeCombo.Text}").Count()} / {ItemIDs.Count}");

                            if (Directory.GetFiles($"{SaveDirectory}\\{ItemTypeCombo.Text}").Count() != ItemIDs.Count)
                            {
                                LogData(LogType.System, "Due to issues with some assets, some failed to download!");
                            }
                        }));

                        try
                        {
                            Array.ForEach(Directory.GetFiles($"{SaveDirectory}\\temp"), x => File.Delete(x));
                            Directory.Delete($"{SaveDirectory}\\temp");
                        }
                        catch (Exception er) { Console.WriteLine(er.ToString()); }
                        LogData(LogType.System, "Opening directory!");

                        ItemTypeCombo.Invoke(new Action(() =>
                        {
                            Process.Start(SaveDirectory+"\\"+ItemTypeCombo.Text);
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
    }
}
