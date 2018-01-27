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
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ShootWave();
		}
	}

	private void ShootWave()
	{
		if(GameManagement.instance.GetWin())
		{
			return;
		}

		Vector3 initialPosition = transform.position;
		for (int i = 0; i < burstNumber; i++)
		{
			initialPosition += transform.forward * distance;
			GameObject Temp = GameObject.Instantiate<GameObject>(wavePrefab, initialPosition, transform.rotation);
			WaveShooter wshooter = Temp.GetComponent<WaveShooter>();
			wshooter.Shoot(transform.rotation);
			GameManagement.instance.RegisterWave(Temp);
		}
	}
}
