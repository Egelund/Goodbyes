using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOverLifetime : MonoBehaviour {

	public float lifetime;
	private float birthtime;
	private SpriteRenderer spriteRenderer;
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		birthtime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		Color tmp = spriteRenderer.color;
		tmp.a -= Time.deltaTime/lifetime;
		spriteRenderer.color = tmp;

		//Chau baby!
		if (Time.time > birthtime+lifetime)
			Destroy(gameObject);
	}
}
