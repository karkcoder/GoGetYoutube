﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace GoGetYoutube.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private readonly AppSettings _appSettings;
		private readonly ILogger _logger;
		private readonly ICommander _commander;

		public HomeController(IOptions<AppSettings> appSettings, ILogger<HomeController> logger, ICommander commander)
		{
			_appSettings = appSettings.Value;
			_logger = logger;
			_commander = commander;
		}

		/// <summary>
		/// Downloads video and saves it to the folder defined in appsetting.json. Please configure YoutubeDLConfig on appsettings.json
		/// </summary>
		/// <param name="YoutubeURL">URL of Youtube video</param>
		/// <returns>Returns true if the process is kicked off</returns>
		[HttpPost]
		public IActionResult GetVideo(string YoutubeURL)
		{
			_logger.LogInformation("Downloading from " + YoutubeURL);
			var youtubedlConfig=  _appSettings.YoutubeDLConfig;
			Task.Run(()=> _commander.RunYoutubeDL(YoutubeURL, youtubedlConfig));
			return Ok("Process started for " + YoutubeURL + " using config " + youtubedlConfig);
		}
	}
}
