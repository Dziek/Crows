using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestScript : MonoBehaviour {
	
	public GameObject treeGO;
	
	private const float screenWidth = 18f;
	
	// Use this for initialization
	void Start () {
		PopulateForest();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void PopulateForest () {
		int treeAmount = 20;
		
		float treeDistanceX = screenWidth / treeAmount;
		
		for (int i = 0; i < treeAmount; i++)
		{
			GameObject tempTree = Instantiate(treeGO);
			
			float newX = -(screenWidth/2) + treeDistanceX * i;
			float newY = Random.Range(-4.5f, -3.5f);
			
			tempTree.transform.position = new Vector2(newX, newY);
		}
	}
}
