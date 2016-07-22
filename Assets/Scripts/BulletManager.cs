using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletManager : MonoBehaviour
{
	List<GameObject> bulletList;

	ObjectPool bulletPool;

	[SerializeField]
	GameObject bulletPrefab;

	Transform player;

	void Awake()
	{
		bulletList = new List<GameObject> ();
		bulletPool = new ObjectPool (bulletPrefab, 100, transform);

		bulletPool.Preload (100);

		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update()
	{
		bulletList.Add (bulletPool.Spawn (player.localPosition + Vector3.right * 30.0f));

		for (int i = bulletList.Count - 1; i >= 0; --i) {
			if (bulletList [i].transform.localPosition.x > 960.0f) {
				bulletPool.Remove (bulletList [i]);
				bulletList.Remove (bulletList [i]);
			}
		}
	}
}
