package md52f4e9aa914243b0c5bb7b22ac19ef178;


public class CardListView
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("hackathon.droid.Activities.CardListView, hackathon.droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CardListView.class, __md_methods);
	}


	public CardListView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CardListView.class)
			mono.android.TypeManager.Activate ("hackathon.droid.Activities.CardListView, hackathon.droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
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
