using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

	public GameObject playerGO;
	// private GameObject currentPlayer;
	
	void Awake () {
		if (GameObject.Find("Player") == null)
		{
			// playerGO = Instantiate("Player");
		}
	}
}
