using System;
using System.Diagnostics;
using System.IO;

namespace GoGetYoutube
{
	public class Commander
	{
        public void RunYoutubeDL(string youtubeUrl, string youtubedlConfig)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "youtube-dl";
            start.Arguments = string.Format("{0} {1}", youtubeUrl, youtubedlConfig);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }
        }
    }
}
