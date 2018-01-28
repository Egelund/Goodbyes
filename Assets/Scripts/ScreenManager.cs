using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour {

	public void StartGame()
	{
		ScreenFade.instance.FadeIn();
		ScreenFade.instance.fadeInFinished += FinallyStartGame;
	}

	public void FinallyStartGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
	}
}
