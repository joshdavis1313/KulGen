using System.Windows.Input;
using KulGen.Core;
using KulGen.DataModels;
using KulGen.ViewModels.CombatTracker;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;

namespace KulGen.ViewModels.AddCombatants
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
		public readonly INC<bool> IsPlayer = new NC<bool> (false);

		public ICommand AddClicked => new MvxCommand (DoAdd);

		public AddCombatantViewModel (ILocalSettings settings) : base (settings) { }

		void DoAdd ()
		{
			if (!IsPlayer.Value) {
				AddNPC ();
			} else {
				AddPlayer ();
			}

			ShowViewModel<CombatTrackerViewModel> ();
		}

		void AddNPC ()
		{
			for (int x = 1; x <= CreateNumber.Value; x++) {
				var tempCharacterName = CharacterName.Value;
				if (CreateNumber.Value > 1) {
					tempCharacterName = tempCharacterName + " " + x;
				}

				var combatant = new Combatant {
					Name = tempCharacterName,
					IsPlayer = false,
					Initiative = Initiative.Value,
					MaxHealth = Health.Value,
					Health = Health.Value,
					ArmorClass = ArmorClass.Value,
					PassivePerception = PassivePerception.Value
				};

				settings.SQLiteDatabase.Insert (combatant);
			}
		}

		void AddPlayer ()
		{
			var combatant = new Combatant {
				Name = CharacterName.Value,
				IsPlayer = true,
				PlayerName = PlayerName.Value,
				Initiative = Initiative.Value,
				MaxHealth = Health.Value,
				Health = Health.Value,
				ArmorClass = ArmorClass.Value,
				PassivePerception = PassivePerception.Value
			};

			settings.SQLiteDatabase.Insert (combatant);
		}
	}
}
