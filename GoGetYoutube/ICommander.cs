namespace GoGetYoutube
{
	public interface ICommander
	{
		void RunYoutubeDL(string youtubeUrl, string youtubedlConfig);
	}
}