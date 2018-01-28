using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOverLifetime : MonoBehaviour {

	public float lifetime;
	public float birthtime;
	//private SpriteRenderer spriteRenderer;
	private LineRenderer lineRenderer;
	Wave myWave;
	public void ResetLifeTime()
	{
		birthtime = Time.time;
		//Debug.Log("Reseted");
	}

	void Start () {
		//spriteRenderer = GetComponent<SpriteRenderer>();
		lineRenderer = GetComponent<LineRenderer>();
		birthtime = Time.time;
		myWave = GetComponent<Wave>();
	}
	
	// Update is called once per frame
	void Update () {
		// Color tmp = spriteRenderer.color;
		// tmp.a -= Time.deltaTime/lifetime;
		// spriteRenderer.color = tmp;

		Color tmp = lineRenderer.endColor;
		tmp.a = Mathf.Lerp(1,0,(Time.time-birthtime)/lifetime);
		lineRenderer.endColor = tmp;

		tmp = lineRenderer.startColor;
		tmp.a = Mathf.Lerp(1,0,(Time.time-birthtime)/lifetime);
		lineRenderer.startColor = tmp;

		//Chau baby!
		if (Time.time > birthtime + lifetime)
			myWave.DestroyWave();
	}
}
