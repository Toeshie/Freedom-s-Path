using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectLayerShifter : MonoBehaviour
{
    [FormerlySerializedAs("treeStoringLayer")] [SerializeField] private string originalLayer;
    [FormerlySerializedAs("treeBehindPlayerLayer")] [SerializeField] private string targetLayer;
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
    
    

