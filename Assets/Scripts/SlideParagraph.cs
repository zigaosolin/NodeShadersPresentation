using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TextMeshProUGUI)), ExecuteInEditMode]
public class SlideParagraph : SlideElement {

    private void Start()
    {
    }

    // Update is called once per frame
    void Update () {

        SetPosition();
	}

    void SetPosition()
    {
        var rectTransform = GetComponent<RectTransform>();
        var localPos = rectTransform.localPosition;
        var localSize = rectTransform.sizeDelta;

        rectTransform.sizeDelta = new Vector2(-200, localSize.y);
        rectTransform.localPosition = new Vector2(0, localPos.y);

    }
}
