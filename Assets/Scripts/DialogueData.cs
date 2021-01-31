using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DialogueData", order = 1)]
public class DialogueData : ScriptableObject
{
	public enum ConversationContext
	{
		BEFORE_ITEM,
		RECEIVING_ITEM,
		AFTER_ITEM,
		WRONG_ITEM
	}

	public NPCConversations[] data;

	private DialogueLine[] errorDialogue = new DialogueLine[]{
		new DialogueLine 
		{
			CurrentSpeaker = NPCName.James,
			DialogueText = "< blorp ??? >"
		}
	};

	public DialogueLine[] GetAllLinesForConversation(NPCName name, ConversationContext context)
	{
		foreach(var npcConversation in data)
		{
			if(name == npcConversation.NPC)
			{
				foreach(var conversation in npcConversation.Conversations)
				{
					if(conversation.Context == context)
					{
						return conversation.Lines;
					}
				}
			}
		}

		Debug.LogError(string.Format("[DialogData] - Missing dialogue for NPC {0} during Context {1}", name.ToString(), context.ToString()));
		return errorDialogue;
	}

	[System.Serializable]
	public class NPCConversations
	{
		public NPCName NPC;
		public Conversation[] Conversations;
	}

	[System.Serializable]
	public class Conversation
	{
		public ConversationContext Context;
		public DialogueLine[] Lines;
	}

	[System.Serializable]
	public class DialogueLine
	{
		public NPCName CurrentSpeaker;
		public string DialogueText;
	}

}
