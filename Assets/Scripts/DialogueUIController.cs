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
	public NPCData NPCData;

	private void Start()
	{
		TalkPromptContainer.SetActive(false);
		NPCDialogueContainer.SetActive(false);
	}

	public bool IsShowingTalkPrompt()
	{
		return TalkPromptContainer.activeSelf;
	}

	public bool IsShowingDialogue()
	{
		return NPCDialogueContainer.activeSelf;
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
		NPCImage.sprite = NPCData.GetSprite(npcID);
	}

	
	
}
