using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{

    private int enhancedCount = 0;
    private int lastEnhancerID;
    LineRenderer lineRenderer;

	public int burstID;

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

    public void DestroyWave()
    {
        Destroy(this.gameObject);
    }

    public void OnWaveCollision(Wave other){
        addLifetime(other.getLifeTime(),other.GetInstanceID());
    }

    void addLifetime(float time, int sourceID)
    {
        if (sourceID != lastEnhancerID)
        {
            GetComponent<FadeOverLifetime>().lifetime += time;
            lastEnhancerID = sourceID;
            enhancedCount++;
        }
    }

    float getLifeTime()
    {
        return GetComponent<FadeOverLifetime>().lifetime;
    }
}
