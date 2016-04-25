using UnityEngine;
using System.Collections;

public class DayBasedLight : MonoBehaviour
{
    public bool varianceOn = false;
    public float varianceMin = 0;
    public float varianceMax = 30;

    public Light light;

    private float variance;
    private float varianceGoal;

    // Use this for initialization
    void Start()
    {
        variance = 0;
        varianceGoal = Random.Range(varianceMin, varianceMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (God.god.day.isNight)
        {
            if (variance > varianceGoal || !varianceOn)
            {
                light.enabled = true;
            }
            else
            {
                variance += Time.deltaTime;
            }
        }
        else
        {
            if (variance < 0 || !varianceOn)
            {
                light.enabled = false;
            }
            else
            {
                variance -= Time.deltaTime;
            }
        }
    }
}
