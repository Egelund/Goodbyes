using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandCircle : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private LineRenderer lineRenderer;

    public GameObject spawn;

    public float size;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        size += Time.deltaTime;
        transform.localScale = new Vector3(size, size, size);
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, size);
        for (int i = 0; i < col.Length; i++)
        {
			//Instantiate(spawn,col[i].bounds.center,Quaternion.identity);
        }
    }


}
