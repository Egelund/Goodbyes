using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour {

	public float TriggerTime;

	public float currentTriggerTime;

	public bool triggered;

	private void Update()
	{
		if (!triggered)
			return;

		if(currentTriggerTime > 0)
		{
			currentTriggerTime -= Time.deltaTime;
		}

		if(currentTriggerTime <= 0)
		{
			triggered = false;
			GameManagement.instance.SubstractWinTrigger();
		}
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
