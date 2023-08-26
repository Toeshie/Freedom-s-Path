
using System;
using System.Collections;
using UnityEngine;



public class ItemsPickUp : MonoBehaviour
{
    public Item item;
    [SerializeField] private AudioSource pickUpAudioSource = null;
    [SerializeField] private AudioClip pickUpAudioClip = null;

    private TextBalloons _textBalloons = null;

    private void Awake()
    {
        _textBalloons = FindObjectOfType<TextBalloons>().GetComponent<TextBalloons>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickUp();
        }
    }
    
    public void TryPickUp()
    {
        if (InventoryManager.instance.items.Count < 2 && IsPlayerInTrigger())
        {
            pickUpAudioSource.PlayOneShot(pickUpAudioClip);
            InventoryManager.instance.Add(item);
            StartCoroutine(DelayDestroy());
            
        }

        if (IsPlayerInTrigger() && InventoryManager.instance.items.Count == 2)
        {
            _textBalloons.InventoryFullTrigger();
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
