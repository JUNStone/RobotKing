using UnityEngine;
using System.Collections;

public class MainSceneScript : MonoBehaviour
{
	//GameObject popup;

	void Awake()
	{
	//	popup.SetActive (false);
	}

	public void Btn_Start()
	{
		Time.timeScale = 2.0f;
		Application.LoadLevel("GameScene");
		// move to start scene
	}

	public void Btn_Help()
	{
	//	popup.SetActive (true);
	}

	public void Btn_DismissHelp()
	{
	//	popup.SetActive (false);
	}
}
