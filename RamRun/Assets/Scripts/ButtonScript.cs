using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

	private Button but;

	void Start () {
		but = GetComponent<Button> ();
		but.onClick.AddListener (delegate {
			Debug.Log ("Fuck you mate");
		});
	}

}