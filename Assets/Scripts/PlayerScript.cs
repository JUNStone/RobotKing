using UnityEngine;
using System.Collections;

public class PlayerScript : CharacterScript
{
	static PlayerScript _instance;

	public static PlayerScript Instance {
		get {
			if (!Instance) {
				_instance = GameObject.FindObjectOfType (typeof(PlayerScript)) as PlayerScript;
				if (!_instance) {
					return null;
				}
				return _instance;
			} else {
				return _instance;
			}
		}
	}

	PlayerWeapon currentWeapon;

	[SerializeField]
	int maxHuman;
	int currentHuman;

	GameObject rifle;
	GameObject laser;
	GameObject cannon;

	GameObject weaponChangeEffect;

	void Awake ()
	{
		base.Awake ();

		rifle = GameObject.Find ("Rifle");
		laser = GameObject.Find ("Laser");
		cannon = GameObject.Find ("Cannon");

		weaponChangeEffect = GameObject.FindGameObjectWithTag ("WCEffect");
		weaponChangeEffect.SetActive (false);

		currentHuman = maxHuman;

		SetStatus (CharacterStatus.Run);
		SetWeapon (PlayerWeapon.rifle);

	}

	public void SetWeapon(PlayerWeapon status)
	{
		if (status != currentWeapon) {
			StartCoroutine ("Effect");
		}
		currentWeapon = status;
		switch (currentWeapon) {
		case PlayerWeapon.rifle:
			rifle.SetActive(true);
			laser.SetActive (false);
			cannon.SetActive (false);
			break;
		case PlayerWeapon.laser:
			rifle.SetActive(false);
			laser.SetActive (true);
			cannon.SetActive (false);
			break;
		case PlayerWeapon.cannon:
			rifle.SetActive(false);
			laser.SetActive (false);
			cannon.SetActive (true);
			break;
		}
	}

	public void ProcessHuman(int human)
	{
		currentHuman += human;
		if (currentHuman > maxHuman) {
			currentHuman = maxHuman;
		} else if (currentHuman < 0) {
			SetStatus (CharacterStatus.Die);
		}
	}

	IEnumerator Effect()
	{
		weaponChangeEffect.SetActive (true);
		yield return new WaitForSeconds(0.5f);
		weaponChangeEffect.SetActive (false);
	}

	void OnCollisionEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals ("Zombie")) {
			Debug.Log ("MoveBack");
			StartCoroutine (other.gameObject.GetComponent<EnemyCommons> ().MoveBack ());
		}
	}
}
