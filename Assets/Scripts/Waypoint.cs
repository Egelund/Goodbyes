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

		WaveTriggerWithPath wave = collision.gameObject.GetComponent<WaveTriggerWithPath>();
		if (wave == null)
		{
			WaveTriggerMovable movableWave = collision.gameObject.GetComponent<WaveTriggerMovable>();
			if (movableWave.currentWaypoint == this)
			{
				movableWave.SetNewDirection(this);
			}
		}
		else
		{
			if (wave.currentWaypoint == this)
			{
				wave.SetNewDirection(this);
			}
		}
	}
}
