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
		player = GameObject.FindGameObjectWithTag("Player");

	
	}
//	void OnTriggerEnter(Collider other)
//	{
//		if (other.gameObject.CompareTag("Player"))
//		{
//			Debug.Log("Detected!");
//		}
//	}
//	void OnTriggerExit(Collider other)
//	{
//		if (other.gameObject.CompareTag("Player"))
//		{
//			Debug.Log("Not Detected!");
//		}
//	}
	// Update is called once per frame
	void Update () 
	{
		float v = Vector3.Dot(transform.forward, player.transform.position);

		if (v > -threshold && v < threshold)
		{
			
			RaycastHit2D hit = Physics2D.Raycast(transform.position,player.transform.position - transform.forward,range);

			if (hit != null)
			{
				if (hit.collider.tag == "Player")
				{
					Debug.Log("Detected!");
				}
				else
				{
					Debug.Log("Not Detected!");
				}
			}

		}
	
	}
}
