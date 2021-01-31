using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
	public NPCName Name;
	public NPCData Data;
	public SpriteRenderer SpriteRenderer;


	private void Start()
	{
		SpriteRenderer.sprite = Data.GetSprite(Name);
	}

}
