﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private string key;
    private AudioSource pickupSound;

    private void OnCollisionEnter(Collision c)
    {
        
        if(c.gameObject.tag == "Player")
        {
            Pickup(c.gameObject, key);
        }
    }

    private void Pickup(GameObject player, string key)
    {
        // Add the collectable to the player's inventory.
        PlayerMovement.instance.PlayPickUpSound();
        PlayerInventory inventory = player.GetComponent<PlayerInventory>();
        inventory.AddToInventory(key);

        Destroy(gameObject);
    }
}
