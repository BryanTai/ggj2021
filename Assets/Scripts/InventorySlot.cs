using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    Item item;

    private DialogueController _dialogueController;

    private void Start()
    {
        _dialogueController = FindObjectOfType<DialogueController>();
    }

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.Icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void OnGiveItem()
    {
        
        if (item != null && _dialogueController.IsInDialogue() && !_dialogueController.HasCurrentNPCRecievedDesiredItem())
        {
            bool gaveDesiredItem = _dialogueController.TryToGiveDesiredItemToCurrentNPC(item);
            if(gaveDesiredItem)
            {
                Inventory.instance.Remove(item);
            }
            else
            {
                //TODO: Show the player that they're WRONG. Maybe shake the icon or something.
            }
            
        }
    }
}
