package md5d4b30cb825df585d090b84a4ec555c95;


public abstract class MvxActivity_1
	extends mvvmcross.droid.fullfragging.views.MvxActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MvvmCross.Droid.FullFragging.Views.MvxActivity`1, MvvmCross.Droid.FullFragging, Version=5.1.1.0, Culture=neutral, PublicKeyToken=null", MvxActivity_1.class, __md_methods);
	}


	public MvxActivity_1 ()
	{
		super ();
		if (getClass () == MvxActivity_1.class)
			mono.android.TypeManager.Activate ("MvvmCross.Droid.FullFragging.Views.MvxActivity`1, MvvmCross.Droid.FullFragging, Version=5.1.1.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
