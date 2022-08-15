using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TutorialVideoHandler : MonoBehaviour
{
    VideoPlayer videoPlayer;
    MeshRenderer meshRenderer;
    int videoIndex = -1;

    public VideoClip[] videoClips;

    public GameObject[] disableWhilePlaying;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        meshRenderer = GetComponent<MeshRenderer>();

        videoPlayer.loopPointReached += EndReached;

        // videoPlayer.clip = videoClips[videoIndex];
    }

    private void EndReached(VideoPlayer source)
    {
        HideVideoPlane();
    }

    private void HideVideoPlane()
    {
        meshRenderer.enabled = false;
        foreach (var item in disableWhilePlaying) item.SetActive(true);
    }

    public void NextVideo()
    {
        videoPlayer.Stop();
        meshRenderer.enabled = true;
        videoIndex++;
        if (videoIndex < videoClips.Length)
        {
            videoPlayer.clip = videoClips[videoIndex];
            videoPlayer.Play();
            foreach (var item in disableWhilePlaying) item.SetActive(false);
        }
        else
        {
            foreach (var item in disableWhilePlaying) item.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void PlayVideo()
    {
        if (videoPlayer.enabled)
            videoPlayer.Play();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
