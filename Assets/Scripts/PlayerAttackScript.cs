using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerAttackScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	bool state;
	PointerEventData pData;
	Image img;

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
			if (pData.position.x > 960 && pData.position.x <= 1920) {
				if (pData.position.y >= 0 && pData.position.y <= 1080) {
					img.color = new Color (0, 1.0f, 1.0f);
					Debug.Log ("ATTACK");
				}
			}
		} else {
			img.color = new Color (0, 0, 1.0f);
		}
	}
}
