using UnityEngine;
using System.Collections;

public class SecurityCameraRotation : MonoBehaviour {

	public Quaternion startRot;
	public Quaternion endRot;
	public bool backward;
	private float timer;
	public float flipAmount = 4.0f;
	// Use this for initialization
	void Start () {
		startRot = transform.rotation;
		backward = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		float percentageOfTime = Mathf.Clamp((Time.time % flipAmount) / flipAmount, 0.0f, 1.0f);
		if (!backward)
		{
			transform.rotation = Quaternion.Slerp(startRot, endRot, percentageOfTime);
		}
		if (backward)
		{
			transform.rotation = Quaternion.Slerp(endRot, startRot, percentageOfTime);
		}
		if (timer > flipAmount)
		{
			FlipRotation();
			timer = 0.0f;
		}
	}
	void FlipRotation()
	{
		backward = !backward;
	}
}
