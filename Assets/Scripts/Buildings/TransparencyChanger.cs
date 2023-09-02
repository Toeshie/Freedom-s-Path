using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyChanger : MonoBehaviour
{
   private SpriteRenderer mySpriteRenderer = null;
   private Color normalColor;
   [SerializeField] private Color transparentColor;

   private void Awake()
   {
      mySpriteRenderer = GetComponent<SpriteRenderer>();
      normalColor = mySpriteRenderer.color;
   }
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         mySpriteRenderer.color = transparentColor;
      }
   }
   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         mySpriteRenderer.color = normalColor;
      }
      
   }
}
