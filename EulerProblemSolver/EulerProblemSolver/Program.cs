using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace EulerProblemSolver
{
    class Program
    {
        public static void getName(string url)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.ContentType = "text/html; charset=utf-8;en-us";
            request.UserAgent = @"Mozilla/5.0 Chrome/32.0.1667.0";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            StreamReader sr = new StreamReader(response?.GetResponseStream());
            var stream = sr.ReadToEnd();
            sr.Close();

            string pattern =
                "<tr><td class=\"id_column\">(.*?)</td><td><a href=\"(.*?)\" title=\"(.*?)\">(.*?)</a></td><td><div style=\"text-align:center;\">(.*?)</div></td></tr>";

            foreach (Match match in Regex.Matches(stream, pattern, RegexOptions.IgnoreCase))
                if (match.Groups[5].Value.Contains("fastest"))
                    Data.Items.Add(new Data
                    {
                        Number = Convert.ToInt32(match.Groups[1].Value),
                        Name = match.Groups[4].Value,
                        Solved =
                            Convert.ToInt32(
                                Regex.Match(match.Groups[5].Value, "<a href=\"(.*?)\" title=\"(.*?)\">(.*?)</a>",
                                    RegexOptions.IgnoreCase).Groups[3].Value)
                    });
                else
                    Data.Items.Add(new Data
                    {
                        Number = Convert.ToInt32(match.Groups[1].Value),
                        Name = match.Groups[4].Value,
                        Solved = Convert.ToInt32(match.Groups[5].Value)
                    });
        }
       
        private static void Main(string[] args)
        {
            //
            try
            {
                for (int i = 1; i <= 12; i++)
                    getName(string.Concat("https://projecteuler.net/archives;page=", i));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                using (StreamWriter sw = new StreamWriter("tasks.txt"))
                {
                    foreach (var t in Data.Items.OrderBy(s => -s.Solved))
                    {
                        sw.WriteLine(t.ToString());
                    }
                }
            }
        }
    }
}
