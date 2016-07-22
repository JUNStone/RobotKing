using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMoveScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	bool state;
	PointerEventData pData;
	public Image img;

	void Awake() {
		img = GetComponent<Image> ();
		state = false;
	}

	public void OnPointerDown(PointerEventData data) {
		state = true;

		pData = data;
	}

	public void OnPointerUp(PointerEventData data) {
		state = false;
	}

	void Update() {
		if (state) {
			if (pData.position.x >= 0 && pData.position.x <= 960) {
				if (pData.position.y >= 540 && pData.position.y <= 1080) {
					img.color = new Color (0, 1.0f, 0);
					Debug.Log ("UP");
				} else if (pData.position.y >= 0 && pData.position.y < 540) {
					img.color = new Color (1.0f, 1.0f, 0);
					Debug.Log ("DOWN");
				}
			}
		} else {
			img.color = new Color (1.0f, 0, 0);
		}
	}
}
