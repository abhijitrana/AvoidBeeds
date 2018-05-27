using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public float velocity =4f;
	public GameObject path;
	public GameObject beedBatch;
	public GameObject spawnPos;
	public GameObject destroyPoint;
	public GameObject player;

	public AudioSource bgMusic;
	public AudioSource sfxGameOver;

	public Text scoreText;

	bool isGameOver = false;
	public int score = 0;
	float spawnTime = 4f;


	bool isMoving = false
		;


	public List<GameObject>  allBeedBatch;

	void Awake(){
		allBeedBatch = new List<GameObject>();
	}


	// Use this for initialization
	void Start () {
		allBeedBatch.Add (beedBatch);
		InvokeRepeating ("spawnBeedBatch", spawnTime, spawnTime);
		InvokeRepeating ("increaseScore", 1f, 1f);
	}
 
	// Update is called once per frame
	void Update () {


		//Checking all beed batches to deallocate when out of frame

		for (int i = 0; i < allBeedBatch.Count; i++) {
			GameObject beeds = allBeedBatch [i];
			if (beeds.transform.position.y > destroyPoint.transform.position.y) {
				allBeedBatch.Remove (beeds);
				Destroy (beeds);
			} else { // move all batchbeeds
				beeds.GetComponent<MoveBeed>().speed = velocity;
			}
		}


		// move all batchbeeds
 
		path.GetComponent<MoveRoad> ().speed = velocity;


		// MObile Deveice Control
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began) {
				isMoving = true;
				velocity = 4f;
			}

			if (touch.phase == TouchPhase.Ended) {
				isMoving = false;
				velocity = 0f;
			}
		}


		//DesktopControl
//		if (Input.GetMouseButtonDown()) {
//			isMoving = true;
//			velocity = 4f;
//		}
//
//		if(Input.GetMouseButtonUp()){
//			isMoving = false;
//			velocity = 0f;
//		}



	}




	void increaseScore(){
		if (isMoving == true) {
			
			score++;
			scoreText.text = "" + score;

			PlayerPrefs.SetInt ("CURRENT_SCORE", score);

			int best_score = PlayerPrefs.GetInt ("BEST_SCORE",0);
 
			if (score > best_score) {
				PlayerPrefs.SetInt ("BEST_SCORE", score);
			} 
		}
	}

	void spawnBeedBatch()
	{
		if (isMoving == true) {

			int random =(int) Random.Range (1f, 5f);

			GameObject newBeedBatch = Instantiate(Resources.Load("BeedBatch_"+random)) as GameObject;
			newBeedBatch.transform.position = spawnPos.transform.position;
			allBeedBatch.Add (newBeedBatch);
		}

		Debug.Log ("allBeedBatch" + allBeedBatch.Count);
	}



}
