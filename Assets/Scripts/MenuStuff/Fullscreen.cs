using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullscreen : MonoBehaviour
{
   public void FullScreenController()
   {
      
      bool isFullScreen = Screen.fullScreen;
      
      Screen.fullScreen = !isFullScreen;
   }
}
