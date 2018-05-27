using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroller : MonoBehaviour {
	public float speed =4f;

	Vector3 startPos;

	// Use this for initialization
	void Start () {
		
		startPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (Vector3.up * speed * Time.deltaTime);
		if(gameObject.transform.position.y > 23.8374f) {
			gameObject.transform.position = startPos;
		}
	}
}
