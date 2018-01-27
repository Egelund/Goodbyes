using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
	
	
	public float radius;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawSphere(transform.position, radius);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag != "MovableWave")
		{

			return;
		}

		WaveTriggerMovable wave = collision.gameObject.GetComponent<WaveTriggerMovable>();
		if(wave.currentWaypoint == this)
		{
			wave.SetNewDirection(this);
		}
	}
}
