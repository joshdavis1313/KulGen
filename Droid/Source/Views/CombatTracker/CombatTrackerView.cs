using System;
using Android.App;
using Android.Content.PM;
using Android.Support.Design.Widget;
using Android.Widget;
using KulGen.Source.ViewModels.CombatTracker;
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

		protected override void OnInitializeComponents()
		{
			base.OnInitializeComponents ();

			var toolbar = FindViewById<Toolbar> (Resource.Id.toptoolbar);
			SetActionBar (toolbar);
			ActionBar.Title = "Combat Tracker";

			var fab = FindViewById<FloatingActionButton> (Resource.Id.fab_add);
			fab.Click += AddCharacter;
		}

		protected override void SetupBindings(MvvmCross.Binding.BindingContext.MvxFluentBindingDescriptionSet<CombatTrackerView, CombatTrackerViewModel> bindingSet)
		{
			base.SetupBindings (bindingSet);
		}

		public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.top_menu, menu);
			return base.OnCreateOptionsMenu (menu);
		}

		public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
		{
			return base.OnOptionsItemSelected (item);
		}

		void AddCharacter(object sender, EventArgs e)
		{
			ViewModel.AddCombatItem.Execute(null);
		}
	}
}
