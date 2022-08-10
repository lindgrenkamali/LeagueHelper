using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LeagueHelper.LockFile
{
    public static class FileManager
    {
        public static bool Exists = false;

        public static List<string> LockFileList = new();

        public static string LoginURL;

        public static string Password;

        public static async void ReadLockFile()
        {
            while (Exists == false)
            {
                string path = @"C:\Riot Games\League of Legends\lockfile";

                if (File.Exists(path))
                {
                    try
                    {
                        using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read,
                        FileShare.ReadWrite))
                        {
                            using (StreamReader sr = new StreamReader(stream))
                            {
                                LockFileList = sr.ReadLine().Split(":").ToList();

                            }

                        }

                        LoginURL = @"https://127.0.0.1:" + LockFileList[2] + "/lol-summoner/v1/current-summoner";
                        Password = LockFileList[3];
                        Login.LoginLCU lcu = new();
                        Exists = true;
                        lcu.GetCurrentSummoner();
                       
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                }
                Thread.Sleep(1000);
            }

        }
    }
}
