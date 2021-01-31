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
		HideAllDialogueUIElements();
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

	public bool IsInDialogue()
	{
		return NPCDialogueContainer.activeInHierarchy;
	}

	public void HideAllDialogueUIElements()
	{
		TalkPromptContainer.SetActive(false);
		HideDialogue();
	}

	public void HideDialogue()
	{
		NPCDialogueContainer.SetActive(false);
	}

	public void SetNPCSprite(NPCName name)
	{
		NPCImage.sprite = NPCData.GetSprite(name);
	}
}
