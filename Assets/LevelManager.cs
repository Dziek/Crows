using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	
	public GameObject[] levelQueue;
	
	private GameObject levelGO;
	private int currentLevelNum;
	
	void Awake () {
		NextLevel();
	}
	
	void LevelEnd () {
		if (currentLevelNum < levelQueue.Length)
		{
			// NextLevel();
			MoveCamera();
		}else{
			NextScene();
		}
	}
	
	void MoveCamera () {
		
		// Camera.main.transform.Translate(Vector3.right * 18);
		Camera.main.transform.position = levelQueue[currentLevelNum].transform.position + Vector3.forward * -10;
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
		Messenger.AddListener("LevelEnd", LevelEnd);
	}
	
	void OnDisable () {
		Messenger.RemoveListener("LevelEnd", LevelEnd);
	}
}
