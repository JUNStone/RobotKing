using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackgroundScript : MonoBehaviour {

	[SerializeField]
	string tag;
	[SerializeField]
	GameObject[] sprites;
	[SerializeField]
	Vector3[] startPosition;

	[SerializeField]
	float speed;
	[SerializeField]
	float imageOffsetX;

	void Awake ()
	{
		sprites = GameObject.FindGameObjectsWithTag (tag);
		imageOffsetX = sprites [0].GetComponent<RectTransform> ().rect.width;
		startPosition = new Vector3[sprites.Length];

		for (int i = sprites.Length-1; i >= 0; --i) {
			startPosition [i] = sprites [i].transform.localPosition;
		}
	}

	void Update ()
	{
		for (int i = sprites.Length - 1; i >= 0; --i) {
			int prev = i + 1;
			if (prev == sprites.Length) { prev = 0; }

			sprites [i].transform.Translate (Vector3.left * Time.deltaTime * speed);

			if (sprites [i].transform.localPosition.x < imageOffsetX * -1) {

				float interpolation = 0.0f;

				if (sprites [prev].transform.localPosition.x > 0.0f) {
					interpolation = sprites [prev].transform.localPosition.x;
				} else {
					interpolation = sprites [prev].transform.localPosition.x * -1;
				}

				sprites [i].transform.localPosition = new Vector3 (
					imageOffsetX - interpolation,
					startPosition[i].y,
					0.0f);
			}
		}
		float dist = Mathf.Abs (sprites [0].transform.localPosition.x) + Mathf.Abs (sprites [1].transform.localPosition.x) - 1920.0f;

		if (dist > 1.0f) {
			if (sprites [0].transform.localPosition.x > sprites [1].transform.localPosition.x) {
				sprites [1].transform.localPosition = new Vector3 (
					sprites [1].transform.localPosition.x + dist,
					sprites [1].transform.localPosition.y,
					0.0f);
			} else {
				sprites [0].transform.localPosition = new Vector3 (
					sprites [0].transform.localPosition.x + dist,
					sprites [0].transform.localPosition.y,
					0.0f);
			}
		}
	}
}
