package md5c0cddfe2bcae6ef40b86d10b94a521d7;


public class CardAdapter
	extends com.huxq17.swipecardsview.BaseCardAdapter
	implements
		mono.android.IGCUserPeer,
		com.huxq17.swipecardsview.SwipeCardsView.CardsSlideListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getCardLayoutId:()I:GetGetCardLayoutIdHandler\n" +
			"n_getCount:()I:GetGetCountHandler\n" +
			"n_onBindData:(ILandroid/view/View;)V:GetOnBindData_ILandroid_view_View_Handler\n" +
			"n_onCardVanish:(ILcom/huxq17/swipecardsview/SwipeCardsView$SlideType;)V:GetOnCardVanish_ILcom_huxq17_swipecardsview_SwipeCardsView_SlideType_Handler:Com.Huxq17.Swipecardsview.SwipeCardsView/ICardsSlideListenerInvoker, SwipeCardView\n" +
			"n_onItemClick:(Landroid/view/View;I)V:GetOnItemClick_Landroid_view_View_IHandler:Com.Huxq17.Swipecardsview.SwipeCardsView/ICardsSlideListenerInvoker, SwipeCardView\n" +
			"n_onShow:(I)V:GetOnShow_IHandler:Com.Huxq17.Swipecardsview.SwipeCardsView/ICardsSlideListenerInvoker, SwipeCardView\n" +
			"";
		mono.android.Runtime.register ("Fundo.Adapter.CardAdapter, Fundo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CardAdapter.class, __md_methods);
	}


	public CardAdapter () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CardAdapter.class)
			mono.android.TypeManager.Activate ("Fundo.Adapter.CardAdapter, Fundo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public int getCardLayoutId ()
	{
		return n_getCardLayoutId ();
	}

	private native int n_getCardLayoutId ();


	public int getCount ()
	{
		return n_getCount ();
	}

	private native int n_getCount ();


	public void onBindData (int p0, android.view.View p1)
	{
		n_onBindData (p0, p1);
	}

	private native void n_onBindData (int p0, android.view.View p1);


	public void onCardVanish (int p0, com.huxq17.swipecardsview.SwipeCardsView.SlideType p1)
	{
		n_onCardVanish (p0, p1);
	}

	private native void n_onCardVanish (int p0, com.huxq17.swipecardsview.SwipeCardsView.SlideType p1);


	public void onItemClick (android.view.View p0, int p1)
	{
		n_onItemClick (p0, p1);
	}

	private native void n_onItemClick (android.view.View p0, int p1);


	public void onShow (int p0)
	{
		n_onShow (p0);
	}

	private native void n_onShow (int p0);

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
