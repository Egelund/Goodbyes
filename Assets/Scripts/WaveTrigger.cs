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

		if (collision.tag == "Wave")
		{
			Debug.Log("TriggerEnter2D");
			WaveShooter waveShooter = collision.gameObject.GetComponent<WaveShooter>();
			Vector3 speed = waveShooter.GetComponent<Rigidbody2D>().velocity;
			GameManagement.instance.UnregisterWave(collision.gameObject);
			Destroy(collision.gameObject);	
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

		//Debug.Log("Collision exit");
	}

	private void RedirectWave(Vector3 speed)
	{
		Vector3 initialPosition = CircleRetriggerer.position;
		Vector3 eulerRotation = CircleRetriggerer.rotation.eulerAngles;


		speed.Normalize();

		GameObject Temp = GameObject.Instantiate<GameObject>(wavePrefab, initialPosition, transform.rotation);

		GameManagement.instance.RegisterWave(Temp);
		retriggeredWaves.Add(Temp);
		WaveShooter wshooter = Temp.GetComponent<WaveShooter>();
		wshooter.Shoot(CircleRetriggerer.rotation);
	}
}
