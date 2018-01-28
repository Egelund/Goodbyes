using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour {

	public static GameManagement instance;

	public List<GameObject> spawnedWaves = new List<GameObject>();

	WaveTrigger[] waveTriggers;

	private bool win;

	private int waveID;

	public int WinTriggersNeeded;

	private int currentWinTriggers;

	public int GetCurrentWinTriggers()
	{
		return currentWinTriggers;
	}

	public void AddWinTrigger()
	{
		currentWinTriggers++;
		Debug.Log("added" + currentWinTriggers);
		if(currentWinTriggers == WinTriggersNeeded)
		{
			SetWin(true);
		}
	}

	public void SubstractWinTrigger()
	{
		currentWinTriggers--;
		if(currentWinTriggers < 0)
		{
			currentWinTriggers = 0;
		}
		Debug.Log("substracted" + currentWinTriggers);

	}

	public void SetWinTriggersNeeded()
	{
		WinTriggersNeeded = FindObjectsOfType<GoalTrigger>().Length;
		currentWinTriggers = 0;
	}

	public int GetNewID()
	{
		waveID++;
		return waveID;
	}

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this);
		}
	}

	public void RegisterWave(GameObject newWave)
	{
		if(!spawnedWaves.Contains(newWave))
		{
			spawnedWaves.Add(newWave);
		}
	}

	public void UnregisterWave(GameObject oldWave)
	{
		if (spawnedWaves.Contains(oldWave))
		{
			spawnedWaves.Remove(oldWave);
		}
		else
		{
			Debug.Log("here is the problem");
		}
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		SetWinTriggersNeeded();
	}

	public bool GetWin()
	{
		return win;
	}

	public void ControlTriggers(int direction)
	{
		Debug.Log("Control Triggers");
		Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

		if (hit)
		{
			WaveTrigger triggerSelected = hit.collider.gameObject.GetComponent<WaveTrigger>();
			if(triggerSelected != null)
			{
				triggerSelected.Rotate(direction);
			}
		}
	}

	public void FindTriggers()
	{
		for (int i = 0; i < waveTriggers.Length; i++)
		{
			waveTriggers[i] = null;
		}

		waveTriggers = FindObjectsOfType<WaveTrigger>();
	}

	public void SetWin(bool value)
	{
		win = value;
		for (int i = 0; i < spawnedWaves.Count; i++)
		{
			if(spawnedWaves[i] != null)
			{
				Destroy(spawnedWaves[i]);
			}
		}

		spawnedWaves.Clear();
	}
	
	// Update is called once per frame
	void Update () {
		if(win)
		{
			Debug.Log("Win");
		}

		if(win && currentWinTriggers == 0)
		{
			win = false;
		}

		if(Input.GetMouseButtonDown(0))
		{
			ControlTriggers(0);
		}

		if (Input.GetMouseButtonDown(1))
		{
			ControlTriggers(1);
		}
	}
}
