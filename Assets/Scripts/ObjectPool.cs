using UnityEngine;
using System.Collections.Generic;

public class ObjectPool
{
	int objectId = 1;

	Stack<GameObject> inactive;

	GameObject prefab;

	Transform parent;

	public ObjectPool(GameObject prefab, int size, Transform parent)
	{
		this.prefab = prefab;
		this.parent = parent;
		inactive = new Stack<GameObject>(size);
	}

	public GameObject Spawn(Vector3 pos)
	{
		GameObject obj;
	
		if(inactive.Count == 0) {
			obj = (GameObject)GameObject.Instantiate(prefab, pos, Quaternion.identity);
			obj.name = prefab.name + " ("+(objectId++)+")";
			obj.transform.SetParent (parent);
		} else {
			obj = inactive.Pop();
			if(obj == null) { return Spawn(pos); }
		}

		obj.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		obj.transform.localPosition = pos;
		obj.SetActive(true);
		return obj;
	}

	public void Remove(GameObject obj)
	{
		obj.SetActive(false);
		inactive.Push(obj);
	}

	public void Preload(int size = 1)
	{
		GameObject[] obs = new GameObject[size];
		for (int i = 0; i < size; i++) {
			obs[i] = Spawn (Vector3.zero);
		}
	
		for (int i = 0; i < size; i++) {
			Remove(obs[i]);
		}
	}
}