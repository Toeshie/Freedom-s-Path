using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectLayerShifter : MonoBehaviour
{
    [SerializeField] private string originalLayer;
    [SerializeField] private string targetLayer;
    [SerializeField] private SpriteRenderer treeSpriteRenderer;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            treeSpriteRenderer.sortingLayerName = targetLayer;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            treeSpriteRenderer.sortingLayerName = originalLayer;
        }
    }
}
    
    

