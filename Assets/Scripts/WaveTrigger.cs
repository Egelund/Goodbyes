using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTrigger : MonoBehaviour
{
	public GameObject wavePrefab;
	public BoxCollider2D myBoxCollider;

	public List<GameObject> retriggeredWaves;
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

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(retriggeredWaves.Contains(collision.gameObject))
		{
			retriggeredWaves.Remove(collision.gameObject);
		}

		Debug.Log("Collision exit");
	}

	private void RedirectWave(Vector3 speed)
	{
		Vector3 initialPosition = transform.position;
		speed.Normalize();
		Vector3 eulerRotation = transform.rotation.eulerAngles;

		GameObject Temp = GameObject.Instantiate<GameObject>(wavePrefab, initialPosition, transform.rotation);

		GameManagement.instance.RegisterWave(Temp);
		retriggeredWaves.Add(Temp);
		WaveShooter wshooter = Temp.GetComponent<WaveShooter>();
		wshooter.Shoot(transform.rotation);
	}
}
