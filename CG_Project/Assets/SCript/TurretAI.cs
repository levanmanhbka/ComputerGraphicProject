using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * By TrangNTH
*/

public class TurretAI : MonoBehaviour {
	//tao nang luong cua tru
	public int curHealth=100;

	//khoang cach giua nguoi choi va tru
	public float distance;

	//khoang cach tru bat dau hoat dong
	public float wakeRange;

	//chu ki ban vien dan cua user
	public float bulletTimer;

	//toc do dan
	public float bulletSpeed;

	//khoang thoi gian ban dan
	public float shootInterval;

	//check tinh trang tru
	public bool awake=false;
	public bool lookingRight = false;

	//tao object de ban dan
	public GameObject bullet;

	//lay vi tri nguoi choi
	public Transform target;

	//lay bien trong animator de thay dioi hinh anh
	public Animator anim;

	//lay vi tri 2 diem ban
	public Transform shootPointL, shootPointR;

	private void Awake(){
		//lay cac bien trong animator
		anim = GetComponent<Animator> ();
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	//set vi tri trong animator
		anim.SetBool("Awake",awake);
		anim.SetBool ("LookRight", lookingRight);

		//check vi tri
		RangheCheck();

		//kiem tra trang thai
		/*
		 * neu vi tri nguoi choi > vi tri vat thi vat nhin sang phai
		 * nguoc lai nhin sang ctrai
		*/
		if (target.transform.position.x > transform.position.x) {
			lookingRight = true;
		}
		if (target.transform.position.x < transform.position.x) {
			lookingRight = false;
		}

		//neu mau cua tru it hon 0 thi tieu diet tru
		if (curHealth < 0) {
			Destroy (gameObject);
		}
		
	}

	//check khoang cach nguoi choi
	void RangheCheck(){
		distance = Vector2.Distance (transform.position,target.transform.position);
		if (distance < wakeRange) {
			awake = true;
		}

		if (distance > wakeRange) {
			awake = false;
		}


	}

	/*
		 * Ham tan cong cua tru
		 * paramater kiem tra xem tan cong ve ben tay trai hay phai
		 * public de cac scrip khac goi
		*/

	public void Attack(bool attackRight){
		bulletTimer -= Time.deltaTime;
		//neu thoi gian ban lon hon khang thoi gian mac dinh thi cho phep ban
		if (bulletTimer >= shootInterval) {
			//lay bien de xac dinh huong nguoi choi
			Vector2 director= target.transform.position -transform.position;
			director.Normalize ();

			if (attackRight) {

				//khoi tao gameojlec bulletma vi tri bat dau tu shootpointR va xoay theo huogn shootpointR

				GameObject bulletClone;
				bulletClone = Instantiate (bullet, shootPointR.transform.position,shootPointR.transform.rotation) as GameObject;

				//thay doi toc do nguoi choi
				bulletClone.GetComponent<Rigidbody2D> ().velocity = director * bulletSpeed;

				bulletTimer = 0;
				
			}

			if (!attackRight) {

				//khoi tao gameojlec bulletma vi tri bat dau tu shootpointR va xoay theo huogn shootpointR

				GameObject bulletClone;
				bulletClone = Instantiate (bullet, shootPointL.transform.position,shootPointL.transform.rotation) as GameObject;

				//thay doi toc do nguoi choi
				bulletClone.GetComponent<Rigidbody2D> ().velocity = director * bulletSpeed;

				bulletTimer = 0;

			}
		}
	}

	//ham tao mat mau va tieu diet
	public void Damage(int dmg){
		curHealth -= dmg;
		gameObject.GetComponent<Animation> ().Play ("redflash");
	}
}
