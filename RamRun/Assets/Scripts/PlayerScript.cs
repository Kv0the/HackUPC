using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float jumpForce;
    public Camera cam;
	public AudioSource playerJump;

	private bool canJump = false;
	private Rigidbody rb = null;
    private Collider selfcollider;
	private Collider previous = null;

	void Awake() {
		if (rb == null) {
			rb = GetComponent<Rigidbody> ();
            if (rb == null) Debug.Log("Cannot get de Rigdbody component of Player");
		}
		selfcollider = GetComponentInChildren<Collider> ();
	}

	void Start() {
		GameManager.score = 0;
	}

	void Update () {
		// TODO: update to touch control
		if (Input.GetAxisRaw ("Vertical") > 0 && canJump) {
			canJump = false;
			playerJump.Play ();
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
		else if (collision.collider.bounds.max.z == selfcollider.bounds.min.z) {
			canJump = true;
		}
	}


	void OnTriggerExit(Collider other) {
		if (previous != other) {
			GameManager.score += 1;
			previous = other;
		}
	}
		
}
