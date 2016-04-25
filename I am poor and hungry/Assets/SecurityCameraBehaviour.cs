using UnityEngine;
using System.Collections;

public class SecurityCameraBehaviour : MonoBehaviour {

	public PlayerController player;
	public bool detectedPlayer;
	// Use this for initialization
	void Start () {
		player = GetComponent<DetectionBehaviour>().player;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (detectedPlayer)
		{
			DetectionBar.detectionAmount += 0.005f;
		}
		if (DetectionBar.detectionAmount == 1.0f)
		{
			player.BeenCaught(new Vector3(0.0f,-2.0f,0.0f));
		}

	
	}
	void OnDetectionStart(GameObject detectedObj)
	{
		detectedPlayer = true;
	}
	void OnDetectionEnd(GameObject detectedObj)
	{
		detectedPlayer = false;
	}
	void OnDetectionStay(GameObject detectedObj)
	{
		detectedPlayer = true;
	}

}
