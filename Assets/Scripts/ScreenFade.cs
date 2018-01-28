using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFade : MonoBehaviour {

	public bool FadingIn;
	public bool FadeInFinished;
	public bool FadingOut;
	public bool FadeOutFinished;

	public static ScreenFade instance;

	public delegate void OnFadeInFinished();

	public OnFadeInFinished fadeInFinished;

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
			//DontDestroyOnLoad(this);
		}
		else
		{
			Destroy(this);
		}
	}

	Animator ScreenAnimator;
	// Use this for initialization
	void Start () {
		ScreenAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		ScreenAnimator.SetBool("FadeInFinished", FadeInFinished);
		ScreenAnimator.SetBool("FadeOutFinished", FadeOutFinished);

		ScreenAnimator.SetBool("FadingOut", FadingOut);
		ScreenAnimator.SetBool("FadingIn", FadingIn);
		//if(Input.GetKeyDown(KeyCode.F))
		//{
		//	FadeIn();
		//}
		//if (Input.GetKeyDown(KeyCode.K))
		//{
		//	FadeOut();
		//}
	}

	public void FadeIn()
	{
		FadingIn = true;
		FadingOut = false;
	}

	public void FadeOut()
	{
		FadingOut = true;
		FadingIn = false;
	}

	public void OnFadeIn()
	{
		if(fadeInFinished != null)
		{
			fadeInFinished();
			fadeInFinished = null;
		}
	}
}
