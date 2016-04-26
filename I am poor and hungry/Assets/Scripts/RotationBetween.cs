using UnityEngine;
using System.Collections;

public class RotationBetween : MonoBehaviour
{
    public bool loop = false;
    //public float angle = 90;

    //public GameObject fromNode;
    //public GameObject toNode;

    public float rotationTime;
    private float rotationTimeCurrent;

    public Vector3 rotateStartAngle;
    public Vector3 rotateEndAngle;

    private Quaternion rotateStart;
    private Quaternion rotateEnd;

    // Use this for initialization
    void Start()
    {
        rotateStart = Quaternion.Euler(rotateStartAngle);
        rotateEnd = Quaternion.Euler(rotateEndAngle);
    }

    // Update is called once per frame
    void Update()
    {
        rotationTimeCurrent += Time.deltaTime;

        if (rotationTimeCurrent > rotationTime)
        {
            rotationTimeCurrent = 0;
        }

        if (loop)
        {
            // Looping logic
            if (rotationTimeCurrent < rotationTime / 2)
            {
                transform.rotation = Quaternion.Slerp(rotateStart, rotateEnd, (rotationTimeCurrent / rotationTime) * 2);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(rotateEnd, rotateStart, ((rotationTimeCurrent / rotationTime) - 0.5f) * 2);
            }
        }
        else
        {
            // Non looping
            transform.rotation = Quaternion.Slerp(rotateStart, rotateEnd, rotationTimeCurrent / rotationTime);
        }
    }
}
