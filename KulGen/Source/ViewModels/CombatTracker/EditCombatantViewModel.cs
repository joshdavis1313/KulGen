using System.Threading.Tasks;
using System.Windows.Input;
using KulGen.Core;
using KulGen.Source.DataModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;

namespace KulGen.Source.ViewModels.CombatTracker
{
	public class EditCombatantViewModel : BaseViewModel
	{
		public readonly INC<string> CharacterName = new NC<string>();
		public readonly INC<string> PlayerName = new NC<string>();
		public readonly INC<int> Initiative = new NC<int>();
		public readonly INC<int> CurrentHealth = new NC<int>();
		public readonly INC<int> ArmorClass = new NC<int>();
		public readonly INC<int> PassivePerception = new NC<int>();

		public ICommand UpdateClicked => new MvxCommand(DoUpdate);
		public ICommand DeleteClicked => new MvxCommand(DoDelete);

		int combatantId;

		public EditCombatantViewModel(ILocalSettings settings) : base(settings)
		{
		}

		public void Init(NavObject nav)
		{
			if(nav != null)
			{
				combatantId = nav.Id;
				CharacterName.Value = nav.Name;
				PlayerName.Value = nav.PlayerName;
				Initiative.Value = nav.Initiative;
				CurrentHealth.Value = nav.Health;
				ArmorClass.Value = nav.ArmorClass;
				PassivePerception.Value = nav.PassivePerception;
			}
		}

		void DoUpdate()
		{
			var combatant = new Combatant
			{
				ID = combatantId,
				Name = CharacterName.Value,
				PlayerName = PlayerName.Value,
				Initiative = Initiative.Value,
				Health = CurrentHealth.Value,
				ArmorClass = ArmorClass.Value,
				PassivePerception = PassivePerception.Value
			};

			settings.SQLiteDatabase.Update(combatant);
			ShowViewModel<CombatTrackerViewModel>();
		}

		void DoDelete()
		{
			var combatant = new Combatant
			{
				ID = combatantId
			};

			settings.SQLiteDatabase.Delete(combatant);
			ShowViewModel<CombatTrackerViewModel>();
		}

		public class NavObject
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public string PlayerName { get; set; }
			public int Initiative { get; set; }
			public int MaxHealth { get; set; }
			public int Health { get; set; }
			public int ArmorClass { get; set; }
			public int PassivePerception { get; set; }
		}
	}
}
