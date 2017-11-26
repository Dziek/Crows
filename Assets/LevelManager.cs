using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	
	public int startingLevel; // for testing yo
	
	public GameObject[] levelQueue;
	
	private GameObject levelGO;
	private int currentLevelNum;
	
	private int currentChunkNum;
	
	private List<GameObject> levelChunk;
	
	void Awake () {
		// NextLevel();
		
		levelChunk = new List<GameObject>();
		
		for (int i = 0; i < transform.childCount; i++)
		{
			levelChunk.Add(transform.GetChild(i).gameObject);
			levelChunk[i].SetActive(false);
		}
		
		levelChunk[startingLevel].SetActive(true);
		currentChunkNum = startingLevel;
	}
	
	void Start () {
		// for (int i = 1; i < levelChunk.Count; i++)
		// {
			// levelChunk[i].SetActive(false);
		// }
	}
	
	// void LevelEnd (Vector2 nextCameraPos) {
		
		// Camera.main.transform.position = (Vector3)nextCameraPos + Vector3.forward * -10;
		// Debug.Log("Moved Camera!");
		
		// // if (currentLevelNum < levelQueue.Length)
		// // {
			// // // NextLevel();
			// // MoveCamera(nextLevel);
		// // }else{
			// // NextScene();
		// // }
	// }
	
	void LevelEnd (Vector2 endPos) {
		
		int closestID = 0;
		float closestDistance = 10000000;
		
		for (int i = 0; i < levelChunk.Count; i++)
		{
			float distance = Vector2.Distance(endPos, levelChunk[i].transform.position);
			
			if (distance < closestDistance && levelChunk[i] != levelChunk[currentChunkNum])
			{
				closestDistance = distance;
				closestID = i;
			}
			
		}
		
		Debug.Log("Loading " + levelChunk[closestID].name);
		
		levelChunk[closestID].SetActive(true);
		Camera.main.transform.position = levelChunk[closestID].transform.position + Vector3.forward * -10;
		
		levelChunk[currentChunkNum].SetActive(false);
		currentChunkNum = closestID;
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
	
	
	public void AddChunk (GameObject chunk) {
		levelChunk.Add(chunk);
	}
	
	
	
	void OnEnable () {
		Messenger<Vector2>.AddListener("LevelEnd", LevelEnd);
	}
	
	void OnDisable () {
		Messenger<Vector2>.RemoveListener("LevelEnd", LevelEnd);
	}
}
