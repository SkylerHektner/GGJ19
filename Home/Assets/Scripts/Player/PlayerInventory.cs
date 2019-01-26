using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<string> collectedItems; // The items that are currently collected.

    void Start()
    {
        collectedItems = new List<string>();
    }

    void Update()
    {
        
    }
    
    public void AddToInventory(string key)
    {
        collectedItems.Add(key);
    }

    public void RemoveFromInventory(string key)
    {
        collectedItems.Remove(key);
    }

    public bool HasItem(string key)
    {
        if(collectedItems.Contains(key))
            return true;
        else
            return false;
    }
}
