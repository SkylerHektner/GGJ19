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
    private PlayerInventory inventory;
    private float distance = 2f;
    private int itemsRemaining;
    private AudioSource buildSound;

    private bool inPlace = false;

    public GameObject spawnPortalBackTrigger;

    void Start()
    {
        //interactionCanvas.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<PlayerInventory>();
        itemsRemaining = blueprintItems.Count;
        buildSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(itemsRemaining == 0) // The fort is built!
        {
            // TODO: Win state.
            spawnPortalBackTrigger.SetActive(true);
            return;
        }

        if (inPlace)
        {
            if (Input.GetButtonDown("Interact"))
            {
                if (itemsRemaining > 0)
                {
                    PlayerInventory inventory = player.GetComponent<PlayerInventory>();
                    itemsToBeShown[0].ShowItem();
                    inventory.RemoveFromInventory(itemsToBeShown[0].itemName);
                    itemsRemaining--;
                    itemsToBeShown.Remove(itemsToBeShown[0]);
                    buildSound.Play();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inPlace = true;
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            foreach (BlueprintItem bit in blueprintItems)
            {
                if (inventory.HasItem(bit.itemName))
                {
                    itemsToBeShown.Add(bit);
                    bit.HighlightItem();
                    //interactionCanvas.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inPlace = false;
            foreach (BlueprintItem bit in itemsToBeShown)
            {
                bit.CancelHighlightItem();
            }
            itemsToBeShown.Clear();
            //interactionCanvas.SetActive(false);
        }
    }
}
