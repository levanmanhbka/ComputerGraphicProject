using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * By TrangNTH
*/

public class PlayerAttack : MonoBehaviour {
	public float attackdelay = 0.3f;
	public bool attacking = false;
	public Animator anim;
	public Collider2D trigger;

	//su dung ham Awke tuong tu nhu start nhung no van chay khi PlayerAttack enable
	private void Awake(){
		//chuyen hoat anh nho bien attking moi tao troa animator
		anim = gameObject.GetComponent<Animator> ();
		trigger.enabled = false;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//kiem tra nguoi choi dang nhan nut gi
		//cho phet tan cong khi nguoi choi dang chua tan cong va nhan nut Z
		if (Input.GetKeyDown (KeyCode.Z) && !attacking) {
			attacking = true;
			trigger.enabled = true;
			attackdelay = 0.3f;

		}
			
		//ham delay tan cong, khong cho nguoi choi tan cong qua nhanh

		if(attacking)
		{
			if (attackdelay > 0) {
				attackdelay -= Time.deltaTime;
			} 
			else {
				attacking = false;
				trigger.enabled = false;
			}
		}
		//set su thay doi ha=inh anh
		anim.SetBool("Attacking",attacking);
	}
}
