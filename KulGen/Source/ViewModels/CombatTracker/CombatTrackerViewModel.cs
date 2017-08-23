using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using KulGen.Core;
using KulGen.Source.ViewModels.Dialogs;
using MvvmCross.Core.ViewModels;
using Smash.Source.DataModels;

namespace KulGen.Source.ViewModels.CombatTracker
{
	public class CombatTrackerViewModel : NavigationBarViewModel
	{
		public ICommand AddCombatItem { get { return new MvxCommand(DoAddCombatItem); } }
		public ICommand UpdateCombatantList { get { return new MvxCommand(DoUpdateCombatantList); } }

		public ObservableCollection<Combatant> CombatantList { get; private set; }

		public CombatTrackerViewModel(ILocalSettings settings) : base (settings)
		{
			var combatantsList = settings.CombatantsList.OrderBy(x => x.Initiative).ToList();
			CombatantList = new ObservableCollection<Combatant>(combatantsList);
		}

		public void OnCombatItemClicked(Combatant combatitem)
		{
			
		}

		void DoAddCombatItem()
		{
			ShowViewModel<AddCombatantViewModel>();
		}

		void DoUpdateCombatantList()
		{
			if (settings.NewCombatant != null)
			{
				CombatantList.Add(settings.NewCombatant);
				settings.NewCombatant = null;
			}
		}
	}
}
