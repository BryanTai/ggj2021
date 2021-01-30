using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUIController : MonoBehaviour
{
	public GameObject TalkPromptContainer;
	public GameObject NPCDialogueContainer;
	public Text DialogueText;
	public Image NPCImage;

	private void Start()
	{
		TalkPromptContainer.SetActive(false);
		NPCDialogueContainer.SetActive(false);
	}

	public void ShowTalkPrompt()
	{
		TalkPromptContainer.SetActive(true);
	}

	public void ShowDialogueText(string text)
	{
		TalkPromptContainer.SetActive(false);
		NPCDialogueContainer.SetActive(true);
		DialogueText.text = text;
	}

	public void SetNPCSprite(string npcID)
	{
		//TODO: Implement
	}
	
}
