using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using KulGen.Droid.Source.Adapters;
using KulGen.Source.ViewModels.CombatTracker;
using MvvmCross.Binding.BindingContext;

namespace KulGen.Droid.Source.Views.AddCombatants
{
	[Activity(
		LaunchMode = LaunchMode.SingleTask,
		Theme = "@style/Theme.Main",
		NoHistory = true,
		ScreenOrientation = ScreenOrientation.Portrait
	)]
	public class AddMonsterView : BaseView<AddMonsterView, AddCombatantViewModel>
	{
		EditText editCombatantName;
		EditText editPlayerName;
		EditText editInitiative;
		EditText editHealth;
		EditText editPassivePerception;
		EditText editArmorClass;
		EditText editCreateNumber;

		protected override int LayoutResId => Resource.Layout.add_combatant_layout;

		protected override void OnInitializeComponents()
		{
			editCombatantName = FindViewById<EditText>(Resource.Id.add_character_name);
			editPlayerName = FindViewById<EditText>(Resource.Id.add_player_name);
			editInitiative = FindViewById<EditText>(Resource.Id.add_initiative);
			editHealth = FindViewById<EditText>(Resource.Id.add_max_health);
			editPassivePerception = FindViewById<EditText>(Resource.Id.add_perception);
			editArmorClass = FindViewById<EditText>(Resource.Id.add_armor);
			editCreateNumber = FindViewById<EditText>(Resource.Id.create_number);

			var toolbar = FindViewById<Toolbar>(Resource.Id.toptoolbar);
			SetActionBar(toolbar);
			ActionBar.Title = "Add Combatant";
		}

		protected override void SetupBindings(MvxFluentBindingDescriptionSet<AddMonsterView, AddCombatantViewModel> bindingSet)
		{
			bindingSet.Bind(editCombatantName).For(x => x.Text).To(vm => vm.CharacterName);
			bindingSet.Bind(editPlayerName).For(x => x.Text).To(vm => vm.PlayerName);
			bindingSet.Bind(editInitiative).For(x => x.Text).To(vm => vm.Initiative).WithConversion("StringToIntConverter");
			bindingSet.Bind(editHealth).For(x => x.Text).To(vm => vm.Health).WithConversion("StringToIntConverter");
			bindingSet.Bind(editPassivePerception).For(x => x.Text).To(vm => vm.PassivePerception).WithConversion("StringToIntConverter");
			bindingSet.Bind(editArmorClass).For(x => x.Text).To(vm => vm.ArmorClass).WithConversion("StringToIntConverter");
			bindingSet.Bind(editCreateNumber).For(x => x.Text).To(vm => vm.CreateNumber).WithConversion("StringToIntConverter");
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.add_combatant_menu, menu);
			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			ViewModel.AddClicked.Execute(null);
			return base.OnOptionsItemSelected(item);
		}
	}
}
