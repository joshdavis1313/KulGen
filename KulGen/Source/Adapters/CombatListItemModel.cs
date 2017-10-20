using System;
using System.Windows.Input;
using KulGen.Core;
using KulGen.DataModels;
using KulGen.Source.Util;
using KulGen.ViewModels;
using KulGen.ViewModels.CombatTracker;
using KulGen.ViewModels.EditCombatants;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;

namespace KulGen.Adapters
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
		public readonly INC<bool> HasGone = new NC<bool> ();
		public readonly INC<int> Health = new NC<int> ();
		public readonly INC<int> Damage = new NC<int> (1);
		public readonly INC<bool> ShowCombatWindow = new NC<bool> (false);
		public readonly INC<bool> IsCheckBoxInitiative = new NC<bool> (false);

		Combatant combatant;

		public CombatListItemModel (ILocalSettings settings, Combatant combatant) : base (settings)
		{
			this.combatant = combatant;
			IsCheckBoxInitiative.Value = settings.GetSavedInitiate () == InitiativeOptions.Checkbox;

			Initiative.Value = combatant.Initiative;
			CharacterName.Value = combatant.Name;
			ArmorClass.Value = combatant.ArmorClass;
			PassivePerception.Value = combatant.PassivePerception;
			Health.Value = combatant.Health;
			HasGone.Value = combatant.HasGone;

			if (combatant.IsPlayer) {
				PlayerName.Value = combatant.PlayerName;
			} else {
				PlayerName.Value = "NPC";
			}
		}

		public void DoEditItem ()
		{
			var navObj = new EditCombatantViewModel.NavObject {
				Id = combatant.ID,
				Name = combatant.Name,
				IsPlayer = combatant.IsPlayer,
				PlayerName = combatant.PlayerName,
				Initiative = combatant.Initiative,
				MaxHealth = combatant.MaxHealth,
				Health = Health.Value,
				ArmorClass = combatant.ArmorClass,
				PassivePerception = combatant.PassivePerception,
				HasGone = combatant.HasGone
			};

			ShowViewModel<EditCombatantViewModel> (navObj);
		}

		void DoShowHideCombatWindow ()
		{
			Damage.Value = 1;
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
			UpdateCombatantHealth ();
			DoShowHideCombatWindow ();
		}

		void DoSetMaxHealth ()
		{
			Health.Value = combatant.MaxHealth;
			UpdateCombatantHealth ();
			DoShowHideCombatWindow ();
		}

		void UpdateCombatantHealth ()
		{
			combatant.Health = Health.Value;
			settings.SQLiteDatabase.Update (combatant);
		}
	}
}
