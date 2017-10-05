using System.Windows.Input;
using KulGen.Core;
using KulGen.Core.PropertyDependency;
using KulGen.Source.DataModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;

namespace KulGen.Source.ViewModels.AddCombatants
{
	public class AddCombatantViewModel : BaseViewModel
	{
		public readonly INC<string> CharacterName = new NC<string> ();
		public readonly INC<string> PlayerName = new NC<string> ();
		public readonly INC<int> Initiative = new NC<int> ();
		public readonly INC<int> Health = new NC<int> ();
		public readonly INC<int> ArmorClass = new NC<int> ();
		public readonly INC<int> PassivePerception = new NC<int> ();
		public readonly INC<int> CreateNumber = new NC<int> (1);

		public ICommand AddClicked => new MvxCommand (DoAdd);

		public AddCombatantViewModel (ILocalSettings settings) : base (settings)
		{
		}

		void DoAdd ()
		{
			//If it doesn't have a player name we can assume its a monster
			if (string.IsNullOrEmpty (PlayerName.Value)) {
				PlayerName.Value = "Monster";
			}

			for (int x = 1; x <= CreateNumber.Value; x++) {
				var tempCharacterName = CharacterName.Value;
				if (CreateNumber.Value > 1) {
					tempCharacterName = tempCharacterName + " " + x;
				}

				var combatant = new Combatant {
					Name = tempCharacterName,
					PlayerName = PlayerName.Value,
					Initiative = Initiative.Value,
					MaxHealth = Health.Value,
					Health = Health.Value,
					ArmorClass = ArmorClass.Value,
					PassivePerception = PassivePerception.Value
				};

				settings.SQLiteDatabase.Insert (combatant);

			}
			ShowViewModel<CombatTrackerViewModel> ();
		}
	}
}
