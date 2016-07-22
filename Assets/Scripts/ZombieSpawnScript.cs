using UnityEngine;
using System.Collections;

public class ZombieSpawnScript : MonoBehaviour {
	
	void Start () {
		StartCoroutine ("SpawnNormalZombie");
	}
	
	IEnumerator SpawnNormalZombie() {
		while (true) {
			EnemyManager.Instance.AddZombie ((int) Random.Range (0, 3));
			yield return new WaitForSeconds (Random.Range(1.0f, 5.0f));
		}
	}
}
