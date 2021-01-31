using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
	public NPCName Name;
	public NPCData Data;
	public SpriteRenderer SpriteRenderer;

	public Item DesiredItem;
	public bool HasReceivedDesiredItem;

[HideInInspector]
	public int StrikesRemaining;

	private void Start()
	{
		SpriteRenderer.sprite = Data.GetSprite(Name);
		StrikesRemaining = 3;
		HasReceivedDesiredItem = false;

		if(DesiredItem == null)
		{
			Debug.LogError("[NPC] - Missing Desired Item for " + Name.ToString());
		}
	}

	public bool TryToGiveDesiredItem(Item givenItem)
	{
		HasReceivedDesiredItem = DesiredItem.Equals(givenItem);
		return HasReceivedDesiredItem;
	}

	public bool ReduceStrike()
	{
		StrikesRemaining--;
		return StrikesRemaining <= 0;
	}

}
