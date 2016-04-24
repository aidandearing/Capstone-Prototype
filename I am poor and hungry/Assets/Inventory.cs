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
            items.Add(obj);
        }
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
