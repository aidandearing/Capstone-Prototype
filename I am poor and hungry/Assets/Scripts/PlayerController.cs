using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Inventory inventory;
    public PlayerBehaviour player;

    public float movementSpeed = 3;

    private Rigidbody2D selfRigid;

    public bool handsFull = false;
	public int maxInventory;

    // Use this for initialization
    void Start()
    {
        selfRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        player.Update();

        HandleInput();

        if (inventory.items.Count > 0)
        {
            handsFull = true;
            Food food = (inventory.items[0] as GameObject).GetComponent<FoodUnity>().food;
            UIInterface.UI.SetItemInHandText(food.name);
        }
        else
        {
            handsFull = false;
            UIInterface.UI.SetItemInHandText("");
        }
    }

    void HandleInput()
    {
        // Movement Logic
        Vector3 movementVec = Vector3.zero;

        if (Input.GetAxis("Vertical") > 0)
        {
            movementVec += new Vector3(-1, 1, 0) * Input.GetAxis("Vertical");
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            movementVec += new Vector3(-1, -1, 0) * -Input.GetAxis("Horizontal");
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            movementVec += new Vector3(1, -1, 0) * -Input.GetAxis("Vertical");
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            movementVec += new Vector3(1, 1, 0) * Input.GetAxis("Horizontal");
        }

        movementVec.Normalize();
        movementVec *= movementSpeed;

        selfRigid.MovePosition(transform.position + movementVec * Time.deltaTime);

        if (movementVec.magnitude > 0)
            selfRigid.MoveRotation(Mathf.Rad2Deg * Mathf.Atan2(movementVec.y, movementVec.x) + 270);
        // End of Movement Logic

        // Eating Logic
        if (Input.GetButtonDown("Eat"))
        {
            player.EatFood(inventory.RetrieveItem().GetComponent<FoodUnity>().food);
        }
    }
	public void BeenCaught(Vector3 startPos)
	{
		transform.position = startPos;
		GroceryCart.resetCart = true;
		if (inventory.items.Count != 0)
		{
			inventory.items.RemoveAt(0);
		}

	}
}