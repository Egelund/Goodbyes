using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour {

	public float TriggerTime;

	public float currentTriggerTime;

	public bool triggered;
	Animator myAnimator;

	bool changingLevel;

	private void Update()
	{
		myAnimator.SetBool("Win", triggered);

		if (!triggered)
			return;

		if(currentTriggerTime > 0)
		{
			currentTriggerTime -= Time.deltaTime;
		}

		if(currentTriggerTime <= 0)
		{
			if (GameManagement.instance.GetWin())
			{
				if(!changingLevel)
				{
					ScreenFade fade = FindObjectOfType<ScreenFade>();
					fade.FadeIn();
					fade.fadeInFinished = ChangeLevel;
					changingLevel = true;
				}
				return;
			}


			triggered = false;
			GameManagement.instance.SubstractWinTrigger();
		}
	}

	public string SceneToLoad;

	public void ChangeLevel()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(SceneToLoad);
	}

	private void Start()
	{
		myAnimator = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (triggered)
			return;

		if (collision.tag == "Wave")
		{			
			GameManagement.instance.AddWinTrigger();
			triggered = true;
			currentTriggerTime = TriggerTime;
		}
	}

}
