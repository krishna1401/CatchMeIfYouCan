using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UserController : MonoBehaviour {

	// Use this for initialization
	private Rigidbody2D rigidBody;
	public float speed = 5f;
	public float horizontal_movement = 0f;
	public float vertical_movement = 0f;
	private Animator playerAnimator;

	
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		playerAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		horizontal_movement = Input.GetAxis("Horizontal");
		vertical_movement = Input.GetAxis("Vertical");
		if(horizontal_movement < 0f){
			rigidBody.velocity = new Vector2(horizontal_movement*speed,rigidBody.velocity.y);
			transform.localScale = new Vector2(-0.2651711f,0.1745926f);
		}else if(horizontal_movement > 0f){
			rigidBody.velocity = new Vector2(horizontal_movement*speed,rigidBody.velocity.y);
			transform.localScale = new Vector2(0.2651711f,0.1745926f);
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
		playerAnimator.SetFloat("Speed",Math.Abs(rigidBody.velocity.x));
	}

	public void Dead(){
		playerAnimator.SetTrigger("Death");
	}

	public void Reset(){
		try{
			playerAnimator.Play("Idle");
			playerAnimator.SetFloat("Speed",0f);
			playerAnimator.ResetTrigger("Death");
		}catch(Exception e){
			Debug.Log(e);
		}
		horizontal_movement = 0;
		vertical_movement = 0;
	}
}
