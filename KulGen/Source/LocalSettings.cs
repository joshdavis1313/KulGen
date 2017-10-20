using System.Collections.Generic;
using System.Threading.Tasks;
using KulGen.DataModels;
using KulGen.Source.Util;
using SQLite;

namespace KulGen.Core
{
	public interface ILocalSettings
	{
		SQLiteConnection SQLiteDatabase { get; set; }
		List<Combatant> CombatantsList { get; set; }
		Combatant NewCombatant { get; set; }
		string MultiNpcCustomSuffix { get; }

		MultiNpcSuffixOptions GetMultipleNpcOption ();
		void SetMultipleNpcOption (MultiNpcSuffixOptions option);
		InitiativeOptions GetSavedInitiate ();
		void SetSavedInitiate (InitiativeOptions sort);
		void SetMultiNpcCustomSuffix (string suffix);
	}

	public class LocalSettings : ILocalSettings
	{
		public SQLiteConnection SQLiteDatabase { get; set; }
		public List<Combatant> CombatantsList { get; set; }
		public Combatant NewCombatant { get; set; }
		public string MultiNpcCustomSuffix { get; private set; }

		MultiNpcSuffixOptions savedMultipleNpcOption;
		InitiativeOptions savedInitiateSort;

		public LocalSettings (string dbPath)
		{
			CreateDatabase (dbPath);
			GetPersistantValues ();
		}

		public static async Task<LocalSettings> LoadLocalSettings (string dbPath)
		{
			return new LocalSettings (dbPath);
		}

		void CreateDatabase (string dbPath)
		{
			SQLiteDatabase = new SQLiteConnection (dbPath);
			SQLiteDatabase.CreateTable<Combatant> ();
		}

		void GetPersistantValues ()
		{
			switch (PersistantSettings.PersistantInitiativeSort) {
				case 1:
					savedInitiateSort = InitiativeOptions.Descending;
					break;
				case 2:
					savedInitiateSort = InitiativeOptions.Ascending;
					break;
				case 3:
					savedInitiateSort = InitiativeOptions.Checkbox;
					break;
			}

			switch (PersistantSettings.PersistantMultipleNpcOption) {
				case 1:
					savedMultipleNpcOption = MultiNpcSuffixOptions.Numeric;
					break;
				case 2:
					savedMultipleNpcOption = MultiNpcSuffixOptions.Alphabetic;
					break;
				case 3:
					savedMultipleNpcOption = MultiNpcSuffixOptions.Custom;
					break;
			}

			MultiNpcCustomSuffix = PersistantSettings.MultipleNpcCustomSuffix;
		}

		public InitiativeOptions GetSavedInitiate ()
		{
			return savedInitiateSort;
		}

		public void SetSavedInitiate (InitiativeOptions sort)
		{
			savedInitiateSort = sort;
			switch (sort) {
				case InitiativeOptions.Descending:
					PersistantSettings.PersistantInitiativeSort = 1;
					break;
				case InitiativeOptions.Ascending:
					PersistantSettings.PersistantInitiativeSort = 2;
					break;
				case InitiativeOptions.Checkbox:
					PersistantSettings.PersistantInitiativeSort = 3;
					break;
			}
		}

		public MultiNpcSuffixOptions GetMultipleNpcOption ()
		{
			return savedMultipleNpcOption;
		}

		public void SetMultipleNpcOption (MultiNpcSuffixOptions option)
		{
			savedMultipleNpcOption = option;
			switch (option) {
				case MultiNpcSuffixOptions.Numeric:
					PersistantSettings.PersistantMultipleNpcOption = 1;
					break;
				case MultiNpcSuffixOptions.Alphabetic:
					PersistantSettings.PersistantMultipleNpcOption = 2;
					break;
				case MultiNpcSuffixOptions.Custom:
					PersistantSettings.PersistantMultipleNpcOption = 3;
					break;
			}
		}

		public void SetMultiNpcCustomSuffix (string suffix)
		{
			MultiNpcCustomSuffix = suffix;
			PersistantSettings.MultipleNpcCustomSuffix = suffix;
		}
	}
}
