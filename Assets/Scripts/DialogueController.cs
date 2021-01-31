using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
	public DialogueData Data;

	private NPC _currentNPC = null;

	private DialogueUIController _dialogueUIController;
	private ThirdPersonMovement _movementController;

	private DialogueData.DialogueLine[] _currentLines = null;
	private int _currentLineIndex = -1;

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
		if(Input.GetButtonDown("Talk") && _currentNPC != null)
		{
			if(_currentLines == null)
			{
				LoadDialogueOfCurrentNPC();
			}

			ShowNextDialogueLine();
		}
	}

	private void LoadDialogueOfCurrentNPC()
	{
		var context = FindStartingConversationContextOfCurrentNPC();
		_currentLines = Data.GetAllLinesForConversation(_currentNPC.Name, context);
		_currentLineIndex = 0;
		_movementController.SetMovementEnabled(false);
	}

	private DialogueData.ConversationContext FindStartingConversationContextOfCurrentNPC()
	{
		return _currentNPC.HasReceivedDesiredItem ? DialogueData.ConversationContext.AFTER_ITEM : DialogueData.ConversationContext.BEFORE_ITEM;
	}

	public bool IsInDialogue()
	{
		return _dialogueUIController.NPCDialogueContainer.activeInHierarchy;
	}

	public bool HasCurrentNPCRecievedDesiredItem()
	{
		return _currentNPC != null && _currentNPC.HasReceivedDesiredItem;
	}

	public bool TryToGiveDesiredItemToCurrentNPC(Item givenItem)
	{
		
		if(_currentNPC == null)
		{
			return false;
		}
		


		bool gaveDesiredItem = _currentNPC.TryToGiveDesiredItem(givenItem);

		var newContext = gaveDesiredItem ? DialogueData.ConversationContext.RECEIVING_ITEM : DialogueData.ConversationContext.WRONG_ITEM;
		InterruptCurrentDialogue(newContext);

		if (_currentNPC.Name != NPCName.Slime && gaveDesiredItem)
		{
			GameController.ItemsReturned += 1;
		}

		return gaveDesiredItem;
	}

	private void InterruptCurrentDialogue(DialogueData.ConversationContext newContext)
	{
		_currentLines = Data.GetAllLinesForConversation(_currentNPC.Name, newContext);
		_currentLineIndex = 0;
		ShowNextDialogueLine();
	}

	private void ShowNextDialogueLine()
	{
		if(_currentLineIndex >= _currentLines.Length || _currentLineIndex < 0)
		{
			//Dialogue is over, set everything back to normal
			CloseDialogue();
		}
		else
		{
			_dialogueUIController.SetNPCSprite(_currentLines[_currentLineIndex].CurrentSpeaker);
			_dialogueUIController.ShowDialogueText(_currentLines[_currentLineIndex].DialogueText);

			_currentLineIndex++;
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

	private void CloseDialogue()
	{
		_currentNPC = null;
		_currentLineIndex = -1;
		_currentLines = null;
		_dialogueUIController.HideDialogue();
		_movementController.SetMovementEnabled(true);
	}

	private void OnTriggerExit(Collider other)
	{
		CloseDialogue();
		_dialogueUIController.HideAllDialogueUIElements();
	}

}
