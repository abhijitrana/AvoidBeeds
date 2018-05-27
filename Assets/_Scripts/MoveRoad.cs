using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoad : MonoBehaviour {

	public float speed;
	public GameObject resetPos;
	Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = gameObject.transform.position;

	}
	
	// Update is called once per frame
	void Update () {

		gameObject.transform.Translate (Vector3.up * speed * Time.deltaTime);
		if(gameObject.transform.position.y > resetPos.transform.position.y) {
			gameObject.transform.position = startPos;
		}
	}
}
