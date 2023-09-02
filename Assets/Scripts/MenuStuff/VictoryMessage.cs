using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMessage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalText = null;
    
    private void Start()
    {
        finalText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            finalText.gameObject.SetActive(true);
            StartCoroutine(SceneReload());
        }
    }
    
    private IEnumerator SceneReload()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
