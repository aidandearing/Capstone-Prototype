using UnityEngine;
using System.Collections;

public class DetectionBehaviour : MonoBehaviour
{
	public PlayerController player;
    public GameObject detectIcon;
    public float viewDistance = 100;
    public float viewAngle = 90;

    private float viewThreshold;
    private GameObject detectInstance;

    private bool detectedPlayer = false;
    private Collider2D playerLastCollision;

    // Use this for initialization
    void Start()
    {
        Vector3 angle = new Vector3(Mathf.Sin(viewAngle / 2 * Mathf.Deg2Rad), Mathf.Cos(viewAngle / 2 * Mathf.Deg2Rad), 0);
        viewThreshold = Vector3.Dot((transform.localToWorldMatrix * new Vector3(0, 1, 0)).normalized, (transform.localToWorldMatrix * angle).normalized);
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
		//Debug.DrawRay(transform.forward,player.transform.position );
		Vector3 delta = player.transform.position - transform.position;
        Debug.DrawLine(transform.position, transform.position + delta, new Color(255,0,0), 0.1f);

        if (delta.magnitude <= viewDistance)
        {
            float dot = Vector3.Dot((transform.localToWorldMatrix * new Vector3(0, 1, 0)).normalized, delta.normalized);

            if (dot >= viewThreshold)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, delta);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.tag == "Player")
                    {
                        if (detectedPlayer)
                        {
							DetectionBar.detectionAmount += 0.005f;
                            OnDetectionStay(hit.collider);
                        }
                        else
                        {
                            OnDetectionStart(hit.collider);
                            detectedPlayer = true;
                        }
                    }
                    playerLastCollision = hit.collider;
                }
                else
                {
                    if (detectedPlayer)
                    {
                        OnDetectionEnd(playerLastCollision);

                        detectedPlayer = false;

                    }
                }
            }
            else
            {
                if (detectedPlayer)
                {
                    OnDetectionEnd(playerLastCollision);
                    detectedPlayer = false;
                }
            }
        }
        else
        {
            if (detectedPlayer)
            {
                OnDetectionEnd(playerLastCollision);
                detectedPlayer = false;
            }
        }
		if (DetectionBar.detectionAmount == 1.0f)
		{
			player.BeenCaught(new Vector3(0.0f,-2.0f,0.0f));
			DetectionBar.detectionAmount = 0.0f;
		}
    }

    void OnDetectionStart(Collider2D other)
    {
        if (detectInstance == null)
        {
            detectInstance = Instantiate(detectIcon, transform.position, new Quaternion()) as GameObject;
        }
        SendMessage("StartDetectingPlayer", other.gameObject, SendMessageOptions.DontRequireReceiver);

        Debug.Log("Started detecting player");
    }

    void OnDetectionStay(Collider2D other)
    {
        Debug.Log("Continued detecting player");
        SendMessage("DetectingPlayer", other.gameObject, SendMessageOptions.DontRequireReceiver);
    }

    void OnDetectionEnd(Collider2D other)
    {
        if (detectInstance != null)
        {
            Destroy(detectInstance);
            detectInstance = null;
        }
        SendMessage("StopDetectingPlayer", other.gameObject, SendMessageOptions.DontRequireReceiver);

        Debug.Log("Ended detecting player");
    }
}
