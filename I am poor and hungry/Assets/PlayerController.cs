using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 3;

    private Rigidbody2D selfRigid;

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
    }
}