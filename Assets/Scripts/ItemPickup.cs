using UnityEngine;

public class ItemPickup : Interactable {

	public ItemName Name;
	public ItemData Data;

	public SpriteRenderer SpinningIcon;

	private Item item;	// Item to put in the inventory if picked up

	private void Start()
	{
		item = Data.GetItem(Name);
		SpinningIcon.sprite = item.Icon;
	}

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

		Destroy(gameObject);	// Destroy item from scene
	}


}

