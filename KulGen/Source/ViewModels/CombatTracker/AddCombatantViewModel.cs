using System;
using System.Windows.Input;
using KulGen.Core;
using KulGen.Source.ViewModels.CombatTracker;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;
using Smash.Source.DataModels;

namespace KulGen.Source.ViewModels.Dialogs
{
	public class AddCombatantViewModel : BaseViewModel
	{
		public readonly INC<string> CharacterName = new NC<string>();
		public readonly INC<string> PlayerName = new NC<string>();
		public readonly INC<int> Initiative = new NC<int>();
		public readonly INC<int> MaxHealth = new NC<int>();
		public readonly INC<int> ArmorClass = new NC<int>();
		public readonly INC<int> PassivePerception = new NC<int>();

		public ICommand AddClicked => new MvxCommand(DoAdd);

		public AddCombatantViewModel(ILocalSettings settings) : base(settings)
		{
		}

		void DoAdd()
		{
			var combatant = new Combatant{
				Name = CharacterName.Value,
				PlayerName = PlayerName.Value,
				Initiative = Initiative.Value,
				MaxHealth = MaxHealth.Value,
				ArmorClass = ArmorClass.Value,
				PassivePerception = PassivePerception.Value
			};

			settings.NewCombatant = combatant;

			ShowViewModel<CombatTrackerViewModel>();
		}
	}
}
