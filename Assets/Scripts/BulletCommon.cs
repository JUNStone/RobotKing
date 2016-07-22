using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletCommon : MonoBehaviour
{
	delegate void DelegateMethod(GameObject target);

	[SerializeField] DelegateMethod onHit;
	[SerializeField] float damage;
	[SerializeField] float speed;
	[SerializeField] bool pierceable;

	private List<GameObject> hitEnemies;

	void Awake ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate (Vector3.right * speed * Time.smoothDeltaTime);
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



	//public void Inactivate() {
	//	hitEnemies.Clear ();
	//	this.gameObject.SetActive (false);
	//}
}
