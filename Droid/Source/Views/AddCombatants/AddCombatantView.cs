using System;
using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using KulGen.ViewModels.AddCombatants;
using MvvmCross.Binding.BindingContext;

namespace KulGen.Droid.Views.AddCombatants
{
	[Activity (
		LaunchMode = LaunchMode.SingleTask,
		Theme = "@style/Theme.Main",
		NoHistory = true,
		ScreenOrientation = ScreenOrientation.Portrait
	)]
	public class AddCombatantView : BaseView<AddCombatantView, AddCombatantViewModel>
	{
		EditText editCombatantName;
		EditText editPlayerName;
		EditText editInitiative;
		EditText editHealth;
		EditText editPassivePerception;
		EditText editArmorClass;
		EditText editCreateNumber;
		RadioButton radioNpc;
		RadioButton radioPlayer;
		LinearLayout layoutPlayerName;
		LinearLayout layoutCreateNumber;

		protected override int LayoutResId => Resource.Layout.add_combatant_layout;

		protected override void OnInitializeComponents ()
		{
			editCombatantName = FindViewById<EditText> (Resource.Id.add_character_name);
			editPlayerName = FindViewById<EditText> (Resource.Id.add_player_name);
			editInitiative = FindViewById<EditText> (Resource.Id.add_initiative);
			editHealth = FindViewById<EditText> (Resource.Id.add_max_health);
			editPassivePerception = FindViewById<EditText> (Resource.Id.add_perception);
			editArmorClass = FindViewById<EditText> (Resource.Id.add_armor);
			editCreateNumber = FindViewById<EditText> (Resource.Id.add_create_number);
			radioNpc = FindViewById<RadioButton> (Resource.Id.radio_npc);
			radioPlayer = FindViewById<RadioButton> (Resource.Id.radio_player);
			layoutPlayerName = FindViewById<LinearLayout> (Resource.Id.layout_add_player_name);
			layoutCreateNumber = FindViewById<LinearLayout> (Resource.Id.layout_add_create_number);

			var toolbar = FindViewById<Toolbar> (Resource.Id.toptoolbar);
			SetActionBar (toolbar);
			ActionBar.Title = "Add Combatant";

			radioNpc.Click += OnNpcClicked;
			radioPlayer.Click += OnPlayerClicked;
		}

		protected override void SetupBindings (MvxFluentBindingDescriptionSet<AddCombatantView, AddCombatantViewModel> bindingSet)
		{
			bindingSet.Bind (editCombatantName).For (x => x.Text).To (vm => vm.CharacterName);
			bindingSet.Bind (editPlayerName).For (x => x.Text).To (vm => vm.PlayerName);
			bindingSet.Bind (layoutPlayerName).For ("Visibility").To (vm => vm.IsPlayer).WithConversion ("Visibility");
			bindingSet.Bind (editInitiative).For (x => x.Text).To (vm => vm.Initiative).WithConversion ("StringToIntConverter");
			bindingSet.Bind (editHealth).For (x => x.Text).To (vm => vm.Health).WithConversion ("StringToIntConverter");
			bindingSet.Bind (editPassivePerception).For (x => x.Text).To (vm => vm.PassivePerception).WithConversion ("StringToIntConverter");
			bindingSet.Bind (editArmorClass).For (x => x.Text).To (vm => vm.ArmorClass).WithConversion ("StringToIntConverter");
			bindingSet.Bind (editCreateNumber).For (x => x.Text).To (vm => vm.CreateNumber).WithConversion ("StringToIntConverter");
			bindingSet.Bind (layoutCreateNumber).For ("Visibility").To (vm => vm.IsPlayer).WithConversion ("InvertedVisibility");
		}

		void OnNpcClicked (Object sender, EventArgs e)
		{
			ViewModel.IsPlayer.Value = false;
		}

		void OnPlayerClicked (Object sender, EventArgs e)
		{
			ViewModel.IsPlayer.Value = true;
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.add_combatant_menu, menu);
			return base.OnCreateOptionsMenu (menu);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			ViewModel.AddClicked.Execute (null);
			return base.OnOptionsItemSelected (item);
		}

		protected override void OnDestroy ()
		{
			radioNpc.Click -= OnNpcClicked;
			radioPlayer.Click -= OnPlayerClicked;
			base.OnDestroy ();
		}
	}
}
