using UnityEngine;
using System.Collections;

public class LootInteraction : MonoBehaviour {

	public GameObject[] items;
	public bool hasInteracted;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasInteracted)
		{
			hasInteracted = true;
		}
	
	}
	void Interact(GameObject interactor)
	{
		if (!hasInteracted)
		{
			interactor.BroadcastMessage("AddItem", items[Random.Range(0, items.Length - 1)]);
		}
	}
}
