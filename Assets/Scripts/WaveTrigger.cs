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
			RedirectWave(collision.gameObject);
		}
	}

	private void RedirectWave(GameObject wave)
	{
		//Wave wave = wave.GetComponent<wave>();
		//wave.direction = this.transform.rotation.eulerAngles;
		Debug.Log("Redirecting Wave");
	}
}
