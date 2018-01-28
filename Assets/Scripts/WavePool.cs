using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePool : MonoBehaviour {

	public GameObject wavePrefab;

	public List<GameObject> instantiatedWaves = new List<GameObject>();

	public List<GameObject> inUseWave = new List<GameObject>();

	public static WavePool instance;

	public int WavesInitialNumber;
	GameObject instantiatedObject;

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			Destroy(this);
		}
	}

	void Start () {
		for (int i = 0; i < WavesInitialNumber; i++)
		{
			InstantiateWave();
		}
	}

	public void InstantiateWave()
	{
		instantiatedObject = Instantiate<GameObject>(wavePrefab);
		instantiatedObject.name = "Wave" + instantiatedWaves.Count;
		instantiatedObject.SetActive(false);
		instantiatedWaves.Add(instantiatedObject);
	}

	public GameObject GetWave()
	{
		//Debug.Log("ASked");

		if (instantiatedWaves.Count > 0)
		{
			instantiatedObject = instantiatedWaves[0];
			instantiatedWaves.Remove(instantiatedObject);
		}
		else
		{
			InstantiateWave();
		}

		instantiatedObject.SetActive(true);

		inUseWave.Add(instantiatedObject);

		instantiatedObject.GetComponent<FadeOverLifetime>().ResetLifeTime();
		if(instantiatedObject.GetComponent<Wave>().retriggerer!= null)
		{
			instantiatedObject.GetComponent<Wave>().retriggerer.retriggeredWaves.Remove(instantiatedObject);

		}
		return instantiatedObject;
	}

	public void ReturnWave(GameObject returnedWave)
	{
		//Debug.Log("Returned");
		GameManagement.instance.UnregisterWave(returnedWave);
		inUseWave.Remove(returnedWave);
		instantiatedWaves.Add(returnedWave);
		returnedWave.SetActive(false);
	}	
}
