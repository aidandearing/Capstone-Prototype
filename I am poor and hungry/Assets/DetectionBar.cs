using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DetectionBar : MonoBehaviour {

	public Image detectionBar;
	public static float detectionAmount;
	// Use this for initialization
	void Start () {
		//detectionBar.rectTransform.sizeDelta.x = 0.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
		//detectionBar.rectTransform.sizeDelta.x += detectionAmount;
		detectionBar.rectTransform.localScale = new Vector3(detectionAmount, 1.0f,1.0f);

		if (detectionAmount >= 1.0f)
		{
			detectionAmount = 1.0f;
		}
	
	}
}
