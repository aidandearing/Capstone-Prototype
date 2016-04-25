using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Inventory inventory;

    public float movementSpeed = 3;

    private Rigidbody2D selfRigid;

    public bool handsFull = false;

    // Use this for initialization
    void Start()
    {
        selfRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementVec = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movementVec += new Vector3(-1, 1, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movementVec += new Vector3(-1, -1, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movementVec += new Vector3(1, -1, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movementVec += new Vector3(1, 1, 0);
        }

        movementVec.Normalize();
        movementVec *= movementSpeed;

        selfRigid.MovePosition(transform.position + movementVec * Time.deltaTime);

        if (movementVec.magnitude > 0)
            selfRigid.MoveRotation(Mathf.Rad2Deg * Mathf.Atan2(movementVec.y, movementVec.x) + 270);

        if (inventory.items.Count > 0)
        {
            handsFull = true;
        }
        else
        {
            handsFull = false;
        }
    }
	public void BeenCaught(Vector3 startPos)
	{
		transform.position = startPos;
		handsFull = false;

		if (inventory.items.Count != 0)
		{
			inventory.items.Remove(0);
		}

	}
}