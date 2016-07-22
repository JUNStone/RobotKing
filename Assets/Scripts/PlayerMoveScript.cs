using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerMoveScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	bool state;
	PointerEventData pData;

	void Awake() {
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
		Debug.Log (pData.position);
		if (state) {
			if (pData.position.x >= 0 && pData.position.x <= 960) {
				if (pData.position.y >= 540 && pData.position.y <= 1080) {
					Debug.Log ("UP");
				} else if (pData.position.y >= 0 && pData.position.y < 540) {
					Debug.Log ("DOWN");
				}
			}
		}
	}
}
