using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Video;

public class CutSceneManager : MonoBehaviour
{
    public static CutSceneManager instance;

    [SerializeField] private VideoPlayer mainVideoPlayer = null;
    [SerializeField] private VideoClip noItemVideo = null;
    [SerializeField] private VideoClip item1Video = null;
    [SerializeField] private VideoClip item2Video = null;
    [SerializeField] private VideoClip item3Video = null;
    [SerializeField] private VideoClip item1N2Video = null;
    [SerializeField] private VideoClip item1N3Video = null;
    [SerializeField] private VideoClip item2N3Video = null;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlayNoItemCutScene()
    {
        mainVideoPlayer.clip = noItemVideo;
        mainVideoPlayer.Play();
    }

    public void PlayCutSceneItem1()
    {
        mainVideoPlayer.clip = item1Video;
        mainVideoPlayer.Play();
    }
    
    public void PlayCutSceneItem2()
    {
        mainVideoPlayer.clip = item2Video;
        mainVideoPlayer.Play();
    }
    
    public void PlayCutSceneItem3()
    {
        mainVideoPlayer.clip = item3Video;
        mainVideoPlayer.Play();
    }
    
    public void PlayCutSceneItem1N2()
    {
        mainVideoPlayer.clip = item1N2Video;
        mainVideoPlayer.Play();
    }
    public void PlayCutSceneItem1N3()
    {
        mainVideoPlayer.clip = item1N3Video;
        mainVideoPlayer.Play();
    }
    public void PlayCutSceneItem2N3()
    {
        mainVideoPlayer.clip = item2N3Video;
        mainVideoPlayer.Play();
    }
}
