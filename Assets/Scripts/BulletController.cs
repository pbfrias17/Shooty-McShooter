using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float speed;
	public float damage;
	public GameObject target;

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
		//transform.Translate(target * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag != "Player")
			Destroy(gameObject);
	}
}
