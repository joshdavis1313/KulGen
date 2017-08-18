using System.Threading.Tasks;

namespace KulGen.Core
{
	public interface ILocalSettings
	{
	}

	public class LocalSettings : ILocalSettings
	{
		public LocalSettings()
		{
			
		}

		public static async Task<LocalSettings> LoadLocalSettings()
		{
			return new LocalSettings ();
		}
		
	}
}
