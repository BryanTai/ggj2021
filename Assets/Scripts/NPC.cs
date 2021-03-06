﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
	public NPCName Name;
	
	public SpriteRenderer SpriteRenderer;

	private Item _desiredItem;
	public bool HasReceivedDesiredItem;
	public NPCModelController ModelController;

	[Header("Data")]
	public NPCData NPCSpriteMap;
	public NPCDesiredItems DesiredItemsData;

[HideInInspector]
	public int StrikesRemaining;

	private void Start()
	{
		_desiredItem = DesiredItemsData.GetDesiredItem(Name);
	
		StrikesRemaining = 3;
		HasReceivedDesiredItem = false;

		bool modelSet = ModelController.TrySetModelFromName(Name);
		if(!modelSet)
		{
			SpriteRenderer.gameObject.SetActive(true);
			SpriteRenderer.sprite = NPCSpriteMap.GetNPCData(Name).Sprite;
		}
		else
		{
			SpriteRenderer.gameObject.SetActive(false);
		}

		if(_desiredItem == null)
		{
			Debug.LogError("[NPC] - Missing Desired Item for " + Name.ToString());
		}
	}

	public bool TryToGiveDesiredItem(Item givenItem)
	{
		if(Name == NPCName.Slime)
		{
			//can receive ANY item
			return true;
		}

		if(Name == NPCName.Elemental)
		{
			//cannot receive anything
			return false;
		}

		HasReceivedDesiredItem = _desiredItem.Equals(givenItem);
		if(!HasReceivedDesiredItem)
		{
			ReduceStrike();
		}
		return HasReceivedDesiredItem;
	}

	public bool ReduceStrike()
	{
		StrikesRemaining--;
		return StrikesRemaining <= 0;
	}

}
