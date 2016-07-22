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
			sprites [i].transform.Translate (Vector3.left * Time.smoothDeltaTime * speed);
			if (sprites [i].transform.localPosition.x < imageOffsetX * -1) {
				sprites [i].transform.localPosition = new Vector3 (imageOffsetX * (sprites.Length - 1), startPosition[i].y, 0.0f);
			}
		}
	}
}
