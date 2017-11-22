using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	
	public GameObject[] levelQueue;
	
	private GameObject levelGO;
	private int currentLevelNum;
	
	void Awake () {
		// NextLevel();
	}
	
	void LevelEnd (Vector2 nextCameraPos) {
		
		Camera.main.transform.position = (Vector3)nextCameraPos + Vector3.forward * -10;
		Debug.Log("Moved Camera!");
		
		// if (currentLevelNum < levelQueue.Length)
		// {
			// // NextLevel();
			// MoveCamera(nextLevel);
		// }else{
			// NextScene();
		// }
	}
	
	void MoveCamera (GameObject nextLevel) {
		
		// Camera.main.transform.Translate(Vector3.right * 18);
		
		Vector3 nextCameraPos = Vector3.zero;
		
		if (nextLevel != null)
		{
			// nextLevel.transform.position + Vector3.forward * -10;
		}else{
			
		}
		
		Camera.main.transform.position = nextCameraPos;
		Debug.Log("Moved Camera!");
		
		currentLevelNum++;
	}
	
	public void NextLevel () {
		// if (levelGO != null)
		// {
			// levelGO = null;
		// }
		
		levelGO = Instantiate(levelQueue[currentLevelNum]);
		
		currentLevelNum++;
	}
	
	void NextScene () {
		Debug.Log("Next Scene Time!");
	}
	
	
	
	
	
	
	void OnEnable () {
		Messenger<Vector2>.AddListener("LevelEnd", LevelEnd);
	}
	
	void OnDisable () {
		Messenger<Vector2>.RemoveListener("LevelEnd", LevelEnd);
	}
}
