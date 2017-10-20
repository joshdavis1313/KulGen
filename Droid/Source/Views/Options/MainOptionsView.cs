using System;
using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using KulGen.Droid.Views;
using KulGen.Source.Util;
using KulGen.Source.ViewModels.Options;

namespace KulGen.Droid.Source.Views.Options
{
	[Activity (
		Label = "Options",
		Theme = "@style/Theme.Main",
		ScreenOrientation = ScreenOrientation.Portrait
	)]
	public class MainOptionsView : NavigationBarView<MainOptionsView, MainOptionsViewModel>
	{
		protected override int LayoutResId => Resource.Layout.main_options_layout;

		RadioButton radioDesc;
		RadioButton radioAsc;
		RadioButton radioCheck;
		RadioButton radioNum;
		RadioButton radioAlpha;
		RadioButton radioCustom;
		LinearLayout layoutCustom;
		EditText editCustom;

		protected override void OnInitializeComponents ()
		{
			base.OnInitializeComponents ();

			radioDesc = FindViewById<RadioButton> (Resource.Id.radio_desc);
			radioAsc = FindViewById<RadioButton> (Resource.Id.radio_asc);
			radioCheck = FindViewById<RadioButton> (Resource.Id.radio_checkbox);
			radioNum = FindViewById<RadioButton> (Resource.Id.radio_num);
			radioAlpha = FindViewById<RadioButton> (Resource.Id.radio_alpha);
			radioCustom = FindViewById<RadioButton> (Resource.Id.radio_custom);
			layoutCustom = FindViewById<LinearLayout> (Resource.Id.multi_npc_custom_layout);
			editCustom = FindViewById<EditText> (Resource.Id.multi_npc_custom);

			SetupActionBar ("Options");

			GetOptionsFromPersistent ();
		}

		protected override void SetupBindings (MvvmCross.Binding.BindingContext.MvxFluentBindingDescriptionSet<MainOptionsView, MainOptionsViewModel> bindingSet)
		{
			bindingSet.Bind (layoutCustom).For ("Visibility").To (vm => vm.IsCustomNpcSuffix).WithConversion ("Visibility");
			bindingSet.Bind (editCustom).For (v => v.Text).To (vm => vm.MultiNpcCustomSuffix);
			base.SetupBindings (bindingSet);
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.main_options_menu, menu);
			return base.OnCreateOptionsMenu (menu);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			ViewModel.SaveOptions.Execute (null);
			return base.OnOptionsItemSelected (item);
		}

		protected override void OnResume ()
		{
			radioDesc.Click += OnDescendingClicked;
			radioAsc.Click += OnAscendingClicked;
			radioCheck.Click += OnCheckBoxClicked;
			radioNum.Click += OnNumericClicked;
			radioAlpha.Click += OnAlphabeticClicked;
			radioCustom.Click += OnCustomClicked;
			base.OnResume ();
		}

		protected override void OnPause ()
		{
			radioDesc.Click -= OnDescendingClicked;
			radioAsc.Click -= OnAscendingClicked;
			radioCheck.Click -= OnCheckBoxClicked;
			radioNum.Click -= OnNumericClicked;
			radioAlpha.Click -= OnAlphabeticClicked;
			radioCustom.Click -= OnCustomClicked;
			base.OnPause ();
		}

		void GetOptionsFromPersistent ()
		{
			//Figure out which initiatve option they selected
			switch (ViewModel.Initiative.Value) {
				case InitiativeOptions.Descending:
					radioDesc.Checked = true;
					break;
				case InitiativeOptions.Ascending:
					radioAsc.Checked = true;
					break;
				case InitiativeOptions.Checkbox:
					radioCheck.Checked = true;
					break;
			}

			//Which Multi NPC option they selected
			switch (ViewModel.MultiNpcSuffix.Value) {
				case MultiNpcSuffixOptions.Numeric:
					radioNum.Checked = true;
					break;
				case MultiNpcSuffixOptions.Alphabetic:
					radioAlpha.Checked = true;
					break;
				case MultiNpcSuffixOptions.Custom:
					radioCustom.Checked = true;
					break;
			}
		}

		void OnDescendingClicked (Object sender, EventArgs e)
		{
			ViewModel.Initiative.Value = InitiativeOptions.Descending;
		}

		void OnAscendingClicked (Object sender, EventArgs e)
		{
			ViewModel.Initiative.Value = InitiativeOptions.Ascending;
		}

		void OnCheckBoxClicked (Object sender, EventArgs e)
		{
			ViewModel.Initiative.Value = InitiativeOptions.Checkbox;
		}

		void OnNumericClicked (Object sender, EventArgs e)
		{
			ViewModel.MultiNpcSuffix.Value = MultiNpcSuffixOptions.Numeric;
			ViewModel.IsCustomNpcSuffix.Value = false; ;
		}

		void OnAlphabeticClicked (Object sender, EventArgs e)
		{
			ViewModel.MultiNpcSuffix.Value = MultiNpcSuffixOptions.Alphabetic;
			ViewModel.IsCustomNpcSuffix.Value = false;
		}

		void OnCustomClicked (Object sender, EventArgs e)
		{
			ViewModel.MultiNpcSuffix.Value = MultiNpcSuffixOptions.Custom;
			ViewModel.IsCustomNpcSuffix.Value = true;
		}
	}
}
