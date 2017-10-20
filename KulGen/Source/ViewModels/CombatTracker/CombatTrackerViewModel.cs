using System.Collections.Generic;
using System.Windows.Input;
using KulGen.Core;
using KulGen.Adapters;
using KulGen.DataModels;
using KulGen.ViewModels.AddCombatants;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;
using KulGen.ViewModels.EditCombatants;
using KulGen.Source.ViewModels.Options;
using KulGen.Source.Util;
using SQLite;
using KulGen.Source.ViewModels.Help;

namespace KulGen.ViewModels.CombatTracker
{
	public class CombatTrackerViewModel : NavigationBarViewModel
	{
		public ICommand AddCombatItem { get { return new MvxCommand (DoAddCombatItem); } }
		public ICommand UpdateCombatantList { get { return new MvxCommand (DoUpdateCombatantList); } }
		public ICommand ClearCombatants { get { return new MvxCommand (DoClearCombatants); } }
		public ICommand GoToOptions { get { return new MvxCommand (DoGoToOptions); } }
		public ICommand GoToHelp { get { return new MvxCommand (DoGoToHelp); } }
		public ICommand ClearCheckBoxes { get { return new MvxCommand (DoClearCheckBoxes); } }

		public readonly INCList<CombatListItemModel> CombatantList = new NCList<CombatListItemModel> ();
		public readonly INC<bool> IsCheckBoxInitiative = new NC<bool> ();

		public CombatTrackerViewModel (ILocalSettings settings) : base (settings)
		{
		}

		void DoAddCombatItem ()
		{
			ShowViewModel<AddCombatantViewModel> ();
		}

		void DoUpdateCombatantList ()
		{
			IsCheckBoxInitiative.Value = settings.GetSavedInitiate () == InitiativeOptions.Checkbox;
			var combatantList = new List<CombatListItemModel> ();

			//Figure out which sort order is needed from the settings
			TableQuery<Combatant> combatantTableSorted = null;
			switch (settings.GetSavedInitiate ()) {
				case InitiativeOptions.Descending:
					combatantTableSorted = settings.SQLiteDatabase.Table<Combatant> ().OrderByDescending (x => x.Initiative);
					break;
				case InitiativeOptions.Ascending:
					combatantTableSorted = settings.SQLiteDatabase.Table<Combatant> ().OrderBy (x => x.Initiative);
					break;
				default:
					combatantTableSorted = settings.SQLiteDatabase.Table<Combatant> ().OrderBy (x => x.IsPlayer);
					break;
			}

			foreach (Combatant c in combatantTableSorted) {
				combatantList.Add (new CombatListItemModel (settings, c));
			}

			CombatantList.Value = combatantList;
		}

		void DoClearCombatants ()
		{
			settings.SQLiteDatabase.DeleteAll<Combatant> ();
			CombatantList.Value = new List<CombatListItemModel> ();
		}

		void DoGoToOptions ()
		{
			ShowViewModel<MainOptionsViewModel> ();
		}

		void DoGoToHelp()
		{
			ShowViewModel<MainHelpViewModel> ();
		}

		void DoClearCheckBoxes ()
		{
			foreach (CombatListItemModel c in CombatantList.Value) {
				c.HasGone.Value = false;
			}
		}
	}
}
