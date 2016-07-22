using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour
{
	Text scoreText;
	public float score;

	void Awake ()
	{
		scoreText = GetComponent<Text> ();
		score = 0.0f;
		scoreText.text = score.ToString ();
	}

	void Update ()
	{
		if (true) { // when player anim is not die
			this.score += 1250 * Time.smoothDeltaTime;
			scoreText.text = ((int)score).ToString ();
		}
	}
}
