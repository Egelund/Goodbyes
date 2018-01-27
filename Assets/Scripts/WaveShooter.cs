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

	Vector3 savedVelocity;
	Vector3 savedAngularVelocity;

	void OnPauseGame()
	{
		//savedVelocity = rigidBody.velocity;
		//savedAngularVelocity = rigidBody.angularVelocity;
	}

	void OnResumeGame()
	{
		//rigidBody.AddForce(savedVelocity, ForceMode.VelocityChange);
		//rigidBody.AddTorque(savedAngularVelocity, ForceMode2D.Impulse);
	}

	public void Shoot(Quaternion newRotation)
	{
		rigidBody = GetComponent<Rigidbody2D>();
		transform.rotation = newRotation;
		rigidBody.AddForce(transform.up * 10, ForceMode2D.Impulse);
	}
}
