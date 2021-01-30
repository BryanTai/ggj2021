using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<Item> items = new List<Item>();

    public int space = 15;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of inventory singleton");
            return;
        }
        instance = this;
    }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("not enough room");
            return false;
        }
        items.Add(item);

        if(onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

}
