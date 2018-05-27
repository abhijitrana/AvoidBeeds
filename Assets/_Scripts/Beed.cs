using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Beed : MonoBehaviour {

	public GameObject gameManager;
	 
	public float rotateSpeed = 40f;
	Vector3 pos;


	// Use this for initialization
	void Start () {
		
		rotateSpeed = Random.Range (30, 120);
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log ("collided other.gameObject.tag ");

		if (other.gameObject.tag == "Player") 
		{
			Debug.Log ("boom ---");

			SceneManager.LoadScene ("gameover");
		}
	}


	// Update is called once per frame
	void Update () {
		pos = gameObject.transform.parent.gameObject.transform.position;

		transform.RotateAround (pos,Vector3.forward, rotateSpeed *Time.deltaTime);
	}
}
