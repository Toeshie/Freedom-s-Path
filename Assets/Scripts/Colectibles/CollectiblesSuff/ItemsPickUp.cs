
using System;
using System.Collections;
using UnityEngine;


public class ItemsPickUp : MonoBehaviour
{
    public Item item;
    [SerializeField] private AudioSource pickUpAudioSource = null;
    [SerializeField] private AudioClip pickUpAudioClip = null;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickUp();
        }
    }

    private void TryPickUp()
    {
        if (InventoryManager.instance.items.Count < 2 && IsPlayerInTrigger())
        {
            pickUpAudioSource.PlayOneShot(pickUpAudioClip);
            InventoryManager.instance.Add(item);
            StartCoroutine(DelayDestroy());
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private bool IsPlayerInTrigger()
    {
        Collider2D playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        return playerCollider.IsTouching(GetComponent<Collider2D>());
    }

    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
