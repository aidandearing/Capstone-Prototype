using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{
    private ArrayList items;

    // Use this for initialization
    void Start()
    {
        items = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItem(GameObject item)
    {
        items.Add(item);
    }

    public GameObject RetrieveItem()
    {
        GameObject item = items[0] as GameObject;
        items.RemoveAt(0);
        return item;
    }
}
