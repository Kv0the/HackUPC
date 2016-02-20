using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float jumpForce;

	private bool canJump = false;
	private Rigidbody rb = null;
	private Collider selfcollider;

	void Awake() {
		if (rb == null) {
			rb = GetComponent<Rigidbody> ();
            if (rb == null) Debug.Log("Cannot get de Rigdbody component of Player");
		}
		selfcollider = GetComponentInChildren<Collider> ();
	}

	void Update () {
		// TODO: update to touch control
		if (Input.GetAxisRaw ("Vertical") > 0 && canJump) {
			canJump = false;
            rb.AddForce(new Vector3(0, 0, jumpForce), ForceMode.Impulse);
		}
    }

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Obstacle") {
			Vector3 contactPoint = collision.contacts[0].point;

			if (contactPoint.y >= collision.collider.bounds.max.y &&
				contactPoint.y <= selfcollider.bounds.min.y) canJump = true;
			//else gameOver
		} else if (collision.collider.tag == "Floor") {
			canJump = true;
		}
	}


}
