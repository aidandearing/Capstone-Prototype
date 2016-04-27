using UnityEngine;
using System.Collections;

public class SecurityDetection
{
    public float detectionPercent = 0.0f;

    // Fancy C# singleton
    private static SecurityDetection instance;
    public static SecurityDetection Instance
    {
        get { return instance = (instance == null) ? new SecurityDetection() : instance; }
        private set { instance = value; }
    }

    private SecurityDetection()
    {

    }
    // End of fancy c# singleton
}

public class SecurityCameraBehaviour : MonoBehaviour
{
    public PlayerController player;
    public float detectionTime = 8.0f;
    private bool detectedPlayer;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<DetectionBehaviour>().player;
    }

    // Update is called once per frame
    void Update()
    {
        if (detectedPlayer)
        {
            SecurityDetection.Instance.detectionPercent += 1 / detectionTime * Time.deltaTime;
            UIInterface.UI.SetDetectionBar(SecurityDetection.Instance.detectionPercent);
        }
        if (SecurityDetection.Instance.detectionPercent >= 1.0f)
        {
            player.BeenCaught(new Vector3(0.0f, -2.0f, 0.0f));
            SecurityDetection.Instance.detectionPercent = 0;
            UIInterface.UI.SetDetectionBar(SecurityDetection.Instance.detectionPercent);
        }
    }

    void DetectionStart(Collider2D collider)
    {
        detectedPlayer = true;
    }

    void DetectionEnd(Collider2D collider)
    {
        detectedPlayer = false;
    }

}
