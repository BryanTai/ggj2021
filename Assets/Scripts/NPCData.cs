using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NPCData", order = 1)]
public class NPCData : ScriptableObject
{
	public NPC[] data;
	
	[System.Serializable]
	public class NPC
	{
		public string ID;
		public Sprite Sprite;

	}

	public Sprite GetSprite(string id)
	{
		foreach(NPC npc in data)
		{
			if(npc.ID.Equals(id))
			{
				return npc.Sprite;
			}
		}

		Debug.LogError("[NPCData] - Cannot find Sprite for NPC with id: " + id);

		return null;
	}

	[System.Serializable]
	public class DialogueEntry
	{
		public string SpeakerID;
		public string DialogueText;
	}
}
