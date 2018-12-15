using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartController : MonoBehaviour {

	public Transform board;
	public Transform user;
	public Transform enemy;
	private UserCaught caughtScript;
	private UserController userScript;
	private EnemyController enemyScript;
	private CoinController coinScript;
	public Text scoreText;
	private int score;
	// Use this for initialization
	void Start () {
		userScript = FindObjectOfType<UserController>();
		caughtScript = FindObjectOfType<UserCaught>();
		enemyScript = FindObjectOfType<EnemyController>();
		coinScript = FindObjectOfType<CoinController>();
		userScript.enabled = false;
		enemyScript.enabled = false;
		user.parent = board;
		enemy.parent = board;
		scoreText.text = "Score : 0";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Initialization(){
		caughtScript.ResetCollision();
		enemy.transform.localPosition = new Vector3(10.05f,-5.83f,0f);
		user.transform.localPosition = new Vector3(-10.5f,5.79f,0f);
		enemyScript.enabled = true;
		enemyScript.Reset();
		enemyScript.Play();
		userScript.enabled = true;
		userScript.Reset();
		coinScript.Play();
		score = 0;
		scoreText.text = "Score : 0";
	}

	public void AddScore(int value){
		score = score + value;
		scoreText.text = "Score : " + score; 
		enemyScript.IncreaseSpeed(score);
	}
}
