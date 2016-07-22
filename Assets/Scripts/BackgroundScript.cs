using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {

	[SerializeField]
	GameObject[] sprites;
	[SerializeField]
	Vector3[] startPosition;

	// 임시 변수
	public float speed;
	public float imageOffsetX;

	void Awake ()
	{
		sprites = GameObject.FindGameObjectsWithTag ("Background");
		startPosition = new Vector3[sprites.Length];

		for (int i = sprites.Length-1; i >= 0; --i) {
			startPosition [i] = sprites [i].transform.localPosition;
		}
	}

	void Update ()
	{
		for (int i = sprites.Length - 1; i >= 0; --i) {
			sprites [i].transform.Translate (Vector3.left * Time.smoothDeltaTime * speed);
			if (sprites [i].transform.localPosition.x < imageOffsetX * -1) { sprites [i].transform.localPosition = new Vector3 (imageOffsetX * (sprites.Length - 1), 0.0f, 0.0f); }
		}
	}
}
