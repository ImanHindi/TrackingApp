package md5955c93690b5da764d155539bbe01fa4d;


public class GeolocationServiceBinder
	extends android.os.Binder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("TrackingApp.Droid.Services.GeolocationServiceBinder, TrackingApp.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", GeolocationServiceBinder.class, __md_methods);
	}


	public GeolocationServiceBinder ()
	{
		super ();
		if (getClass () == GeolocationServiceBinder.class)
			mono.android.TypeManager.Activate ("TrackingApp.Droid.Services.GeolocationServiceBinder, TrackingApp.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public GeolocationServiceBinder (md5955c93690b5da764d155539bbe01fa4d.GeolocationService p0)
	{
		super ();
		if (getClass () == GeolocationServiceBinder.class)
			mono.android.TypeManager.Activate ("TrackingApp.Droid.Services.GeolocationServiceBinder, TrackingApp.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "TrackingApp.Droid.Services.GeolocationService, TrackingApp.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
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
