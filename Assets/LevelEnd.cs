using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {
	
	public GameObject connectedLevel; // if left black, will try to guess it;
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player")
		{
			Debug.Log("Level End");
			Messenger.Broadcast("LevelEnd");
		}
	}
}
