using LeagueHelper.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeagueHelper.Backend
{
    public static class FileManager
    {
        public static string RiotPath()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                string riotPath = drive.Name + "Riot Games";
                if (Directory.Exists(riotPath))
                {
                    return riotPath;
                }
            }

            return "";
        }

        public static LockFile ReadLockFile(string riotPath)
        {
            List<string> lockFileList = new();
                bool exists = false;
                string NormalClientPath = riotPath + @"\League of Legends\lockfile";
                string PBEClientPath = riotPath + @"\League of Legends (PBE)\lockfile";
                string path = "";
                LockFile lf = new();
                while (exists == false)
                {

                    if (File.Exists(NormalClientPath))
                    {
                        path = NormalClientPath;
                    }

                    else if (File.Exists(PBEClientPath))
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
                                    lockFileList = sr.ReadLine().Split(":").ToList();

                                }

                            }

                            lf.ProcessName = lockFileList[0];
                            lf.ProcessID = uint.Parse(lockFileList[1]);
                            lf.Port = uint.Parse(lockFileList[2]);
                            lf.Password = lockFileList[3];
                            lf.Protocol = lockFileList[4];
                            exists = true;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }

                    }
                }
                return lf;
            }
        }
    }

