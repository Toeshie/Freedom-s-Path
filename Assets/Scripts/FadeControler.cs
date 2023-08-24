using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeControler : MonoBehaviour
{
   private FadeInOutBlack fadeInOutBlack = null;
   
   private void Start()
   {
      fadeInOutBlack = FindObjectOfType<FadeInOutBlack>();
      fadeInOutBlack.FadeOut();
   }
}
