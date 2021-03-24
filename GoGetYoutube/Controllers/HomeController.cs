using Microsoft.AspNetCore.Mvc;
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

		public HomeController(IOptions<AppSettings> appSettings, ILogger<HomeController> logger)
		{
			_appSettings = appSettings.Value;
			_logger = logger;
		}

		[HttpPost]
		public IActionResult GetVideo(string YoutubeURL)
		{
			_logger.LogInformation(YoutubeURL);
			var youtubedlConfig=  _appSettings.YoutubeDLConfig;
			var commander = new Commander();
			Task.Run(()=> commander.RunYoutubeDL(YoutubeURL, youtubedlConfig));
			return Ok(true);
		}
	}
}
