using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueprint : MonoBehaviour
{
    [Header("A Collection of Blueprint Items")]
    public List<BlueprintItem> blueprintItems = new List<BlueprintItem>();
    private GameObject player;
    private List<BlueprintItem> itemsToBeShown = new List<BlueprintItem>();
    private PlayerInventory inventory;
    private float distance = 2f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<PlayerInventory>();

        //Testcode need to be deleted.
        player.GetComponent<PlayerInventory>().AddToInventory("Pillow1");
        player.GetComponent<PlayerInventory>().AddToInventory("Pillow2");
        player.GetComponent<PlayerInventory>().AddToInventory("Lamp");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InRangeOfFort())
        {
            PlayerInventory inventory = player.GetComponent<PlayerInventory>();
            itemsToBeShown[0].ShowItem();
            inventory.RemoveFromInventory(itemsToBeShown[0].itemName);
            itemsToBeShown.Remove(itemsToBeShown[0]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            foreach (BlueprintItem bit in blueprintItems)
            {
                if (inventory.HasItem(bit.itemName))
                {
                    itemsToBeShown.Add(bit);
                    bit.HighlightItem();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (BlueprintItem bit in itemsToBeShown)
            {
                bit.CancelHighlightItem();
            }
            itemsToBeShown.Clear();
        }
    }

    private bool InRangeOfFort()
    {
        Debug.Log(Vector3.Distance(player.transform.position, transform.position));
        if(Vector3.Distance(player.transform.position, transform.position) < distance)
            return true;
        
        return false;
    }
}
