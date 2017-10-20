using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Widget;
using KulGen.Droid.Views;
using KulGen.Source.ViewModels.Help;
using MvvmCross.Binding.BindingContext;
using Uri = Android.Net.Uri;

namespace KulGen.Droid.Source.Views.Help
{
	[Activity (
		Label = "Help",
		Theme = "@style/Theme.Main",
		ScreenOrientation = ScreenOrientation.Portrait
	)]
	public class MainHelpView : NavigationBarView<MainHelpView, MainHelpViewModel>
	{
		protected override int LayoutResId => Resource.Layout.main_help_layout;

		const string GreyHawkHelpLink = "http://media.wizards.com/2017/dnd/downloads/UAGreyhawkInitiative.pdf";
		const string NarrativeHelpLink = "https://lootthebody.wordpress.com/2017/08/04/the-art-of-starting-a-fight-narrative-initiative-in-dd/";

		TextView textGreyHawkLink;
		TextView textNarritiveLink;

		protected override void OnInitializeComponents ()
		{
			base.OnInitializeComponents ();

			textGreyHawkLink = FindViewById<TextView> (Resource.Id.text_help_greyhawk_link);
			textNarritiveLink = FindViewById<TextView> (Resource.Id.text_help_narrative_link);

			SetupActionBar ("Help");
		}

		protected override void SetupBindings (MvxFluentBindingDescriptionSet<MainHelpView, MainHelpViewModel> bindingSet)
		{
			base.SetupBindings (bindingSet);
		}

		protected override void OnResume ()
		{
			textGreyHawkLink.Click += GreyHawkLinkClicked;
			textNarritiveLink.Click += NarrativeLinkClicked;
			base.OnResume ();
		}

		protected override void OnPause ()
		{
			textGreyHawkLink.Click -= GreyHawkLinkClicked;
			textNarritiveLink.Click -= NarrativeLinkClicked;
			base.OnPause ();
		}

		void GreyHawkLinkClicked (Object sender, EventArgs e)
		{
			var uri = Uri.Parse (GreyHawkHelpLink);
			var intent = new Intent (Intent.ActionView, uri);
			StartActivity (intent);
		}

		void NarrativeLinkClicked (Object sender, EventArgs e)
		{
			var uri = Uri.Parse (NarrativeHelpLink);
			var intent = new Intent (Intent.ActionView, uri);
			StartActivity (intent);
		}
	}
}
