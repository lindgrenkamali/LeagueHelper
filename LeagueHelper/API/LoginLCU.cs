using LeagueHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LeagueHelper.Login
{
    internal class LoginLCU
    {
        public CurrentSummoner cs { get; set; }

        public string Username = "riot";
        

        public async void GetCurrentSummoner()
        {
            try
            {

            HttpClientHandler handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            HttpClient client = new HttpClient(handler);
            var authString = Encoding.ASCII.GetBytes(Username + ":" + LockFile.FileManager.Password);
            
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(authString));
            string response = await client.GetStringAsync(LockFile.FileManager.LoginURL);
            cs = Newtonsoft.Json.JsonConvert.DeserializeObject<CurrentSummoner>(response);

                MainWindow.main.Dispatcher.Invoke(new Action(delegate()
                {
                    MainWindow.main.SummonerNameLabel.Content = cs.DisplayName;
                    
                    string iconPath = @"C:\Users\david\Downloads\dragontail-12.14.1\12.14.1\img\profileicon\" + cs.ProfileIconId + ".png";
                    
                    MainWindow.main.SummonerIcon.Source = new ImageSourceConverter().ConvertFromString(iconPath) as ImageSource;
                    MainWindow.main.LevelLabel.Content = cs.SummonerLevel;
                }));



            }
            catch(Exception ex)
            {
                
                GetCurrentSummoner();
            }
        }
    }
}
