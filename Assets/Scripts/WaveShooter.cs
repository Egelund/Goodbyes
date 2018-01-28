using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShooter : MonoBehaviour {

	[HideInInspector]
	public Rigidbody2D rigidBody;

	private void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
	}

	public void Shoot(Quaternion newRotation)
	{
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.velocity = new Vector2(0, 0);
		transform.rotation = newRotation;
		rigidBody.AddForce(transform.up * 10, ForceMode2D.Impulse);
	}
}
