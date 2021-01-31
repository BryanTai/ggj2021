﻿using UnityEngine;

public class ItemPickup : Interactable {

	public Item item;	// Item to put in the inventory if picked up

	// When the player interacts with the item
	public override void Interact()
	{
		base.Interact();

		PickUp();
	}

	// Pick up the item
	void PickUp ()
	{
		Inventory.instance.Add(item);	// Add to inventory

		Destroy(gameObject, 0.1f);	// Destroy item from scene
	}


}

