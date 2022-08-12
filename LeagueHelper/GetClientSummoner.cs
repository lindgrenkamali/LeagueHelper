using LeagueHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueHelper
{
    public class GetClientSummoner
    {
        public void Run()
        {
            LockFile lf = LockFile.Read();

            string LoginURL = @"https://127.0.0.1:" + lf.Port + "/lol-summoner/v1/current-summoner";
            
            Login.LoginLCU lcu = new();
            
            lcu.GetCurrentSummoner(LoginURL, lf.Password);
        }
    }
}
