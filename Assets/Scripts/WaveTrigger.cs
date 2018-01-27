using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTrigger : MonoBehaviour
{
	public GameObject wavePrefab;

	[HideInInspector]
	public List<GameObject> retriggeredWaves;

	public Transform CircleRetriggerer;

	public float angleToRotate;

	public bool rotatableByUser;

	public bool rotateOnItOwn;

	private void OnTriggerEnter2D(Collider2D collision)
	{		
		if(retriggeredWaves.Contains(collision.gameObject))
		{
			Debug.Log("Non called trigger");
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
						Debug.Log("Non called trigger");

						return;
					}
				}
			}
		}



		if (collision.tag == "Wave")
		{
			Debug.Log("TriggerEnter2D");
			WaveShooter waveShooter = collision.gameObject.GetComponent<WaveShooter>();
			Vector3 speed = waveShooter.GetComponent<Rigidbody2D>().velocity;

			retriggeredWaves.Add(collision.gameObject.transform.parent.gameObject);

			GameManagement.instance.UnregisterWave(collision.gameObject);
			collision.gameObject.transform.parent.GetComponent<Wave>().DestroyWave();
			RedirectWave(speed);
		}
		else
		{
			Debug.Log(collision.tag);
			Debug.Log("didnt set tag properly");
		}
	}

	public void Rotate()
	{
		if (!rotatableByUser)
			return;

		Vector3 newEuler = CircleRetriggerer.eulerAngles;
		newEuler.z += angleToRotate;
		CircleRetriggerer.eulerAngles = newEuler;
	}	

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(retriggeredWaves.Contains(collision.gameObject))
		{
			retriggeredWaves.Remove(collision.gameObject);
		}
	}

	private void RedirectWave(Vector3 speed)
	{
		Vector3 initialPosition = CircleRetriggerer.position;
		Vector3 eulerRotation = CircleRetriggerer.rotation.eulerAngles;


		speed.Normalize();

		GameObject Temp = GameObject.Instantiate<GameObject>(wavePrefab, initialPosition, transform.rotation);
		Temp.transform.rotation = CircleRetriggerer.rotation;
		GameManagement.instance.RegisterWave(Temp);
		retriggeredWaves.Add(Temp);
		//WaveShooter wshooter = Temp.GetComponent<WaveShooter>();
		//wshooter.Shoot(CircleRetriggerer.rotation);
		WaveShooter[] points = Temp.transform.GetComponentsInChildren<WaveShooter>();
		for (int k = 0; k < points.Length; k++)
		{
			points[k].Shoot(CircleRetriggerer.rotation);
		}

	}
}
