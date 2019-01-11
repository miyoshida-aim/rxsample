using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreen : MonoBehaviour
{
    [SerializeField]
    RectTransform child;
    [SerializeField]
    RectTransform parent;

    [SerializeField]
    AspectRatioFitter rateFitter;


    [SerializeField]
    float width = 1280.0f;
    [SerializeField]
    float height = 1980.0f;

    void Update()
    {


        var rateX = parent.sizeDelta.x / width;
        var rateY = parent.sizeDelta.y / height;



        if (rateX > rateY)
        {

            rateFitter.aspectMode = AspectRatioFitter.AspectMode.HeightControlsWidth;
            rateFitter.aspectRatio = width / height;
            child.offsetMin = new Vector2(0, 0);
            child.offsetMax = new Vector2(0, 0);
            child.anchoredPosition = Vector2.zero;
        }
        else
        {
            rateFitter.aspectMode = AspectRatioFitter.AspectMode.WidthControlsHeight;
            rateFitter.aspectRatio = width / height;
            child.offsetMin = new Vector2(0, 0);
            child.offsetMax = new Vector2(0, 0);
            child.anchoredPosition = Vector2.zero;
        }


    }
}
