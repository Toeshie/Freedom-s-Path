using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerShifter : MonoBehaviour
{
    private string playerStoringLayer;
    private string playerBehindFencesLayer;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;

    private void Awake()
    {
        playerBehindFencesLayer = "PlayerBehindFences";
        playerStoringLayer = "Player";
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FenceInFrontOfPlayer"))
        {
            playerSpriteRenderer.sortingLayerName = playerBehindFencesLayer;
        }
        if (other.CompareTag("FactoryWalls"))
        {
            playerSpriteRenderer.sortingLayerName = playerBehindFencesLayer;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("FenceInFrontOfPlayer"))
        {
            playerSpriteRenderer.sortingLayerName = playerStoringLayer;
        }

        if (other.CompareTag("FactoryWalls"))
        {
            playerSpriteRenderer.sortingLayerName = playerStoringLayer;
        }
    }
}
