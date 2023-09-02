using System;
using System.Collections;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private FadeInOutBlack fadeInOutBlack = null;
    private bool hasFadedOutTimer = false;
    private AudioSource checkPointAudio = null;
    [SerializeField] private AudioClip checkPointSound;
    private Movement _movement = null;
    private float blinkTimer = 2f;
    private float blinkReset = 30f;

    private void Awake()
    {
        _movement = FindObjectOfType<Movement>().GetComponent<Movement>();
    }

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
                _movement.SetCanMove(false);
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
        yield return new WaitForSeconds(blinkReset);
        hasFadedOutTimer = false;
    }

    private IEnumerator BlinkOut()
    {
        yield return new WaitForSeconds(blinkTimer);
        fadeInOutBlack.FadeOut();
        hasFadedOutTimer = true;
        _movement.SetCanMove(true);
    }
}