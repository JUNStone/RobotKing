using UnityEngine;
using System.Collections;

//Must be added to every zombie type

public class EnemyCommons : CharacterScript
{
	[SerializeField] float moveSpeed;
	public float damage;

	public int type;

	bool vulnerable = true;

	BackgroundScript road;

	void Awake ()
	{
		base.Awake ();

		Vector3 newPos = this.gameObject.transform.position;
		newPos.y = Random.Range (300, 850);
		this.gameObject.transform.position = newPos; // y pos anchor is bottom.
		road = GameObject.Find("Road").GetComponent<BackgroundScript>();
	}

	void Update ()
	{
		if (status == CharacterStatus.Run)
			this.gameObject.transform.Translate (Vector3.left * Time.smoothDeltaTime * moveSpeed);
		else
			this.gameObject.transform.Translate (Vector3.left * Time.smoothDeltaTime * road.GetSpeed());

		if (this.vulnerable && true) { //when player-enemy collides
			// player hp decline
			currentHp = 0;
		}

		if (this.currentHp <= 0.0f /* && while death anim isn't playing' */) {
			this.vulnerable = false;
			//starts death animation
		}


		if (false) { // when death animation overs
			EnemyManager.Instance.RemoveZombie (this.gameObject);
		}

		if (this.transform.localPosition.x < -1260.0f) {
			EnemyManager.Instance.RemoveZombie (this.gameObject);
			//humans hp decline
		}
	}

	public void ProcessDamage (float dmg)
	{
		ProcessHp (dmg * -1);
		if (status == CharacterStatus.Die) {
			Invoke ("Die", 1.0f);
		}
	}

	public IEnumerator MoveBack()
	{
		float _t = 0.0f;
		float origin = moveSpeed;
		moveSpeed = 0.0f;
		while (_t < 1.5f) {
			_t += Time.smoothDeltaTime;
			this.gameObject.transform.Translate (Vector3.right * Time.smoothDeltaTime * ((1.5f - _t) * 150));
			yield return null;
		}
		moveSpeed = origin;
	}

	void Die()
	{
		EnemyManager.Instance.RemoveZombie (this.gameObject);
	}

	public bool IsVulnerable()
	{
		return vulnerable;
	}
}
