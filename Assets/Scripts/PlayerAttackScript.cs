using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerAttackScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
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
		if (state) {
			if (pData.position.x > 960 && pData.position.x <= 1920) {
				if (pData.position.y >= 0 && pData.position.y <= 1080) {
					Debug.Log ("ATTACK");
				}
			}
		}
	}
}
