using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	
	//thoi gian song cua vien dan bay ra
	public float liftTime = 2;

	// Use this for initialization
	void Start () {
		//player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		
	}

	private void OnTriggerEnter2D (Collider2D col){
		if (col.isTrigger != true) {
			if(col.CompareTag("Player")){
				col.SendMessageUpwards("Damage",1);
			}

			Destroy(gameObject);
		}
				
	}
	
	// Update is called once per frame
	void Update () {

		liftTime -= Time.deltaTime;
		if (liftTime <= 0) {
			Destroy (gameObject);
		}
		
	}
}
