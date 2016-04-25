using UnityEngine;
using System.Collections;

[System.Serializable]
public class Day
{
    public static int daysPassed = 0;
    public static float dayLength = 600;
    public static float dayNightStart = dayLength * 0.25f;
    public static float dayNightEnd = dayLength * 0.75f;

    public bool isNight = false;

    [SerializeField]
    private float timeCurrent;

    public void Update()
    {
        timeCurrent += Time.deltaTime;

        if (timeCurrent >= dayNightStart && timeCurrent <= dayNightEnd)
        {
            isNight = true;
        }
        else
        {
            isNight = false;
        }

        if (timeCurrent >= dayLength)
        {
            daysPassed++;
            timeCurrent = 0;
            God.god.DayChange();
        }
    }

    public float TimeInSeconds()
    {
        return timeCurrent;
    }

    public float TimeInPercent()
    {
        return timeCurrent / dayLength;
    }
}

public class God : MonoBehaviour
{
    public static God god;
    public Day day;

    public Light directionalLight;
    public Gradient lightGradient;
    public AnimationCurve lightIntensity;

    // Use this for initialization
    void Start()
    {
        god = this;
        day = new Day();
    }

    // Update is called once per frame
    void Update()
    {
        day.Update();

        directionalLight.color = lightGradient.Evaluate(day.TimeInPercent());
        directionalLight.intensity = lightIntensity.Evaluate(day.TimeInPercent());
        UIInterface.UI.SetProgressBar(day.TimeInPercent());
    }

    // Called when the day has changed
    public void DayChange()
    {

    }
}
