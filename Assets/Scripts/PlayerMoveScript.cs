using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMoveScript : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
	[SerializeField]
	bool state;

	PointerEventData pData;

	Transform player;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
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
		if (pData.position.x > 960) {
			state = false;
		}

		if (pData.position.x <= 960) {
			state = true;
		}
	}

	void Update() {

		if (state) {
			if (pData.position.x >= 0 && pData.position.x <= 960) {
				if (pData.position.y >= 540 && pData.position.y <= 1080) {
					//플레이어 위로 이동
					player.Translate(Vector3.up * Time.smoothDeltaTime * 30.0f);
				} else if (pData.position.y >= 0 && pData.position.y < 540) {
					//플레이어 아래로 이동
					player.Translate(Vector3.down * Time.smoothDeltaTime * 30.0f);
				}
			}
		} else {
			//이동터치종료
		}
	}
}
