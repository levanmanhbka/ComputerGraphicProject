using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * by TrangNTH
 * kiem tra nguoi choi dung o dau? ben trai hay phai
 * tan cong
*/

public class AttackCone : MonoBehaviour {
	
	public TurretAI turret;
	public bool isLeft=false;


	private void Awake(){
		turret = gameObject.GetComponent<TurretAI> ();
	}
	
	private void OnTriggerStay2D(Collider2D collider){

		//kiem tra tag co dung la nguoi choi k
		if(collider.CompareTag("Player"))
			{
			if(isLeft)
			{
				turret.Attack(false);

			}

			else{
				turret.Attack(true);

			}
			}
		}
		

}
