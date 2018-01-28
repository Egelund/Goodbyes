using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField]
    public GameObject wavePrefab;
    private AudioSource audioSource;

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

    private int currentID;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
            if (GameManagement.instance.spawnedWaves.Count >= 4 * burstNumber)
            {
                return;
            }

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
                currentID = GameManagement.instance.GetNewID();
            }
        }
    }

    private void ShootWave()
    {

        if (GameManagement.instance.GetWin())
        {
            return;
        }
        audioSource.PlayOneShot(audioSource.clip);
        shootingWave = true;

        Vector3 initialPosition = transform.position;
        initialPosition += transform.forward * distance;

        //GameObject Temp = WavePool.instance.GetWave();
        GameObject Temp = Instantiate<GameObject>(wavePrefab);
        Temp.transform.position = initialPosition;
        Temp.transform.rotation = transform.rotation;

        Temp.GetComponent<Wave>().ResetWavePosition();
        Temp.GetComponent<Wave>().burstID = currentID;

        WaveShooter[] points = Temp.transform.GetComponentsInChildren<WaveShooter>();
        for (int k = 0; k < points.Length; k++)
        {
            points[k].Shoot(transform.rotation);
        }
        GameManagement.instance.RegisterWave(Temp);

    }
}
