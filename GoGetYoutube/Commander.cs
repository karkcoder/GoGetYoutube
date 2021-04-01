using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;

namespace GoGetYoutube
{
	public class Commander : ICommander
	{
		private readonly ILogger _logger;
		
		public Commander(ILogger<Commander> logger)
		{
			_logger = logger;
		}
		
		public void RunYoutubeDL(string youtubeUrl, string youtubedlConfig)
		{
			ProcessStartInfo start = new ProcessStartInfo();
			start.FileName = "youtube-dl";
			start.Arguments = string.Format("{0} {1}", youtubedlConfig, youtubeUrl);
			_logger.LogInformation("Running " + start.FileName + " with options " + start.Arguments);
			start.UseShellExecute = false;
			start.RedirectStandardOutput = true;
			_logger.LogInformation("Started downloading " + youtubeUrl);
			try
			{
				using (Process process = Process.Start(start))
				{
					using (StreamReader reader = process.StandardOutput)
					{
						string result = reader.ReadToEnd();
						_logger.LogInformation(result);
					}
				}
			}
			catch (Exception ex)
            {
				_logger.LogError(ex.Message);
            }
			_logger.LogInformation("Completed downloading " + youtubeUrl);
		}
	}
}
