
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelTransition : MonoBehaviour
{
    private FadeInOutBlack fadeInOutBlack = null;
    [SerializeField] private float timeToMainMenu = 3f;

    private void Start()
    {
        fadeInOutBlack = FindObjectOfType<FadeInOutBlack>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TransitionToSecondLevel());
        }
    }
    
    private IEnumerator TransitionToSecondLevel()
    {
        fadeInOutBlack.FadeIn();
        yield return new WaitForSeconds(timeToMainMenu);
        SceneManager.LoadScene("2º Level");
    }

    
}
