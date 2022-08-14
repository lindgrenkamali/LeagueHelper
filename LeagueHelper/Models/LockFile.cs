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

        public bool Exists = false;

        public List<string> LockFileList = new();

    }
}

