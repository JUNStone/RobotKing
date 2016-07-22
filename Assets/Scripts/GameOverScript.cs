using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	GameObject gameOverPopup;

	void Awake () {
		gameOverPopup = GameObject.Find ("GameOverPopup");
		gameOverPopup.SetActive (false);
	}

	public void RestartButtonClick() {
		Debug.Log ("Restart");
		Application.LoadLevel (0);
	}

	public void GoToMenuButtonClick() {
	}
}
