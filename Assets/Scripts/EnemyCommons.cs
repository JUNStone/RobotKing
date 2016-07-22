using UnityEngine;
using System.Collections;

//Must be added to every zombie type

public class EnemyCommons : MonoBehaviour
{
	[SerializeField] float maxHp;
	[SerializeField] float moveSpeed;
	[SerializeField] float damage;

	float hp = 0.0f;
	bool vulnerable = true;

	void Awake ()
	{
		this.hp = maxHp;

		Vector3 newPos = this.gameObject.transform.position;
		newPos.y = Random.Range (300, 850);
		this.gameObject.transform.position = newPos; // y pos anchor is bottom.
	}

	void Update ()
	{
		this.gameObject.transform.Translate (Vector3.left * Time.smoothDeltaTime * moveSpeed);

		if (this.vulnerable && true) { //when player-enemy collides
			// player hp decline
			this.hp = 0;
		}

		if (this.hp <= 0.0f /* && while death anim isn't playing' */) {
			this.vulnerable = false;
			//starts death animation
		}


		if (false) { // when death animation overs
			Destroy (this.gameObject);
		}

		if (this.transform.position.x < -300.0f) {
			Destroy (this.gameObject);
			//humans hp decline
		}
	}

	public void ProcessDamage (float dmg)
	{
		this.hp -= dmg;
	}

	public bool IsVulnerable()
	{
		return vulnerable;
	}
}
