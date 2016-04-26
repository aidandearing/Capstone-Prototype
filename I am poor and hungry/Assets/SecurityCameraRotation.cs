using UnityEngine;
using System.Collections;

public class SecurityCameraRotation : MonoBehaviour {

	public Quaternion startRot;
	public Quaternion currentRot;
	public Quaternion endRot;
	public bool backward;
	private float timer;
	public float flipAmount = 4.0f;
	public float turningRate = 0.1f;
	public float amt;
	public int type;
	// Use this for initialization
	void Start () {
		startRot = Quaternion.identity;

	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		//float percentageOfTime = Mathf.Clamp((Time.time % flipAmount) / flipAmount, 0.0f, 1.0f);
		if (backward)
		{
			transform.rotation = Quaternion.Lerp(transform.rotation, startRot, turningRate);
		}
		else
		{
			transform.rotation = Quaternion.Lerp(transform.rotation, endRot, turningRate);
		}
		if (type == 1)
		{
			if((endRot.eulerAngles - transform.rotation.eulerAngles).sqrMagnitude < 0.3) 
			{
				FlipRotation();
			}
			if (transform.rotation.eulerAngles.z > 357.0f)
			{
				FlipRotation();
			}
		}
		if (type == 2)
		{
			if((startRot.eulerAngles - transform.rotation.eulerAngles).sqrMagnitude < 0.3) 
			{
				FlipRotation();
			}
			if (transform.rotation.eulerAngles.z < 0.0f)
			{
				FlipRotation();
			}
		}


	}
	void FlipRotation()
	{
		backward = !backward;
	}
	void Backward()
	{
		
	}
	void Forward()
	{
		
	}
}
