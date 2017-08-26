using System.Collections.Generic;
using System.Threading.Tasks;
using KulGen.Source.DataModels;
using SQLite;

namespace KulGen.Core
{
	public interface ILocalSettings
	{
		SQLiteConnection SQLiteDatabase { get; set; }
		List<Combatant> CombatantsList { get; set; }
		Combatant NewCombatant { get; set; }
	}

	public class LocalSettings : ILocalSettings
	{
		public SQLiteConnection SQLiteDatabase { get; set; }
		public List<Combatant> CombatantsList { get; set; }
		public Combatant NewCombatant { get; set; }

		public LocalSettings(string dbPath)
		{
			CreateDatabase(dbPath);
		}

		public static async Task<LocalSettings> LoadLocalSettings(string dbPath)
		{
			return new LocalSettings (dbPath);
		}

		void CreateDatabase(string dbPath)
		{
			SQLiteDatabase = new SQLiteConnection(dbPath);
			SQLiteDatabase.CreateTable<Combatant>();
		}
	}
}
