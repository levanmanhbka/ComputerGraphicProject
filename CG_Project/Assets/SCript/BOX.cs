using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX : MonoBehaviour {
	//dat mau cho box
	public int Health=100;

	// Update is called once per frame
	void Update () {
		if (Health <= 0) {
			Destroy (gameObject);
		}
		
	}

	// moi lan bi tan cong box se bi mau 1 luong mau dmg=20;
	void Damage(int dmg){
		Health -= dmg;
	}
}
