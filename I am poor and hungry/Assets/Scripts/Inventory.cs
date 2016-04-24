using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{
    public GameObject[] itemsToStart;
    public ArrayList items;

    // Use this for initialization
    void Start()
    {
        items = new ArrayList();

        foreach (GameObject obj in itemsToStart)
        {
            AddItem(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItem(GameObject item)
    {
        items.Add(item);
        Debug.Log("An item of name: " + item.name + " has been added to: " + this.name);
    }

    public void AddItems(GameObject[] items)
    {
        foreach (GameObject obj in items)
        {
            AddItem(obj);
        }
    }

    public GameObject RetrieveItem()
    {
        GameObject item = items[0] as GameObject;
        Debug.Log("An item of name: " + item.name + " has been removed from: " + this.name);
        items.RemoveAt(0);
        return item;
    }

    public GameObject RetrieveRandomItem()
    {
        GameObject item = items[Random.Range(0, items.Count)] as GameObject;
        items.Remove(item);
        return item;
    }
}
