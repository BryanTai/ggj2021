using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
	public DialogueData Data;

	private NPC _currentNPC = null;

	private DialogueUIController _dialogueUIController;
	private ThirdPersonMovement _movementController;

	private DialogueData.DialogueLine[] currentLines = null;
	private int currentLineIndex = -1;

	private void Start()
	{
		_dialogueUIController = FindObjectOfType<DialogueUIController>();
		_movementController = FindObjectOfType<ThirdPersonMovement>();

		if(_dialogueUIController == null)
		{
			Debug.LogError("[DialogueController] - CANNOT FIND UICONTROLLER");
		}

		if(_movementController == null)
		{
			Debug.LogError("[DialogueController] - CANNOT FIND MOVEMENT CONTROLLER");
		}
	}

	private void Update()
	{
		if(Input.GetButtonDown("Fire1") && _currentNPC != null)
		{
			if(currentLines == null) //Load up the correct conversation!
			{
				//TODO: Find the Actual context from what items the player has, what the NPC is looking for, and the State of the NPC
				var context = DialogueData.ConversationContext.BEFORE_ITEM;
				currentLines = Data.GetAllLinesForConversation(_currentNPC.Name, context);
				currentLineIndex = 0;
			}

			ShowNextDialogueLine();
		}
	}

	private void ShowNextDialogueLine()
	{
		if(currentLineIndex >= currentLines.Length || currentLineIndex < 0)
		{
			currentLineIndex = -1;
			currentLines = null;
			_dialogueUIController.HideDialogue();
		}
		else
		{
			_dialogueUIController.SetNPCSprite(currentLines[currentLineIndex].CurrentSpeaker);
			_dialogueUIController.ShowDialogueText(currentLines[currentLineIndex].DialogueText);

			currentLineIndex++;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		_currentNPC = other.gameObject.GetComponent<NPC>();

		if(_currentNPC == null)
		{
			return;
		}

		_dialogueUIController.ShowTalkPrompt();

	}

	private void OnTriggerExit(Collider other)
	{
		_dialogueUIController.HideAllDialogueUIElements();
		_currentNPC = null;
	}

}
