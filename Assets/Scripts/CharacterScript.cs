using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour
{
	protected CharacterStatus status;

	[SerializeField]
	protected float maxHp;
	[SerializeField]
	protected float currentHp;

	[SerializeField]
	Animator _anim;

	protected void Awake()
	{
		_anim = GetComponentInChildren<Animator> ();
		if (_anim == null) {
			_anim = GetComponent<Animator> ();
		}

		currentHp = maxHp;

	}

	public void SetStatus(CharacterStatus status)
	{
		this.status = status;
		_anim.SetInteger ("status", (int)status);
	}

	public void ProcessHp(float hp)
	{
		if (status == CharacterStatus.Die) {
			return;
		}
		currentHp += hp;
		if (currentHp > maxHp) {
			currentHp = maxHp;
		} else if (currentHp < 0.0f) {
			currentHp = 0.0f;
			SetStatus (CharacterStatus.Die);
			GetComponent<BoxCollider2D> ().isTrigger = true;
		}
		Debug.Log (currentHp);
	}
}
