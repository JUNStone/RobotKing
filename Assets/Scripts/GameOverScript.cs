using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour
{
	[SerializeField]
	GameObject gameOverPopup;

	void Awake ()
	{
		gameOverPopup = GameObject.Find ("GameOverPopup");
	}

	public void RestartButtonClick()
	{
		Application.LoadLevel ("GameScene");
	}

	public void GoToMenuButtonClick()
	{
		Application.LoadLevel ("MainScene");
	}
}
