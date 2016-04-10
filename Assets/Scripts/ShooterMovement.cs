using UnityEngine;
using System.Collections;

public class ShooterMovement : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator playerAnim;
	public float speed;
	public float jumpVel;
	private bool grounded;
	private Vector2[] groundOverlap;
	public GameObject marker;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		playerAnim = gameObject.GetComponent<Animator>();

		groundOverlap = new Vector2[2];
		faceRight(true);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		handleMovement();
	}

	void handleMovement() {
		float xComp = Input.GetAxis("Horizontal");
		if(xComp > 0) faceRight(true);
		else if(xComp < 0) faceRight(false);
		rb.velocity = new Vector2(xComp * speed, rb.velocity.y);
		playerAnim.SetFloat("xComp", Mathf.Abs(xComp));

		if (Input.GetKeyDown(KeyCode.Space)) {
			jump();
		}
		
	}

	void jump() {
		rb.velocity = new Vector2(rb.velocity.x, jumpVel);
	}

	bool isGrounded() {
		groundOverlap[0] = new Vector2(transform.position.x - 0.1f, transform.position.y - 0.15f);
		groundOverlap[1] = new Vector2(transform.position.x + 0.1f, transform.position.y - 0.2f);
		Instantiate(marker, new Vector3(groundOverlap[0].x, groundOverlap[0].y, 0), Quaternion.identity);
		Instantiate(marker, new Vector3(groundOverlap[1].x, groundOverlap[1].y, 0), Quaternion.identity);
		return Physics2D.OverlapArea(groundOverlap[0], groundOverlap[1], LayerMask.NameToLayer("Player"));
	}

	void faceRight(bool right) {
		//face player in correct direction
		//and make sure the gun changes "layers" accordingly
		if(right) {
			if (transform.localScale.x < 0) {
				transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				transform.GetChild(0).localPosition -= new Vector3(0, 0, 1);
			}
		} else {
			if (transform.localScale.x > 0) {
				transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				transform.GetChild(0).localPosition += new Vector3(0, 0, 1);
			}
		}
	}
}
