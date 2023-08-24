
using UnityEngine;

public class Stealth : MonoBehaviour
{
    private LayerMask originalLayer;
    private LayerMask stealthLayer;
    
    private string stealthSortingLayerName;
    private string playerStoringLayer;
    

    private void Awake()
    {
        originalLayer = gameObject.layer; 
        stealthLayer = LayerMask.NameToLayer("StealthLayer");
        
        stealthSortingLayerName = "StealthLayerWithNoLightShadows";
        playerStoringLayer = "Player";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("StealthProvider"))
        {
            gameObject.layer = stealthLayer;
            GetComponent<SpriteRenderer>().sortingLayerName = stealthSortingLayerName;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("StealthProvider"))
        {
            gameObject.layer = originalLayer;
            GetComponent<SpriteRenderer>().sortingLayerName = playerStoringLayer;
        }
    }
}
