using UnityEngine;
using System.Collections;

public class GroceryCart : MonoBehaviour {

	public Inventory inventory;
	public int maxItems;
	public static bool resetCart;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (resetCart)
		{
			foreach (GameObject item in inventory.items)
			{
				inventory.items.Remove(item);
			}
			resetCart = false;

		}
	}
	void Interact(GameObject interactor)
	{
		PlayerController player = interactor.GetComponent<PlayerController>();

		if (player != null)
		{
			if (player.handsFull)
			{
				if (inventory.items.Count >= maxItems)
				{
					Debug.Log("Cant place item. Your grocery Cart is Full!");
				}
				else
				{
					inventory.AddItem(player.inventory.RetrieveItem());
				}
			}
		}
	}
}
