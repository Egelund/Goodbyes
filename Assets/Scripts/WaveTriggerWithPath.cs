using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTriggerWithPath : WaveTriggerMovable {

	public Waypoint[] path;
	int currentIndex;

	private void Start()
	{
		currentIndex = 0;
		SetNewDirection(path[0]);
	}

	public override void SetNewDirection(Waypoint waypoint)
	{
		//base.SetNewDirection(waypoint);
		if(currentWaypoint == path[path.Length-1])
		{
			currentIndex = 0;
		}
		else
		{
			currentIndex++;
		}

		currentWaypoint = path[currentIndex];
	}

	// Update is called once per frame
	public override void Update () {
		MoveToWaypoint();
	}
}
