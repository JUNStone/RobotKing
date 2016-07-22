using UnityEngine;
using System.Collections;

public class MainSceneScript : MonoBehaviour {

	// Use this for initialization
	GameObject popup;

	void Awake() {
		popup = GameObject.Find ("Howto Popup");
		popup.SetActive (false);
	}

	public void Btn_Start() {
		// Application.LoadLevel("StartScene");
		// move to start scene
	}

	public void Btn_Help() {
		popup.SetActive (true);
	}

	public void Btn_DismissHelp() {
		popup.SetActive (false);
	}
}
