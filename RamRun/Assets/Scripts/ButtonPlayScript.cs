using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPlayScript : MonoBehaviour {

	private Button but;

	void Start () {
		but = GetComponent<Button> ();
		but.onClick.AddListener (delegate {
			SceneManager.LoadScene("main");
		});
	}

}