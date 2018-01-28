using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTrigger : MonoBehaviour
{
	public GameObject wavePrefab;
	private AudioSource audioSource;

	[HideInInspector]
	public List<GameObject> retriggeredWaves;

	public Transform CircleRetriggerer;

	public float angleToRotate;

	public bool rotatableByUser;

	public bool rotateOnItOwn;

	private int lastIDTook;

	private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{		
		if(retriggeredWaves.Contains(collision.gameObject))
		{
			//Debug.Log("Non called trigger");
			return;
		}

		if (collision.gameObject != null)
		{
			if(collision.gameObject.transform.parent != null)
			{
				if (collision.gameObject.transform.parent.gameObject != null)
				{
					if (collision.gameObject.transform.parent.gameObject != null && retriggeredWaves.Contains(collision.gameObject.transform.parent.gameObject))
					{
						//Debug.Log("Non called trigger");

						return;
					}
				}
			}
		}



		if (collision.tag == "Wave")
		{
			//Debug.Log("TriggerEnter2D");
			retriggeredWaves.Add(collision.gameObject.transform.parent.gameObject);

			Wave waveToDestroy = collision.gameObject.transform.parent.GetComponent<Wave>();
			lastIDTook = waveToDestroy.burstID;

			waveToDestroy.DestroyWave(this);

			RedirectWave();
		}
		else
		{
			//Debug.Log(collision.tag);
			//Debug.Log("didnt set tag properly");
		}
	}

	public void Rotate(int direction)
	{
		if (!rotatableByUser)
			return;
		Vector3 newEuler = CircleRetriggerer.eulerAngles;

		if (direction == 0)
		{
			newEuler.z += angleToRotate;
		}
		else
		{
			newEuler.z -= angleToRotate;
		}

		CircleRetriggerer.eulerAngles = newEuler;
		audioSource.PlayOneShot(audioSource.clip);

	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(retriggeredWaves.Contains(collision.gameObject))
		{
			retriggeredWaves.Remove(collision.gameObject);
		}
	}
	GameObject Temp;
	private void RedirectWave()
	{
		//		if(GameManagement.instance.spawnedWaves.Count > 0)
		//		{ 
		//}
		//		while(!GameManagement.instance.spawnedWaves.Contains(Temp))
		//		{
		//			Temp = WavePool.instance.GetWave();
		//		}

		GameObject Temp = Instantiate<GameObject>(wavePrefab);
		Temp.GetComponent<Wave>().ResetWavePosition();

		Temp.transform.position = transform.position;
		Temp.transform.rotation = CircleRetriggerer.rotation;

		Temp.GetComponent<Wave>().burstID = lastIDTook;

		GameManagement.instance.RegisterWave(Temp);

		if(!retriggeredWaves.Contains(Temp))
		{
			retriggeredWaves.Add(Temp);
		}

		WaveShooter[] points = Temp.transform.GetComponentsInChildren<WaveShooter>();
		for (int k = 0; k < points.Length; k++)
		{
			points[k].Shoot(CircleRetriggerer.rotation);
		}
	}
}
