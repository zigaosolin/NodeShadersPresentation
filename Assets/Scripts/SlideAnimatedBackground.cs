using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideAnimatedBackground : MonoBehaviour
{

    public Color StartColor = new Color(0, 0, 0);
    public Color EndColor = new Color(0.1f, 0.1f, 0.1f);
    public float AnimTime = 1.0f;

    float currentTime = 0.0f;

    Image image;

    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > 2 * AnimTime)
            currentTime -= 2 * AnimTime;

        if (currentTime < AnimTime)
        {
            image.color = Color.Lerp(StartColor, EndColor, currentTime / AnimTime);
        }
        else
        {
            image.color = Color.Lerp(EndColor, StartColor, (currentTime - AnimTime) / AnimTime);
        }

    }
}
