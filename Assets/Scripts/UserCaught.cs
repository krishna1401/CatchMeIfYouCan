using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCaught : MonoBehaviour {

	public Transform mouth;
	public Transform enemy;
	public Transform user;
	private UserController userScript;
	private EnemyController enemyScript;
	private bool collision;
	private Vector3 userPosition;
	private Vector3 enemyPosition;
	// Use this for initialization
	void Start () {
		mouth.parent = enemy;
		collision = false;
		userScript = FindObjectOfType<UserController>();
		enemyScript = FindObjectOfType<EnemyController>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = new Vector3(-0.49f,-0.03f,0f);
		if(collision){
			user.transform.localPosition = userPosition;
			enemy.transform.localPosition = enemyPosition;
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name == "User"){
			collision = true;
			userPosition = user.transform.localPosition;
			enemyPosition = enemy.transform.localPosition;
			userScript.Reset();
			userScript.Dead();
			userScript.enabled = false;
			enemyScript.Reset();
			enemyScript.enabled = false;
			Debug.Log("Caught");
		}
	}

	public void ResetCollision(){
		collision = false;
		userPosition = new Vector3(-10.50769f,5.519879f,0f);
		enemyPosition = new Vector3(10.05f,-5.83f,0f);
	}
}
