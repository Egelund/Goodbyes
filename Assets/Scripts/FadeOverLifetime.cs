using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOverLifetime : MonoBehaviour {

	public float lifetime;
	private float birthtime;
	//private SpriteRenderer spriteRenderer;
	private LineRenderer lineRenderer;
	void Start () {
		//spriteRenderer = GetComponent<SpriteRenderer>();
		lineRenderer = GetComponent<LineRenderer>();
		birthtime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		// Color tmp = spriteRenderer.color;
		// tmp.a -= Time.deltaTime/lifetime;
		// spriteRenderer.color = tmp;

		Color tmp = lineRenderer.endColor;
		tmp.a -= Time.deltaTime/lifetime;
		lineRenderer.endColor = tmp;

		tmp = lineRenderer.startColor;
		tmp.a -= Time.deltaTime/lifetime;
		lineRenderer.startColor = tmp;

		//Chau baby!
		if (Time.time > birthtime+lifetime)
			Destroy(gameObject);
	}
}
