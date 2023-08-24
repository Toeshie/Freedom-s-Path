using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class FirstButton : MonoBehaviour
{
    private Button backButton;
    
    void OnEnable()
    {
        backButton = GetComponent<Button>();
        backButton.Select();
    }
}