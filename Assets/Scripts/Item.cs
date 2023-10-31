using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName; // Name of the item

    public string ItemName
    {
        get { return itemName; }
    }
}
