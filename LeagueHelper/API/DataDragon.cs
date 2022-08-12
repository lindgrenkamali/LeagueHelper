using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeagueHelper.API
{
    internal class DataDragon
    {

        HttpClient client = new();

        WebClient wc = new();

        string LatestVersion { get; set; }

        string APIUrl = "https://ddragon.leagueoflegends.com/api/versions.json";
        public async Task GetLatestVersion()
        {
            using (client)
            {

                string response = await client.GetStringAsync(APIUrl);

                List<string> responseList = response.Split(",").ToList();

                LatestVersion = responseList[0].Replace("[", "").Replace("\"", "");

            }


        }

        public async Task<string> ReturnIcon(string iconid)
        {
            using (client)
            {
                //wc.DownloadFile(new Uri(APIUrl + iconid));
            }
            return ">:(";
        }
    }
}
