﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
	private NPC _currentNPC = null;

	private DialogueUIController _dialogueUIController;

	private void Start()
	{
		_dialogueUIController = FindObjectOfType<DialogueUIController>();

		if(_dialogueUIController == null)
		{
			Debug.LogError("[DialogueController] - CANNOT FIND UICONTROLLER");
		}
	}

	private void Update()
	{
		if(Input.GetButtonDown("Fire1") && _currentNPC != null)
		{

			_dialogueUIController.ShowDialogueText("Hey there, James"); //TODO: TESTING!

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

}