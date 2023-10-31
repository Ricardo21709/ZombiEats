using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private static PlayerInventory instance;
    public static PlayerInventory Instance { get { return instance; } }

    private List<string> inventory = new List<string>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Add an item to the inventory.
    public void AddItem(string item)
    {
        Debug.Log("Added Weapon To Inventory");
        inventory.Add(item);
    }

    // Remove an item from the inventory.
    public void RemoveItem(string item)
    {
        inventory.Remove(item);
    }

    // Check if the inventory contains a specific item.
    public bool HasItem(string item)
    {
        return inventory.Contains(item);
    }
}
