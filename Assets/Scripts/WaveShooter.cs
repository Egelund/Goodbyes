using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShooter : MonoBehaviour {

	[HideInInspector]
	public Rigidbody2D rigidBody;

	public GameObject wavePrefab;

	// Use this for initialization
	void Start () {
	}

	public void Shoot(Quaternion newRotation)
	{
		rigidBody = GetComponent<Rigidbody2D>();
		transform.rotation = newRotation;
		rigidBody.AddForce(transform.up * 10, ForceMode2D.Impulse);
	}
}
