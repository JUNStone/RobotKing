using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletCommon : MonoBehaviour
{
	delegate void DelegateMethod(GameObject target, float damage);

	[SerializeField] DelegateMethod onHit;
	[SerializeField] float damage;
	[SerializeField] float speed;
	[SerializeField] bool pierceable;

	private List<GameObject> hitEnemies;

	void Awake ()
	{
		
	}

	void Update ()
	{
		this.gameObject.transform.Translate (Vector3.right * speed * Time.smoothDeltaTime);

		if (this.gameObject.transform.localPosition.x > 960.0f) {
			BulletManager.Instance.RemoveBullet (this.gameObject);
		}
		/*GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0, len = enemies.Length; i < len; ++i) {
			//when enemy collides
			if (false && !hitEnemies.Contains (enemies [i])) {
				onHit (enemies[i]); // damage, hit effects or something
				if (!this.pierceable) {
					Inactivate ();
					return;
				} else {
					hitEnemies.Add (enemies [i]);
				}
			}
		}*/

		//if (this.transform.position.x >= 2000) {
		//	Inactivate ();
		//}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag.Equals("Zombie")) {
			BulletManager.Instance.RemoveBullet (this.gameObject);
			other.gameObject.GetComponent<EnemyCommons> ().ProcessDamage (damage);
		}
	}



	//public void Inactivate() {
	//	hitEnemies.Clear ();
	//	this.gameObject.SetActive (false);
	//}
}