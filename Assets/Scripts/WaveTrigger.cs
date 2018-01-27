using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTrigger : MonoBehaviour
{



	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Wave")
		{
			Debug.Log("TriggerEnter2D");
			RedirectWave();
		}
	}

	private void RedirectWave()
	{
		//Add wave parameter
		//Redirect wave vector
		Debug.Log("Redirecting Wave");
	}
}
