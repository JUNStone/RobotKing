using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
	private const int NORMAL = 0, BIG = 1, FAST = 2;

	private static EnemyManager _instance;
	public static EnemyManager Instance {
		get {
			if (!_instance) {
				_instance = GameObject.FindObjectOfType (typeof(EnemyManager)) as EnemyManager;
				if (!_instance) {
					return null;
				}
				return _instance;
			} else {
				return _instance;
			}
		}
	}

	List<GameObject> enemyList;

	ObjectPool normalZombiePool, bigZombiePool, fastZombiePool;

	[SerializeField] GameObject normalZombiePrefab;
	[SerializeField] GameObject bigZombiePrefab;
	[SerializeField] GameObject fastZombiePrefab;

	Transform player;

	void Awake()
	{
		enemyList = new List<GameObject> ();
		normalZombiePool = new ObjectPool (normalZombiePrefab, 10, this.transform);
		bigZombiePool = new ObjectPool (bigZombiePrefab, 10, this.transform);
		fastZombiePool = new ObjectPool (fastZombiePrefab, 10, this.transform);

		normalZombiePool.Preload (10);
		bigZombiePool.Preload (10);
		fastZombiePool.Preload (10);

		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	public void AddZombie(int type)
	{
		GameObject zombie = null;
		if (type == NORMAL) {
			zombie = normalZombiePool.Spawn (new Vector3 (960, Random.Range (-300, 230), 0));
		} else if (type == BIG) {
			zombie = bigZombiePool.Spawn (new Vector3 (960, Random.Range (-300, 230), 0));
		} else if (type == FAST) {
			zombie = fastZombiePool.Spawn (new Vector3 (960, Random.Range (-300, 230), 0));
		}
		EnemyCommons zombieStat = zombie.GetComponent<EnemyCommons> ();
		zombieStat.ProcessHp (10000.0f);
		zombieStat.SetStatus (CharacterStatus.Run);
		zombie.GetComponent<Collider2D> ().isTrigger = false;

		enemyList.Add (zombie);
	}

	public void RemoveZombie(GameObject obj) {
		enemyList.Remove (obj);
		int type = obj.GetComponent<EnemyCommons> ().type;
		if (type == NORMAL) {
			normalZombiePool.Remove (obj);
		} else if (type == BIG) {
			bigZombiePool.Remove (obj);
		} else if (type == FAST) {
			fastZombiePool.Remove (obj);
		}
	}
}
