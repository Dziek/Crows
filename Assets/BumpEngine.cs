using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BumpEngine : MonoBehaviour {
	
	private string[] bumpStrings = new string[]{"Woops", "Excuse me", "Sorry about that", "Coming through!", "How rude", "Butterfingers",
				"Little to the left", "Any day now", "Give me a moment", "Watch your feet", "Oooh that one stung", "Heavens above!", "Ow", 
				"If I can just squeeze past", "Any minute now", "Need a new approach", "Nearly there", "So close", "Back of the net"};
	
	public float displayTime = 0.5f;
	public Text bumpTextBox;
	
	private RectTransform textRect;
	private bool displaying;
	
	void Awake () {
		bumpTextBox.enabled = false;
		textRect = bumpTextBox.GetComponent<RectTransform>();
	}
	
	void OnCollisionEnter2D (Collision2D other) {
		
		// Debug.Log(other.gameObject.name);
		
		if (displaying == false)
		{
			StartCoroutine("DisplayText");
		}
	}
	
	IEnumerator DisplayText () {
		
		displaying = true;
		bumpTextBox.enabled = true;
		
		bumpTextBox.text = bumpStrings[Random.Range(0, bumpStrings.Length)];
		textRect.anchoredPosition = new Vector2(Random.Range(-40, 40), 60);
		// bumpTextBox.transform.rotation = new Vector3(0,0,130);
		
		yield return new WaitForSeconds(displayTime);
		
		bumpTextBox.enabled = false;	
		displaying = false;
	}
}
