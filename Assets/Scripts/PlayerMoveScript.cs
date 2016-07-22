using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMoveScript : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
	[SerializeField]
	float speed;

	bool state;

	Vector3 dir;

	bool isMoving;

	bool State {
		set {
			state = value;
			if (value) {
				if (pData.position.x >= 0 && pData.position.x <= 960 && !isMoving) {
					StartCoroutine ("Move");
					isMoving = true;
				}
			} else {
				StopCoroutine ("Move");
				isMoving = false;
			}
			
		}
	}

	PointerEventData pData;

	Transform player;

	void Awake()
	{
		isMoving = false;
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		State = false;
	}

	public void OnPointerDown(PointerEventData data)
	{
		pData = data;
		State = true;
	}

	public void OnPointerUp(PointerEventData data)
	{
		State = false;
	}

	public void OnDrag(PointerEventData data)
	{
		if (pData.position.x > 960) { State = false; }
		if (pData.position.x <= 960) { State = true; }
	}

	IEnumerator Move()
	{
		while (true) {
			if (pData.position.y >= 540 && pData.position.y <= 1080) {
				dir = Vector3.up;
			} else if (pData.position.y >= 0 && pData.position.y < 540) {
				dir = Vector3.down;
			}
			player.Translate (dir * Time.smoothDeltaTime * speed);

			yield return null;
		}
	}
}
