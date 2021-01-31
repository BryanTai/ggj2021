using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NPCData", order = 1)]
public class NPCData : ScriptableObject
{
	public NPC[] data;
	
	[System.Serializable]
	public class NPC
	{
		public NPCName Name;
		public string DisplayName = "Monster";
		public Sprite Sprite;

	}

	public Sprite GetSprite(NPCName name)
	{
		foreach(NPC npc in data)
		{
			if(npc.Name.Equals(name))
			{
				return npc.Sprite;
			}
		}

		Debug.LogError("[NPCData] - Cannot find Sprite for NPC with id: " + name);

		return null;
	}
}
