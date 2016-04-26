using UnityEngine;
using System.Collections;

public class ShelfBehaviour : MonoBehaviour
{
    public Inventory inventory;

    public int lootTimes = 0;
    public int lootTimesMax = 1;

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
        if (lootTimes < lootTimesMax)
        {
            PlayerController player = interactor.GetComponent<PlayerController>();

            if (player != null)
            {
                // Give them an item
                if (!player.handsFull)
                {
                    player.inventory.AddItem(inventory.RetrieveRandomItem());
                    lootTimes++;
                }
            }
        }
    }
}
