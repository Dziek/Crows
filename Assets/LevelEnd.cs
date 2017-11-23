using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {
	
	public GameObject connectedLevel; // if left black, will try to guess it;
	private Transform currentLevel;
	
	private Vector2 cameraDimensions;
	
	void Awake () {
		currentLevel = transform.parent;
		
		// cameraDimensions = new Vector2(Camera.main.transform.localScale.x / 2, Camera.main.transform.localScale.y / 2);
		cameraDimensions = new Vector2(18, 11);
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player")
		{
			Debug.Log("Level End");
			
			Vector2 nextCameraPos = Vector2.zero;
			
			if (connectedLevel != null)
			{
				// nextCameraPos = connectedLevel.transform.position + Vector3.forward * -10;
				nextCameraPos = connectedLevel.transform.position;
			}else{
				Vector2 currentCameraPos = Camera.main.transform.position;
				
				if (transform.position.x > currentLevel.position.x + cameraDimensions.x / 2)
				{
					nextCameraPos = currentCameraPos + Vector2.right * cameraDimensions.x;
				}
				
				Debug.Log("NCP " + nextCameraPos);
			}
			
			// Messenger<Vector2>.Broadcast("LevelEnd", nextCameraPos);
			Messenger<Vector2>.Broadcast("LevelEnd", transform.position);
			gameObject.SetActive(false);
		}
	}
}
