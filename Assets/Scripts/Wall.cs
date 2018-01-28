using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Wave wave = collision.gameObject.transform.parent.gameObject.GetComponent<Wave>();
		if(wave != null)
		{
			wave.DestroyWave();
		}
		else
		{
			Debug.Log("wave is null");
		}
	}
}
