using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

	public Transform coin;
	public Transform board;
	private Vector3 coinPosition;
	private StartController mainScreen;
	
	// Use this for initialization
	void Start () {
		coin.parent = board;
		mainScreen = FindObjectOfType<StartController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "User"){
			mainScreen.AddScore(5);
			coinPosition = new Vector3(Random.Range(-10.50f,10.50f),Random.Range(-6.00f,6.00f),transform.position.z);
			transform.localPosition = coinPosition;
		}
	}
}
