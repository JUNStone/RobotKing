using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerAttackScript : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler 
{
	[SerializeField]
	bool state;

	bool State {
		set {
			state = value;
			if (value) {
				if (pData.position.x > 960 && pData.position.x <= 1920) {
					if (pData.position.y >= 0 && pData.position.y <= 1080) {
						//플레이어 공격
						StartCoroutine ("ShootBullet");
					}
				}
			} else {
				StopCoroutine ("ShootBullet");
			}
		}
	}

	[SerializeField]
	float delay;

	float _time;

	bool isFiring;
	PointerEventData pData;

	void Awake() {
		_time = 0.0f;
		State = false;
		isFiring = false;
	}

	public void OnPointerDown(PointerEventData data) {
		pData = data;
		State = true;
	}

	public void OnPointerUp(PointerEventData data) {
		State = false;
	}

	public void OnDrag(PointerEventData data) {
		if (pData.position.x <= 960) {
			state = false;
		}

		if (pData.position.x > 960) {
			state = true;
		}
	}

	IEnumerator ShootBullet()
	{
		while (true) {
			_time += Time.deltaTime;
			if (_time < delay) {
				yield return null;
			} else {
				_time = 0.0f;
				BulletManager.Instance.ShootBullet ();
				yield return null;
			}
		}
	}
}
