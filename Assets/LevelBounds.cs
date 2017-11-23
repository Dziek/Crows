using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBounds : MonoBehaviour {

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Player")
		{
			
			Debug.Log("Leaving " + gameObject.transform.parent.name + " at " + other.transform.position);
			
			// Messenger<Vector2>.Broadcast("LevelEnd", nextCameraPos);
			Messenger<Vector2>.Broadcast("LevelEnd", other.transform.position);
			
			// Debug
			
			// gameObject.SetActive(false);
			
			// Debug.Log("We're Going Somewhere! " + gameObject.transform.parent.name);
			// Debug.Log("We're Going Somewhere! " + other.transform.position);
			// Debug.Break();
		}
	}
}
