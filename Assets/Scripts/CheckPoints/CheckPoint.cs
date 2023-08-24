using System;
using System.Collections;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private FadeInOutBlack fadeInOutBlack = null;
    private bool hasFadedOutTimer = false;
    private AudioSource checkPointAudio = null;
    [SerializeField] private AudioClip checkPointSound;
    
    private void Start()
    {
        checkPointAudio = GetComponent<AudioSource>();
        fadeInOutBlack = FindObjectOfType<FadeInOutBlack>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasFadedOutTimer)
            {
                fadeInOutBlack.FadeIn();
                checkPointAudio.PlayOneShot(checkPointSound);
                StartCoroutine(BlinkOut());
                StartCoroutine(BlinkOutReset());
            }
            SetRespawnPosition(other.transform.position);
        }
    }

    private void SetRespawnPosition(Vector3 position)
    {
        CheckpointManager.SetRespawnPosition(position);
    }

    private IEnumerator BlinkOutReset()
    {
        yield return new WaitForSeconds(30f);
        hasFadedOutTimer = false;
    }

    private IEnumerator BlinkOut()
    {
        yield return new WaitForSeconds(2f);
        fadeInOutBlack.FadeOut();
        hasFadedOutTimer = true;
    }
}