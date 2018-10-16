using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePageStage : MonoBehaviour {

    public GameObject[] ActivateElements;
    public GameObject[] DeactivateElements;

    public bool ZoomToRegion = false;


    public void SetAsCurrentStage()
    {
        foreach(var go in ActivateElements)
        {
            go.SetActive(true);
        }

        foreach (var go in DeactivateElements)
        {
            go.SetActive(false);
        }
    }

    public void UnSetAsCurrentStage()
    {
        foreach (var go in ActivateElements)
        {
            go.SetActive(false);
        }

        foreach (var go in DeactivateElements)
        {
            go.SetActive(true);
        }
    }
}
