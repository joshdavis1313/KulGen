using System;
using System.Windows.Input;
using KulGen.Core;
using KulGen.Source.DataModels;
using KulGen.Source.ViewModels;
using KulGen.Source.ViewModels.CombatTracker;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;

namespace KulGen.Source.Adapters
{
	public class CombatListItemModel : BaseViewModel
	{
		public ICommand EditItem { get { return new MvxCommand (DoEditItem); } }
		public ICommand UpdateHealth { get { return new MvxCommand (DoUpdateHealth); } }
		public ICommand SetMaxHealth { get { return new MvxCommand (DoSetMaxHealth); } }
		public ICommand MinusDamage { get { return new MvxCommand (DoMinusDamage); } }
		public ICommand AddDamage { get { return new MvxCommand (DoAddDamage); } }
		public ICommand ShowHideCombatWindow { get { return new MvxCommand (DoShowHideCombatWindow); } }

		public readonly INC<int> Initiative = new NC<int> ();
		public readonly INC<string> CharacterName = new NC<string> ();
		public readonly INC<string> PlayerName = new NC<string> ();
		public readonly INC<int> ArmorClass = new NC<int> ();
		public readonly INC<int> PassivePerception = new NC<int> ();
		public readonly INC<int> Health = new NC<int> ();
		public readonly INC<int> Damage = new NC<int> ();
		public readonly INC<bool> ShowCombatWindow = new NC<bool> (false);

		Combatant combatant;

		public CombatListItemModel (ILocalSettings settings, Combatant combatant) : base (settings)
		{
			this.combatant = combatant;
			Initiative.Value = combatant.Initiative;
			CharacterName.Value = combatant.Name;
			PlayerName.Value = combatant.PlayerName;
			ArmorClass.Value = combatant.ArmorClass;
			PassivePerception.Value = combatant.PassivePerception;
			Health.Value = combatant.Health;
			Damage.Value = 1;
		}

		public void DoEditItem ()
		{
			var navObj = new EditCombatantViewModel.NavObject {
				Id = combatant.ID,
				Name = combatant.Name,
				PlayerName = combatant.PlayerName,
				Initiative = combatant.Initiative,
				MaxHealth = combatant.MaxHealth,
				ArmorClass = combatant.ArmorClass,
				PassivePerception = combatant.PassivePerception
			};

			ShowViewModel<EditCombatantViewModel> (navObj);
		}

		void DoShowHideCombatWindow ()
		{
			if (ShowCombatWindow.Value == true) {
				ShowCombatWindow.Value = false;
			} else {
				ShowCombatWindow.Value = true;
			}
		}

		void DoMinusDamage ()
		{
			Damage.Value--;
		}

		void DoAddDamage ()
		{
			Damage.Value++;
		}

		void DoUpdateHealth ()
		{
			Health.Value = Health.Value - Damage.Value;
			DoShowHideCombatWindow ();
		}

		void DoSetMaxHealth ()
		{
			Health.Value = combatant.MaxHealth;
			DoShowHideCombatWindow ();
		}
	}
}
