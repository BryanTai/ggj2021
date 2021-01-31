using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NPCDesiredItems", order = 1)]
public class NPCDesiredItems : ScriptableObject
{
	public NPCDesiredItemMap[] data;

	public Item GetDesiredItem(NPCName name)
	{
		foreach (var mapping in data)
		{
			if(mapping.Name == name)
			{
				return mapping.DesiredItem;
			}
		}

		Debug.LogError("[NPCDesiredItems] - Missing Desired Item for " + name.ToString());
		return null;
	}

	[System.Serializable]
	public class NPCDesiredItemMap
	{
		public NPCName Name;
		public Item DesiredItem;
	}
}
