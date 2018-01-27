using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShooter : MonoBehaviour {

	[HideInInspector]
	public Rigidbody2D wavePrefab;

	public Vector2 ForceOnShoot;
	// Use this for initialization
	void Start () {
		wavePrefab = GetComponent<Rigidbody2D>();
		//wavePrefab.AddForce(Vector2.right * 1000f);
		//wavePrefab.Add
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			wavePrefab.AddForce(ForceOnShoot	);
			Debug.Log("Shooted");
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("CollisionEnter");
	}
}
