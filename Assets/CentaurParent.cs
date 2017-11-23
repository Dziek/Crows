using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentaurParent : MonoBehaviour {

	void Awake () {
		
		int childCount = transform.childCount;
		
		for (int i = 0; i < childCount; i++)
		{
			transform.GetChild(0).parent = null;
		}
		
		GameObject.Destroy(gameObject);
	}
}
