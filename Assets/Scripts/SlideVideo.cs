using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(RawImage), typeof(VideoPlayer))]
public class SlideVideo : SlideElement {

    VideoPlayer videoPlayer;
    RawImage rawImage;

    public float VideoBorderClip = 0.0f;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        rawImage = GetComponent<RawImage>();

        rawImage.uvRect = new Rect(VideoBorderClip, VideoBorderClip, 1.0f - 2 * VideoBorderClip, 1.0f - 2 * VideoBorderClip);
    }

    private void OnEnable()
    {
        videoPlayer.Play();
    }

    private void OnDisable()
    {
        videoPlayer.Stop();

        Graphics.SetRenderTarget(videoPlayer.targetTexture);
        GL.Clear(false, true, new Color(0, 0, 0));
    }

}
