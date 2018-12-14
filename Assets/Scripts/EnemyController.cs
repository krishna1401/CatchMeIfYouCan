using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour {

	private Rigidbody2D rigidBody;
	public UserController user;
	public float speed = 5f;
	private float horizontal_movement;
	private float vertical_movement;
	private Animator enemyAnimator;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();		
		user = FindObjectOfType<UserController>();
		enemyAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Movement(){
		
		horizontal_movement = (float)Math.Tanh(user.transform.position.x - rigidBody.transform.position.x);
		vertical_movement = (float)Math.Tanh(user.transform.position.y - rigidBody.transform.position.y);

		if(horizontal_movement < 0f){
			rigidBody.velocity = new Vector2(horizontal_movement*speed,rigidBody.velocity.y);
			transform.localScale = new Vector2(1.25f,1.25f);
		}else if(horizontal_movement > 0f){
			rigidBody.velocity = new Vector2(horizontal_movement*speed,rigidBody.velocity.y);
			transform.localScale = new Vector2(-1.25f,1.25f);
		}else{
			rigidBody.velocity = new Vector2(0,rigidBody.velocity.y);
		}

		if(vertical_movement > 0f){
			rigidBody.velocity = new Vector2(rigidBody.velocity.x,vertical_movement*speed);
		}else if(vertical_movement < 0f){
			rigidBody.velocity = new Vector2(rigidBody.velocity.x,vertical_movement*speed);
		}else{
			rigidBody.velocity = new Vector2(rigidBody.velocity.x,0);
		}
		if(Math.Abs(rigidBody.velocity.x) > 0.1){
			enemyAnimator.SetFloat("Speed",Math.Abs(rigidBody.velocity.x));
		}else {
			enemyAnimator.SetFloat("Speed",Math.Abs(rigidBody.velocity.y));
		}
		Debug.Log(horizontal_movement + "|"+ vertical_movement);
	}

	public void Play(){
		InvokeRepeating("Movement",0f,0.01f);
	}

	public void Reset(){
		horizontal_movement = 0;
		vertical_movement = 0;
		try{
			enemyAnimator.SetFloat("Speed",0f);
		}catch(Exception e){
			Debug.Log(e);
		}
	}
}