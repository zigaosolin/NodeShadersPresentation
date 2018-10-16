using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePage : MonoBehaviour
{
    int currentStage = -1;
    SlidePageStage[] Stages;

    // Use this for initialization
    void Start()
    {
        Stages = GetComponentsInChildren<SlidePageStage>(true);

        for (currentStage = Stages.Length - 1; currentStage >= 0; currentStage--)
        {
            Stages[currentStage].UnSetAsCurrentStage();
        }
    }


    public void ActivateSlide()
    {
        if (gameObject.activeSelf)
            return;

        gameObject.SetActive(true);

        if (currentStage != -1)
        {
            throw new Exception("Expected current stage as -1 on activation");
        }
    }

    public void DeactivateSlide()
    {
        for (; currentStage >= 0; currentStage--)
        {
            Stages[currentStage].UnSetAsCurrentStage();
        }

        gameObject.SetActive(false);
    }

    public bool NextSlideElement(out Rect? targetRect)
    {
        if (currentStage + 1 >= Stages.Length)
        {
            targetRect = null;
            return false;
        }

        ++currentStage;

        var stage = Stages[currentStage];
        if (currentStage > 0)
        {
            Stages[currentStage - 1].UnSetAsCurrentStage();
        }
        stage.SetAsCurrentStage();

        targetRect = null;
        if (stage.ZoomToRegion)
        {
            var rectTransform = stage.GetComponent<RectTransform>();

            targetRect = new Rect(stage.transform.localPosition.x, stage.transform.localPosition.y,
                rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
        }

        return true;
    }
}
