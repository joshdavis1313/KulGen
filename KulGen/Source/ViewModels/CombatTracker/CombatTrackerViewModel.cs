using System.Collections.ObjectModel;
using System.Windows.Input;
using KulGen.Core;
using KulGen.Source.DataModels;
using MvvmCross.Core.ViewModels;

namespace KulGen.Source.ViewModels.CombatTracker
{
	public class CombatTrackerViewModel : NavigationBarViewModel
	{
		public ICommand AddCombatItem { get { return new MvxCommand(DoAddCombatItem); } }
		public ICommand UpdateCombatantList { get { return new MvxCommand(DoUpdateCombatantList); } }
		public ICommand EditItem { get { return new MvxCommand<Combatant>(DoEditItem); } }

		public ObservableCollection<Combatant> CombatantList { get; }

		public CombatTrackerViewModel(ILocalSettings settings) : base (settings)
		{
			CombatantList = new ObservableCollection<Combatant>();
		}

		public void DoEditItem(Combatant combatant)
		{
			var navObj = new EditCombatantViewModel.NavObject
			{
				Id = combatant.ID,
				Name = combatant.Name,
				PlayerName = combatant.PlayerName,
				Initiative = combatant.Initiative,
				Health = combatant.Health,
				ArmorClass = combatant.ArmorClass,
				PassivePerception = combatant.PassivePerception
			};

			ShowViewModel<EditCombatantViewModel>(navObj);
		}

		void DoAddCombatItem()
		{
			ShowViewModel<AddCombatantViewModel>();
		}

		void DoUpdateCombatantList()
		{
			CombatantList.Clear();
			foreach (Combatant c in settings.SQLiteDatabase.Table<Combatant>().OrderBy(x => x.Initiative))
			{
				CombatantList.Add(c);
			}
		}
	}
}
