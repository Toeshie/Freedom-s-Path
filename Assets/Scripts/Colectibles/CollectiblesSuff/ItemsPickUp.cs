
using System;
using UnityEngine;


public class ItemsPickUp : MonoBehaviour
{
    public Item item;
    
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
            InventoryManager.instance.Add(item);
            Destroy(gameObject);
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private bool IsPlayerInTrigger()
    {
        Collider2D playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        return playerCollider.IsTouching(GetComponent<Collider2D>());
    }
}
