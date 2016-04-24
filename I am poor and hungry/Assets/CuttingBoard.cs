using UnityEngine;
using System.Collections;

public class CuttingBoard : MonoBehaviour
{

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
                GameObject item = player.inventory.RetrieveItem();
                item.GetComponent<FoodUnity>().food.modifier.AddModifier(Modifier.ModType.Sliced);
                player.inventory.AddItem(item);
                Debug.Log(item.name + " has been sliced");
            }
        }
    }
}
