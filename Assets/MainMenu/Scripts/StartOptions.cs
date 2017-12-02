﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOptions : MonoBehaviour {

	public int sceneToStart = 1;										

	[HideInInspector] public Animator animColorFade;
	[HideInInspector] public Animator animMenuAlpha;
	public AnimationClip fadeColorAnimationClip;
	
	public void StartButtonClicked()
	{
			Invoke ("LoadDelayed", fadeColorAnimationClip.length * .5f);
			animColorFade.SetTrigger ("fade");		
	}

	public void LoadDelayed()
	{
		SceneManager.LoadScene (sceneToStart);
	}
}
