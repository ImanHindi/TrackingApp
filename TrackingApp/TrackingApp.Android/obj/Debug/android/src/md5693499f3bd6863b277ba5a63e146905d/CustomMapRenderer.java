package md5693499f3bd6863b277ba5a63e146905d;


public class CustomMapRenderer
	extends md55b943cb46934695d066180d3c9f40d32.MapRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("TrackingApp.Droid.Renderers.CustomMapRenderer, TrackingApp.Android", CustomMapRenderer.class, __md_methods);
	}


	public CustomMapRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CustomMapRenderer.class)
			mono.android.TypeManager.Activate ("TrackingApp.Droid.Renderers.CustomMapRenderer, TrackingApp.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public CustomMapRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CustomMapRenderer.class)
			mono.android.TypeManager.Activate ("TrackingApp.Droid.Renderers.CustomMapRenderer, TrackingApp.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CustomMapRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CustomMapRenderer.class)
			mono.android.TypeManager.Activate ("TrackingApp.Droid.Renderers.CustomMapRenderer, TrackingApp.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
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
