package md571b9c0452879b08b3e32572c62f2a3af;


public class CombatTrackerView
	extends md5b080e29214788936adecfb0fd8f33ccb.NavigationBarView_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateOptionsMenu:(Landroid/view/Menu;)Z:GetOnCreateOptionsMenu_Landroid_view_Menu_Handler\n" +
			"n_onOptionsItemSelected:(Landroid/view/MenuItem;)Z:GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler\n" +
			"";
		mono.android.Runtime.register ("KulGen.Droid.Source.Views.CombatTracker.CombatTrackerView, KulGen.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CombatTrackerView.class, __md_methods);
	}


	public CombatTrackerView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CombatTrackerView.class)
			mono.android.TypeManager.Activate ("KulGen.Droid.Source.Views.CombatTracker.CombatTrackerView, KulGen.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public boolean onCreateOptionsMenu (android.view.Menu p0)
	{
		return n_onCreateOptionsMenu (p0);
	}

	private native boolean n_onCreateOptionsMenu (android.view.Menu p0);


	public boolean onOptionsItemSelected (android.view.MenuItem p0)
	{
		return n_onOptionsItemSelected (p0);
	}

	private native boolean n_onOptionsItemSelected (android.view.MenuItem p0);

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
