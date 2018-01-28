using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBlocker : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag != "Wave")
		{
			Debug.Log("Wave Blocker collided with something its not a dot");
			return;
		}

		if(GetComponent<LineRenderer>() != null)
		{
			return;
		}

		GameObject lineRenderer = collision.gameObject.transform.parent.gameObject;
		Destroy(collision.gameObject);
	}
}
