using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {
	//khi va cham voi ke thu luong damage=huhai=20
	public int dmg=20;
	//chi tan cong nhung thu khong phai la trigger va co tag enemy

	private void OnTriggerEnter2D(Collider col){
		if((col.isTrigger !=true && col.CompareTag("Enemy")))
			{
			col.SendMessageUpwards("Damage",dmg);
		}
	}
}
