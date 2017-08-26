using System;
using Android.App;
using Android.Content.PM;
using Android.Widget;
using KulGen.Source.ViewModels.CombatTracker;
using MvvmCross.Binding.BindingContext;

namespace KulGen.Droid.Source.Views.Dialogs
{
	[Activity(
		LaunchMode = LaunchMode.SingleTask,
		Theme = "@style/Theme.Main",
		NoHistory = true,
		ScreenOrientation = ScreenOrientation.Portrait
	)]
	public class AddCombatantView : BaseView<AddCombatantView, AddCombatantViewModel>
	{
		EditText editCharacterName;
		EditText editPlayerName;
		EditText editInitiative;
		EditText editHealth;
		EditText editPassivePerception;
		EditText editArmorClass;

		protected override int LayoutResId => Resource.Layout.add_combatant_layout;

		protected override void OnInitializeComponents()
		{
			editCharacterName = FindViewById<EditText>(Resource.Id.edit_character_name);
			editPlayerName = FindViewById<EditText>(Resource.Id.edit_player_name);
			editInitiative = FindViewById<EditText>(Resource.Id.edit_initiative);
			editHealth = FindViewById<EditText>(Resource.Id.edit_max_health);
			editPassivePerception = FindViewById<EditText>(Resource.Id.edit_perception);
			editArmorClass = FindViewById<EditText>(Resource.Id.edit_armor);

			var toolbar = FindViewById<Toolbar>(Resource.Id.toptoolbar);
			SetActionBar(toolbar);
			ActionBar.Title = "Add Combatant";

			editCharacterName.Click += ClearText;
			editPlayerName.Click += ClearText;
			editInitiative.Click += ClearText;
			editHealth.Click += ClearText;
			editPassivePerception.Click += ClearText;
			editArmorClass.Click += ClearText;
		}

		protected override void SetupBindings(MvxFluentBindingDescriptionSet<AddCombatantView, AddCombatantViewModel> bindingSet)
		{
			bindingSet.Bind(editCharacterName).For(x => x.Text).To(vm => vm.CharacterName);
			bindingSet.Bind(editPlayerName).For(x => x.Text).To(vm => vm.PlayerName);
			bindingSet.Bind(editInitiative).For(x => x.Text).To(vm => vm.Initiative).WithConversion("StringToIntConverter");
			bindingSet.Bind(editHealth).For(x => x.Text).To(vm => vm.Health).WithConversion("StringToIntConverter");
			bindingSet.Bind(editPassivePerception).For(x => x.Text).To(vm => vm.PassivePerception).WithConversion("StringToIntConverter");
			bindingSet.Bind(editArmorClass).For(x => x.Text).To(vm => vm.ArmorClass).WithConversion("StringToIntConverter");
		}

		public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.add_combatant_menu, menu);
			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
		{
			ViewModel.AddClicked.Execute(null);
			return base.OnOptionsItemSelected(item);
		}

		private void ClearText(object sender, EventArgs e)
		{
			var editText = (EditText)sender;
			editText.Text = "";
		}
	}
}
