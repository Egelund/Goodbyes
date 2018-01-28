using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{

    private AudioSource audioSource;
    private int enhancedCount = 0;
    private int lastEnhancerID;
    LineRenderer lineRenderer;

	public int burstID;

	public WaveTrigger retriggerer;

	public List<Vector3> deltaPositions = new List<Vector3>();
	public Transform[] childPositions;
	// Use this for initialization
	void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lineRenderer = GetComponent<LineRenderer>();
        Debug.Assert(lineRenderer != null);
        Debug.Assert(transform.childCount > 0);

		childPositions = gameObject.GetComponentsInChildren<Transform>();
		for (int i = 0; i < childPositions.Length; i++)
		{
			deltaPositions.Add(childPositions[i].position);
		}
	}

	public void ResetWavePosition()
	{
		//for (int i = 0; i < childPositions.Length; i++)
		//{
		//	if (childPositions[i] != null)
		//	{
		//		childPositions[i].position = new Vector3(childPositions[i].position.x + deltaPositions[i].x, 
		//													childPositions[i].position.y + deltaPositions[i].y);
		//	}
		//}
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

    public void DestroyWave(WaveTrigger trigger = null)
    {
		if(trigger != null)
		{
			if(retriggerer != null)
			{
				retriggerer.retriggeredWaves.Remove(this.gameObject);
			}
			retriggerer = trigger;
		}

		GameManagement.instance.UnregisterWave(this.gameObject);
		Destroy(this.gameObject);

		//WavePool.instance.ReturnWave(this.gameObject);
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
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    float getLifeTime()
    {
        return GetComponent<FadeOverLifetime>().lifetime;
    }

	private void OnDisable()
	{
		transform.rotation = Quaternion.Euler(Vector3.zero);
		for (int i = 0; i < childPositions.Length; i++)
		{
			childPositions[i].position = deltaPositions[i];
		}
	}
}
