using System;
using System.IO;
using System.Net;

namespace WindKit
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Environment.UserName;
            string DownloadPath = @"c:\Users\" + username + @"\Downloads\WindKitTemp";

            void WellcomeMessage(bool FirstPrint)
            {
                Console.Clear();

                if (FirstPrint == true) { 
                    Console.WriteLine("WindKit v0.0.1");
                }

                Console.WriteLine("--Select kit for install--");
                Console.WriteLine("(1)--Starter");
                Console.WriteLine("(2)--Dev");
                Console.WriteLine("(3)--Games");
                Console.WriteLine("(4)--Full");
                Console.WriteLine("(5)--Full Dev");
                Console.WriteLine("(6)--mar4elkin kit");
                Console.WriteLine("--Type kit number to download selected kit--");
                Console.WriteLine("After downloading check 'Donloads' dir ");

                if (FirstPrint == true){
                    Console.WriteLine("type help to see available commands");
                }
            }

            void HelpMessage() {
                Console.Clear();
                Console.WriteLine("kitlist - To see the kit list");
                Console.WriteLine("kitset - To see what programs are in the kits");
                Console.WriteLine("help - To see that message");

            }

            void KitSet() {
                Console.Clear();
                Console.WriteLine("Starter - googlechrome");
                Console.WriteLine("Dev - vscode, nodejs, python");
                Console.WriteLine("Games - steam, battle.net, Hamachi, minecraft");
                Console.WriteLine("Full - Starter and Games");
                Console.WriteLine("Full Dev - Starter, Dev and Games kits");
                Console.WriteLine("mar4elkin kit - Full Dev kit and osu :-) ");
            }

            static string GetFileSize(Uri uriPath) {
                var webRequest = HttpWebRequest.Create(uriPath);
                webRequest.Method = "HEAD";

                using (var webResponse = webRequest.GetResponse()) {
                    var fileSize = webResponse.Headers.Get("Content-Length");
                    var fileSizeInMegaByte = Math.Round(Convert.ToDouble(fileSize) / 1024.0 / 1024.0, 2);
                    return fileSizeInMegaByte + " MB";
                }
            } 

            static string GetFileName(Uri uriPath) {

                string filename = System.IO.Path.GetFileName(uriPath.LocalPath);
                return filename;
            }

            void DownloadFile(string FileUrl, string FileName) {
                    
                WebClient myWebClient = new WebClient { UseDefaultCredentials = true };
                if (FileName != "getInstaller") {
                    myWebClient.DownloadFile(FileUrl, DownloadPath + @"\" + FileName);
                } else {
                    myWebClient.DownloadFile(FileUrl, DownloadPath + @"\battle_installer.exe");
                }
                    
            }

            void FileDownlaodPrecess(string[] Urls) {
                
                Directory.CreateDirectory(DownloadPath);

                for (int i = 0; i < Urls.Length; i++) {

                    string FileSize = GetFileSize(new Uri(Urls[i]));
                    string FileName = GetFileName(new Uri(Urls[i]));
                    Console.WriteLine("name: {0}, size: {1}", FileName, FileSize);
                    DownloadFile(Urls[i], FileName);

                }
            }

            void Starter() {
                Console.Clear();
                Console.WriteLine("Selected Starter kit");

                string[] Urls = new string[] { 
                    "https://dl.google.com/tag/s/appguid%3D%7B8A69D345-D564-463C-AFF1-A69D9E530F96%7D%26iid%3D%7BA4531812-65D3-3C19-99B4-4CCAA2912036%7D%26lang%3Dru%26browser%3D4%26usagestats%3D1%26appname%3DGoogle%2520Chrome%26needsadmin%3Dprefers%26ap%3Dx64-stable-statsdef_1%26installdataindex%3Dempty/update2/installers/experimental/4/ChromeSetup.exe?src=5&filename=ChromeSetup.exe",
                };

                FileDownlaodPrecess(Urls);

            }

            void Dev() {
                Console.Clear();
                Console.WriteLine("Selected Dev kit");

                string[] Urls = new string[] {
                    "https://az764295.vo.msecnd.net/stable/c47d83b293181d9be64f27ff093689e8e7aed054/VSCodeUserSetup-x64-1.42.1.exe",
                    "https://nodejs.org/dist/v12.16.1/node-v12.16.1-x64.msi",
                    "https://www.python.org/ftp/python/3.8.1/python-3.8.1.exe",
                };

                FileDownlaodPrecess(Urls);
            }

            void Games() {
                Console.Clear();
                Console.WriteLine("Selected Games kit");

                string[] Urls = new string[] {
                    "https://steamcdn-a.akamaihd.net/client/installer/SteamSetup.exe",
                    "https://eu.battle.net/download/getInstaller?os=win&installer=Overwatch-Setup.exe",
                    "https://secure.logmein.com/hamachi.msi",
                    "https://launcher.mojang.com/download/MinecraftInstaller.msi"
                };

                FileDownlaodPrecess(Urls);
            }

            void Full() {
                Console.Clear();
                Console.WriteLine("Selected stFullarter kit");

                Starter();
                Games();

            }

            void FullDev() {
                Console.Clear();
                Console.WriteLine("Selected FullDev kit");

                Full();
                Dev();
            }

            void MyKit() {
            
                FullDev();

                Console.Clear();
                Console.WriteLine("Selected mar4elkin kit");

                string[] Urls = new string[] {
                    "https://m1.ppy.sh/r/osu!install.exe"
                };

                FileDownlaodPrecess(Urls);
            }

            WellcomeMessage(true);

            bool is_selected = true;

            while(is_selected == true) { 

                string user_output = Console.ReadLine();

                switch (user_output)
                {
                    case "1":
                        Starter();
                        is_selected = false;
                        break;
                    case "2":
                        Dev();
                        is_selected = false;
                        break;
                    case "3":
                        Games();
                        is_selected = false;
                        break;
                    case "4":
                        Full();
                        is_selected = false;
                        break;
                    case "5":
                        FullDev();
                        is_selected = false;
                        break;
                    case "6":
                        MyKit();
                        is_selected = false;
                        break;
                    case "kitlist":
                        WellcomeMessage(false);
                        break;
                    case "kitset":
                        KitSet();
                        break;
                    case "help":
                        HelpMessage();
                        break;
                    default:
                        Console.WriteLine("can't find kit or command, type help to see command list");
                        break;
                }

            }
        }
    }
}
