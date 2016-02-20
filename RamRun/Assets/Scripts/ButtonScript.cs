﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

	private Button but;

	void Start () {
		but = GetComponent<Button> ();
		but.onClick.AddListener (delegate {
			SceneManager.LoadScene("menu");
		});
	}

}