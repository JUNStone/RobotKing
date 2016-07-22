using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerAttackScript : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {
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

	public void OnDrag(PointerEventData data) {
		if (pData.position.x <= 960) {
			state = false;
		}

		if (pData.position.x > 960) {
			state = true;
		}
	}

	void Update() {

		if (state) {
			if (pData.position.x > 960 && pData.position.x <= 1920) {
				if (pData.position.y >= 0 && pData.position.y <= 1080) {
					img.color = new Color (0, 1.0f, 1.0f);
					//플레이어 공격
				}
			}
		} else {
			img.color = new Color (0, 0, 1.0f);
			//공격터치종료
		}
	}
}
