using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using KulGen.Core;
using KulGen.Source.Adapters;
using KulGen.Source.DataModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;

namespace KulGen.Source.ViewModels.CombatTracker
{
	public class CombatTrackerViewModel : NavigationBarViewModel
	{
		public ICommand AddCombatItem { get { return new MvxCommand (DoAddCombatItem); } }
		public ICommand UpdateCombatantList { get { return new MvxCommand (DoUpdateCombatantList); } }
		public ICommand EditItem { get { return new MvxCommand<Combatant> (DoEditItem); } }
		public ICommand ClearCombatants { get { return new MvxCommand (DoClearCombatants); } }

		public readonly INCList<CombatListItemModel> CombatantList = new NCList<CombatListItemModel> ();

		public CombatTrackerViewModel (ILocalSettings settings) : base (settings) { }

		public void DoEditItem (Combatant combatant)
		{
			var navObj = new EditCombatantViewModel.NavObject {
				Id = combatant.ID,
				Name = combatant.Name,
				PlayerName = combatant.PlayerName,
				Initiative = combatant.Initiative,
				MaxHealth = combatant.Health,
				ArmorClass = combatant.ArmorClass,
				PassivePerception = combatant.PassivePerception
			};

			ShowViewModel<EditCombatantViewModel> (navObj);
		}

		void DoAddCombatItem ()
		{
			ShowViewModel<AddCombatantViewModel> ();
		}

		void DoUpdateCombatantList ()
		{
			var combatantList = new List<CombatListItemModel> ();
			foreach (Combatant c in settings.SQLiteDatabase.Table<Combatant> ().OrderByDescending (x => x.Initiative)) {
				combatantList.Add (new CombatListItemModel (settings, c));
			}

			CombatantList.Value = combatantList;
		}

		void DoClearCombatants ()
		{
			settings.SQLiteDatabase.DeleteAll<Combatant> ();
			CombatantList.Value = new List<CombatListItemModel> ();
		}
	}
}
