using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using KulGen.Droid.Source.Adapters;
using KulGen.Source.ViewModels.CombatTracker;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;

namespace KulGen.Droid.Source.Views.CombatTracker
{
	[Activity (
		Label = "Combat Tracker",
		LaunchMode = LaunchMode.SingleTask,
		Theme = "@style/Theme.Main",
		ScreenOrientation = ScreenOrientation.Portrait
	)]
	public class CombatTrackerView : NavigationBarView<CombatTrackerView, CombatTrackerViewModel>
	{
		protected override int LayoutResId => Resource.Layout.combat_tracker_layout;

		MvxListView combatantList;

		protected override void OnInitializeComponents ()
		{
			base.OnInitializeComponents ();

			var toolbar = FindViewById<Toolbar> (Resource.Id.toptoolbar);
			var fab = FindViewById<FloatingActionButton> (Resource.Id.fab_add);
			combatantList = FindViewById<MvxListView> (Resource.Id.list_combat);

			combatantList.Adapter = new CombatantAdapter (this, BindingContext as IMvxAndroidBindingContext);

			SetActionBar (toolbar);
			ActionBar.Title = "Combat Tracker";

			fab.Click += AddCharacter;
		}

		protected override void SetupBindings (MvvmCross.Binding.BindingContext.MvxFluentBindingDescriptionSet<CombatTrackerView, CombatTrackerViewModel> bindingSet)
		{
			bindingSet.Bind (combatantList).For (x => x.ItemsSource).To (vm => vm.CombatantList);
			bindingSet.Bind (combatantList).For (combatantList.ItemClickEvent ()).To (vm => vm.EditItem);
			base.SetupBindings (bindingSet);
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.combat_tracker_menu, menu);
			return base.OnCreateOptionsMenu (menu);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId) {
				case Resource.Id.menu_clear:
					ViewModel.ClearCombatants.Execute (null);
					break;
			}

			return base.OnOptionsItemSelected (item);
		}

		void AddCharacter (object sender, EventArgs e)
		{
			ViewModel.AddCombatItem.Execute (null);
		}

		protected override void OnResume ()
		{
			ViewModel.UpdateCombatantList.Execute (null);
			base.OnResume ();
		}
	}
}
