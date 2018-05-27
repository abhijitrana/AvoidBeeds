using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	public GameObject gameManager;



	// Use this for initialization
	void Start () {
 
		int currentScore = PlayerPrefs.GetInt ("CURRENT_SCORE",0);
		int bestScore    = PlayerPrefs.GetInt ("BEST_SCORE",0);

		scoreText.text = "Score " + currentScore;
		highScoreText.text = "Best Score " + bestScore;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onTapRetry(){
		SceneManager.LoadScene ("game");
	}
}
