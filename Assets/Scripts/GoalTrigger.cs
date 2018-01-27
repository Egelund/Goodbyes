using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Wave")
		{
			GameManagement.instance.SetWin();
		}
	}

}
