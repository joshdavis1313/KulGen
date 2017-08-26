using System;
using Android.Content;
using Android.Graphics;
using Android.Support.V4.Content;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;

namespace KulGen.Droid.Source.Adapters
{
	public class CombatantListAdapter : MvxAdapter
	{
		Context context;

		public CombatantListAdapter(Context context, IMvxAndroidBindingContext bindingContext) : base(context, bindingContext)
   		{
			this.context = context;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = base.GetView(position, convertView, parent);

			if (position % 2 == 1) {
				view.SetBackgroundColor(new Color(ContextCompat.GetColor(context, Resource.Color.lightgrey)));  
			} else {
			    view.SetBackgroundColor(Color.White);  
			}

			return view;
		}
	}
}
