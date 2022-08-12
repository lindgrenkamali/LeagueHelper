using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeagueHelper.Models
{
    public class LockFile
    {
        public string ProcessName { get; set; }
        public uint ProcessID { get; set; }
        public uint Port { get; set; }
       

        public string Password { get; set; }

        public string Protocol { get; set; }

        public static bool Exists = false;

        public static List<string> LockFileList = new();

        public static string NormalClientPath = @"C:\Riot Games\League of Legends\lockfile";

        public static string PBEClientPath = @"C:\Riot Games\League of Legends (PBE)\lockfile";


        public static LockFile Read()
        {
            string path = "";
            LockFile lf = new();
            while (Exists == false)
            {

                if(File.Exists(NormalClientPath))
                {
                    path = NormalClientPath;
                }

                else if(File.Exists(PBEClientPath))
                {
                    path = PBEClientPath;
                }

                

                if (path != "")
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

                        lf.ProcessName = LockFileList[0];
                        lf.ProcessID = uint.Parse(LockFileList[1]);
                        lf.Port = uint.Parse(LockFileList[2]);
                        lf.Password = LockFileList[3];
                        lf.Protocol = LockFileList[4];
                        Exists = true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                }
                Thread.Sleep(1000);
            }
            return lf;
        }


    }
}

