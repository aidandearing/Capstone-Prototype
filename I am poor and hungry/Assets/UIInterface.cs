using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIInterface : MonoBehaviour
{
    public static UIInterface UI;

    [SerializeField]
    private Text text_itemInHand;

    [SerializeField]
    private Image image_progressBar;

    [SerializeField]
    private Image image_hungerBar;

    [SerializeField]
    private Image image_detectionBar;
    [SerializeField]
    private Image image_detectionBarDark;
    [SerializeField]
    private bool detectionOn = false;

    // Use this for initialization
    void Start()
    {
        UI = this;

        image_progressBar.fillMethod = Image.FillMethod.Horizontal;
        image_progressBar.type = Image.Type.Filled;

        image_hungerBar.fillMethod = Image.FillMethod.Horizontal;
        image_hungerBar.type = Image.Type.Filled;

        image_detectionBar.enabled = image_detectionBarDark.enabled = detectionOn;

        if (detectionOn)
        {
            image_detectionBar.fillMethod = Image.FillMethod.Horizontal;
            image_detectionBar.type = Image.Type.Filled;
            SetDetectionBar(SecurityDetection.Instance.detectionPercent);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetItemInHandText(string text)
    {
        text_itemInHand.text = text;
    }

    public void SetProgressBar(float percent)
    {
        image_progressBar.fillAmount = percent;
    }

    public void SetHungerBar(float percent)
    {
        image_hungerBar.fillAmount = percent;
    }


    public void SetDetectionBar(float percent)
    {
        if (detectionOn)
        {
            image_detectionBar.fillAmount = percent;
        }
    }
}
