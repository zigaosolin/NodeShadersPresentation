using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SlideShow : MonoBehaviour
{
    public SlidePage StartPage;
    public Camera Camera;
    public float InterpolationSpeed = 3.0f;

    Rect targetCameraRect;

    int currentPageIndex = 0;
    List<SlidePage> pages;

    void Start()
    {
        ResetCamera(true);

        pages = GetComponentsInChildren<SlidePage>(true).ToList();

        if(StartPage != null)
        {
            currentPageIndex = pages.IndexOf(StartPage);
        }

        SetSlide(currentPageIndex);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            TransitionToNext();
        }
        
        if(Input.GetMouseButtonDown(1))
        {
            ResetCamera(true);
            SetSlide(currentPageIndex - 1);
        }

        float size = Camera.orthographicSize;
        Vector2 position = Camera.transform.localPosition;


        float targetSize = targetCameraRect.height / 2.0f;

        Vector2 targetPosition = new Vector2(targetCameraRect.x, targetCameraRect.y);

        Camera.orthographicSize = size + (targetSize - size) * Mathf.Clamp01(InterpolationSpeed * Time.deltaTime);

        Vector2 newPosition = position + (targetPosition - position) * Mathf.Clamp01(InterpolationSpeed * Time.deltaTime);
        Camera.transform.localPosition = new Vector3(newPosition.x, newPosition.y, -10);
    }

    void ResetCamera(bool instant)
    {
        targetCameraRect = new Rect(0, 0, 1920, 1080);

        if(instant)
        {
            Camera.transform.localPosition = new Vector3(0, 0, -10);
            Camera.orthographicSize = 1080 / 2;
        }
    }

    void TransitionToNext()
    {
        Rect? target;

        bool proceedToNextSlide = !pages[currentPageIndex].NextSlideElement(out target);
        if(proceedToNextSlide)
        {
            ResetCamera(true);
            SetSlide(currentPageIndex + 1);
        }

        if(target == null)
        {
            ResetCamera(false);
        }
        else
        {
            targetCameraRect = target.Value;
        }
    }

    void SetSlide(int slideIndex)
    {
        currentPageIndex = Mathf.Clamp(slideIndex, 0, pages.Count-1); 

        for (int i = 0; i < pages.Count; i++)
        {
            var page = pages[i];

            if (i != currentPageIndex)
            {
                pages[i].DeactivateSlide();
            }
            else
            {
                pages[i].ActivateSlide();
            }
        }
    }
}

