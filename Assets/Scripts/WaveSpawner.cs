using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

	[SerializeField]
	public GameObject wavePrefab;

	public List<Wave> spawnedWaves = new List<Wave>();
	public Dictionary<int, WaveShooter[]> wavePoints = new Dictionary<int, WaveShooter[]>();
	public float distance;
	public int burstNumber;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ShootWave();
		}

		//Debug.Log("Transform forward" + transform.forward);
	}

	private void ShootWave()
	{
		Vector3 initialPosition = transform.position;
		//Debug.Log("InitialPosition : " + initialPosition.ToString());
		for (int i = 0; i < burstNumber; i++)
		{
			initialPosition += transform.forward * distance;
			GameObject Temp = GameObject.Instantiate<GameObject>(wavePrefab, initialPosition, transform.rotation);
			WaveShooter wshooter = Temp.GetComponent<WaveShooter>();
			wshooter.Shoot(transform.rotation);
			//spawnedWaves.Add(Temp.GetComponent<Wave>());
			//WaveShooter[] points = Temp.GetComponentsInChildren<WaveShooter>();
			//wavePoints.Add(spawnedWaves.Count - 1, points);
			//for (int k = 0; k < points.Length; k++)
			//{
			//	//Debug.Log("Shoot");
			//	points[k].Shoot();
			//}
		}

	}
}
