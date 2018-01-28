using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTriggerMovable : WaveTrigger
{

	public Waypoint waypointA;

	public Waypoint waypointB;

	[HideInInspector]
	public Vector3 direction;

	[HideInInspector]
	public Waypoint currentWaypoint;

	public bool shouldItMove;
	// Update is called once per frame

	private void Start()
	{
		if (!shouldItMove)
		{
			return;
		}

		currentWaypoint = waypointA;
	}

	void Update()
	{
		if(!shouldItMove)
		{
			return;
		}
		MoveToWaypoint();
	}

	public void SetNewDirection(Waypoint waypoint)
	{
		if (waypointA == null || waypointB == null)
		{
			// Debug.Log("Trying to set direction with null waypont");
			return;
		}

		if (waypoint == waypointA)
		{
			currentWaypoint = waypointB;
			// Debug.Log("New DirectionB");

		}
		else
		{
			currentWaypoint = waypointA;

		}
	}

	public float speed;

	public void MoveToWaypoint()
	{
		direction = currentWaypoint.transform.position - transform.position;
		direction.Normalize();

		Vector3 newPosition = transform.position;
		newPosition += speed * Time.deltaTime * direction;
		//transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime / 1.f);
		transform.position = newPosition;
	}
}
