using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using KulGen.Droid.MvxBindings;
using KulGen.Adapters;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;

namespace KulGen.Droid.Adapters
{
	public class CombatantAdapter : MvxListViewAdapter<CombatListItemModel>
	{
		readonly Context context;
		public override int ItemTemplateId => Resource.Layout.combat_item;

		public CombatantAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
		}

		public CombatantAdapter(Context context, IMvxAndroidBindingContext bindingContext) : base(context, bindingContext, Resource.Layout.combat_item)
		{
			this.context = context;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view;

			if (convertView == null){
				view = LayoutInflater.FromContext(context).Inflate(ItemTemplateId, null);
			} else {
				view = base.GetView(position, convertView, parent);
			}

			if (position % 2 == 1) {
				view.SetBackgroundColor(new Color(ContextCompat.GetColor(context, Resource.Color.secondary_color)));
			} else {
				view.SetBackgroundColor(Color.White);
			}

			return view;
		}


		protected override IMvxListItemView CreateViewBasedOnInfo(CombatListItemModel dataContext, int templateId)
		{
			var item = new CombatListItem(Context);
			item.DataContext = dataContext;
			return item;
		}
	}
}
