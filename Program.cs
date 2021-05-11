using doctolibsniper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;

namespace doctolibsniper
{
    class Program
    {
        public static readonly string doctolibSearchUrl = "https://www.doctolib.fr/vaccination-covid-19/bordeaux?ref_visit_motive_ids[]=6970&ref_visit_motive_ids[]=7005&force_max_limit=2";
        public static readonly List<string> centersToIgnore = new List<string>
        {
            "Tonneins",
            "Libournais",
            "Biscarosse",
            "Castillon",
            "Margaux",
            "Astier"
        };

        public static void Main(string[] args)
        {
            Console.WriteLine("URL surveillée : " + doctolibSearchUrl);
            Console.WriteLine("Centres ignorés : " + string.Join(", ", centersToIgnore));
            while (true)
            {
                var found = false;

                foreach (var center in ExtractCenterUrlList())
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36");
                        var response = client.GetAsync(center);
                        var stringResult = response.Result.Content.ReadAsStringAsync();
                        Debug.WriteLine(stringResult.Result);
                        var result = JsonConvert.DeserializeObject<DoctolibReturnObject>(stringResult.Result);

                        if (result.Availabilities.Any())
                        {
                            if(!ShouldBeIgnored(result.SearchResult.LastName))
                            {
                                found = true;
                                Console.Beep();
                                Console.WriteLine("{0} RDV Dispo {1} => https://www.doctolib.fr{2}", result.Total, result.SearchResult.LastName, result.SearchResult.Url);
                                OpenBrowser(String.Format("https://www.doctolib.fr{0}", result.SearchResult.Url));
                                Thread.Sleep(10000);
                            } else
                            {
                                Console.WriteLine("Créneaux disponibles ignorés dans le centre suivant : {0}", result.SearchResult.LastName);

                            }

                        }
                    }
                }
                if (!found)
                {
                    Console.WriteLine(DateTime.Now + " - Pas de rdv dispo");
                }
                Thread.Sleep(1000);
            }
        }

        static void OpenBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        static bool ShouldBeIgnored(string centerName)
        {
            foreach (var ctrPartName in centersToIgnore)
            {
                if (centerName.Contains(ctrPartName, StringComparison.InvariantCultureIgnoreCase)) return true;
            }
            return false;
        }

        static List<string> ExtractCenterUrlList()
        {
            var urlList = new List<string>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36");
                var response = client.GetAsync(doctolibSearchUrl);
                var stringResult = response.Result.Content.ReadAsStringAsync().Result;

                var pattern = "search-result-(\\d+)";
                var matches = Regex.Matches(stringResult, pattern);

                foreach (var match in matches)
                {
                    string centerId = match.ToString().Replace("search-result-", "");
                    urlList.Add(string.Format("https://www.doctolib.fr/search_results/{0}.json?limit=7&ref_visit_motive_ids%5B%5D=6970&ref_visit_motive_ids%5B%5D=7005&speciality_id=5494&search_result_format=json&force_max_limit=2", centerId));
                }

            }

            return urlList;
        }
    }
}
