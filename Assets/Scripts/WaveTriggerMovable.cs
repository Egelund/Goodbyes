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

	public bool shouldItFlip;

	public SpriteRenderer spriteRenderer;

	private void Start()
	{
		if (!shouldItMove)
		{
			return;
		}

		currentWaypoint = waypointA;

		
	}

	public virtual void Update()
	{
		if(!shouldItMove)
		{
			return;
		}

		MoveToWaypoint();
	}

	public virtual void SetNewDirection(Waypoint waypoint)
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

		if(shouldItFlip)
		{
			spriteRenderer.flipX = !spriteRenderer.flipX;
			Debug.Log("Flip");
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
