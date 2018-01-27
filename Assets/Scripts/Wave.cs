using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    LineRenderer lineRenderer;

    // Use this for initialization
    void Start()
    {

        lineRenderer = GetComponent<LineRenderer>();
        Debug.Assert(lineRenderer != null);
        Debug.Assert(transform.childCount > 0);
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount = transform.childCount;
        for (int i = 0; i < transform.childCount; i++)
        {
            lineRenderer.SetPosition(i, transform.GetChild(i).position);
        }
    }
}
