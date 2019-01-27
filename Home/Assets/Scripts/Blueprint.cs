using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueprint : MonoBehaviour
{
    [Header("A Collection of Blueprint Items")]
    public List<BlueprintItem> blueprintItems = new List<BlueprintItem>();
    public GameObject interactionCanvas;
    private GameObject player;
    private List<BlueprintItem> itemsToBeShown = new List<BlueprintItem>();

    void Start()
    {
        interactionCanvas.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        //Testcode need to be deleted.
        player.GetComponent<PlayerInventory>().AddToInventory("pillow1");
        player.GetComponent<PlayerInventory>().AddToInventory("pillow2");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerInventory inventory = player.GetComponent<PlayerInventory>();
            if (itemsToBeShown.Count == 0)
            {
                interactionCanvas.SetActive(false);
            }
            else
            {
                itemsToBeShown[0].ShowItem();
                inventory.RemoveFromInventory(itemsToBeShown[0].itemName);
                itemsToBeShown.Remove(itemsToBeShown[0]);
                if (itemsToBeShown.Count == 0)
                {
                    interactionCanvas.SetActive(false);
                }
            }
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
                    interactionCanvas.SetActive(true);
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
            interactionCanvas.SetActive(false);
        }
    }
}
