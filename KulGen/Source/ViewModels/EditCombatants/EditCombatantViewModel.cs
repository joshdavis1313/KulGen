using System.Windows.Input;
using KulGen.Core;
using KulGen.DataModels;
using KulGen.ViewModels.CombatTracker;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;

namespace KulGen.ViewModels.EditCombatants
{
	public class EditCombatantViewModel : BaseViewModel
	{
		public readonly INC<string> CharacterName = new NC<string> ();
		public readonly INC<string> PlayerName = new NC<string> ();
		public readonly INC<int> Initiative = new NC<int> ();
		public readonly INC<int> MaxHealth = new NC<int> ();
		public readonly INC<int> ArmorClass = new NC<int> ();
		public readonly INC<int> PassivePerception = new NC<int> ();
		public readonly INC<bool> IsPlayer = new NC<bool> ();

		public ICommand UpdateClicked => new MvxCommand (DoUpdate);
		public ICommand DeleteClicked => new MvxCommand (DoDelete);

		int combatantId;
		int health;

		public EditCombatantViewModel (ILocalSettings settings) : base (settings) { }

		public void Init (NavObject nav)
		{
			if (nav != null) {
				combatantId = nav.Id;
				CharacterName.Value = nav.Name;
				IsPlayer.Value = nav.IsPlayer;
				PlayerName.Value = nav.PlayerName;
				Initiative.Value = nav.Initiative;
				MaxHealth.Value = nav.MaxHealth;
				health = nav.Health;
				ArmorClass.Value = nav.ArmorClass;
				PassivePerception.Value = nav.PassivePerception;
			}
		}

		void DoUpdate ()
		{
			var combatant = new Combatant {
				ID = combatantId,
				Name = CharacterName.Value,
				IsPlayer = IsPlayer.Value,
				PlayerName = PlayerName.Value,
				Initiative = Initiative.Value,
				Health = health,
				MaxHealth = MaxHealth.Value,
				ArmorClass = ArmorClass.Value,
				PassivePerception = PassivePerception.Value
			};

			settings.SQLiteDatabase.Update (combatant);
			ShowViewModel<CombatTrackerViewModel> ();
		}

		void DoDelete ()
		{
			var combatant = new Combatant {
				ID = combatantId
			};

			settings.SQLiteDatabase.Delete (combatant);
			ShowViewModel<CombatTrackerViewModel> ();
		}

		public class NavObject
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public bool IsPlayer { get; set; }
			public string PlayerName { get; set; }
			public int Initiative { get; set; }
			public int MaxHealth { get; set; }
			public int Health { get; set; }
			public int ArmorClass { get; set; }
			public int PassivePerception { get; set; }
		}
	}
}
