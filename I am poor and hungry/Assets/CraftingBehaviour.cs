using UnityEngine;
using System.Collections;

public class CraftingBehaviour : MonoBehaviour
{
    public Inventory inventory;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Interact(GameObject interactor)
    {
        PlayerController player = interactor.GetComponent<PlayerController>();

        if (player != null)
        {
            if (player.handsFull)
            {
                inventory.AddItem(player.inventory.RetrieveItem());
            }
            else
            {
                // this is where we show the UI for recipes
            }
        }
    }
}
