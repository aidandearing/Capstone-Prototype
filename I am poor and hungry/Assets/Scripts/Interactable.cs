using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour
{
    public GameObject interactIcon;

    private GameObject interactInstance;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (interactInstance == null)
            {
                interactInstance = Instantiate(interactIcon, transform.position, new Quaternion()) as GameObject;
            }
        }
    }

    void OnTriggerStay2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetButtonDown("Interact"))
            {
                gameObject.SendMessage("Interact", other.gameObject, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (interactInstance != null)
            {
                Destroy(interactInstance);
            }
        }
    }
}
