using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private Slider fxSlider = null;
    [SerializeField] private Slider ambienceSlider = null;
    [SerializeField] private AudioMixer audioMixer;
    private float initialVolume;
    
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadValues();
        audioMixer.GetFloat("MasterVolume", out initialVolume);
    }

    public void ChangeMasterVolume(float volumeValue)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volumeValue)*20);
    }

    public void ChangeFxVolume(float fxVolumeValue)
    {
        audioMixer.SetFloat("fxVolume", Mathf.Log10(fxVolumeValue)*20);
    }

    public void ChangeAmbienceVolume(float ambienceVolume)
    {
        audioMixer.SetFloat("ambienceVolume", Mathf.Log10(ambienceVolume)*20);
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        float ambienceVolume = ambienceSlider.value;
        float fxVolumeValue = fxSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        PlayerPrefs.SetFloat("ambienceVolume", ambienceVolume);
        PlayerPrefs.SetFloat("fxVolume" , fxVolumeValue);
        LoadValues();
    }

    private void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        float ambienceVolume = PlayerPrefs.GetFloat("ambienceVolume");
        float fxVolumeValue = PlayerPrefs.GetFloat("fxVolume");
        volumeSlider.value = volumeValue;
        ambienceSlider.value = ambienceVolume;
        fxSlider.value = fxVolumeValue;
    }

    public void FadeOutVolumeOverTime()
    {
        StartCoroutine(FadeOutVolume(6f));
    }

    private IEnumerator FadeOutVolume(float fadeDuration)
    {
        float elapsedTime = 0;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = elapsedTime / fadeDuration;
            float newVolume = Mathf.Lerp(initialVolume, -80f, normalizedTime);

            audioMixer.SetFloat("MasterVolume", newVolume);

            yield return null;
        }

        audioMixer.SetFloat("MasterVolume", -80f);
    }
}
