using UnityEngine;
using System.Collections;

public class ShelfBehaviour : MonoBehaviour
{
    public FoodUnity[] foodObjects;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        // Ensure the collider is a player
        // If the player interacts, give them one item at random
    }
}
