using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentaurControl : MonoBehaviour {
	
	public float horizontalForce = 15;
	public float verticalForce = 5;
	
	private Rigidbody2D rb2D;
	
	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Horizontal") != 0)
		{
			rb2D.AddForce(Vector2.right * Input.GetAxisRaw("Horizontal") * horizontalForce);
		}
		
		if (Input.GetAxisRaw("Vertical") > 0)
		{
			rb2D.AddForce(Vector2.up * Input.GetAxisRaw("Vertical") * verticalForce);
		}
	}
}
