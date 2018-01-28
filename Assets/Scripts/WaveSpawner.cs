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
	private int currentBurstCounter;
	public float burstRate;
	private float currentBurstRate;

	public float spawnRate;
	private float currentSpawnTime;
	private bool shootingWave;
	void Update()
	{
		SpawnRateControl();
	}

	public void SpawnRateControl()
	{

		if (shootingWave)
		{
			if (currentBurstCounter >= burstNumber)
			{
				shootingWave = false;
				currentBurstCounter = 0;
				return;
			}

			currentBurstRate -= Time.deltaTime;
			if (currentBurstRate <= 0)
			{
				currentBurstRate = burstRate;
				currentBurstCounter++;
				ShootWave();
			}
		}
		else
		{
			currentSpawnTime -= Time.deltaTime;
			if (currentSpawnTime <= 0)
			{
				currentSpawnTime = spawnRate;
				shootingWave = true;
			}
		}
	}

	private void ShootWave()
	{
		if (GameManagement.instance.GetWin())
		{
			return;
		}

		shootingWave = true;

		Vector3 initialPosition = transform.position;
		//for (int i = 0; i < burstNumber; i++)
		//{
		//initialPosition += transform.forward * distance;
		//GameObject Temp = GameObject.Instantiate<GameObject>(wavePrefab, initialPosition, transform.rotation);
		//WaveShooter wshooter = Temp.GetComponent<WaveShooter>();
		//wshooter.Shoot(transform.rotation);
		//GameManagement.instance.RegisterWave(Temp);
		initialPosition += transform.forward * distance;
		GameObject Temp = GameObject.Instantiate<GameObject>(wavePrefab, initialPosition, transform.rotation);
		WaveShooter[] points = Temp.transform.GetComponentsInChildren<WaveShooter>();
		for (int k = 0; k < points.Length; k++)
		{
			points[k].Shoot(transform.rotation);
		}
		GameManagement.instance.RegisterWave(Temp);
		//}
	}
}
