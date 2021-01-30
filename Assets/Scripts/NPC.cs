using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
	public string ID;
	public NPCData Data;
	public SpriteRenderer SpriteRenderer;


	private void Start()
	{
		if(string.IsNullOrEmpty(ID))
		{
			Debug.LogError("[NPC] Missing ID! Cannot Initialize");
			return;
		}

		SpriteRenderer.sprite = Data.GetSprite(ID);
	}

}
