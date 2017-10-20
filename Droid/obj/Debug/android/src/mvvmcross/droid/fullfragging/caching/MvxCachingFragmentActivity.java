package mvvmcross.droid.fullfragging.caching;


public class MvxCachingFragmentActivity
	extends mvvmcross.droid.fullfragging.views.MvxActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPostCreate:(Landroid/os/Bundle;)V:GetOnPostCreate_Landroid_os_Bundle_Handler\n" +
			"n_onSaveInstanceState:(Landroid/os/Bundle;)V:GetOnSaveInstanceState_Landroid_os_Bundle_Handler\n" +
			"n_onBackPressed:()V:GetOnBackPressedHandler\n" +
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_setContentView:(I)V:GetSetContentView_IHandler\n" +
			"n_onCreate:(Landroid/os/Bundle;Landroid/os/PersistableBundle;)V:GetOnCreate_Landroid_os_Bundle_Landroid_os_PersistableBundle_Handler\n" +
			"n_onAttachedToWindow:()V:GetOnAttachedToWindowHandler\n" +
			"n_onDetachedFromWindow:()V:GetOnDetachedFromWindowHandler\n" +
			"";
		mono.android.Runtime.register ("MvvmCross.Droid.FullFragging.Caching.MvxCachingFragmentActivity, MvvmCross.Droid.FullFragging, Version=5.1.1.0, Culture=neutral, PublicKeyToken=null", MvxCachingFragmentActivity.class, __md_methods);
	}


	public MvxCachingFragmentActivity ()
	{
		super ();
		if (getClass () == MvxCachingFragmentActivity.class)
			mono.android.TypeManager.Activate ("MvvmCross.Droid.FullFragging.Caching.MvxCachingFragmentActivity, MvvmCross.Droid.FullFragging, Version=5.1.1.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onPostCreate (android.os.Bundle p0)
	{
		n_onPostCreate (p0);
	}

	private native void n_onPostCreate (android.os.Bundle p0);


	public void onSaveInstanceState (android.os.Bundle p0)
	{
		n_onSaveInstanceState (p0);
	}

	private native void n_onSaveInstanceState (android.os.Bundle p0);


	public void onBackPressed ()
	{
		n_onBackPressed ();
	}

	private native void n_onBackPressed ();


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void setContentView (int p0)
	{
		n_setContentView (p0);
	}

	private native void n_setContentView (int p0);


	public void onCreate (android.os.Bundle p0, android.os.PersistableBundle p1)
	{
		n_onCreate (p0, p1);
	}

	private native void n_onCreate (android.os.Bundle p0, android.os.PersistableBundle p1);


	public void onAttachedToWindow ()
	{
		n_onAttachedToWindow ();
	}

	private native void n_onAttachedToWindow ();


	public void onDetachedFromWindow ()
	{
		n_onDetachedFromWindow ();
	}

	private native void n_onDetachedFromWindow ();

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
