using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float jumpForce;

	private bool canJump = false;
	private Rigidbody2D rb = null;
	private Collider2D selfcollider;

	void Awake() {
		if (rb == null) {
			rb = GetComponent<Rigidbody2D> ();
		}
		selfcollider = GetComponent<Collider2D> ();
	}

	void Update () {
		// TODO: update to touch control
		if (Input.GetAxisRaw ("Vertical") > 0 && canJump) {
			canJump = false;
			rb.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.collider.tag == "Obstacle") {
			Vector3 contactPoint = collision.contacts[0].point;

			if (contactPoint.y >= collision.collider.bounds.max.y &&
				contactPoint.y <= selfcollider.bounds.min.y) canJump = true;
			//else gameOver
		}
		if (collision.collider.tag == "Floor") {
			canJump = true;
		}
	}


}
