package md5f0bdb3c61c86dcd5f2eea12d318086e4;


public abstract class MvxListViewAdapter_1
	extends md5f01635529583fb899ec3b27570b8c484.MvxAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getView:(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;:GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler\n" +
			"";
		mono.android.Runtime.register ("KulGen.Droid.Source.MvxBindings.MvxListViewAdapter`1, KulGen.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MvxListViewAdapter_1.class, __md_methods);
	}


	public MvxListViewAdapter_1 () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MvxListViewAdapter_1.class)
			mono.android.TypeManager.Activate ("KulGen.Droid.Source.MvxBindings.MvxListViewAdapter`1, KulGen.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public MvxListViewAdapter_1 (android.content.Context p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == MvxListViewAdapter_1.class)
			mono.android.TypeManager.Activate ("KulGen.Droid.Source.MvxBindings.MvxListViewAdapter`1, KulGen.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public android.view.View getView (int p0, android.view.View p1, android.view.ViewGroup p2)
	{
		return n_getView (p0, p1, p2);
	}

	private native android.view.View n_getView (int p0, android.view.View p1, android.view.ViewGroup p2);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
