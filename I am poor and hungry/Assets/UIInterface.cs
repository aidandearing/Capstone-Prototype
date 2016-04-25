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

    // Use this for initialization
    void Start()
    {
        UI = this;

        image_progressBar.fillMethod = Image.FillMethod.Horizontal;
        image_progressBar.type = Image.Type.Filled;
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
}
