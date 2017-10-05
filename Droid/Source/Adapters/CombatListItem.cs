using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KulGen.Droid.Source.MvxBindings;
using KulGen.Source.Adapters;
using MvvmCross.Binding.BindingContext;

namespace KulGen.Droid.Source.Adapters
{
	public class CombatListItem : LinearLayout, IMvxListItem
	{
		public IMvxBindingContext BindingContext { get; set; }

		public int TemplateId => Resource.Layout.combat_item;

		public View Content { get; set; }

		public object DataContext
		{
			get {
				return BindingContext.DataContext;
			}
			set {
				if (BindingContext.DataContext == value) {
					return;
				}
				BindingContext.DataContext = value;
			}
		}

		TextView TextUpdate;
		TextView TextSetMaxHealth;
		TextView TextKill;
		TextView TextInitiative;
		TextView TextCharacterName;
		TextView TextPlayerName;
		TextView TextArmorClass;
		TextView TextPassivePerception;
		TextView TextHealth;
		TextView TextMinusDamage;
		TextView TextPlusDamage;
		EditText EditDamage;
		ImageView ImgCombatWindow;
		LinearLayout LayoutEditBox;
		LinearLayout LayoutCombatBox;

		public CombatListItem (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer)
		{
		}

		public CombatListItem (Context context) : base (context)
		{
			Init (context);
		}

		void Init (Context context)
		{
			Clickable = true;
			Content = LayoutInflater.From (context).Inflate (TemplateId, this, true);

			TextUpdate = FindViewById<TextView> (Resource.Id.change_health_update);
			TextSetMaxHealth = FindViewById<TextView> (Resource.Id.change_health_max_health);
			TextInitiative = FindViewById<TextView> (Resource.Id.text_initiative);
			TextCharacterName = FindViewById<TextView> (Resource.Id.text_character_name);
			TextPlayerName = FindViewById<TextView> (Resource.Id.text_player_name);
			TextArmorClass = FindViewById<TextView> (Resource.Id.text_armor_class);
			TextPassivePerception = FindViewById<TextView> (Resource.Id.text_passive_perception);
			TextHealth = FindViewById<TextView> (Resource.Id.text_health);
			TextMinusDamage = FindViewById<TextView> (Resource.Id.change_health_minus);
			TextPlusDamage = FindViewById<TextView> (Resource.Id.change_health_plus);
			EditDamage = FindViewById<EditText> (Resource.Id.change_health_amount);
			ImgCombatWindow = FindViewById<ImageView> (Resource.Id.img_combat_window);
			LayoutEditBox = FindViewById<LinearLayout> (Resource.Id.layout_edit_box);
			LayoutCombatBox = FindViewById<LinearLayout> (Resource.Id.layout_expand_combat);

			this.CreateBindingContext ();
			BindingContext.DelayBind (() => {
				var set = this.CreateBindingSet<CombatListItem, CombatListItemModel> ();
				set.Bind (LayoutCombatBox).For ("Visibility").To (vm => vm.ShowCombatWindow).WithConversion ("Visibility");
				set.Bind (TextInitiative).For (x => x.Text).To (vm => vm.Initiative).WithConversion ("IntToStringConverter");
				set.Bind (TextCharacterName).For (x => x.Text).To (vm => vm.CharacterName);
				set.Bind (TextPlayerName).For (x => x.Text).To (vm => vm.PlayerName);
				set.Bind (TextArmorClass).For (x => x.Text).To (vm => vm.ArmorClass).WithConversion ("IntToStringConverter");
				set.Bind (TextPassivePerception).For (x => x.Text).To (vm => vm.PassivePerception).WithConversion ("IntToStringConverter");
				set.Bind (TextHealth).For (x => x.Text).To (vm => vm.Health).WithConversion ("IntToStringConverter");
				set.Bind (EditDamage).For (x => x.Text).To (vm => vm.Damage).WithConversion ("IntToStringConverter");
				set.Bind (TextMinusDamage).For (TextMinusDamage.ClickEvent ()).To (vm => vm.MinusDamage);
				set.Bind (TextPlusDamage).For (TextPlusDamage.ClickEvent ()).To (vm => vm.AddDamage);
				set.Bind (TextUpdate).For (TextUpdate.ClickEvent ()).To (vm => vm.UpdateHealth);
				set.Bind (TextSetMaxHealth).For (TextSetMaxHealth.ClickEvent ()).To (vm => vm.SetMaxHealth);
				set.Bind (ImgCombatWindow).For (ImgCombatWindow.ClickEvent ()).To (vm => vm.ShowHideCombatWindow);
				set.Bind (LayoutEditBox).For (LayoutEditBox.ClickEvent ()).To (vm => vm.EditItem);
				set.Apply ();
			});
		}

		protected override void Dispose (bool disposing)
		{
			BindingContext?.ClearAllBindings ();
			base.Dispose (disposing);
		}
	}
}
