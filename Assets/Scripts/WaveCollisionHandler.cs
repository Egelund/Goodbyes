using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollisionHandler : MonoBehaviour
{

	List<GameObject> augmentedWaves = new List<GameObject>();

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject != null)
		{
			if (other.transform.parent == null)
			{
				return;
			}
		}

		//Debug.Log("Trigger Entered Handler");

		if (other.transform.parent.gameObject.tag == "Wave")
		{
			Wave otherWave = other.transform.parent.gameObject.GetComponent<Wave>();
			Wave thisWave = transform.parent.GetComponent<Wave>();
			if (augmentedWaves.Contains(other.gameObject))
			{
				return;
			}

			if (thisWave.burstID == otherWave.burstID)
			{
				//Debug.Log("FIXED");
				return;
			}

			augmentedWaves.Add(other.gameObject);
			thisWave.OnWaveCollision(otherWave);
		}
	}
}
