using UnityEngine;
using System.Collections;

public class ZombieSpawnScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("SpawnNormalZombie");
	}
	
	IEnumerator SpawnNormalZombie() {
		while (true) {
			EnemyManager.Instance.AddZombie (0);
			yield return new WaitForSeconds (1.0f);
		}
	}
}
