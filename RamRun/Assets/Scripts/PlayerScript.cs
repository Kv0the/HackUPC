using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float jumpForce;
    public Camera cam;

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

        if (transform.position.x < 0) rb.AddForce(new Vector3(-transform.position.x/10, 0, 0), ForceMode.Acceleration);
        cam.transform.position = new Vector3(0f,10f,transform.position.z + 2.7f);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            canJump = true;
        }
    }
    void OnCollisionExit(Collision collision) {
		if (collision.collider.tag == "Obstacle" && collision.contacts.Length > 0) {
			Vector3 contactPoint = collision.contacts[0].point;

			if (contactPoint.z >= collision.collider.bounds.max.z &&
				contactPoint.z <= selfcollider.bounds.min.z) canJump = true;
			//else gameOver
		} 
	}

	void OnTriggerExit(Collider other) {
		GameManager.score += 1;
	}
		
}
