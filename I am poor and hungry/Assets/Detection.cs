using UnityEngine;
using System.Collections;

public class Detection : MonoBehaviour {

	public GameObject player;
	public float range;
	public float angle;
	private float threshold;
	// Use this for initialization
	void Start () {
		// Rotate the forward by the angle / 2
		// Store the dot product of the rotated vector against the forward
		transform.Rotate(transform.forward, angle / 2);
		Vector3 rotatedForward = transform.forward;
		transform.Rotate(transform.forward, -angle / 2);
		threshold = Vector3.Dot(rotatedForward,transform.forward);

	
	}
	
	// Update is called once per frame
	void Update () {
		float v = Vector3.Dot(transform.forward, player.transform.position);

		if (v > -threshold && v < threshold)
		{
			if (Physics2D.Raycast(transform.position,player.transform.position - transform.position,range).collider.gameObject.tag == "Player")
			{
				Debug.Log("detected!");
			}
		}
	
	}
}
