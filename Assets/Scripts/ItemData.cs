using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemData", order = 1)]

public class ItemData : ScriptableObject
{
	public Item[] data;

	public Item GetItem(ItemName name)
	{
		foreach (Item item in data)
		{
			if(item.ItemName == name)
			{
				return item;
			}
		}

		Debug.LogError("[ItemData] - Cannot find Item with id: " + name);
		return null;
	}

}
