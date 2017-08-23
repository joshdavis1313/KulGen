using System.Collections.Generic;
using System.Threading.Tasks;
using Smash.Source.DataModels;

namespace KulGen.Core
{
	public interface ILocalSettings
	{
		List<Combatant> CombatantsList { get; set; }
		Combatant NewCombatant { get; set; }
	}

	public class LocalSettings : ILocalSettings
	{
		public List<Combatant> CombatantsList { get; set; }
		public Combatant NewCombatant { get; set; }

		public LocalSettings()
		{
			CombatantsList = new List<Combatant>();
			CombatantsList.Add(new Combatant { Name = "bob" });
			CombatantsList.Add(new Combatant { Name = "Joe" });
		}

		public static async Task<LocalSettings> LoadLocalSettings()
		{
			return new LocalSettings ();
		}
		
	}
}
