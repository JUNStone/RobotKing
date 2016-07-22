using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour
{
	[SerializeField]
	GameObject pausePopup;
	GameObject pauseButton;

	void Awake()
	{
		pausePopup = GameObject.Find ("PausePopup");
		pausePopup.SetActive (false);

		pauseButton = GameObject.Find ("PauseButton");
	}

	public void PauseButtonClick()
	{
		pausePopup.SetActive (true);
		pauseButton.SetActive (false);
		Time.timeScale = 0.0f;
	}

	public void ResumeButtonClick()
	{
		pausePopup.SetActive (false);
		pauseButton.SetActive (true);
		Time.timeScale = 1.0f;
	}

	public void MenuButtonClick()
	{
	}
}
