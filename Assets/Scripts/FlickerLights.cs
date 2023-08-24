
using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;


public class FlickerLights : MonoBehaviour
{
    [SerializeField] private new Light2D light;

    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    [SerializeField] private float timer;

    private AudioSource streetLightAudioSource = null;
    [SerializeField] private AudioClip streetLightAudioClip = null;

    private void Awake()
    {
        streetLightAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }

    private void Update()
    {
        FlickerLight();
    }

    private void FlickerLight()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            light.enabled = !light.enabled;
            timer = Random.Range(minTime, maxTime);
            streetLightAudioSource.PlayOneShot(streetLightAudioClip);
        }
    }
}
