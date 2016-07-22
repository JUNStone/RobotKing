using UnityEngine;
using System.Collections.Generic;

public class ObjectPool
{
	int objectId = 1;

	Stack<GameObject> inactive;

	GameObject prefab;

	public ObjectPool(GameObject prefab, int size)
	{
		this.prefab = prefab;
		inactive = new Stack<GameObject>(size);
	}

	public GameObject Spawn(Vector3 pos, Quaternion rot = Quaternion.identity)
	{
		GameObject obj;
	
		if(inactive.Count == 0) {
			obj = (GameObject)GameObject.Instantiate(prefab, pos, rot);
			obj.name = prefab.name + " ("+(objectId++)+")";
		} else {
			obj = inactive.Pop();
			if(obj == null) { return Spawn(pos); }
		}

		obj.transform.position = pos;
		obj.transform.rotation = rot;
		obj.SetActive(true);
		return obj;
	}

	public void Remove(GameObject obj)
	{
		obj.SetActive(false);
		inactive.Push(obj);
	}

	public void Preload(GameObject prefab, int size = 1)
	{
		GameObject[] obs = new GameObject[size];
		for (int i = 0; i < size; i++) {
			obs[i] = Spawn (prefab, Vector3.zero);
		}
	
		for (int i = 0; i < size; i++) {
			Remove(obs[i]);
		}
	}
}