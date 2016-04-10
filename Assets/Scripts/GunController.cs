using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

	private Animator gunAnim;
	public GameObject shooter; //"attach" to shooter transform
	public GameObject scope;
	public GameObject bullet;
	public float fireRate;
	private float nextFire;

	// Use this for initialization
	void Start () {
		//shooterTrans = shooter.GetComponent<Transform>();
		gunAnim = gameObject.GetComponent<Animator>();
		nextFire = Time.time;
	}


	void FixedUpdate() {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		scope.transform.position = mousePos + new Vector3(0, 0, 1);
		if (transform.parent.localScale.x < 0) {
			scope.transform.position = new Vector3(-scope.transform.position.x, scope.transform.position.y, scope.transform.position.z);
		}
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
	}


	// Update is called once per frame
	void Update () {
		//transform.position = shooterTrans.position + new Vector3(0, -.75f, 0);
		if(Input.GetMouseButtonDown(0) && Time.time >= nextFire) {
			nextFire = Time.time + fireRate;
			gunAnim.SetTrigger("Shoot");
			Shoot();
		}
	}

	void Shoot() {

		GameObject projectile = Instantiate(bullet, transform.GetChild(0).position, transform.rotation) as GameObject;
		BulletController bc = projectile.GetComponent<BulletController>();
		bc.target = scope;
	}
}
