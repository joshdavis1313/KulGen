using System.Collections.ObjectModel;
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
		public ObservableCollection<CombatItem> CombatTrackerList { get; }

		public CombatTrackerViewModel(ILocalSettings settings) : base (settings)
		{
			CombatTrackerList = new ObservableCollection<CombatItem> ();
			CombatTrackerList.Add(new CombatItem() { Name = "bob", Initiative = 1, Health = 3 });
			CombatTrackerList.Add(new CombatItem() { Name = "Billy", Initiative = 1, Health = 3 });
			CombatTrackerList.Add(new CombatItem() { Name = "Joe", Initiative = 1, Health = 3 });
		}

		public void OnCombatItemClicked(CombatItem combatitem)
		{
			
		}

		void DoAddCombatItem()
		{
			ShowDialogViewModel<AddCombatItemViewModel>();
		}
	}
}
