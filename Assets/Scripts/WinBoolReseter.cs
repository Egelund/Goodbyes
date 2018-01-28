using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBoolReseter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameManagement.instance.SetWin(false);
		GameManagement.instance.SubstractWinTrigger();
		GameManagement.instance.SubstractWinTrigger();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
