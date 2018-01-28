using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollisionHandler : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

private void OnTriggerEnter2D(Collider2D other) {
       if (other.transform.parent.gameObject.tag == "Wave") {
		   	Wave otherWave = other.transform.parent.gameObject.GetComponent<Wave>();
            transform.parent.GetComponent<Wave>().OnWaveCollision(otherWave);
       }
    }
}
