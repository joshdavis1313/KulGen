package md5bc24a46e04b3958954ecb526d9cdfa3a;


public abstract class MvxCachingFragmentActivity_1
	extends mvvmcross.droid.fullfragging.caching.MvxCachingFragmentActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MvvmCross.Droid.FullFragging.Caching.MvxCachingFragmentActivity`1, MvvmCross.Droid.FullFragging, Version=5.1.1.0, Culture=neutral, PublicKeyToken=null", MvxCachingFragmentActivity_1.class, __md_methods);
	}


	public MvxCachingFragmentActivity_1 () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MvxCachingFragmentActivity_1.class)
			mono.android.TypeManager.Activate ("MvvmCross.Droid.FullFragging.Caching.MvxCachingFragmentActivity`1, MvvmCross.Droid.FullFragging, Version=5.1.1.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
